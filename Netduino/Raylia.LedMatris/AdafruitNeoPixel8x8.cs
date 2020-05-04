using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Presentation.Media;

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

        public virtual void PutBmp(int x, int y, Bitmap bmp)
        {
            for (int yy = y; yy < bmp.Height; yy++)
            {
                for (int xx = x; xx < bmp.Width; xx++)
                {
                    PutPixel(xx, yy, bmp.GetPixel(x, y));
                }
            }
        }

        public virtual void PutPixel(int x, int y, Color color)
        {
            SetColorRect(x, y, 1, 1, (int)color);
        }
    }
}
