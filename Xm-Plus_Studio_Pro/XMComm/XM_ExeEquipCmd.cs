#define INSTRUSUPPORT  
using System;
using System.Collections.Generic;
using System.IO;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{

    public class EquipAlias
    {
        public string MainName { get; set; }
        public string AliasName { get; set; }
        public int Type { get; set; }
        public string OscillCmd { get; set; }
        public EquipAlias(string MainName, string AliasName,string Cmd, int Type)
        {
            this.MainName = MainName;
            this.AliasName = AliasName;
            this.Type = Type;
            this.OscillCmd = Cmd;
        }
    }

    class XM_ExeEquipCmd_Util : XM_ExeCmd
    {

        private List<XM_EquipVisa_Util> EquipList = new List<XM_EquipVisa_Util>();
        private string ERR_INSTRUOPEN = "Open Instrument Error";
        private char[] DelimiterChars = { ' ', ',', '\t' };
        byte[] ScopeScreenResultsArray; // Screen Results array.

        public XM_ExeEquipCmd_Util() {  }

        public bool ExcuteCmd(string Cmd, byte CmdType, byte XmCategory, ref string RdStr)
        {
            bool ret = true;
            if (RunInfo.FoundLoopList.Count > 0) { RunInfo.XmCmdInfo.Excute = false; return false; }
            if (RunInfo.RunLoop == null && RunInfo.RunLoopList.Count > 0) { RunInfo.XmCmdInfo.Excute = false; return false; };

            string[] XmCmd = (string[])MergeXMCmds(Cmd.Trim()).ToArray(typeof(string));
            string[] XmPlusData = ExchangeXmData(RunInfo.RunLoopList, XmCmd, RunInfo.XmCmdInfo, XmCategory);
            string IndexVal = CombineIndex();

            if (XM_Cmd_Lib.xmd[26] == XmCmd[0]) ret = XmEquipDef(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[27] == XmCmd[0]) ret = XmEquipSend(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[28] == XmCmd[0]) ret = XmEquipXfer(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[29] == XmCmd[0]) ret = XmEquipRead(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[30] == XmCmd[0]) ret = XmEquipClose(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[38] == XmCmd[0]) ret = XmOscilloSave(XmPlusData, IndexVal, ref RdStr);
            return ret;
        }

        private bool XmOscilloSave(string[] EquipCmd, string FileIndex, ref string RdStr)
        {
            bool ret = true;
            int Index = 0, nViStatus=0;
            int RunOscillscope_Type = 1;
            XM_IO_Util IOUtil = new XM_IO_Util();

            //int g_ScreenLength = 0;

            string FileName = string.IsNullOrEmpty(FileIndex) ? EquipCmd[1] : string.Concat(IOUtil.GetPureFileName(EquipCmd[1]) ,"_", FileIndex);
            FileName = string.Compare(IOUtil.GetExtName(FileName), ".png") == 0 ? FileName : string.Concat(FileName, ".png");
            FileName = string.Concat(Setting.ExeScopeDirPath, "\\", FileName);

            if (!FoundToEquipName(EquipCmd[0], null, ref Index)) return false;
            if (!EquipList[Index].IsOpen()) ret = EquipList[Index].VisaOpen();

            nViStatus = EquipList[Index].OscilloScopeImage(out string GetOSCType/*Agilent or Tektronix*/, RunOscillscope_Type/*need to switch cmd depend on Agilent*/);
            nViStatus = EquipList[Index].VisaReadPictureBinaryFormat(out ScopeScreenResultsArray, out int g_ScreenLength, GetOSCType);

            if (nViStatus != 0 ? true : false)
            {
                nViStatus = RunOscillscope_Type = RunOscillscope_Type == 1 ? 0 : 1;
                nViStatus = EquipList[Index].OscilloScopeImage(out GetOSCType, RunOscillscope_Type);
                nViStatus = EquipList[Index].VisaReadPictureBinaryFormat(out ScopeScreenResultsArray, out g_ScreenLength, GetOSCType);
            }

            FileStream fStream = File.Open(FileName, FileMode.Create);
            fStream.Write(ScopeScreenResultsArray, 0, g_ScreenLength);
            fStream.Close();
            EquipList[Index].VisaSend(":RUN");

            return true;
        }

        private bool XmEquipClose(string[] EquipCmd, ref string RdStr)
        {
            bool ret = true;
            int Index = 0;
            if (!FoundToEquipName(EquipCmd[0], null, ref Index)) return false;
             EquipList.RemoveAt(Index);
            return ret;
        }

        private bool XmEquipDef(string[] EquipCmd, ref string RdStr)
        {
            int Count = 0;
            if (FoundAliasName(EquipCmd[0], ref Count)) { RdStr += "Equip Alias already defined"; }
            if (FoundEquipName(EquipCmd[1], ref Count)) { RdStr = "Equip Name already defined,"; }
        
            return  FoundToJoinList(EquipCmd[0], EquipCmd[1],ref Count);
        }

        private bool XmEquipRead(string[] EquipCmd, ref string RdStr)
        {
            bool ret = true;
            int Index = 0;
            if (!FoundToEquipName(EquipCmd[0],null,ref Index)) return false;
            ret = (!EquipList[Index].IsOpen()) ? EquipList[Index].VisaOpen() : true;
            ret = (ret) ? (EquipList[Index].VisaRead(out RdStr) == 0) ? true : false : true;
            RdStr = String.IsNullOrEmpty(RdStr) ? ERR_INSTRUOPEN : RdStr.TrimEnd();
            if (RdStr.CompareTo(ERR_INSTRUOPEN) == 0) return false;
            if (EquipCmd.Length == 2 && EquipCmd[EquipCmd.Length - 1].EndsWith("txt"))
            {
                string FilePath = Setting.ExeLogDirPath + "\\" + EquipCmd[EquipCmd.Length - 1];
                using (StreamWriter sw = File.AppendText(FilePath))
                    sw.Write(RdStr);
            }
            return ret;
        }

        private bool XmEquipSend(string[] EquipCmd, ref string RdStr)
        {
            bool ret = true;
            int Index = 0;
            if (!FoundToEquipName(EquipCmd[0], null, ref Index)) return false;
            if (!EquipList[Index].IsOpen()) ret = EquipList[Index].VisaOpen();
            if (ret)
            {
                string SendCmd = EquipTotalCmd(EquipCmd);
                ret = (EquipList[Index].VisaSend(SendCmd) == 0) ? true : false;
            }
            else
                RdStr = ERR_INSTRUOPEN;
            return ret;
        }

        private bool XmEquipXfer(string[] EquipCmd, ref string RdStr)
        {
            bool ret = true;
            int Index = 0;
            if (!FoundToEquipName(EquipCmd[0], null, ref Index)) return false;
            if (!EquipList[Index].IsOpen()) ret = EquipList[Index].VisaOpen();

            if (ret)
            {
                string SendCmd = EquipTotalCmd(EquipCmd);
                ret = EquipList[Index].VisaSendandRead(SendCmd, out RdStr)==0 ? true :false ;
                RdStr = String.IsNullOrEmpty(RdStr) ? null : RdStr.Trim();
                if (!String.IsNullOrEmpty(RdStr) && EquipCmd[EquipCmd.Length - 1].EndsWith(".txt"))
                    SaveEquipData(EquipCmd[EquipCmd.Length - 1], RdStr.Trim());
            }
            else
                RdStr = ERR_INSTRUOPEN;
            return ret;
        }

        private bool SaveEquipData(string FileName,string Message)
        {
            string FilePath = Path.Combine(Setting.ExeLogDirPath, FileName);
            using (StreamWriter sw = File.AppendText(FilePath))
            {
                sw.Write(Message);
            }
            return true;
        }

        private string EquipTotalCmd(string[] EquipCmd)
        {
            string Command = null;
            List<string> EquipCommand = new List<string>(EquipCmd);
            EquipCommand.RemoveAt(0);
            if (EquipCmd[EquipCmd.Length - 1].EndsWith(".txt"))
                EquipCommand.RemoveAt(EquipCommand.Count - 1);
            foreach (string Cmd in EquipCommand) { Command = string.Concat(Command," ", Cmd); }
            return Command.Trim();

        }

        private bool SearchEquipName(string EquipName, ref int Count)
        {
            for (int i = 0; i < EquipList.Count; i++)
            {
                if (string.IsNullOrEmpty(EquipList[i].EquipName)) return false;
            }
            XM_EquipVisa_Util EquipFormal = EquipList.Find(x => x.EquipName.CompareTo(EquipName) == 0);
            XM_EquipVisa_Util EquipAlias = EquipList.Find(x => x.EquipAliasName.CompareTo(EquipName) == 0);
            Count = EquipList.IndexOf(EquipFormal);
            //if(Count <0) Count = EquipList.IndexOf(EquipAlias);
            return (Count >= 0) ? true : false;
        }

        //EquipName Can be defined  by User 
        private bool FoundEquipName(string EquipName, ref int Count)
        {
            List<XM_EquipVisa_Util> Equipments = EquipList.FindAll(x => x.EquipName.CompareTo(EquipName) == 0);
            Count = Equipments.Count;
            return (Equipments.Count != 0) ? true : false;
        }

        //Every Equipment has one and only Alias name, User can not defind it.
        private bool FoundAliasName(string AliasName, ref int Count)
        {   
            List<XM_EquipVisa_Util> Equipments = EquipList.FindAll(x => x.EquipAliasName.CompareTo(AliasName) == 0);
            Count = Equipments.Count;
            return (Equipments.Count != 0) ? true : false;
        }

        private bool FoundToJoinList(string AliasName, string EquipName, ref int Count)
        {
            int Match = -1;
            if (SearchEquipName(EquipName, ref Match))
            {
                Count = Match;
                if (!string.IsNullOrEmpty(AliasName)) EquipList[Count].EquipAliasName = AliasName;
            }
            else 
            {
                if (string.IsNullOrEmpty(EquipName)) EquipName = AliasName;
                if (string.IsNullOrEmpty(AliasName)) AliasName = EquipName;

                EquipList.Add(new XM_EquipVisa_Util(AliasName));
                Count = EquipList.Count - 1;
                EquipList[Count].EquipName = EquipName;
                EquipList[Count].EquipAliasName = AliasName;
            }
            return (Count >= 0) ? true : false;
        }

        private bool FoundToEquipName(string EquipName, string AliasName, ref int Count)
        {
            int Match = -1;
            if (SearchEquipName(EquipName, ref Match))
            {
                if (!string.IsNullOrEmpty(AliasName)) EquipList[Count].EquipAliasName = AliasName;
            }
            Count = Match;
            return (Count >= 0) ? true : false;
        }

        ~XM_ExeEquipCmd_Util()
        {
            foreach (XM_EquipVisa_Util InstruUtil in EquipList)
            {
                if (InstruUtil.IsOpen()) InstruUtil.VisaClose();
            }
        }
    }
}
