using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Raylia.LedMatrix;
using System.Threading;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using Toolbox.NETMF.Hardware;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Controls;

namespace LedMatrixDemo
{
    public class Program
    {
        public static void Main()
        {
            // turn off Ethernet in case of Netduino2Plus
            var ethernetPower = new OutputPort((Cpu.Pin)47, false);
            ethernetPower.Write(false);

            AdafruitNeoPixel32x8 matrix = new AdafruitNeoPixel32x8();
            matrix.CompactedCharStyle = true;

            matrix.Test0();

            //byte[] bytes = Properties.Resources.GetBytes(Properties.Resources.BinaryResources.TEST2);

            //matrix.PutBytes(0, 0, 32, 8, bytes, true);

            //using (Bitmap bmp = new Bitmap(bytes, Bitmap.BitmapImageType.Jpeg))
            //{
            //    matrix.PutBmp(0, 0, bmp, true);
            //}

            //Thread.Sleep(5000);

            while (true)
            {
                matrix.ScrollToRightText(1, 0, "012345678", 0x1f0000, 0x000010, 50);
//                Thread.Sleep(500);
                //matrix.ScrollToLeftText(1, 0, "0123456789000111222333444555666777888999", 0x1f0000, 0x001000, 100);
                Thread.Sleep(500);
            }
        }

        private static void Pin0Irq_OnStateChange(IIRQPort Object, bool State, DateTime Time)
        {
            Trace.Print("D3Irq_OnStateChange: " + State + " - " + Time.ToString());
        }
    }
}
