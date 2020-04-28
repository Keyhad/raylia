using System;
using Microsoft.SPOT;
using System.Threading;

namespace Raylia.LedMatrix
{
    public class AdafruitNeoPixel8x8: RgbMatrix
    {
        public AdafruitNeoPixel8x8() : base(8, 8)
        {

        }

        public void WriteText(int x, int y, string text, int color, int Delay)
        {
            for (int i = 0; i < text.Length; i++)
            {
                WriteChar(x, y, text[i], color, 0, false);
                Thread.Sleep(Delay);
            }
        }
    }
}
