using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    class XM_ExeSysCmd_Util : XM_ExeCmd
    {
        private char[] DelimiterChars = { ' ', ',', '\t' };
        enum CmdType { Read, Write, WrAndRd }
        public bool bPauseCmd = false, bScopeCmd = false, bGammaCmd = false;
        public bool ExcuteCmd(string SystemCmd, byte ElecsType, byte XmCategory, ref string RdStr)
        {
            if (RunInfo.FoundLoopList.Count > 0) { RunInfo.XmCmdInfo.Excute = false; return false; }
            if (RunInfo.RunLoop == null && RunInfo.RunLoopList.Count > 0) { RunInfo.XmCmdInfo.Excute = false; return false; };
            string[] XmCmd = (string[])MergeXMCmds(SystemCmd.Trim()).ToArray(typeof(string));
            string[] XmPlusData = ExchangeXmData(RunInfo.RunLoopList, XmCmd, RunInfo.XmCmdInfo, XmCategory);

            if (ElecsType == (byte)CmdType.Write)
            {
                if (XM_Cmd_Lib.xmd[37] == XmCmd[0]) { bScopeCmd = true; }
                if (XM_Cmd_Lib.xmd[39] == XmCmd[0]) { bGammaCmd = true; }
                if (XM_Cmd_Lib.xmd[40] == XmCmd[0]) { bPauseCmd = true; }
                if (XM_Cmd_Lib.xmd[41] == XmCmd[0]) { RdStr = XmWrTxtStr(XmPlusData); }
                if (XM_Cmd_Lib.xmd[42] == XmCmd[0]) { RdStr = SystemLoad(SystemCmd); }
                if (XM_Cmd_Lib.xmd[25] == XmCmd[0]) { RdStr = XMImgOutTxt(XmPlusData); }
                if (XM_Cmd_Lib.xmd[111] == XmCmd[0]) { RdStr = InfoMsg(SystemCmd); }
            }
            else
            {
                if (XmCmd[0] == XM_Cmd_Lib.xmd[34]) { RdStr = SystemInfo(); }
            }
            return true;
        }

        private string XMImgOutTxt(string[] XmPlusData)
        {
            string Msg = null , StrWrNum = "0", StrPageMode ="0";
            int WrNum = 0,PageMode = 0;
            XM_IO_Util IOUtil = new XM_IO_Util();
            XM_Img_Lib ImgLib = new XM_Img_Lib();
            string Path = System.IO.Path.Combine(Setting.ExeLogDirPath, XmPlusData[XmPlusData.Length-1]);
            if (!ImgLib.IsFileExist(XmPlusData[0])) Msg = "File Not Exist";
            if (XmPlusData.Length > 2) StrWrNum = XmPlusData[1];
            if (XmPlusData.Length > 3) StrPageMode = XmPlusData[2];
            WrNum = int.TryParse(StrWrNum, out WrNum) ? WrNum : 0;
            PageMode = int.TryParse(StrPageMode, out PageMode) ? PageMode : 0;
            List<byte> ImgList = ImgLib.ArrayWithBmp(PageMode);
            IOUtil.WriteByteToTxt(Path, ImgList, ImgLib.GetWidth(), WrNum, true);
            return Msg;
        }


        private string XmWrTxtStr(string[] XmPlusData)
        {
            XM_IFSpt_Util ScriptUtil = new XM_IFSpt_Util();
            string FilePath = Setting.ExeLogDirPath + "\\" + XmPlusData[1];
            string Message = ScriptUtil.ReplaceStr(XmPlusData[0]); ;
            using (StreamWriter sw = File.AppendText(FilePath))
            {
                sw.Write(Message);
            }
            return null;
        }

        private string InfoMsg(string SystemCmd)
        {
            string[] Parameter = SystemCmd.Split(DelimiterChars);
            return Parameter[1];
        }


        private string SystemLoad(string SystemCmd)
        {
            string Msg = null;
            string[] Parameter = SystemCmd.Split(DelimiterChars);
            if (Parameter.Length == 2) ExeScriptFile(Parameter[1], ref Msg);
            return Msg;
        }

        private string SystemInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.ProductVersion;
        }

        public bool ExeScriptFile(string FileName, ref string RdStr)
        {
            return true;
        }
    }
}
