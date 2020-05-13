using System;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using Toolbox.NETMF.Hardware;
using System.Text;
using System.Threading;

namespace Raylia.LedMatrix
{
    public class RgbMatrix: RgbLedStrip
    {
        public bool Rotate180 { get; set; }
        public bool Mirror { get; set; }

        private byte[] CurrentFont = Font8x8.Sinclair_S;

        public RgbMatrix(int width, int height): base(Chipsets.WS2812, width * height, SPI_Devices.SPI1, Pins.GPIO_PIN_D7, true)
        {
            this.Width = width;
            this.Height = height;
            Rotate180 = true;
            Mirror = false;
            CompactedCharStyle = false;
        }

        public int Height { get; private set; }

        public int Width { get; private set; }
        public bool CompactedCharStyle { get; set; }

        public void SetBrigthness(int x, int y, int w, int h, int value)
        {
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
        public virtual void SetColorRect(int x, int y, int RectWith, int RectHeight, byte Red, byte Green, byte Blue, bool Delayed = true)
        {           
            for (int i = y; i < (y + RectHeight); i++)
            {
                int ledNo = x + i * Width;
                for (int j = 0; j < RectWith; j++)
                {
                    this.SetColor(ledNo++, Red, Green, Blue, true);
                }
            }

            if (!Delayed) this.Write();
        }

        /// <summary>
        /// RGB tesd
        /// </summary>
        public void Test0()
        {
            Clear();
            // check the colors
            SetColor(0, 0xff0000);
            SetColor(1, 0x00ff00);
            SetColor(2, 0x00ff00);
            SetColor(3, 0x0000ff);
            SetColor(4, 0x0000ff);
            SetColor(5, 0x0000ff);
            Write();
            Thread.Sleep(1000);

            PutPixel(0, 0, 0xff0000);
            PutPixel(1, 1, 0x00ff00);
            PutPixel(2, 2, 0x00ff00);
            PutPixel(3, 3, 0x0000ff);
            PutPixel(4, 4, 0x0000ff);
            PutPixel(5, 5, 0x0000ff);
            Write();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Put one pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <param name="delayed"></param>
        public virtual bool PutPixel(int x, int y, int color, bool delayed = true)
        {
            int xx = x;
            int yy = y;

            if (Rotate180)
            {
                xx = Width - xx - 1;
                yy = Height - yy - 1;
            }

            if (Mirror)
            {
                xx = Width - xx - 1;
            }

            if (xx >= 0 && xx < Width && yy >= 0 && yy < Height)
            {
                SetColorRect(xx, yy, 1, 1, color, delayed);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Test1()
        {
            for (int i = 0; i < LedCount; i++)
            {
                SetColor(i, 0x0000ff);
                Write();
                Thread.Sleep(1);
            }
        }

        public virtual void Test2()
        {
            for (int i = 0; i < LedCount; i++)
            {
                SetColor(i, 0x00ff00);
                Write();
                Thread.Sleep(1);
            }
        }

        public virtual void Test3()
        {
            for (int i = 0; i < LedCount; i++)
            {
                SetColor(i, 0xff0000);
                Write();
                Thread.Sleep(1);
            }
        }

        public virtual void Test4()
        {
        }

        public virtual void Test5()
        {
        }

        /// <summary>
        /// Configures all LEDs to a specific color
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <param name="RectWith">Rect Width</param>
        /// <param name="RectHeight">Rect Height</param>
        /// <param name="Color">Color</param>
        /// <param name="Delayed">Do we have to write all LEDs immediately?</param>
        public void SetColorRect(int x, int y, int RectWith, int RectHeight, int Color, bool Delayed = true)
        {
            SetColorRect(x, y, RectWith, RectHeight, (byte)(Color >> 16), (byte)(Color >> 8), (byte)Color, Delayed);
        }

        public void PutRectMap(int x, int y, byte[] bytes, int start, int len, int Attribute, bool Delayed = true)
        {
            for (int i = 0; i < (len - y); i++)
            {
                byte b = bytes[start + i];
                // check every bit
                if (x < 0)
                {
                    for (int j = -x; j < Width; j++)
                    {
                        SetColorRect(x + j, y + i, 1, 1, ((b & (0x80 >> j)) != 0) ? Attribute : 0, true);
                    }
                }
                else
                {
                    for (int j = 0; j < (Width - x); j++)
                    {
                        SetColorRect(x + j, y + i, 1, 1, ((b & (0x80 >> j)) != 0) ? Attribute : 0, true);
                    }
                }
            }
            if (!Delayed) this.Write();
        }

        /// <summary>
        /// Write a Char in a postion with colors
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="c"></param>
        /// <param name="color"></param>
        /// <param name="bgColor"></param>
        /// <param name="delayed"></param>
        public virtual int WriteChar(int x, int y, char c, int color, int bgColor = 0, bool delayed = true)
        {
            // put the font map
            int start = (int)c - (int)' ';
            start = 4 + (start << 3);

            int compactedOffset = 0;

            for (int i = 0; i < 8; i++)
            {
                byte b = CurrentFont[start + i];
                int yy = i + y;

                for (int j = 0; j < 8; j++)
                {
                    int xx = j + x;

                    if ((b & (0x80 >> j)) != 0)
                    {
                        if (compactedOffset < j)
                        {
                            compactedOffset = j;
                        }

                        PutPixel(xx, yy, color);
                    }
                    else if (bgColor >= 0)
                    {
                        PutPixel(xx, yy, bgColor);
                    }
                }
            }

            if (!delayed) this.Write();

            if (!CompactedCharStyle)
            {
                return 8;
            }

            if (c == ' ')
            {
                return 2;
            }

            return compactedOffset + 1;
        }

        public virtual void WriteText(int x, int y, string text, int color, int bgColor = 0, Boolean Delayed = true)
        {
            WriteChar(x, y, text[0], color, bgColor, Delayed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="bgColor"></param>
        /// <param name="Delay"></param>
        public virtual void ScrollToLeftText(int x, int y, string text, int color, int bgColor = 0, int Delay = 1)
        {
            //int chars = Width / 8;
            //int max = text.Length - chars;
            //for (int i = 0; i < max; i++)
            //{
            //    int xx = 0;
            //    for (int col = 0; col < Width; col++)
            //    {
            //        xx = x - col;
            //        for (int j = 0; j < chars; j++)
            //        {
            //            WriteChar(xx + 8 * j, y, text[i + j], color, bgColor);
            //        }
            //        this.Write();
            //        Thread.Sleep(Delay);
            //    }
            //}
        }

        public virtual void ScrollToRightText(int x, int y, string text, int color, int bgColor = 0, int Delay = 1)
        {

        }
 
        /// <summary>
        /// Clear matrix
        /// </summary>
        /// <param name="color"></param>
        /// <param name="Delayed"></param>
        public void Clear(int color = 0, bool Delayed = true)
        {
            SetColorAll(color, Delayed);
        }

        /// <summary>
        /// Test all leds
        /// </summary>
        public void TestLeds()
        {
            for (int i = 0; i < LedCount; i++)
            {
                SetColor(i, 0x0000ff);
                Write();
                Thread.Sleep(1);
            }
        }
    }
}
