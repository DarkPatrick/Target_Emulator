using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TarEmu3
{
    [StructLayout(LayoutKind.Explicit)]
    public struct ByteArray
    {
        [FieldOffset(0)]
        public byte Byte0;
        [FieldOffset(1)]
        public byte Byte1;
        [FieldOffset(2)]
        public byte Byte2;
        [FieldOffset(3)]
        public byte Byte3;
        [FieldOffset(4)]
        public byte Byte4;
        [FieldOffset(5)]
        public byte Byte5;
        [FieldOffset(6)]
        public byte Byte6;
        [FieldOffset(7)]
        public byte Byte7;
        [FieldOffset(0)]
        public bool Bool;
        [FieldOffset(0)]
        public sbyte SByte;
        [FieldOffset(0)]
        public byte Byte;
        [FieldOffset(0)]
        public Int16 Int_16;
        [FieldOffset(0)]
        public UInt16 UInt_16;
        [FieldOffset(0)]
        public Int32 Int_32;
        [FieldOffset(0)]
        public UInt32 UInt_32;
        [FieldOffset(0)]
        public Int64 Int_64;
        [FieldOffset(0)]
        public UInt64 UInt_64;
        [FieldOffset(0)]
        public float Float;
        [FieldOffset(0)]
        public double Double;
    }
    public static class DataProtocols
    {
        public static string Display(byte[] str, string type)
        {
            ByteArray byte_array;

            byte_array.Bool = false;
            byte_array.SByte = 0;
            byte_array.Byte = 0;
            byte_array.Int_16 = 0;
            byte_array.UInt_16 = 0;
            byte_array.Int_32 = 0;
            byte_array.UInt_32 = 0;
            byte_array.Int_64 = 0;
            byte_array.UInt_64 = 0;
            byte_array.Float = 0;
            byte_array.Double = 0;

            switch (type.ToLower())
            {
                case "bool":
                case "byte":
                case "sbyte":
                    byte_array.Byte0 = str[0];
                    break;
                case "int16":
                case "uint16":
                    byte_array.Byte0 = str[0];
                    byte_array.Byte1 = str[1];
                    break;
                case "int32":
                case "uint32":
                case "float":
                    byte_array.Byte0 = str[0];
                    byte_array.Byte1 = str[1];
                    byte_array.Byte2 = str[2];
                    byte_array.Byte3 = str[3];
                    break;
                case "int64":
                case "uint64":
                case "double":
                    byte_array.Byte0 = str[0];
                    byte_array.Byte1 = str[1];
                    byte_array.Byte2 = str[2];
                    byte_array.Byte3 = str[3];
                    byte_array.Byte4 = str[4];
                    byte_array.Byte5 = str[5];
                    byte_array.Byte6 = str[6];
                    byte_array.Byte7 = str[7];
                    break;
                default:
                    break;
            }

            string str_res = "";

            switch (type.ToLower())
            {
                case "bool":
                    str_res = byte_array.Bool.ToString();
                    break;
                case "byte":
                    str_res = byte_array.Byte.ToString();
                    break;
                case "sbyte":
                    str_res = byte_array.SByte.ToString();
                    break;
                case "int16":
                    str_res = byte_array.Int_16.ToString();
                    break;
                case "uint16":
                    str_res = byte_array.UInt_16.ToString();
                    break;
                case "int32":
                    str_res = byte_array.Int_32.ToString();
                    break;
                case "uint32":
                    str_res = byte_array.UInt_32.ToString();
                    break;
                case "float":
                    str_res = byte_array.Float.ToString();
                    break;
                case "int64":
                    str_res = byte_array.Int_64.ToString();
                    break;
                case "uint64":
                    str_res = byte_array.UInt_64.ToString();
                    break;
                case "double":
                    str_res = byte_array.Double.ToString();
                    break;
                default:
                    str_res = "";
                    break;
            }

            return str_res;
        }


        public static void ConverNumToBytes(string val, string type, ref byte[] res_bytes)
        {
            ByteArray byte_array;

            byte_array.Byte0 = 0;
            byte_array.Byte1 = 0;
            byte_array.Byte2 = 0;
            byte_array.Byte3 = 0;
            byte_array.Byte4 = 0;
            byte_array.Byte5 = 0;
            byte_array.Byte6 = 0;
            byte_array.Byte7 = 0;
            byte_array.Bool = false;
            byte_array.SByte = 0;
            byte_array.Byte = 0;
            byte_array.Int_16 = 0;
            byte_array.UInt_16 = 0;
            byte_array.Int_32 = 0;
            byte_array.UInt_32 = 0;
            byte_array.Int_64 = 0;
            byte_array.UInt_64 = 0;
            byte_array.Float = 0;
            byte_array.Double = 0;

            switch (type.ToLower())
            {
                case "bool":
                    bool.TryParse(val, out byte_array.Bool);
                    res_bytes[0] = byte_array.Byte0;
                    break;
                case "byte":
                    byte.TryParse(val, out byte_array.Byte);
                    res_bytes[0] = byte_array.Byte0;
                    break;
                case "sbyte":
                    sbyte.TryParse(val, out byte_array.SByte);
                    res_bytes[0] = byte_array.Byte0;
                    break;
                case "int16":
                    Int16.TryParse(val, out byte_array.Int_16);
                    res_bytes[0] = byte_array.Byte0;
                    res_bytes[1] = byte_array.Byte1;
                    break;
                case "uint16":
                    UInt16.TryParse(val, out byte_array.UInt_16);
                    res_bytes[0] = byte_array.Byte0;
                    res_bytes[1] = byte_array.Byte1;
                    break;
                case "int32":
                    Int32.TryParse(val, out byte_array.Int_32);
                    res_bytes[0] = byte_array.Byte0;
                    res_bytes[1] = byte_array.Byte1;
                    res_bytes[2] = byte_array.Byte2;
                    res_bytes[3] = byte_array.Byte3;
                    break;
                case "uint32":
                    UInt32.TryParse(val, out byte_array.UInt_32);
                    res_bytes[0] = byte_array.Byte0;
                    res_bytes[1] = byte_array.Byte1;
                    res_bytes[2] = byte_array.Byte2;
                    res_bytes[3] = byte_array.Byte3;
                    break;
                case "int64":
                    Int64.TryParse(val, out byte_array.Int_64);
                    res_bytes[0] = byte_array.Byte0;
                    res_bytes[1] = byte_array.Byte1;
                    res_bytes[2] = byte_array.Byte2;
                    res_bytes[3] = byte_array.Byte3;
                    res_bytes[4] = byte_array.Byte4;
                    res_bytes[5] = byte_array.Byte5;
                    res_bytes[6] = byte_array.Byte6;
                    res_bytes[7] = byte_array.Byte7;
                    break;
                case "uint64":
                    UInt64.TryParse(val, out byte_array.UInt_64);
                    res_bytes[0] = byte_array.Byte0;
                    res_bytes[1] = byte_array.Byte1;
                    res_bytes[2] = byte_array.Byte2;
                    res_bytes[3] = byte_array.Byte3;
                    res_bytes[4] = byte_array.Byte4;
                    res_bytes[5] = byte_array.Byte5;
                    res_bytes[6] = byte_array.Byte6;
                    res_bytes[7] = byte_array.Byte7;
                    break;
                case "float":
                    float.TryParse(val, out byte_array.Float);
                    res_bytes[0] = byte_array.Byte0;
                    res_bytes[1] = byte_array.Byte1;
                    res_bytes[2] = byte_array.Byte2;
                    res_bytes[3] = byte_array.Byte3;
                    break;
                case "double":
                    double.TryParse(val, out byte_array.Double);
                    res_bytes[0] = byte_array.Byte0;
                    res_bytes[1] = byte_array.Byte1;
                    res_bytes[2] = byte_array.Byte2;
                    res_bytes[3] = byte_array.Byte3;
                    res_bytes[4] = byte_array.Byte4;
                    res_bytes[5] = byte_array.Byte5;
                    res_bytes[6] = byte_array.Byte6;
                    res_bytes[7] = byte_array.Byte7;
                    break;
                default:
                    break;
            }
        }
    }
}
