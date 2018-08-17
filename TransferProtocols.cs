using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarEmu3
{
    public static class TransferProtocols
    {
        public enum CODE_TYPE {ENCODE, DDECODE};
        public enum SLIP_BYTES {END = 0xC0, ESC = 0xDB, ESC_END = 0xDC , ESC_ESC = 0xDD};

        public static int Slip(ref byte[] old_arr, ref byte[] new_arr, int old_buf_size, CODE_TYPE code_type)
        {
            var new_len = old_buf_size;
            var full_pack = false;

            if (code_type == CODE_TYPE.ENCODE)
            {
                for (var i = 0; i < old_buf_size; ++i)
                {
                    if ((old_arr[i] == (byte)(SLIP_BYTES.END)) || (old_arr[i] == (byte)(SLIP_BYTES.ESC)))
                    {
                        new_len++;
                    }
                }
                new_len++;
                full_pack = true;
            }
            else
            {
                for (var i = 0; i < old_buf_size - 1; ++i)
                {
                    if (((old_arr[i] == (byte)(SLIP_BYTES.ESC)) && (old_arr[i + 1] == (byte)(SLIP_BYTES.ESC_END))) || ((old_arr[i] == (byte)(SLIP_BYTES.ESC)) && (old_arr[i + 1] == (byte)(SLIP_BYTES.ESC_ESC))))
                    {
                        new_len--;
                    }
                    if (old_arr[i] == (byte)(SLIP_BYTES.END))
                    {
                        full_pack = true;
                        new_len--;
                        break;
                    }
                }
                if ((!full_pack) && (old_arr[old_buf_size - 1] == (byte)(SLIP_BYTES.END)))
                {
                    full_pack = true;
                    new_len--;
                }

                if (!full_pack)
                {
                    return 0;
                }
            }

            //byte[] new_arr = new byte[new_len];
            //Array.Resize<byte>(ref new_arr, new_len);
            new_len = 0;

            if (code_type == CODE_TYPE.ENCODE)
            {
                for (var i = 0; i < old_buf_size; ++i)
                {
                    if (old_arr[i] == (byte)(SLIP_BYTES.END))
                    {
                        new_arr[new_len] = (byte)(SLIP_BYTES.ESC);
                        new_arr[new_len + 1] = (byte)(SLIP_BYTES.ESC_END);
                        new_len += 2;
                    }
                    else if (old_arr[i] == (byte)(SLIP_BYTES.ESC))
                    {
                        new_arr[new_len] = (byte)(SLIP_BYTES.ESC);
                        new_arr[new_len + 1] = (byte)(SLIP_BYTES.ESC_ESC);
                        new_len += 2;
                    }
                    else
                    {
                        new_arr[new_len] = old_arr[i];
                        new_len += 1;
                    }
                }
                new_arr[new_len] = (byte)(SLIP_BYTES.END);
                new_len++;
            }
            else
            {
                var i = 0;
                while (old_arr[i] != (byte)(SLIP_BYTES.END))
                {
                    if ((i < old_buf_size - 1) && (old_arr[i] == (byte)(SLIP_BYTES.ESC)) && (old_arr[i + 1] == (byte)(SLIP_BYTES.ESC_END)))
                    {
                        new_arr[new_len] = (byte)SLIP_BYTES.END;
                        i += 2;
                    } else if ((i < old_buf_size - 1) && (old_arr[i] == (byte)(SLIP_BYTES.ESC)) && (old_arr[i + 1] == (byte)(SLIP_BYTES.ESC_ESC)))
                    {
                        new_arr[new_len] = (byte)SLIP_BYTES.ESC;
                        i += 2;
                    } else
                    {
                        new_arr[new_len] = old_arr[i];
                        i++;
                    }
                    new_len++;
                }
            }

            return new_len;
        }


        public static int CRC8(ref byte[] arr, int len, CODE_TYPE code_type)
        {
            byte[] crc_table = new byte[256] {
                0x00, 0x07, 0x0E, 0x09, 0x1C, 0x1B, 0x12, 0x15,
                0x38, 0x3F, 0x36, 0x31, 0x24, 0x23, 0x2A, 0x2D,
                0x70, 0x77, 0x7E, 0x79, 0x6C, 0x6B, 0x62, 0x65,
                0x48, 0x4F, 0x46, 0x41, 0x54, 0x53, 0x5A, 0x5D,
                0xE0, 0xE7, 0xEE, 0xE9, 0xFC, 0xFB, 0xF2, 0xF5,
                0xD8, 0xDF, 0xD6, 0xD1, 0xC4, 0xC3, 0xCA, 0xCD,
                0x90, 0x97, 0x9E, 0x99, 0x8C, 0x8B, 0x82, 0x85,
                0xA8, 0xAF, 0xA6, 0xA1, 0xB4, 0xB3, 0xBA, 0xBD,
                0xC7, 0xC0, 0xC9, 0xCE, 0xDB, 0xDC, 0xD5, 0xD2,
                0xFF, 0xF8, 0xF1, 0xF6, 0xE3, 0xE4, 0xED, 0xEA,
                0xB7, 0xB0, 0xB9, 0xBE, 0xAB, 0xAC, 0xA5, 0xA2,
                0x8F, 0x88, 0x81, 0x86, 0x93, 0x94, 0x9D, 0x9A,
                0x27, 0x20, 0x29, 0x2E, 0x3B, 0x3C, 0x35, 0x32,
                0x1F, 0x18, 0x11, 0x16, 0x03, 0x04, 0x0D, 0x0A,
                0x57, 0x50, 0x59, 0x5E, 0x4B, 0x4C, 0x45, 0x42,
                0x6F, 0x68, 0x61, 0x66, 0x73, 0x74, 0x7D, 0x7A,
                0x89, 0x8E, 0x87, 0x80, 0x95, 0x92, 0x9B, 0x9C,
                0xB1, 0xB6, 0xBF, 0xB8, 0xAD, 0xAA, 0xA3, 0xA4,
                0xF9, 0xFE, 0xF7, 0xF0, 0xE5, 0xE2, 0xEB, 0xEC,
                0xC1, 0xC6, 0xCF, 0xC8, 0xDD, 0xDA, 0xD3, 0xD4,
                0x69, 0x6E, 0x67, 0x60, 0x75, 0x72, 0x7B, 0x7C,
                0x51, 0x56, 0x5F, 0x58, 0x4D, 0x4A, 0x43, 0x44,
                0x19, 0x1E, 0x17, 0x10, 0x05, 0x02, 0x0B, 0x0C,
                0x21, 0x26, 0x2F, 0x28, 0x3D, 0x3A, 0x33, 0x34,
                0x4E, 0x49, 0x40, 0x47, 0x52, 0x55, 0x5C, 0x5B,
                0x76, 0x71, 0x78, 0x7F, 0x6A, 0x6D, 0x64, 0x63,
                0x3E, 0x39, 0x30, 0x37, 0x22, 0x25, 0x2C, 0x2B,
                0x06, 0x01, 0x08, 0x0F, 0x1A, 0x1D, 0x14, 0x13,
                0xAE, 0xA9, 0xA0, 0xA7, 0xB2, 0xB5, 0xBC, 0xBB,
                0x96, 0x91, 0x98, 0x9F, 0x8A, 0x8D, 0x84, 0x83,
                0xDE, 0xD9, 0xD0, 0xD7, 0xC2, 0xC5, 0xCC, 0xCB,
                0xE6, 0xE1, 0xE8, 0xEF, 0xFA, 0xFD, 0xF4, 0xF3
            };

            byte crc = 0;

            for (var i = 0; i < len - 1; ++i)
            {
                crc = crc_table[crc ^ arr[i]];
            }

            if (code_type == CODE_TYPE.ENCODE)
            {
                crc = crc_table[crc ^ arr[len -1]];
                arr[len] = crc;
            }
            else if (crc != arr[len - 1])
            {
                return 0;
            }

            return 1;
        }
    }
}
