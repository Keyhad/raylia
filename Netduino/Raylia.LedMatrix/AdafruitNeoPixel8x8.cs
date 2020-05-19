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

        public AdafruitNeoPixel8x8(int Matrix_Width, int Matrix_Height, byte Default_Brightness = 150, int Default_Bg = 0) : 
            base(Matrix_Width, Matrix_Height, Default_Brightness, Default_Bg)
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
