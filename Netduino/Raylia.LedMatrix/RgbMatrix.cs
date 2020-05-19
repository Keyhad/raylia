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
        public bool RightToLeft { get; set; }
        public bool Rotate180 { get; set; }
        public bool Mirror { get; set; }

        public Font8x8 FontManager { get; set; }

        public RgbMatrix(int Matrix_Width, int Matrix_Height, byte Default_Brightness = 150, int Default_Bg = 0) : 
            base(Chipsets.WS2812, Matrix_Width * Matrix_Height, SPI_Devices.SPI1, Pins.GPIO_PIN_D7, true, Default_Brightness, Default_Bg)
        {
            FontManager = new Font8x8();
            FontManager.SelectFont(Fonts.Sinclair);
            this.Width = Matrix_Width;
            this.Height = Matrix_Height;
            Rotate180 = true;
            Mirror = false;
        }

        public int Height { get; private set; }

        public int Width { get; private set; }

        public bool FlippChar { get; set; }

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
        public virtual short WriteChar(short x, short y, char c, int color, int bgColor = 0, bool delayed = true)
        {
            // put the font map
            short fontIndex = (short)(c - ' ');
            short rowIndex = (short)(4 + (fontIndex << 3));

            short xx = 0;
            ushort fp = FontManager.FontPaddings[fontIndex];
            short row1 = 0;// FontManager.GetTop(fp);
            short row2 = 7;// 8 - FontManager.GetBottom(fp) - 1;
            for (short fontRow = row1; fontRow <= row2; fontRow++)
            {
                byte b = FontManager.CurrentFont[rowIndex + fontRow];
                short yy = (short)(fontRow + y);
                short bit1 = (short)FontManager.GetLeft(fp);
                short bit2 = (short)(8 - FontManager.GetRight(fp) - 1);
                for (short bit = bit1; bit <= bit2; bit++)
                {
                    xx = (short)(x + (bit - bit1));
                    if (xx >= 0 && xx < Width)
                    {
                        if ((b & (0x80 >> bit)) != 0)
                        {
                            PutPixel(xx, yy, color);
                        }
                        else if (bgColor >= 0)
                        {
                            PutPixel(xx, yy, bgColor);
                        }
                    }
                }
            }

            if (!delayed) this.Write();

            //Debug.Print("write " + c + " x: " + x.ToString("D3") + ", xx: " + xx.ToString("D3"));
            return (short)(xx + 1);
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
        public virtual short WriteCharR(short x, short y, char c, int color, int bgColor = 0, bool delayed = true)
        {
            // put the font map
            int fontIndex = (int)c - (int)' ';
            int rowIndex = 4 + (fontIndex << 3);

            int xx = 0;
            ushort fp = FontManager.FontPaddings[fontIndex];
            int row1 = 0;// FontManager.GetTop(fp);
            int row2 = 7;// 8 - FontManager.GetBottom(fp) - 1;
            for (int fontRow = row1; fontRow <= row2; fontRow++)
            {
                byte b = FontManager.CurrentFont[rowIndex + fontRow];
                int yy = fontRow + y;
                int bit1 = FontManager.GetLeft(fp);
                int bit2 = 8 - FontManager.GetRight(fp) - 1;
                for (int bit = bit2; bit >= bit1; bit--)
                {
                    xx = x + (bit2 - bit);

                    if (xx >= 0 && xx < Width)
                    {
                        if ((b & (0x80 >> bit)) != 0)
                        {
                            PutPixel(Width - xx - 1, yy, color);
                        }
                        else if (bgColor >= 0)
                        {
                            PutPixel(Width - xx - 1, yy, bgColor);
                        }
                    }
                }
            }

            if (!delayed) this.Write();

            //Debug.Print("write " + c + " x: " + x.ToString("D3") + ", xx: " + xx.ToString("D3"));
            return (short)(xx + 1);
        }

        public virtual void WriteText(short x, short y, string text, int color, int bgColor = 0, Boolean Delayed = true)
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
        public virtual void ScrollToLeftText(short x, short y, string text, int color, int bgColor = 0, int Delay = 1)
        {
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
        public virtual void ScrollToRightText(short x, short y, string text, int color, int bgColor = 0, int Delay = 1)
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
