using System;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using Toolbox.NETMF.Hardware;
using System.Text;
using System.Threading;

namespace Raylia.LedMatris
{
    public class RgbMatrix: RgbLedStrip
    {
        public RgbMatrix(int width, int height): base(RgbLedStrip.Chipsets.WS2812, width * height, SPI_Devices.SPI1)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Height { get; private set; }

        public int Width { get; private set; }

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
        public void SetColorRect(int x, int y, int RectWith, int RectHeight, byte Red, byte Green, byte Blue, bool Delayed = true)
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
        /// Configures all LEDs to a specific color
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <param name="RectWith">Rect Width</param>
        /// <param name="RectHeight">Rect Height</param>
        /// <param name="Attribute">Attribute</param>
        /// <param name="Delayed">Do we have to write all LEDs immediately?</param>
        public void SetColorRect(int x, int y, int RectWith, int RectHeight, ulong Attribute, bool Delayed = true)
        {
            SetColorRect(x, y, RectWith, RectHeight, (byte)(Attribute >> 16), (byte)(Attribute >> 8), (byte)Attribute, Delayed);
        }

        public void MapBytes(int x, int y, byte[] bytes, int start, int len, ulong Attribute, bool Delayed = true)
        {
            for (int i = 0; i < (len - y); i++)
            {
                byte b = bytes[start + i];
                // check every bit
                if (x < 0)
                {
                    for (int j = -x; j < 8; j++)
                    {
                        SetColorRect(x + j, y + i, 1, 1, ((b & (0x80 >> j)) != 0) ? Attribute : 0, true);
                    }
                }
                else
                {
                    for (int j = 0; j < (8 - x); j++)
                    {
                        SetColorRect(x + j, y + i, 1, 1, ((b & (0x80 >> j)) != 0) ? Attribute : 0, true);
                    }
                }
            }
            if (!Delayed) this.Write();
        }

        public void WriteChar(int x, int y, char c, ulong Attribute, bool Delayed = true)
        {
            int index = (byte)c - (byte)(' ');

            MapBytes(x, y, Font8x8.TinyFont, 4 + index * 8, 8, Attribute, Delayed);
        }

        public void WriteText(int x, int y, string text, ulong Attribute, int Delay)
        {
            for (int i = 0; i < text.Length; i++)
            {
                WriteChar(x, y, text[i], Attribute, false);
                Thread.Sleep(Delay);
            }
        }

        internal void ScrollLeftText(int x, int y, string text, ulong Attribute, int Delay)
        {
            for (int i = 0; i < text.Length - 1; i++)
            {
                int xx = 0;
                for (int col = 0; col < 8; col++)
                {
                    xx = x - col;
                    WriteChar(xx, y, text[i], Attribute, true);
                    WriteChar(xx + 8, y, text[i + 1], Attribute, true);
                    this.Write();
                    Thread.Sleep(Delay);
                }
            }
        }

        private int calcCharWith(char c)
        {
            return 0;
        }

        public void Claer()
        {
            SetColorAll(0x000000, false);
        }

    }
}
