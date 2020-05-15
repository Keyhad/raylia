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

        public AdafruitNeoPixel8x8(int width, int height) : base(width, height)
        {

        }

        public virtual void PutBmp(int x, int y, Bitmap bmp, bool delayed = true)
        {
            //for (int yy = y; yy < bmp.Height; yy++)
            //{
            //    for (int xx = x; xx < bmp.Width; xx++)
            //    {
            //        PutPixel(xx, yy, bmp.GetPixel(x, y));
            //    }
            //}
            //if (!delayed) this.Write();
        }
    }
}
