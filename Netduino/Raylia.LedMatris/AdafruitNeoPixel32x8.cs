using System;
using Microsoft.SPOT;
using System.Threading;

namespace Raylia.LedMatrix
{
    public class AdafruitNeoPixel32x8: RgbMatrix
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
                ScrollLeftText(1, 0, "abcdefghijk", 0x130000, 7);
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
            int lx1 = y;
            int ly1 = Width - (x + RectWith);

            int lx2 = lx1 + RectHeight - 1; 
            int ly2 = ly1;

            int lx3 = lx2;
            int ly3 = ly2 + RectWith - 1;

            int lx4 = lx1;
            int ly4 = ly3;

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

        public override void ScrollLeftText(int x, int y, string text, int color, int bgColor = 0, int Delay = 1)
        {
            int chars = Width >> 3;
            int max = text.Length << 3;

            Clear(bgColor);

            int offset = Width;
            for (int i = 0; i < max;)
            {
                int charIndex = i >> 3;
                int charMode = i & 7;
                int xx = x - charMode;
                for (int j = charIndex; j < text.Length && xx < Width; xx += 8, j++)
                {
                    WriteChar(offset + xx, y, text[j], color, bgColor);
                }

                this.Write();
                Thread.Sleep(Delay);

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
    }
}
