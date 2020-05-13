using System;
using Microsoft.SPOT;

namespace Raylia.LedMatrix
{
    public static class FarsiTranslator
    {
        //000: 06F0: ۰
        //001: 06F1: ۱
        //002: 06F2: ۲
        //003: 06F3: ۳
        //004: 06F4: ۴
        //005: 06F5: ۵
        //006: 06F6: ۶
        //007: 06F7: ۷
        //008: 06F8: ۸
        //009: 06F9: ۹
        //010: 060C: ،
        //011: 0640: ـ
        //012: 061F: ؟
        //013: FE81: ﺁ
        //014: FE8B: ﺋ
        //015: 0621: ء
        //016: FE8D: ﺍ
        //017: FE8E: ﺎ
        //018: FE8F: ﺏ
        //019: FE91: ﺑ
        //020: FB56: ﭖ
        //021: FB58: ﭘ
        //022: FE95: ﺕ
        //023: FE97: ﺗ
        //024: FE99: ﺙ
        //025: FE9B: ﺛ
        //026: FE9D: ﺝ
        //027: FE9F: ﺟ
        //028: FB7C: ﭼ
        //029: FB7C: ﭼ
        //030: FEA1: ﺡ
        //031: FEA3: ﺣ
        //032: FEA5: ﺥ
        //033: FEA7: ﺧ
        //034: 062F: د
        //035: 0630: ذ
        //036: 0631: ر
        //037: 0632: ز
        //038: 0698: ژ
        //039: FEB1: ﺱ
        //040: FEB3: ﺳ
        //041: FEB5: ﺵ
        //042: FEB7: ﺷ
        //043: FEB9: ﺹ
        //044: FEBB: ﺻ
        //045: FEBD: ﺽ
        //046: FEBF: ﺿ
        //047: 0637: ط
        //048: 2591: ░
        //049: 2592: ▒
        //050: 2593: ▓
        //051: 2502: │
        //052: 2524: ┤
        //053: 2561: ╡
        //054: 2562: ╢
        //055: 2556: ╖
        //056: 2555: ╕
        //057: 2563: ╣
        //058: 2551: ║
        //059: 2557: ╗
        //060: 255D: ╝
        //061: 255C: ╜
        //062: 255B: ╛
        //063: 2510: ┐
        //064: 2514: └
        //065: 2534: ┴
        //066: 252C: ┬
        //067: 251C: ├
        //068: 2500: ─
        //069: 253C: ┼
        //070: 255E: ╞
        //071: 255F: ╟
        //072: 255A: ╚
        //073: 2554: ╔
        //074: 2569: ╩
        //075: 2566: ╦
        //076: 2560: ╠
        //077: 2550: ═
        //078: 256C: ╬
        //079: 2567: ╧
        //080: 2568: ╨
        //081: 2564: ╤
        //082: 2565: ╥
        //083: 2559: ╙
        //084: 2558: ╘
        //085: 2552: ╒
        //086: 2553: ╓
        //087: 256B: ╫
        //088: 256A: ╪
        //089: 2518: ┘
        //090: 250C: ┌
        //091: 2588: █
        //092: 2584: ▄
        //093: 258C: ▌
        //094: 2590: ▐
        //095: 2580: ▀
        //096: 0638: ظ
        //097: FEC9: ﻉ
        //098: FECA: ﻊ
        //099: FECC: ﻌ
        //100: FECB: ﻋ
        //101: FECD: ﻍ
        //102: FECE: ﻎ
        //103: FED0: ﻐ
        //104: FECF: ﻏ
        //105: FED1: ﻑ
        //106: FED3: ﻓ
        //107: FED5: ﻕ
        //108: FED7: ﻗ
        //109: FB8E: ﮎ
        //110: FB90: ﮐ
        //111: FB92: ﮒ
        //112: FB94: ﮔ
        //113: FEDD: ﻝ
        //114: FEFB: ﻻ
        //115: FEDF: ﻟ
        //116: FEE1: ﻡ
        //117: FEE3: ﻣ
        //118: FEE5: ﻥ
        //119: FEE7: ﻧ
        //120: 0648: و
        //121: FEE9: ﻩ
        //122: FEEC: ﻬ
        //123: FEEB: ﻫ
        //124: FBFD: ﯽ
        //125: FBFC: ﯼ
        //126: FBFE: ﯾ
        //127: 00A0:  


        /// <summary>
        /// Iran System
        /// </summary>
        private static int[] TranslationMap = new int[] {
            0x06F0, 0x06F1, 0x06F2, 0x06F3, 0x06F4, 0x06F5, 0x06F6, 0x06F7, 0x06F8, 0x06F9,
            0x060C, 0x0640, 0x061F, 0xFE81, 0xFE8B, 0x0621, 0xFE8D, 0xFE8E, 0xFE8F, 0xFE91,
            0xFB56, 0xFB58, 0xFE95, 0xFE97, 0xFE99, 0xFE9B, 0xFE9D, 0xFE9F, 0xFB7C, 0xFB7C,
            0xFEA1, 0xFEA3, 0xFEA5, 0xFEA7, 0x062F, 0x0630, 0x0631, 0x0632, 0x0698, 0xFEB1,
            0xFEB3, 0xFEB5, 0xFEB7, 0xFEB9, 0xFEBB, 0xFEBD, 0xFEBF, 0x0637, 0x2591, 0x2592,
            0x2593, 0x2502, 0x2524, 0x2561, 0x2562, 0x2556, 0x2555, 0x2563, 0x2551, 0x2557,
            0x255D, 0x255C, 0x255B, 0x2510, 0x2514, 0x2534, 0x252C, 0x251C, 0x2500, 0x253C,
            0x255E, 0x255F, 0x255A, 0x2554, 0x2569, 0x2566, 0x2560, 0x2550, 0x256C, 0x2567,
            0x2568, 0x2564, 0x2565, 0x2559, 0x2558, 0x2552, 0x2553, 0x256B, 0x256A, 0x2518,
            0x250C, 0x2588, 0x2584, 0x258C, 0x2590, 0x2580, 0x0638, 0xFEC9, 0xFECA, 0xFECC,
            0xFECB, 0xFECD, 0xFECE, 0xFED0, 0xFECF, 0xFED1, 0xFED3, 0xFED5, 0xFED7, 0xFB8E,
            0xFB90, 0xFB92, 0xFB94, 0xFEDD, 0xFEFB, 0xFEDF, 0xFEE1, 0xFEE3, 0xFEE5, 0xFEE7,
            0x0648, 0xFEE9, 0xFEEC, 0xFEEB, 0xFBFD, 0xFBFC, 0xFBFE, 0x00A0
        };

        public static void Dump()
        {
            for (int i = 0; i < TranslationMap.Length; i++)
            {
                Debug.Print(i.ToString("D3") + ": " + TranslationMap[i].ToString("X4") + ": " + (char)TranslationMap[i]);
            }
        }

        /// <summary>
        /// translate from unicode to font8x8
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Translate(string text)
        {
            string retValue = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                retValue += (char)Translate(text[i]);
            }

            return retValue;
        }

        public static char Translate(char aChar)
        {
            char retValue = ' ';

            switch (aChar)
            {
                case 'آ':
                case 'ا':
                    retValue = '!';
                    break;
                case 'ب' :
                    retValue = '#';
                    break;
                case 'ﺑ' :
                    retValue = '"';
                    break;
                case 'ﭘ':
                    retValue = '$';
                    break;
                case 'ﺗ':
                    retValue = '&';
                    break;
            }

            return retValue;
        }
    }
}
