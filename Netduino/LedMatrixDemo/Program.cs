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
            matrix.FontManager.SelectFont(Fonts.Mix);

            matrix.Test0();

            //byte[] bytes = Properties.Resources.GetBytes(Properties.Resources.BinaryResources.TEST2);

            //matrix.PutBytes(0, 0, 32, 8, bytes, true);

            //using (Bitmap bmp = new Bitmap(bytes, Bitmap.BitmapImageType.Jpeg))
            //{
            //    matrix.PutBmp(0, 0, bmp, true);
            //}

            //Thread.Sleep(5000);

            //FarsiTranslator.Dump();

            while (true)
            {
#if false
                matrix.Clear(0x000010);
                matrix.FontManager.SelectFont(Fonts.Sinclair);
                matrix.WriteText(0, 0, "abcd", 0x1f0000, 0x000010, false);
                Thread.Sleep(5000);
                matrix.Clear(0x000010);
                matrix.FontManager.SelectFont(Fonts.Farsi);
                matrix.WriteTextR(0, 0, "!$ !$", 0x1f0000, 0x000010, false);
                Thread.Sleep(5000);
#endif

#if true
                matrix.Clear(0x000010);
                matrix.FontManager.SelectFont(Fonts.Mix);

                string test0 = "";
                for (int i = 0; i < 190; i++)
                {
                    test0 += (char)(i + 32);
                }

                string test1 = " .آب بابا پاتون رفته مشهد؛ دیده خبری نیست برگشته ";
                string all = " آ ﺍ ب پ ت ث ج چ ح خ د ذ ر ز ژ س ش ص ض ط ظ ع غ ف ق ک گ ل م ن و ه ی ء ؟ ۰ ۱ ۲ ۳ ۴ ۵ ۶ ۷ ۸ ۹  ";

                matrix.ScrollToLeftText(1, 0, test0, 0x1f0000, 0x000c0c, 50);
                //matrix.ScrollToRightText(1, 0, FarsiTranslator.Translate(test1), 0x1f0000, 0x000c0c, 50);
                Thread.Sleep(5000);
#endif

#if false
                matrix.FontManager.SelectFont(Fonts.Farsi);
                matrix.ScrollToRightText(0, 0, "!$!$ !$!$ !$!$ !$!$", 0x1f0000, 0x000010, 50);
                matrix.FontManager.SelectFont(Fonts.Sinclair);
                matrix.ScrollToRightText(0, 0, "Everyone knows weak security poses a threat to their business ...", 0x1f0000, 0x000010, 50);
#endif

#if false
                matrix.FontManager.SelectFont(Fonts.Sinclair);
                matrix.ScrollToLeftText(0, 0, "Everyone knows weak security poses a threat to their business ...", 0x1f0000, 0x001000, 10);
                matrix.FontManager.SelectFont(Fonts.Farsi);
                matrix.ScrollToLeftText(0, 0, "!$!$ !$!$ !$!$ !$!$", 0x1f0000, 0x001000, 10);
#endif
            }
        }

        private static void Pin0Irq_OnStateChange(IIRQPort Object, bool State, DateTime Time)
        {
            Trace.Print("D3Irq_OnStateChange: " + State + " - " + Time.ToString());
        }
    }
}
