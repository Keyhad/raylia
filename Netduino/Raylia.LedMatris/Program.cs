using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using Toolbox.NETMF.Hardware;

/*
 * Copyright 2020 Keyvan Hadjari
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace Raylia.LedMatrix
{
    public class Program
    {
        public static void Main()
        {
            // There's a 8x8 matrix (64 LEDs) connected to the first SPI bus on the Netduino
            RgbMatrix matrix = new AdafruitNeoPixel32x8();

            matrix.Test0();
            while (true)
            {
                matrix.Clear();
                matrix.Test1();
                matrix.Test2();
                matrix.Test3();
                matrix.Test4();
                matrix.Test5();
            }
            /*
            #if false
                        // Matrix 8x8
                        uint[] colors =
                        {
                            0x070000L,
                            0x0f0000L,
                            0x7f0000L,
                            0xff0000L,
                            0x7f0000L,
                            0x0f0000L,
                        };

                        int color = 0;
                        // Repeats all demos infinitely
                        while (true)
                        {
                            matrix.Claer();
                            Thread.Sleep(1000);

                            matrix.WriteText(1, 0, "1234567890123456789012345678901234567891234567890", 0x00ff00L, 100);

                            matrix.Claer();
                            Thread.Sleep(1000);

                            matrix.ScrollLeftText(1, 0, " Hello World! ... Hello World! ... Hello World! ... Hello World! ", 0x00ff00L, 200);

                            matrix.Claer();
                            Thread.Sleep(1000);

                            color %= 6;

                            uint rgb = colors[color++];

                            // put rect1
                            matrix.SetColorRect(0, 0, 8, 8, rgb);
                            matrix.Write();
                            Thread.Sleep(100);

                            rgb = colors[color++];

                            // put rect2
                            matrix.SetColorRect(1, 1, 6, 6, rgb);
                            matrix.Write();
                            Thread.Sleep(100);

                            rgb = colors[color++];

                            // put rect3
                            matrix.SetColorRect(2, 2, 4, 4, rgb);
                            matrix.Write();
                            Thread.Sleep(100);
            #endif
            #if false
                            // Some other visual efects

                            for (int Seconds = 0; Seconds < 30; ++Seconds)
                            {
                                Chain.InsertColorAtBack(0xff0000, false); Thread.Sleep(333);
                                Chain.InsertColorAtBack(0x00ff00, false); Thread.Sleep(333);
                                Chain.InsertColorAtBack(0x0000ff, false); Thread.Sleep(334);
                            }
                            Chain.SetColorAll(0, false);
                            for (int Seconds = 0; Seconds < 30; ++Seconds)
                            {
                                Chain.InsertColorAtFront(0x0000ff, false); Thread.Sleep(334);
                                Chain.InsertColorAtFront(0x00ff00, false); Thread.Sleep(333);
                                Chain.InsertColorAtFront(0xff0000, false); Thread.Sleep(333);
                            }

                            // Just changing colors
                            Chain.SetColorAll(0xff0000, false); Thread.Sleep(1000);
                            Chain.SetColorAll(0x00ff00, false); Thread.Sleep(1000);
                            Chain.SetColorAll(0x0000ff, false); Thread.Sleep(1000);

                            // Loops nicely through all colors
                            for (byte Brightness = 0; Brightness < 255; ++Brightness)
                            {
                                Chain.SetColorAll(Brightness, 0, 0, false); Thread.Sleep(1);
                            }
                            for (byte Brightness = 0; Brightness < 255; ++Brightness)
                            {
                                Chain.SetColorAll(255, Brightness, 0, false); Thread.Sleep(1);
                            }
                            for (byte Brightness = 0; Brightness < 255; ++Brightness)
                            {
                                Chain.SetColorAll((byte)(255 - Brightness), 255, 0, false); Thread.Sleep(1);
                            }
                            for (byte Brightness = 0; Brightness < 255; ++Brightness)
                            {
                                Chain.SetColorAll(0, 255, Brightness, false); Thread.Sleep(1);
                            }
                            for (byte Brightness = 0; Brightness < 255; ++Brightness)
                            {
                                Chain.SetColorAll(0, (byte)(255 - Brightness), 255, false); Thread.Sleep(1);
                            }
                            for (byte Brightness = 0; Brightness < 255; ++Brightness)
                            {
                                Chain.SetColorAll(Brightness, 0, 255, false); Thread.Sleep(1);
                            }
                            for (byte Brightness = 0; Brightness < 255; ++Brightness)
                            {
                                Chain.SetColorAll(255, Brightness, 255, false); Thread.Sleep(1);
                            }
                            for (byte Brightness = 0; Brightness < 255; ++Brightness)
                            {
                                Chain.SetColorAll((byte)(255 - Brightness), (byte)(255 - Brightness), (byte)(255 - Brightness), false); Thread.Sleep(1);
                            }
            #endif
                        }
                        */
        }

    }
}
