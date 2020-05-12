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

        public override void WriteText(int x, int y, string text, int color, int bgColor = 0, Boolean Delayed = true)
        {
            for (int i = 0; i < text.Length; i++)
            {
                WriteChar(x + (i << 3), y, text[i], color, bgColor);
            }
            if (!Delayed) this.Write();
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
            int chars = Width >> 3;
            int max = text.Length << 3;

            Clear(bgColor);

            int offset = Width;

            // loop trough all pixel columns in whole text banner
            for (int i = 0; i < max;)
            {
                int charIndex = i >> 3;
                int charMode = i & 7;
                int xx = x - charMode;
                int maxColumn = 0;
                for (int j = charIndex; j < text.Length && xx < Width; xx += maxColumn + 1, j++)
                {
                    if (j > charIndex + 5)
                    {
                        break;
                    }
                    maxColumn = WriteChar(offset + xx, y, text[j], color, bgColor);
                }

                this.Write();
                Thread.Sleep(Delay);

                // Make it possible to start with clean screen
                if (offset > 0)
                {
                    offset--;
                }
                else
                {
                    i++;
                }
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
            int chars = Width >> 3;
            int max = text.Length << 3;

            Clear(bgColor);

            int offset = -Width;

            // loop trough all pixel columns in whole text banner
            for (int i = max - 1; i >= 0;)
            {
                int charIndex = i >> 3;
                int charMode = i & 7;
                int xx = Width - x - charMode;

                // clear one column before 
                //for (int j = 0; j < 8; j++)
                //{
                //    PutPixel(offset + xx + 8, j, bgColor);
                //}

                for (int j = charIndex; j >= 0; xx -= 8, j--)
                {
                    if (j < charIndex - 5)
                    {
                        break;
                    }
                    WriteChar(offset + xx, y, text[j], color, bgColor);
                }

                xx += 8;
                // clear one column after 
                for (int j = 0; j < 8; j++)
                {
                    PutPixel(offset + xx - 1, j, bgColor);
                }

                this.Write();
                Thread.Sleep(Delay);

                // Make it possible to start with clean screen
                if (offset < 0)
                {
                    offset++;
                }
                else
                {
                    i--;
                }
            }
        }
    }
}
