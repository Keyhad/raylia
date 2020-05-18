using System;
using Toolbox.NETMF.NET;
using System.Threading;
using Raylia.LedMatrix;
using Toolbox.NETMF.Hardware;
using System.IO.Ports;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace Raylia.WebBanner
{
    public class Program
    {
        private static string dateString;
        private static OutputPort EthernetPower;

        //private static IntegratedIRQ Pin1Irq;
        //private static IntegratedIRQ Pin2Irq;

        public static bool IsConnecting { get; private set; }

        public static void Main()
        {
            NetworkInitializer.NetworkConnected += (object sender, EventArgs e) => {
                IsConnecting = false;
            };
            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

            IsConnecting = true;
            int counter = 0;
            while (IsConnecting)
            {
                led.Write(false); // turn on the LED
                Thread.Sleep(250); // sleep for 250ms
                led.Write(true); // turn off the LED
                Thread.Sleep(250); // sleep for 250ms                

                if (counter == 10)
                {
                    NetworkInitializer.InitializeNetwork();
                }
                counter++;
            }

            // There's a 8x8 matrix (64 LEDs) connected to the first SPI bus on the Netduino
            AdafruitNeoPixel32x8 matrix = new AdafruitNeoPixel32x8();

            PollingAction pollingAction = new PollingAction();
            pollingAction.DataUpdated += new PollingAction.DataUpdatedDelegate((object sender, EventArgs e)=>
            {
                //EthernetPower.Write(false);
                dateString = pollingAction.DateString;
            });

            //EthernetPower = new OutputPort((Cpu.Pin)47,  false);
            //Pin1Irq = new IntegratedIRQ(Pins.GPIO_PIN_D1);
            //Pin1Irq.ID = "D1";
            //Pin1Irq.OnStateChange += OnStateChangeHandler;
            //Pin2Irq = new IntegratedIRQ(Pins.GPIO_PIN_D2);
            //Pin2Irq.ID = "D2";
            //Pin2Irq.OnStateChange += OnStateChangeHandler;

            // power off networkd
            //var ethernetPower = new OutputPort((Cpu.Pin)47, false);

            // software reset 
            //Microsoft.SPOT.Hardware.PowerState.RebootDevice(true);

            matrix.Test0();
            matrix.SetBrightnessAll(50);
            dateString = "";
            counter = 10;
            while (true)
            {
                // power off network
                //ethernetPower.Write(false);
                //Thread.Sleep(500);

                //if (!EthernetPower.Read())
                {
                    matrix.ScrollToLeftText(1, 0, dateString, 0x1f0000, 0x000c0c, 50);
                    //EthernetPower.Write(true);
                }
                Thread.Sleep(500);
                if (counter == 12)
                {
                    pollingAction.CheckTheMessage();
                    //   Thread.Sleep(30000);
                    counter = 0;
                }
                counter++;
            }
        }
        
        private static void OnStateChangeHandler(IIRQPort IrqPort, bool State, DateTime Time)
        {
            Debug.Print("OnStateChangeHandler: " + IrqPort.ID + " - " + State + " - " + Time.ToString());
        }
    }
}
