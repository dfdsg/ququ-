#define VISASUPPORT  
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
/*****************************
 * INI Function
 *****************************/

namespace XM_Tek_Studio_Pro.StudioUtil
{
    class XM_Ini_Util
    {
        private string _filepath;
        public XM_Ini_Util() { }   
        public XM_Ini_Util(string filepath)
        {
            _filepath = filepath;
        }

        public string Filepath
        {
            get
            {
                return _filepath;
            }
            set
            {
                _filepath = value;
            }
        }

        public void CopyIniToDst()
        {
#if (VISASUPPORT)
            FileInfo file = new FileInfo(_filepath);
            string context = Properties.Resources.Default_Config_V01;
            StreamWriter sw = file.CreateText();
            sw.Write(context);
            sw.Close();
#endif
        }


        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, _filepath);
        }

        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(8192);
            GetPrivateProfileString(Section, Key, "", temp, 8192, _filepath);
            return temp.ToString();
        }

        public string GetFileName() { return Path.GetFileName(Filepath); }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
    }

    internal sealed partial class FpgaParm
    {
        internal const string FPAGSEC= "FPGA";
        internal const string HSYNCKEY = "HSync";
        internal const string VSYNCKEY = "VSync";
        internal const string VBPKEY = "VBP";
        internal const string VFPKEY = "VFP";
        internal const string HBPKEY = "HBP";
        internal const string HFPKEY = "HFP";
        internal const string COLORMODEKEY = "ColorMode";
        internal const string MHZPCLKKEY = "MhzPCLK";
        internal const string HACTIVEKEY = "HActive";
        internal const string VACTIVEKEY = "VActive";
        internal const string LPFREQKEY = "LPFreq";
        internal const string HSFREQKEY = "HSFreq";
        internal const string FRAMERATEKEY = "FrameRate";
        internal const string MINHSCLKKEY = "MinHsClk";
        internal const string DTMODEKEY = "DTMode";
        internal const string LANECNTKEY = "LaneCnt";
        internal const string BURSTMODEKEY = "BurstMode";
        internal const string SVNCMODEKEY = "SvncMode";
    }
}
