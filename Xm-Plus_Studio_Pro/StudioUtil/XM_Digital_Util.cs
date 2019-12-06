using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace XM_Tek_Studio_Pro.StudioUtil
{

    class XM_Digital_Util
    {
        private const byte ASCII_0 = 0x30;
        private const byte ASCII_9 = 0x39;
        private const byte ASCII_x = 0x78;
        private const byte ASCII_a = 0x61;
        private const byte ASCII_f = 0x66;
        private string LienChars = "\r\n";
        private string STRHEX = "0x";
        private int HexVal = 0;
        private bool bHex = false;
        /*Determine the value of the size*/
        public bool BoolWithinRange(uint Value, uint Low, uint High)
        {
            if (Low <= Value && Value <= High)
                return true;
            else
                return false;
        }
        /*Determine the value of the size*/
        public bool BoolWithinRange(int Value, int Low, int High)
        {
            if (Low <= Value && Value <= High)
                return true;
            else
                return false;
        }
        /*Determine the value of the size*/
        public bool BoolWithinRange(float Value, float Low, float High)
        {
            bool ret = false;
            if (Value > 0 & (Low <= Value && Value <= High))
                ret = true;
            if (Value < 0 & (Low <= Math.Abs(Value) && Math.Abs(Value) <= High))
                ret = true;
            return ret;
        }
        public class CompareGeneric<T> where T : IComparable
        {
            public static void Compare(T Value, T Low, T High)
            {
                if (Value.CompareTo(0) > 0 & Value.CompareTo(Low) >= 0 & High.CompareTo(Value) >= 0)
                {
                    return;
                }
                else
                {
                    //Math.
                    if (Value.CompareTo(0) < 0)
                    {
                        if (High.CompareTo(Value) > 0)
                        {
                            return;
                        }
                    }


                }
            }
        }
        public bool BoolWithinRange<T>(T Value, T Low, T High)
        {
            return false;
        }
        public bool BoolInnerRange(uint Value, double Low, double High)
        {
            if (Low <= Value && Value < High)
                return true;
            else
                return false;
        }
        /*Determine the value of the size*/
        public bool BoolInnerRange(uint Value, uint Low, uint High)
        {
            if (Low <= Value && Value < High)
                return true;
            else
                return false;
        }
        /*Determine the value of the size and string to the number*/
        public bool ValidStrandRange(string strval, int Low, int Max, ref float Value)
        {
            bool ret = false;
            if (StrToNumber<float>(strval, ref Value) && BoolWithinRange(Value, Low, Max))
                ret = true;
            return ret;
        }
        /*Determine the value of the size and string to the number*/
        public bool ValidStrandRange(string strval, int Low, int Max, ref int Value)
        {
            int Val = 0;
            bool ret = false;
            if (StrToNumber<int>(strval, ref Val) && BoolWithinRange(Val, Low, Max))
                ret = true;
            return ret;
        }
        public bool ValidStrandRange<T>(string strval, int Low, int Max, ref T Value)
        {
            bool ret = false;
            return ret;
        }
        public bool VerifyStrLength(string strval)
        {
            string str = (bHex) ? STRHEX + HexVal.ToString("X2") : HexVal.ToString();
            if (strval.CompareTo(str) == 0) return true;
            return false;
        }
        public bool VerifyNum<T>(string strval)
        {
            foreach (char str in strval)
            {
                if ((str >= ASCII_a && str <= ASCII_f))
                    return false;
            }
            return true;
        }
        public bool StrToNumber<T>(string strval, ref T Value)
        {
            bool ret = true;
            if (strval.Length == 0) return false;
            if (Regex.IsMatch(strval, @"(\b0x[A-Fa-f0-9]+\b)"))
            {
                string target = strval.Substring(2).ToLower();
                ret = int.TryParse(target, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int value);
                if (ret)
                {
                    try
                    {
                        Value = (T)Convert.ChangeType(value, typeof(T));
                        ret = true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                }
                else
                    ret = false;
            }
            else
            {
                if (VerifyNum<T>(strval))
                {
                    try
                    {
                        Value = (T)Convert.ChangeType(strval, typeof(T)); ret = true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
                else ret = false;
            }
            return ret;
        }
        public bool WriteByteToTxt(string FilePath, byte[] Data, bool delFile)
        {
            string Msg = null, TxtFilePath = FilePath;
            if (delFile) new XM_IO_Util().FileDelete(TxtFilePath);
            FileStream fs = new FileStream(TxtFilePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            for (int i = 0; i < Data.Length; i++)
            {
                if (i != 0 && i % 16 == 0)
                {
                    sw.WriteLine(Msg);
                    Msg = null;
                }
                Msg += STRHEX + Data[i].ToString("X2");
                if (i % 16 != 15) Msg += ",\t";
            }
            sw.Write(Msg + LienChars + LienChars);
            sw.Close();
            return true;
        }

    }
}
