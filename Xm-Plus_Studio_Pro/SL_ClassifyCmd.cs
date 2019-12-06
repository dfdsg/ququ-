using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace SL_Tek_Studio_Pro
{
    class SL_ClassifyCmd
    {
        SL_Comm_Util ElecsComm=null;
        string InstruAddr = null, CommAddr = null;
        enum CmdType { Read, Write, WrAndRd }
        string ERR_INSTRUOPEN = "Open Instrument Error";
        private char[] DelimiterChars = { ' ', ',', '\t' };
        private string DELAYCMD = "delay";
        private string ENDTOKEN = "\r\n";
        public List<InstruDefine> lInstruDefine = new List<InstruDefine>();

        public bool SetDevices(string CommAddr, ref SL_Comm_Util Comm,string IntruAddr)
        {
            bool ret = false;
            this.CommAddr = CommAddr;
            this.ElecsComm = Comm;
            this.InstruAddr = IntruAddr;
            if (Comm == null && !String.IsNullOrEmpty(CommAddr))
                ComSetting(CommAddr, ref Comm);
   
            if (Comm != null && Comm.isOpen() == true) ret = true;        
            return ret;         
        }

        public bool ProcessCmd(string Command, byte Type, byte Class, ref string RdStr)
        {
            bool ret = true;
            if (Class == 0) ret = DealWithComm(Command, Type, ref RdStr);
            if (Class == 1) ret = DealWithSystem(Command, Type, ref RdStr);
            if (Class == 2) ret = DealWithInstr(Command, Type, ref RdStr);
            return ret;
        }

        public bool ComSetting(string CommAddr)
        {
            ElecsComm = new SL_Comm_Util(CommAddr, "115200", "8", "None", "1");
            if (ElecsComm.CommOpen())
                return true;
            else
                return false;
        }

        private void ComSetting(string CommAddr, ref SL_Comm_Util Comm)
        {
            ElecsComm = new SL_Comm_Util(CommAddr, "115200", "8", "None", "1");
            if (ElecsComm.CommOpen()) Comm = ElecsComm;
        }

        private string SystemInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.ProductVersion;
        }

        private bool SearchInstruName()
        {
            bool ret = false;
            string InstrName = null;
            if(lInstruDefine.Count > 0) InstrName = lInstruDefine.Find(a => a.NickName == this.InstruAddr).MainName;
            if (!String.IsNullOrEmpty(InstrName)) { this.InstruAddr = InstrName; ret = true; }
            return ret;
        }

        private bool AddInstruNameList(string InstruCmd)
        {
            bool ret = true;
            string[] Token = InstruCmd.Split(DelimiterChars);
            int MatchMain = lInstruDefine.FindIndex(a => a.MainName == Token[0]);
            int MatchNick = lInstruDefine.FindIndex(a => a.NickName == Token[0]);
            if (MatchMain < 0 && MatchNick < 0)
                lInstruDefine.Add(new InstruDefine(Token[0], Token[1]));
            else
                ret = false;

            return ret;
        }

        private bool DealWithInstr(string InstruCmd, byte InstruType, ref string RdStr)
        {
            bool ret = true;

            switch (InstruType)
            {
                case 0:
                    SearchInstruName();
                    ret = InstrRead(ref RdStr);
                    break;
                case 1:
                    SearchInstruName();
                    ret = InstrSend(InstruCmd, ref RdStr);
                    break;
                case 2:
                    SearchInstruName();
                    ret = InstrSendRead(InstruCmd, ref RdStr);
                    break;
                case 3:
                    ret = AddInstruNameList(InstruCmd);
                    break;
                default:
                    break;
            }

            return ret;
        }

        private bool DealWithSystem(string SystemCmd, byte ElecsType, ref string RdStr)
        {
            bool ret = true;
            if (ElecsComm != null && ElecsType == (byte)CmdType.Write)
            {
                if (SystemCmd.CompareTo("elecs.close") == 0) { ElecsComm.CommClose(); ElecsComm = null; }
                if (SystemCmd.CompareTo("system") == 0) { RdStr = SystemInfo(); }
            }
            else
            {
                if (ElecsComm != null) ret = ElecsComm.Read(ref RdStr);
                else RdStr = "Open Device Error";
            }
            return true;
        }

        private bool DealWithComm(string ElecsCmd, byte ElecsType,ref string RdStr)
        {
            bool ret = true;
            int Times = 0;
            string[] Token = ElecsCmd.Split(DelimiterChars);

            if (Token[0].ToLower().CompareTo(DELAYCMD) == 0)
            {
                int.TryParse(Token[1], out Times);
                Thread.Sleep(Times);
                return true;
            }

            if (ElecsComm == null) { RdStr = "ERROR Open Device Err"; return false; }

            ElecsCmd = ElecsCmd + ENDTOKEN;

            if (ElecsType == (byte)CmdType.Write)
                ret = ElecsComm.Write(ElecsCmd);
            else if (ElecsType == (byte)CmdType.WrAndRd)
                ret = ElecsComm.WriteAndRead(ElecsCmd , ref RdStr);
            else
                ret = ElecsComm.Read(ref RdStr);

            return ret;
        }

        private bool InstrRead(ref string RdStr)
        {
            bool ret = true;
            SL_Equip_Util EquipUtil = new SL_Equip_Util();
            ret = EquipUtil.Open(this.InstruAddr);
            if (ret)
            {
                ret = EquipUtil.Read(ref RdStr);
                EquipUtil.Close();
            }
            else
                RdStr = ERR_INSTRUOPEN;
            return ret;
        }

        private bool InstrSend(string instruCmd, ref string RdStr)
        {
            bool ret = true;
            SL_Equip_Util EquipUtil = new SL_Equip_Util();
            ret = EquipUtil.Open(this.InstruAddr);
            if (ret)
            {
                ret = EquipUtil.Send(instruCmd);
                EquipUtil.Close();
            }
            else
                RdStr = ERR_INSTRUOPEN;
            return ret;
        }

        private bool InstrSendRead(string instruCmd, ref string RdStr)
        {
            bool ret = true;
            SL_Equip_Util EquipUtil = new SL_Equip_Util();
            ret = EquipUtil.Open(this.InstruAddr);
            if (ret)
            {
                ret = EquipUtil.SendRead(instruCmd, ref RdStr);
                EquipUtil.Close();
            }
            else
                RdStr = ERR_INSTRUOPEN;
            
            return ret;
        }
    }
}
