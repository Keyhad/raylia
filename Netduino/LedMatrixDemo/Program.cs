using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Raylia.LedMatrix;
using System.Threading;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using Toolbox.NETMF.Hardware;

namespace LedMatrixDemo
{
    public class Program
    {
        public static void Main()
        {
            RgbMatrix matrix = new AdafruitNeoPixel32x8();

            matrix.Test0();

            IntegratedIRQ Pin0Irq = new IntegratedIRQ(Microsoft.SPOT.Hardware.Cpu.Pin.GPIO_Pin0);

            while (true)
            {
                matrix.ScrollToRightText(1, 0, "abcdefghijk", 0x130000, 50, 300);
                Thread.Sleep(500);
                matrix.ScrollToLeftText(1, 0, "abcdefghijk", 0x130000, 50, 300);
                Thread.Sleep(500);
            }
        }

        private static void Pin0Irq_OnStateChange(IIRQPort Object, bool State, DateTime Time)
        {
            Trace.Print("D3Irq_OnStateChange: " + State + " - " + Time.ToString());
        }
    }
}
