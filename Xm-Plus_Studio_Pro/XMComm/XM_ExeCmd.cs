using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    class XM_ExeCmd
    {
        private string Reg = "reg";
        private char[] DelimiterChars = { ' ', '\t' };
        private const int CATEGORY_REG = 8;
        public ExeInfo RunInfo = null;
        public bool SetRunInfo(ExeInfo ExeRunInfo) { this.RunInfo = ExeRunInfo; return true; }

        public string CombineIndex()
        {
            string CombineStr = null;
            for (int i = 0; i < RunInfo.RunLoopList.Count; i++)
            {
                CombineStr += RunInfo.RunLoopList[i].Index.ToString();
            }
            return CombineStr;
        }

        public string[] ExchangeXmData(List<LoopLib> RunLoopList, string[] XmCmd, XmCmdInfo XmCmdInfo, int XmCategory)
        {

            string Cmd = XmCmd[0];
            string[] XmPlusData = new string[XmCmd.Length - 1];
            Array.Copy(XmCmd, 1, XmPlusData, 0, XmPlusData.Length);
            if (XmCategory == 10 || XmCategory == 1 || XmCategory == 11)
            {
                XmPlusData = ReplaceReg(RunLoopList, XmPlusData);
                MergeCommand(XmCmdInfo, XmCmd[0], XmPlusData);
            }
            else
            {
                foreach (string str in XmPlusData) Cmd += " " + str;
                XmCmdInfo.Excute = true;
                XmCmdInfo.XmCmd = Cmd;
            }
            return XmPlusData;
        }

        public void MergeCommand(XmCmdInfo XmCmdInfo, string XmCmd, string[] XmPlusCmd)
        {
            string Cmd = XmCmd;
            foreach (string str in XmPlusCmd) Cmd += " " + str;
            XmCmdInfo.Excute = true;
            XmCmdInfo.XmCmd = Cmd;
        }

        public void SaveMsgToFile(string FileName,string SplitStr, string Msg)
        {
            string FilePath = Setting.ExeLogDirPath + "\\" + FileName;
            string Message = string.Concat(Msg, SplitStr);
            using (StreamWriter sw = File.AppendText(FilePath))
            {
                sw.Write(Message);
            }
        }

        public void SaveMsgToFile(string FileName, string Msg)
        {
            string FilePath = Setting.ExeLogDirPath + "\\" + FileName;
            using (StreamWriter sw = File.AppendText(FilePath))
                sw.Write(Msg);
        }

        public void SaveKleinMsgToFile(string FileName, string Msg)
        {

            string FilePath = Setting.ExeLogDirPath + "\\" + FileName;
            using (StreamWriter sw = File.AppendText(FilePath))
            {
                sw.Write(Msg);
            }
        }

        public void SaveKonicaMsgToFile(string FileName, string LineStr, string Msg)
        {
            string FilePath = Setting.ExeLogDirPath + "\\" + FileName;
            string Pat = @"OK\d+,P\d+\s*(\d+);(\d+);\s*(\S+)", SaveMsg = null;
            Regex r = new Regex(Pat, RegexOptions.IgnoreCase);
            Match m = r.Match(Msg);
            if (m.Success)
            {

                SaveMsg = string.Format("0.{0}", m.Groups[1].ToString());
                SaveMsg += string.Format(" 0.{0}", m.Groups[2].ToString());
                SaveMsg += string.Format(" {0}", m.Groups[3].ToString());
                SaveMsg += LineStr;

            }
            using (StreamWriter sw = File.AppendText(FilePath))
            {
                sw.Write(SaveMsg);
            }
        }

        public ArrayList MergeXMCmds(string Command)
        {
            ArrayList eCmdList = new ArrayList();
            string[] SplitStr = Command.Split(DelimiterChars);
            foreach (string CmdStr in SplitStr)
            {
                if (!string.IsNullOrEmpty(CmdStr))
                    eCmdList.Add(CmdStr);
            }
            return eCmdList;
        }

        private string[] ReplaceReg(List<LoopLib> LoopList, string[] XmData)
        {
            string[] XmPlusData = new string[XmData.Length];
            int Value = 0;
            XM_Digital_Util NumUtil = new XM_Digital_Util();

            for (int i = 0; i < XmData.Length; i++)
            {
                if (NumUtil.StrToNumber<int>(XmData[i], ref Value)) { XmPlusData[i] = XmData[i]; continue; } //Number

                if (LoopList.Count > 0)
                {
                    if (XmData[i].ToLower().CompareTo(Reg) == 0)
                        XmPlusData[i] = LoopList[0].Index.ToString();
                    else if (XmData[i].Length > 3 && XmData[i].Substring(0, 3).ToLower().CompareTo(Reg) == 0)
                    {
                        if (NumUtil.StrToNumber<int>(XmData[i].Substring(3), ref Value) && Value < LoopList.Count)
                            XmPlusData[i] = LoopList[Value].Index.ToString();
                        else
                            XmPlusData[i] = XmData[i];
                    }
                    else
                        XmPlusData[i] = XmData[i];
                }
                else
                    XmPlusData[i] = XmData[i];

            }
            return XmPlusData;
        }
    }
}
