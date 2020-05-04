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
        //private static IntegratedIRQ Pin1Irq;
        //private static IntegratedIRQ Pin2Irq;

        public static bool IsConnecting { get; private set; }

        public static void Main()
        {           
            // There's a 8x8 matrix (64 LEDs) connected to the first SPI bus on the Netduino
            RgbMatrix matrix = new AdafruitNeoPixel32x8();

            matrix.Test0();

            NetworkInitializer.NetworkConnected += NetworkConnected;

            int delayCon = 0;
            IsConnecting = true;

            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
            while (IsConnecting)
            {
                led.Write(false); // turn on the LED
                Thread.Sleep(250); // sleep for 250ms
                led.Write(true); // turn off the LED
                Thread.Sleep(250); // sleep for 250ms

                if (delayCon++ == 10)
                {
                    NetworkInitializer.InitializeNetwork();
                }
            }

            Debug.Print("Network connected!");

            // Creates a new web session
            HTTP_Client WebSession = new HTTP_Client(new IntegratedSocket("www.netmftoolbox.com", 80));

            // Requests the latest source
            HTTP_Client.HTTP_Response Response = WebSession.Get("/helloworld/");

            // Did we get the expected response? (a "200 OK")
            if (Response.ResponseCode != 200)
                throw new ApplicationException("Unexpected HTTP response code: " + Response.ResponseCode.ToString());

            var dateString = Response.ResponseHeader("date");

            //Pin1Irq = new IntegratedIRQ(Pins.GPIO_PIN_D1);
            //Pin1Irq.ID = "D1";
            //Pin1Irq.OnStateChange += OnStateChangeHandler;
            //Pin2Irq = new IntegratedIRQ(Pins.GPIO_PIN_D2);
            //Pin2Irq.ID = "D2";
            //Pin2Irq.OnStateChange += OnStateChangeHandler;

            var ethernetPower = new OutputPort((Cpu.Pin)47, false);
            ethernetPower.Write(false);

            while (true)
            {
                matrix.ScrollToLeftText(1, 0, dateString, 0x130000, 100);
                Thread.Sleep(500);
            }
        }

        private static void NetworkConnected(object sender, EventArgs e)
        {
            IsConnecting = false;
        }

        private static void OnStateChangeHandler(IIRQPort IrqPort, bool State, DateTime Time)
        {
            Debug.Print("OnStateChangeHandler: " + IrqPort.ID + " - " + State + " - " + Time.ToString());
        }
    }
}
