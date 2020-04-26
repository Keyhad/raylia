using System;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using Toolbox.NETMF.Hardware;

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
        /// <param name="Red">Red brightness (0 to 255)</param>
        /// <param name="Green">Green brightness (0 to 255)</param>
        /// <param name="Blue">Blue brightness (0 to 255)</param>
        /// <param name="Delayed">Do we have to write all LEDs immediately?</param>
        public void SetColor(int x, int y, int w, int h, byte Red, byte Green, byte Blue, bool Delayed = true)
        {           
            for (int i = y; i < (y + h); i++)
            {
                int ledNo = x + i * Width;
                for (int j = 0; j < w; j++)
                {
                    this.SetColor(ledNo++, Red, Green, Blue, true);
                }
            }

            if (!Delayed) this.Write();
        }
    }
}
