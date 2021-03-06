using System;
using Microsoft.SPOT;
using System.Threading;

namespace Raylia.LedMatrix
{
    public class AdafruitNeoPixel32x8: AdafruitNeoPixel8x8
    {
        public AdafruitNeoPixel32x8() : base(32, 8)
        {
        }

        public override void Test1()
        {
            SetColorRect(25, 1, 5, 6, 0x000f00, false);
            Thread.Sleep(1000);
        }

        public override void Test2()
        {
            SetColorRect(15, 3, 15, 2, 0x0f0000, false);
            Thread.Sleep(1000);
        }

        public override void Test3()
        {
            Clear();
            WriteText(0, 0, "123", 0x000f00, 0x0f000f);
            Write();
            Thread.Sleep(2000);
        }

        public override void Test4()
        {
            Clear();
            WriteText(5, 0, "5678", 0x000f00, 0x0f0000);
            Write();
            Thread.Sleep(2000);
        }

        public override void Test5()
        {
            Clear();

            while (true)
            {
                ScrollToLeftText(1, 0, "abcdefghijk", 0x130000, 15);
                Thread.Sleep(500);
                ScrollToRightText(1, 0, "abcdefghijk", 0x130000, 15);
                Thread.Sleep(500);
            }
            //Thread.Sleep(500);
        }

        /// <summary>
        /// Configures all LEDs to a specific color
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <param name="RectWith">Rect Width</param>
        /// <param name="RectHeight">Rect Height</param>
        /// <param name="Red">Red brightness (0 to 255)</param>
        /// <param name="Green">Green brightness (0 to 255)</param>
        /// <param name="Blue">Blue brightness (0 to 255)</param>
        /// <param name="Delayed">Do we have to write all LEDs immediately?</param>
        public override void SetColorRect(int x, int y, int RectWith, int RectHeight, byte Red, byte Green, byte Blue, bool Delayed = true)
        {
            int lx10 = y;
            int ly10 = Width - (x + RectWith);

            int lx20 = lx10 + RectHeight - 1;
            int ly20 = ly10;

            int lx30 = lx20;
            int ly30 = ly20 + RectWith - 1;

            int lx40 = lx10;
            int ly40 = ly30;

            int lx1 = lx10;
            int ly1 = ly10;

            int lx2 = lx20;
            int ly2 = ly20;

            int lx3 = lx30;
            int ly3 = ly30;

            int lx4 = lx40;
            int ly4 = ly40;

            for (int yy = ly1; yy <= ly4; yy++)
            {
                if ((yy & 1) == 0)
                {
                    // even row
                    int ledNo = (Height - 1) - lx2 + yy * Height;
                    for (int xx = lx2; xx >= lx1; xx--)
                    {
                        this.SetColor(ledNo++, Red, Green, Blue);
                    }
                }
                else
                {
                    // odd row
                    int ledNo = lx1 + yy * Height;
                    for (int xx = lx1; xx <= lx2; xx++)
                    {
                        this.SetColor(ledNo++, Red, Green, Blue, true);
                    }
                }
            }

            if (!Delayed) this.Write();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="bgColor"></param>
        /// <param name="delayed"></param>
        public void WriteTextR(int x, int y, string text, int color, int bgColor, bool delayed)
        {
            for (int i = text.Length - 1; i >= 0 ; i--)
            {
                x = WriteCharR(x, y, text[i], color, bgColor);
            }
            if (!delayed) this.Write();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="bgColor"></param>
        /// <param name="delayed"></param>
        public override void WriteText(int x, int y, string text, int color, int bgColor = 0, Boolean delayed = true)
        {
            for (int i = 0; i < text.Length; i++)
            {
                x = WriteChar(x, y, text[i], color, bgColor) + 1;
            }
            if (!delayed) this.Write();
        }

        /// <summary>
        /// Scroll text from right to left
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="bgColor"></param>
        /// <param name="Delay"></param>
        public override void ScrollToLeftText(int x, int y, string text, int color, int bgColor = 0, int Delay = 0)
        {
            int maxWidth = 0;

            for (int j = 0; j < text.Length; j++)
            {
                maxWidth = WriteChar(maxWidth, y, text[j], color, bgColor) + 1;
            }

            Clear(bgColor);

            // loop through all pixels columns in whole text banner
            for (int i = 0; ; i++)
            {
                int xx = Width - i;

                for (int j = 0; j < text.Length; j++)
                {
                    xx = WriteChar(xx, y, text[j], color, bgColor);
                    xx = WriteChar(xx, y, ' ', color, bgColor) - 1;
                }

                if (xx < 0)
                {
                    break;
                }

                this.Write();
                Thread.Sleep(Delay);
            }

        }

        /// <summary>
        /// Scroll text from left to right
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="bgColor"></param>
        /// <param name="Delay"></param>
        public override void ScrollToRightText(int x, int y, string text, int color, int bgColor = 0, int Delay = 0)
        {
            int maxWidth = 0;

            text = " " + text;
            for (int j = 0; j < text.Length; j++)
            {
                maxWidth = WriteChar(maxWidth, y, text[j], color, bgColor) + 1;
            }

            Clear(bgColor);

            // loop through all pixels columns in whole text banner
            for (int i = 0;; i++)
            {
                int xx = -maxWidth + i;

                if (xx >= Width)
                {
                    break;
                }

                for (int j = 0; j < text.Length; j++)
                {
                    if (FontManager.isFarsi)
                    {
                        xx = WriteChar(xx, y, text[j], color, bgColor);
                    }
                    else
                    {
                        xx = WriteChar(xx, y, ' ', color, bgColor) - 1;
                        xx = WriteChar(xx, y, text[j], color, bgColor);
                    }
                }

                this.Write();
                Thread.Sleep(Delay);
            }
        }
    }
}
