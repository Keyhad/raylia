﻿using System;
using Microsoft.SPOT;

namespace Raylia.LedMatrix
{
    public class Font8x8
    {
        public byte[] CurrentFont { get; private set; }

        // http://www.rinkydinkelectronics.com/r_fonts.php
        // FarsiFont
        // Font type    : Full (95 characters)
        // Font size    : 8x8 pixels
        // Memory usage : 764 bytes
        public static readonly byte[] FarsiFont ={
            0x08,0x08,0x20,0x5F,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,  // <Space>
            0x00,0x01,0x01,0x01,0x01,0x00,0x00,0x00,  // ! ﺍ
            0x00,0x00,0x02,0x01,0x01,0x0E,0x00,0x04,  // " ﺑ
            0x00,0x00,0x40,0x81,0x81,0x7E,0x00,0x10,  // # ﺏ
            0x00,0x00,0x02,0x01,0x01,0x1E,0x00,0x0E,  // $ ﭘ
            0x00,0x00,0x40,0x81,0x81,0x7E,0x00,0x38,  // % ﭖ
            0x00,0x18,0x02,0x01,0x01,0x1E,0x00,0x00,  // & ﺗ
            0x00,0x18,0x40,0x81,0x81,0x7E,0x00,0x00,  // ' ﺕ
            0x00,0x10,0x2A,0x01,0x01,0x3E,0x00,0x00,  // ( ﺛ
            0x00,0x08,0x54,0x81,0x81,0x7E,0x00,0x00,  // ) ﺙ
            0x00,0x00,0x0C,0x12,0x01,0x3E,0x00,0x04,  // * ﺝ
            0x00,0x00,0x0C,0x12,0x01,0x3E,0x40,0x3A,  // + ﺟ
            0x00,0x00,0x0C,0x12,0x01,0x3E,0x00,0x1C,  // , ﭼ
            0x00,0x00,0x0C,0x12,0x01,0x3E,0x40,0x37,  // - ﭼ
            0x00,0x00,0x0C,0x12,0x01,0x3E,0x00,0x00,  // . ﺡ
            0x00,0x00,0x0C,0x12,0x01,0x3E,0x40,0x38,  // / ﺣ                                                       
            0x00,0x20,0x0C,0x12,0x01,0x3E,0x00,0x00,  // 0
            0x00,0x20,0x0C,0x12,0x01,0x3E,0x40,0x38,  // 1
            0x00,0x00,0x04,0x02,0x01,0x12,0x0C,0x00,  // 2
            0x00,0x10,0x04,0x02,0x01,0x12,0x0C,0x00,  // 3
            0x00,0x00,0x02,0x01,0x01,0x02,0x04,0x18,  // 4
            0x00,0x08,0x02,0x01,0x01,0x02,0x04,0x18,  // 5
            0x00,0x10,0x2A,0x01,0x01,0x02,0x04,0x18,  // 6
            0x00,0x00,0x02,0x29,0x29,0xD6,0x00,0x00,  // 7
            0x00,0x00,0x00,0x55,0x95,0x9A,0x90,0x60,  // 8
            0x00,0x38,0x02,0x29,0x29,0xD6,0x00,0x00,  // 9
            0x00,0x0E,0x00,0x55,0x95,0x9A,0x90,0x60,  // :
            0x00,0x00,0x06,0x29,0x31,0x7E,0x00,0x00,  // ;
            0x00,0x00,0x02,0x55,0x99,0x9E,0x90,0x60,  // <
            0x00,0x10,0x06,0x29,0x31,0x7E,0x00,0x00,  // =
            0x00,0x08,0x02,0x55,0x99,0x9E,0x90,0x60,  // >
            0x00,0x20,0x26,0x29,0x31,0x7E,0x00,0x00,  // ?
            0x00,0x28,0x26,0x29,0x31,0x7E,0x00,0x00,  // @
            0x00,0x00,0x03,0x04,0x04,0x0F,0x00,0x00,  // A
            0x00,0x00,0x1E,0x22,0x1C,0x77,0x00,0x00,  // B
            0x00,0x0E,0x11,0x0E,0x1C,0x23,0x20,0x1C,  // C
            0x00,0x03,0x04,0x04,0x0F,0x10,0x10,0x0F,  // D
            0x00,0x08,0x03,0x04,0x04,0x0F,0x00,0x00,  // E
            0x00,0x40,0x1E,0x22,0x1C,0x77,0x00,0x00,  // F
            0x00,0x4E,0x11,0x0E,0x1C,0x23,0x20,0x1C,  // G
            0x00,0x13,0x04,0x04,0x0F,0x10,0x10,0x0F,  // H
            0x00,0x12,0x05,0x05,0x03,0x1E,0x00,0x00,  // I
            0x00,0x12,0x45,0x85,0x83,0x7E,0x00,0x00,  // J
            0x00,0x66,0x09,0x09,0x07,0x7E,0x00,0x00,  // K
            0x00,0x66,0x09,0x29,0x47,0x41,0x22,0x1C,  // L
            0x00,0x0F,0x10,0x1E,0x01,0x3E,0x00,0x00,  // M
            0x00,0x0F,0x50,0x9E,0x81,0x7E,0x00,0x00,  // N
            0x07,0x0F,0x10,0x1E,0x01,0x3E,0x00,0x00,  // O
            0x07,0x0F,0x50,0x9E,0x81,0x7E,0x00,0x00,  // P
            0x00,0x01,0x01,0x01,0x01,0x06,0x00,0x00,  // Q
            0x00,0x01,0x01,0x11,0x21,0x22,0x1C,0x00,  // R
            0x00,0x00,0x06,0x09,0x09,0x36,0x00,0x00,  // S
            0x00,0x04,0x0A,0x19,0x29,0x46,0x40,0x20,  // T
            0x00,0x0A,0x01,0x01,0x0E,0x00,0x00,0x00,  // U
            0x00,0x00,0x0A,0x21,0x41,0x41,0x22,0x1C,  // V
            0x00,0x06,0x09,0x09,0x09,0x07,0x01,0x0E,  // W
            0x00,0x08,0x04,0x0A,0x15,0x49,0x36,0x00,  // X
            0x00,0x00,0x30,0x48,0x56,0xE9,0x50,0x20,  // Y
            0x00,0x1C,0x24,0x24,0x14,0x03,0x00,0x00,  // Z
            0x00,0x08,0x04,0x0A,0x11,0x11,0x0E,0x00,  // [
            0x00,0x00,0x02,0x01,0x01,0x0E,0x00,0x0C,  // <backslash>
            0x00,0x00,0x00,0x4C,0x92,0x89,0x84,0x78,  // ]
            0x00,0x0C,0x52,0x90,0x8C,0x82,0x42,0x3C,  // ^
            0x00,0x04,0x09,0x0A,0x04,0x08,0x00,0x00,  // _
            0x00,0x01,0x09,0x05,0x05,0x0E,0x00,0x00,  // `
            0x00,0x15,0x35,0x55,0x75,0x15,0x0A,0x00,  // a
            0x00,0x06,0x09,0x08,0x04,0x02,0x00,0x02,  // b
            0x00,0x00,0x00,0x06,0x09,0x09,0x06,0x00,  // c
            0x00,0x01,0x01,0x01,0x01,0x01,0x01,0x00,  // d
            0x00,0x09,0x09,0x0E,0x08,0x08,0x08,0x00,  // e
            0x00,0x25,0x25,0x3A,0x20,0x20,0x20,0x00,  // f
            0x00,0x03,0x14,0x14,0x1F,0x10,0x10,0x00,  // g
            0x00,0x08,0x04,0x12,0x21,0x29,0x16,0x00,  // h
            0x00,0x10,0x21,0x22,0x1C,0x08,0x10,0x00,  // i
            0x00,0x11,0x11,0x0A,0x0A,0x04,0x04,0x00,  // j
            0x00,0x04,0x04,0x0A,0x0A,0x11,0x11,0x00,  // k
            0x00,0x06,0x09,0x09,0x07,0x01,0x01,0x00,  // l
            0xFE,0x82,0xAA,0x92,0xAA,0x82,0xFE,0x00,  // m
            0xFE,0x82,0x82,0x82,0xBA,0x82,0xFE,0x00,  // n
            0xFE,0x82,0xBE,0xA2,0xA2,0xA2,0xFE,0x00,  // o
            0x00,0x00,0x08,0x1C,0x3E,0x7F,0x00,0x00,  // p
            0x00,0x00,0x7F,0x3E,0x1C,0x08,0x00,0x00,  // q
            0x00,0x04,0x0C,0x1C,0x3C,0x1C,0x0C,0x04,  // r
            0x00,0x20,0x30,0x38,0x3C,0x38,0x30,0x20,  // s
            0x00,0x7E,0x7E,0x7E,0x7E,0x7E,0x7E,0x7E,  // t
            0x00,0x6C,0x6C,0x6C,0x6C,0x6C,0x6C,0x6C,  // u
            0x00,0x38,0x7C,0xFE,0xFE,0xFE,0x7C,0x38,  // v
            0x00,0x88,0xCC,0xEE,0xFF,0xEE,0xCC,0x88,  // w
            0x00,0x11,0x33,0x77,0xFF,0x77,0x33,0x11,  // x
            0x00,0x46,0x66,0x76,0x7E,0x76,0x66,0x46,  // y
            0x00,0x62,0x66,0x6E,0x7E,0x6E,0x66,0x62,  // z
            0x1F,0x3F,0x31,0x21,0x27,0xEF,0xE6,0xC0,  // {
            0x04,0x0E,0x0F,0x0B,0x79,0xF8,0xF8,0x70,  // |
            0x10,0x38,0x7C,0xFE,0x38,0x38,0x38,0x00,  // }
            0x38,0x38,0x38,0xFE,0x7C,0x38,0x10,0x00,  // ~
        };
/*
        // http://www.rinkydinkelectronics.com/r_fonts.php
        // TinyFont
        // Font type    : Full (95 characters)
        // Font size    : 8x8 pixels
        // Memory usage : 764 bytes
        public static readonly byte[] TinyFont ={
            0x08,0x08,0x20,0x5F,
		    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00, // <Space>
		    0x18,0x3C,0x3C,0x18,0x18,0x00,0x18,0x00, // !
		    0x66,0x66,0x24,0x00,0x00,0x00,0x00,0x00, // "
		    0x6C,0x6C,0xFE,0x6C,0xFE,0x6C,0x6C,0x00, // #
		    0x18,0x3E,0x60,0x3C,0x06,0x7C,0x18,0x00, // $
		    0x00,0xC6,0xCC,0x18,0x30,0x66,0xC6,0x00, // %
		    0x38,0x6C,0x38,0x76,0xDC,0xCC,0x76,0x00, // &
		    0x18,0x18,0x30,0x00,0x00,0x00,0x00,0x00, // '
		    0x0C,0x18,0x30,0x30,0x30,0x18,0x0C,0x00, // (
		    0x30,0x18,0x0C,0x0C,0x0C,0x18,0x30,0x00, // )
		    0x00,0x66,0x3C,0xFF,0x3C,0x66,0x00,0x00, // *
		    0x00,0x18,0x18,0x7E,0x18,0x18,0x00,0x00, // +
		    0x00,0x00,0x00,0x00,0x00,0x18,0x18,0x30, // ,
		    0x00,0x00,0x00,0x7E,0x00,0x00,0x00,0x00, // -
		    0x00,0x00,0x00,0x00,0x00,0x18,0x18,0x00, // .
		    0x06,0x0C,0x18,0x30,0x60,0xC0,0x80,0x00, // /
		    0x7C,0xC6,0xCE,0xD6,0xE6,0xC6,0x7C,0x00, // 0
		    0x18,0x38,0x18,0x18,0x18,0x18,0x7E,0x00, // 1
		    0x7C,0xC6,0x06,0x1C,0x30,0x66,0xFE,0x00, // 2
		    0x7C,0xC6,0x06,0x3C,0x06,0xC6,0x7C,0x00, // 3
		    0x1C,0x3C,0x6C,0xCC,0xFE,0x0C,0x1E,0x00, // 4
		    0xFE,0xC0,0xC0,0xFC,0x06,0xC6,0x7C,0x00, // 5
		    0x38,0x60,0xC0,0xFC,0xC6,0xC6,0x7C,0x00, // 6
		    0xFE,0xC6,0x0C,0x18,0x30,0x30,0x30,0x00, // 7
		    0x7C,0xC6,0xC6,0x7C,0xC6,0xC6,0x7C,0x00, // 8
		    0x7C,0xC6,0xC6,0x7E,0x06,0x0C,0x78,0x00, // 9
		    0x00,0x18,0x18,0x00,0x00,0x18,0x18,0x00, // :
		    0x00,0x18,0x18,0x00,0x00,0x18,0x18,0x30, // ;
		    0x06,0x0C,0x18,0x30,0x18,0x0C,0x06,0x00, // <
		    0x00,0x00,0x7E,0x00,0x00,0x7E,0x00,0x00, // =
		    0x60,0x30,0x18,0x0C,0x18,0x30,0x60,0x00, // >
		    0x7C,0xC6,0x0C,0x18,0x18,0x00,0x18,0x00, // ?
		    0x7C,0xC6,0xDE,0xDE,0xDE,0xC0,0x78,0x00, // @
		    0x38,0x6C,0xC6,0xFE,0xC6,0xC6,0xC6,0x00, // A
		    0xFC,0x66,0x66,0x7C,0x66,0x66,0xFC,0x00, // B
		    0x3C,0x66,0xC0,0xC0,0xC0,0x66,0x3C,0x00, // C
		    0xF8,0x6C,0x66,0x66,0x66,0x6C,0xF8,0x00, // D
		    0xFE,0x62,0x68,0x78,0x68,0x62,0xFE,0x00, // E
		    0xFE,0x62,0x68,0x78,0x68,0x60,0xF0,0x00, // F
		    0x3C,0x66,0xC0,0xC0,0xCE,0x66,0x3A,0x00, // G
		    0xC6,0xC6,0xC6,0xFE,0xC6,0xC6,0xC6,0x00, // H
		    0x3C,0x18,0x18,0x18,0x18,0x18,0x3C,0x00, // I
		    0x1E,0x0C,0x0C,0x0C,0xCC,0xCC,0x78,0x00, // J
		    0xE6,0x66,0x6C,0x78,0x6C,0x66,0xE6,0x00, // K
		    0xF0,0x60,0x60,0x60,0x62,0x66,0xFE,0x00, // L
		    0xC6,0xEE,0xFE,0xFE,0xD6,0xC6,0xC6,0x00, // M
		    0xC6,0xE6,0xF6,0xDE,0xCE,0xC6,0xC6,0x00, // N
		    0x7C,0xC6,0xC6,0xC6,0xC6,0xC6,0x7C,0x00, // O
		    0xFC,0x66,0x66,0x7C,0x60,0x60,0xF0,0x00, // P
		    0x7C,0xC6,0xC6,0xC6,0xC6,0xCE,0x7C,0x0E, // Q
		    0xFC,0x66,0x66,0x7C,0x6C,0x66,0xE6,0x00, // R
		    0x7C,0xC6,0x60,0x38,0x0C,0xC6,0x7C,0x00, // S
		    0x7E,0x7E,0x5A,0x18,0x18,0x18,0x3C,0x00, // T
		    0xC6,0xC6,0xC6,0xC6,0xC6,0xC6,0x7C,0x00, // U
		    0xC6,0xC6,0xC6,0xC6,0xC6,0x6C,0x38,0x00, // V
		    0xC6,0xC6,0xC6,0xD6,0xD6,0xFE,0x6C,0x00, // W
		    0xC6,0xC6,0x6C,0x38,0x6C,0xC6,0xC6,0x00, // X
		    0x66,0x66,0x66,0x3C,0x18,0x18,0x3C,0x00, // Y
		    0xFE,0xC6,0x8C,0x18,0x32,0x66,0xFE,0x00, // Z
		    0x3C,0x30,0x30,0x30,0x30,0x30,0x3C,0x00, // [
		    0xC0,0x60,0x30,0x18,0x0C,0x06,0x02,0x00, // <Backslash>
		    0x3C,0x0C,0x0C,0x0C,0x0C,0x0C,0x3C,0x00, // ]
		    0x10,0x38,0x6C,0xC6,0x00,0x00,0x00,0x00, // ^
		    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF, // _
		    0x30,0x18,0x0C,0x00,0x00,0x00,0x00,0x00, // '
		    0x00,0x00,0x78,0x0C,0x7C,0xCC,0x76,0x00, // a
		    0xE0,0x60,0x7C,0x66,0x66,0x66,0xDC,0x00, // b
		    0x00,0x00,0x7C,0xC6,0xC0,0xC6,0x7C,0x00, // c
		    0x1C,0x0C,0x7C,0xCC,0xCC,0xCC,0x76,0x00, // d
		    0x00,0x00,0x7C,0xC6,0xFE,0xC0,0x7C,0x00, // e
		    0x3C,0x66,0x60,0xF8,0x60,0x60,0xF0,0x00, // f
		    0x00,0x00,0x76,0xCC,0xCC,0x7C,0x0C,0xF8, // g
		    0xE0,0x60,0x6C,0x76,0x66,0x66,0xE6,0x00, // h
		    0x18,0x00,0x38,0x18,0x18,0x18,0x3C,0x00, // i
		    0x06,0x00,0x06,0x06,0x06,0x66,0x66,0x3C, // j
		    0xE0,0x60,0x66,0x6C,0x78,0x6C,0xE6,0x00, // k
		    0x38,0x18,0x18,0x18,0x18,0x18,0x3C,0x00, // l
		    0x00,0x00,0xEC,0xFE,0xD6,0xD6,0xD6,0x00, // m
		    0x00,0x00,0xDC,0x66,0x66,0x66,0x66,0x00, // n
		    0x00,0x00,0x7C,0xC6,0xC6,0xC6,0x7C,0x00, // o
		    0x00,0x00,0xDC,0x66,0x66,0x7C,0x60,0xF0, // p
		    0x00,0x00,0x76,0xCC,0xCC,0x7C,0x0C,0x1E, // q
		    0x00,0x00,0xDC,0x76,0x60,0x60,0xF0,0x00, // r
		    0x00,0x00,0x7E,0xC0,0x7C,0x06,0xFC,0x00, // s
		    0x30,0x30,0xFC,0x30,0x30,0x36,0x1C,0x00, // t
		    0x00,0x00,0xCC,0xCC,0xCC,0xCC,0x76,0x00, // u
		    0x00,0x00,0xC6,0xC6,0xC6,0x6C,0x38,0x00, // v
		    0x00,0x00,0xC6,0xD6,0xD6,0xFE,0x6C,0x00, // w
		    0x00,0x00,0xC6,0x6C,0x38,0x6C,0xC6,0x00, // x
		    0x00,0x00,0xC6,0xC6,0xC6,0x7E,0x06,0xFC, // y
		    0x00,0x00,0x7E,0x4C,0x18,0x32,0x7E,0x00, // z
		    0x0E,0x18,0x18,0x70,0x18,0x18,0x0E,0x00, // {
		    0x18,0x18,0x18,0x18,0x18,0x18,0x18,0x00, // |
		    0x70,0x18,0x18,0x0E,0x18,0x18,0x70,0x00, // }
		    0x76,0xDC,0x00,0x00,0x00,0x00,0x00,0x00, // ~
	    };
*/
        // http://www.rinkydinkelectronics.com/r_fonts.php
        // Sinclair_S
        // Font type    : Full (95 characters)
        // Font size    : 8x8 pixels
        // Memory usage : 764 bytes
        public static readonly byte[] Sinclair_S ={
            0x08,0x08,0x20,0x5F,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,  // <space>
            0x08,0x08,0x08,0x08,0x08,0x00,0x08,0x00,  // !
            0x14,0x14,0x00,0x00,0x00,0x00,0x00,0x00,  // "
            0x00,0x24,0x7E,0x24,0x24,0x7E,0x24,0x00,  // #
            0x10,0x7C,0x50,0x7C,0x14,0x7C,0x10,0x00,  // $
            0x00,0x62,0x64,0x08,0x10,0x26,0x46,0x00,  // %
            0x00,0x10,0x28,0x10,0x2A,0x44,0x3A,0x00,  // &
            0x00,0x08,0x10,0x00,0x00,0x00,0x00,0x00,  // '
            0x00,0x08,0x10,0x10,0x10,0x10,0x08,0x00,  // (
            0x00,0x10,0x08,0x08,0x08,0x08,0x10,0x00,  // )
            0x00,0x00,0x28,0x10,0x7C,0x10,0x28,0x00,  // *
            0x00,0x00,0x10,0x10,0x7C,0x10,0x10,0x00,  // +
            0x00,0x00,0x00,0x00,0x00,0x08,0x08,0x10,  // ,
            0x00,0x00,0x00,0x00,0x7C,0x00,0x00,0x00,  // -
            0x00,0x00,0x00,0x00,0x00,0x18,0x18,0x00,  // .
            0x00,0x00,0x04,0x08,0x10,0x20,0x40,0x00,  // /
            0x00,0x78,0x8C,0x94,0xA4,0xC4,0x78,0x00,  // 0
            0x00,0x60,0xA0,0x20,0x20,0x20,0xF8,0x00,  // 1
            0x00,0x78,0x84,0x04,0x78,0x80,0xFC,0x00,  // 2
            0x00,0x78,0x84,0x18,0x04,0x84,0x78,0x00,  // 3
            0x00,0x10,0x30,0x50,0x90,0xFC,0x10,0x00,  // 4
            0x00,0xFC,0x80,0xF8,0x04,0x84,0x78,0x00,  // 5
            0x00,0x78,0x80,0xF8,0x84,0x84,0x78,0x00,  // 6
            0x00,0xFC,0x04,0x08,0x10,0x20,0x20,0x00,  // 7
            0x00,0x78,0x84,0x78,0x84,0x84,0x78,0x00,  // 8
            0x00,0x78,0x84,0x84,0x7C,0x04,0x78,0x00,  // 9
            0x00,0x00,0x00,0x10,0x00,0x00,0x10,0x00,  // :
            0x00,0x00,0x10,0x00,0x00,0x10,0x10,0x20,  // ;
            0x00,0x00,0x08,0x10,0x20,0x10,0x08,0x00,  // <
            0x00,0x00,0x00,0x7C,0x00,0x7C,0x00,0x00,  // =
            0x00,0x00,0x20,0x10,0x08,0x10,0x20,0x00,  // >
            0x00,0x3C,0x42,0x04,0x08,0x00,0x08,0x00,  // ?
            0x00,0x3C,0x4A,0x56,0x5E,0x40,0x3C,0x00,  // @
            0x00,0x78,0x84,0x84,0xFC,0x84,0x84,0x00,  // A
            0x00,0xF8,0x84,0xF8,0x84,0x84,0xF8,0x00,  // B
            0x00,0x78,0x84,0x80,0x80,0x84,0x78,0x00,  // C
            0x00,0xF0,0x88,0x84,0x84,0x88,0xF0,0x00,  // D
            0x00,0xFC,0x80,0xF8,0x80,0x80,0xFC,0x00,  // E
            0x00,0xFC,0x80,0xF8,0x80,0x80,0x80,0x00,  // F
            0x00,0x78,0x84,0x80,0x9C,0x84,0x78,0x00,  // G
            0x00,0x84,0x84,0xFC,0x84,0x84,0x84,0x00,  // H
            0x00,0x7C,0x10,0x10,0x10,0x10,0x7C,0x00,  // I
            0x00,0x04,0x04,0x04,0x84,0x84,0x78,0x00,  // J
            0x00,0x88,0x90,0xE0,0x90,0x88,0x84,0x00,  // K
            0x00,0x80,0x80,0x80,0x80,0x80,0xFC,0x00,  // L
            0x00,0x84,0xCC,0xB4,0x84,0x84,0x84,0x00,  // M
            0x00,0x84,0xC4,0xA4,0x94,0x8C,0x84,0x00,  // N
            0x00,0x78,0x84,0x84,0x84,0x84,0x78,0x00,  // O
            0x00,0xF8,0x84,0x84,0xF8,0x80,0x80,0x00,  // P
            0x00,0x78,0x84,0x84,0xA4,0x94,0x78,0x00,  // Q
            0x00,0xF8,0x84,0x84,0xF8,0x88,0x84,0x00,  // R
            0x00,0x78,0x80,0x78,0x04,0x84,0x78,0x00,  // S
            0x00,0xFE,0x10,0x10,0x10,0x10,0x10,0x00,  // T
            0x00,0x84,0x84,0x84,0x84,0x84,0x78,0x00,  // U
            0x00,0x84,0x84,0x84,0x84,0x48,0x30,0x00,  // V
            0x00,0x84,0x84,0x84,0x84,0xB4,0x48,0x00,  // W
            0x00,0x84,0x48,0x30,0x30,0x48,0x84,0x00,  // X
            0x00,0x82,0x44,0x28,0x10,0x10,0x10,0x00,  // Y
            0x00,0xFC,0x08,0x10,0x20,0x40,0xFC,0x00,  // Z
            0x00,0x38,0x20,0x20,0x20,0x20,0x38,0x00,  // [
            0x00,0x00,0x40,0x20,0x10,0x08,0x04,0x00,  // <backslash>
            0x00,0x38,0x08,0x08,0x08,0x08,0x38,0x00,  // ]
            0x00,0x10,0x38,0x54,0x10,0x10,0x10,0x00,  // ^
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFE,  // _
            0x3C,0x42,0x99,0xA1,0xA1,0x99,0x42,0x3C,  // `
            0x00,0x00,0x38,0x04,0x3C,0x44,0x3C,0x00,  // a
            0x00,0x40,0x40,0x78,0x44,0x44,0x78,0x00,  // b
            0x00,0x00,0x1C,0x20,0x20,0x20,0x1C,0x00,  // c
            0x00,0x04,0x04,0x3C,0x44,0x44,0x3C,0x00,  // d
            0x00,0x00,0x38,0x44,0x78,0x40,0x3C,0x00,  // e
            0x00,0x0C,0x10,0x18,0x10,0x10,0x10,0x00,  // f
            0x00,0x00,0x3E,0x42,0x42,0x3E,0x02,0x3C,  // g
            0x00,0x40,0x40,0x78,0x44,0x44,0x44,0x00,  // h
            0x00,0x08,0x00,0x18,0x08,0x08,0x1C,0x00,  // i
            0x00,0x04,0x00,0x04,0x04,0x04,0x24,0x18,  // j
            0x00,0x40,0x50,0x60,0x60,0x50,0x48,0x00,  // k
            0x00,0x10,0x10,0x10,0x10,0x10,0x0C,0x00,  // l
            0x00,0x00,0x68,0x54,0x54,0x54,0x54,0x00,  // m
            0x00,0x00,0x78,0x44,0x44,0x44,0x44,0x00,  // n
            0x00,0x00,0x38,0x44,0x44,0x44,0x38,0x00,  // o
            0x00,0x00,0x78,0x44,0x44,0x78,0x40,0x40,  // p
            0x00,0x00,0x3C,0x44,0x44,0x3C,0x04,0x06,  // q
            0x00,0x00,0x1C,0x20,0x20,0x20,0x20,0x00,  // r
            0x00,0x00,0x38,0x40,0x38,0x04,0x78,0x00,  // s
            0x00,0x10,0x38,0x10,0x10,0x10,0x0C,0x00,  // t
            0x00,0x00,0x44,0x44,0x44,0x44,0x38,0x00,  // u
            0x00,0x00,0x44,0x44,0x28,0x28,0x10,0x00,  // v
            0x00,0x00,0x44,0x54,0x54,0x54,0x28,0x00,  // w
            0x00,0x00,0x44,0x28,0x10,0x28,0x44,0x00,  // x
            0x00,0x00,0x44,0x44,0x44,0x3C,0x04,0x38,  // y
            0x00,0x00,0x7C,0x08,0x10,0x20,0x7C,0x00,  // z
            0x00,0x1C,0x10,0x60,0x10,0x10,0x1C,0x00,  // {
            0x00,0x10,0x10,0x10,0x10,0x10,0x10,0x00,  // |
            0x00,0x70,0x10,0x0C,0x10,0x10,0x70,0x00,  // }
            0x00,0x14,0x28,0x00,0x00,0x00,0x00,0x00,  // ~
        };
/*
        // http://www.rinkydinkelectronics.com/r_fonts.php
        // Sinclair_Inverted_S
        // Font type    : Full (95 characters)
        // Font size    : 8x8 pixels
        // Memory usage : 764 bytes
        public static readonly byte[] Sinclair_Inverted_S ={
            0x08,0x08,0x20,0x5F,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,  // <space>
            0x08,0x08,0x08,0x08,0x08,0x00,0x08,0x00,  // !
            0x14,0x14,0x00,0x00,0x00,0x00,0x00,0x00,  // "
            0x00,0x24,0x7E,0x24,0x24,0x7E,0x24,0x00,  // #
            0x10,0x7C,0x50,0x7C,0x14,0x7C,0x10,0x00,  // $
            0x00,0x62,0x64,0x08,0x10,0x26,0x46,0x00,  // %
            0x00,0x10,0x28,0x10,0x2A,0x44,0x3A,0x00,  // &
            0x00,0x08,0x10,0x00,0x00,0x00,0x00,0x00,  // '
            0x00,0x08,0x10,0x10,0x10,0x10,0x08,0x00,  // (
            0x00,0x10,0x08,0x08,0x08,0x08,0x10,0x00,  // )
            0x00,0x00,0x28,0x10,0x7C,0x10,0x28,0x00,  // *
            0x00,0x00,0x10,0x10,0x7C,0x10,0x10,0x00,  // +
            0x00,0x00,0x00,0x00,0x00,0x08,0x08,0x10,  // ,
            0x00,0x00,0x00,0x00,0x7C,0x00,0x00,0x00,  // -
            0x00,0x00,0x00,0x00,0x00,0x18,0x18,0x00,  // .
            0x00,0x00,0x04,0x08,0x10,0x20,0x40,0x00,  // /
            0x00,0x78,0x8C,0x94,0xA4,0xC4,0x78,0x00,  // 0
            0x00,0x60,0xA0,0x20,0x20,0x20,0xF8,0x00,  // 1
            0x00,0x78,0x84,0x04,0x78,0x80,0xFC,0x00,  // 2
            0x00,0x78,0x84,0x18,0x04,0x84,0x78,0x00,  // 3
            0x00,0x10,0x30,0x50,0x90,0xFC,0x10,0x00,  // 4
            0x00,0xFC,0x80,0xF8,0x04,0x84,0x78,0x00,  // 5
            0x00,0x78,0x80,0xF8,0x84,0x84,0x78,0x00,  // 6
            0x00,0xFC,0x04,0x08,0x10,0x20,0x20,0x00,  // 7
            0x00,0x78,0x84,0x78,0x84,0x84,0x78,0x00,  // 8
            0x00,0x78,0x84,0x84,0x7C,0x04,0x78,0x00,  // 9
            0x00,0x00,0x00,0x10,0x00,0x00,0x10,0x00,  // :
            0x00,0x00,0x10,0x00,0x00,0x10,0x10,0x20,  // ;
            0x00,0x00,0x08,0x10,0x20,0x10,0x08,0x00,  // <
            0x00,0x00,0x00,0x7C,0x00,0x7C,0x00,0x00,  // =
            0x00,0x00,0x20,0x10,0x08,0x10,0x20,0x00,  // >
            0x00,0x3C,0x42,0x04,0x08,0x00,0x08,0x00,  // ?
            0x00,0x3C,0x4A,0x56,0x5E,0x40,0x3C,0x00,  // @
            0x00,0x78,0x84,0x84,0xFC,0x84,0x84,0x00,  // A
            0x00,0xF8,0x84,0xF8,0x84,0x84,0xF8,0x00,  // B
            0x00,0x78,0x84,0x80,0x80,0x84,0x78,0x00,  // C
            0x00,0xF0,0x88,0x84,0x84,0x88,0xF0,0x00,  // D
            0x00,0xFC,0x80,0xF8,0x80,0x80,0xFC,0x00,  // E
            0x00,0xFC,0x80,0xF8,0x80,0x80,0x80,0x00,  // F
            0x00,0x78,0x84,0x80,0x9C,0x84,0x78,0x00,  // G
            0x00,0x84,0x84,0xFC,0x84,0x84,0x84,0x00,  // H
            0x00,0x7C,0x10,0x10,0x10,0x10,0x7C,0x00,  // I
            0x00,0x04,0x04,0x04,0x84,0x84,0x78,0x00,  // J
            0x00,0x88,0x90,0xE0,0x90,0x88,0x84,0x00,  // K
            0x00,0x80,0x80,0x80,0x80,0x80,0xFC,0x00,  // L
            0x00,0x84,0xCC,0xB4,0x84,0x84,0x84,0x00,  // M
            0x00,0x84,0xC4,0xA4,0x94,0x8C,0x84,0x00,  // N
            0x00,0x78,0x84,0x84,0x84,0x84,0x78,0x00,  // O
            0x00,0xF8,0x84,0x84,0xF8,0x80,0x80,0x00,  // P
            0x00,0x78,0x84,0x84,0xA4,0x94,0x78,0x00,  // Q
            0x00,0xF8,0x84,0x84,0xF8,0x88,0x84,0x00,  // R
            0x00,0x78,0x80,0x78,0x04,0x84,0x78,0x00,  // S
            0x00,0xFE,0x10,0x10,0x10,0x10,0x10,0x00,  // T
            0x00,0x84,0x84,0x84,0x84,0x84,0x78,0x00,  // U
            0x00,0x84,0x84,0x84,0x84,0x48,0x30,0x00,  // V
            0x00,0x84,0x84,0x84,0x84,0xB4,0x48,0x00,  // W
            0x00,0x84,0x48,0x30,0x30,0x48,0x84,0x00,  // X
            0x00,0x82,0x44,0x28,0x10,0x10,0x10,0x00,  // Y
            0x00,0xFC,0x08,0x10,0x20,0x40,0xFC,0x00,  // Z
            0x00,0x38,0x20,0x20,0x20,0x20,0x38,0x00,  // [
            0x00,0x00,0x40,0x20,0x10,0x08,0x04,0x00,  // <backslash>
            0x00,0x38,0x08,0x08,0x08,0x08,0x38,0x00,  // ]
            0x00,0x10,0x38,0x54,0x10,0x10,0x10,0x00,  // ^
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFE,  // _
            0x3C,0x42,0x99,0xA1,0xA1,0x99,0x42,0x3C,  // `
            0xFF,0x87,0x7B,0x7B,0x03,0x7B,0x7B,0xFF,  // a
            0xFF,0x07,0x7B,0x07,0x7B,0x7B,0x07,0xFF,  // b
            0xFF,0x87,0x7B,0x7F,0x7F,0x7B,0x87,0xFF,  // c
            0xFF,0x0F,0x77,0x7B,0x7B,0x77,0x0F,0xFF,  // d
            0xFF,0x03,0x7F,0x07,0x7F,0x7F,0x03,0xFF,  // e
            0xFF,0x03,0x7F,0x07,0x7F,0x7F,0x7F,0xFF,  // f
            0xFF,0x87,0x7B,0x7F,0x63,0x7B,0x87,0xFF,  // g
            0xFF,0x7B,0x7B,0x03,0x7B,0x7B,0x7B,0xFF,  // h
            0xFF,0x83,0xEF,0xEF,0xEF,0xEF,0x83,0xFF,  // i
            0xFF,0xFB,0xFB,0xFB,0x7B,0x7B,0x87,0xFF,  // j
            0xFF,0x77,0x6F,0x1F,0x6F,0x77,0x7B,0xFF,  // k
            0xFF,0x7F,0x7F,0x7F,0x7F,0x7F,0x03,0xFF,  // l
            0xFF,0x7B,0x33,0x4B,0x7B,0x7B,0x7B,0xFF,  // m
            0xFF,0x7B,0x3B,0x5B,0x6B,0x73,0x7B,0xFF,  // n
            0xFF,0x87,0x7B,0x7B,0x7B,0x7B,0x87,0xFF,  // o
            0xFF,0x07,0x7B,0x7B,0x07,0x7F,0x7F,0xFF,  // p
            0xFF,0x87,0x7B,0x7B,0x5B,0x6B,0x87,0xFF,  // q
            0xFF,0x07,0x7B,0x7B,0x07,0x77,0x7B,0xFF,  // r
            0xFF,0x87,0x7F,0x87,0xFB,0x7B,0x87,0xFF,  // s
            0xFF,0x01,0xEF,0xEF,0xEF,0xEF,0xEF,0xFF,  // t
            0xFF,0x7B,0x7B,0x7B,0x7B,0x7B,0x87,0xFF,  // u
            0xFF,0x7B,0x7B,0x7B,0x7B,0xB7,0xCF,0xFF,  // v
            0xFF,0x7B,0x7B,0x7B,0x7B,0x4B,0xB7,0xFF,  // w
            0xFF,0x7B,0xB7,0xCF,0xCF,0xB7,0x7B,0xFF,  // x
            0xFF,0x7D,0xBB,0xD7,0xEF,0xEF,0xEF,0xFF,  // y
            0xFF,0x03,0xF7,0xEF,0xDF,0xBF,0x03,0xFF,  // z
            0x00,0x1C,0x10,0x60,0x10,0x10,0x1C,0x00,  // {
            0x00,0x10,0x10,0x10,0x10,0x10,0x10,0x00,  // |
            0x00,0x70,0x10,0x0C,0x10,0x10,0x70,0x00,  // }
            0x00,0x14,0x28,0x00,0x00,0x00,0x00,0x00,  // ~
        };
*/
        /// <summary>
        /// 0x[Top][Right][Bottom][Left]
        /// </summary>
        private int[] _FontPaddings = new int[95];

        public int[] FontPaddings {
            get
            {
                return _FontPaddings;
            }
        }

        public bool isFarsi {
            get
            {
                return CurrentFont == FarsiFont;
            }
        }

        public int GetTop(int padding)
        {
            return (padding >> 12) & 0xF;
        }

        public int SetTop(int padding, int value)
        {
            return (value << 12) + (padding & (0x0FFF));
        }

        public int GetRight(int padding)
        {
            return (padding >> 8) &0xF;
        }

        public int setRight(int padding, int value)
        {
            return (value << 8) + (padding & (0xF0FF));
        }

        public int GetBottom(int padding)
        {
            return (padding >> 4) &0xF;
        }

        public int SetBottom(int padding, int value)
        {
            return (value << 4) + (padding & (0xFF0F));
        }

        public int GetLeft(int padding)
        {
            return padding &0xF;
        }

        public int SetLeft(int padding, int value)
        {
            return value + (padding & (0xFFF0));
        }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeFont()
        {
            int index = 4;
            for (byte i = 0; i < 95; i++, index += 8)
            {
                int fp = _FontPaddings[i];

                if (i == 0)
                {
                    if (isFarsi)
                    {
                        _FontPaddings[i] = 0x0403;
                    }
                    else
                    {
                        _FontPaddings[i] = 0x0303;
                    }
                    continue;
                }

                fp = 0x08888;

                // for top left
                for (byte row = 0; row < 8; row++)
                {
                    byte b = CurrentFont[index++];
                    byte bitMask = 0x80;

                    for (byte bit = 0; bit < 8; bit++)
                    {
                        if ((b & bitMask) != 0)
                        {
                            if (GetTop(fp) > row)
                            {
                                fp = SetTop(fp, row);
                            }

                            if (GetLeft(fp) > bit)
                            {
                                fp = SetLeft(fp, bit);
                            }
                        }

                        bitMask >>= 1;
                    }
                }

                // for bottom right
                for (byte row = 0; row < 8; row++)
                {
                    byte b = CurrentFont[--index];
                    byte bitMask = 0x01;

                    for (byte bit = 0; bit < 8; bit++)
                    {
                        if ((b & bitMask) != 0)
                        {
                            if (GetBottom(fp) > row)
                            {
                                fp = SetBottom(fp, row);
                            }

                            if (GetRight(fp) > bit)
                            {
                                fp = setRight(fp, bit);
                            }
                        }

                        bitMask <<= 1;
                    }
                }

                _FontPaddings[i] = fp;
                //Debug.Print(i.ToString("D3") + ": " + fp.ToString("X4") + ": " + (char)(' ' + i));
            }
        }

        public void SelectFont(Fonts aFont)
        {
            switch (aFont)
            {
                case Fonts.Farsi:
                    CurrentFont = FarsiFont;
                    break;

                default:
                    CurrentFont = Sinclair_S;
                    break;
            }

            InitializeFont();
        }
    }
}