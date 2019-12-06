using KClmtrBase.KClmtrWrapper;
using System.Collections.Generic;
using XM_Tek_Studio_Pro.StudioUtil;
using XM_Tek_Studio_Pro.XMComm;

namespace XM_Tek_Studio_Pro
{
    public class ExeInfo
    {
        public int RealExeLine;
        public List<LoopLib> FoundLoopList;
        public List<LoopLib> RunLoopList;
        public LoopLib RunLoop;
        public List<ScriptInfo> lScriptInfo;
        public XmCmdInfo XmCmdInfo; //Command Send Info
    }

    public class XM_ExeMainCmd
    {
        //LoopLib XmFor =null; 
       XM_Cmd_Lib ExamCmdLib = new XM_Cmd_Lib();
        XM_ExeWolCmd_Util ExeWolSpt = new XM_ExeWolCmd_Util();
        XM_ExeCommCmd_Util ExeCommSpt = new XM_ExeCommCmd_Util();
        XM_ExeCommCmd_Util ExeKonicaSpt = new XM_ExeCommCmd_Util();
        XM_ExeEquipCmd_Util ExeEquipSpt = new XM_ExeEquipCmd_Util();
        XM_ExeKleinCmd_Util ExeKleinSpt = new XM_ExeKleinCmd_Util();
        XM_ExeSysCmd_Util ExeSysSpt = new XM_ExeSysCmd_Util();
        XM_ExeForCmd_Util ExeForSpt = new XM_ExeForCmd_Util();

        public ExeInfo RunInfo = null;

        public XM_ExeMainCmd()
        {
            RunInfo = new ExeInfo
            {
                RealExeLine = 0,
                FoundLoopList = new List<LoopLib>(),
                RunLoopList = new List<LoopLib>(),
                XmCmdInfo = new XmCmdInfo()
            };
        }

        public string ExamScript(string[] Commands, List<ScriptInfo> ScriptInfo)
        {
            return ExamCmdLib.ExamScript(Commands, ScriptInfo) + ExamCmdLib.VerifyForScript(ScriptInfo);
        }

        public bool ExamScript(string[] Commands, List<ScriptInfo> ScriptInfo, ref int Image_num)
        {
            return ExamCmdLib.VerifyRepeatToken(Commands, /*ScriptInfo*/ ref Image_num);
        }

        public bool ExamCmd(ScriptInfo ScriptCmd)
        {
            if (ExamCmdLib.ExamCmd(ScriptCmd) < 2) // 0 , 1 Pass
            {
                //ExeEquipSpt.EquipAddr = GetInstruName();
                ExeCommSpt.CommPort = GetCommName();
                RunInfo.RealExeLine = ScriptCmd.Line;
                return true;
            }

            return false;
        }


        public bool SetDevices(string CommPort, string IntruAddr)
        {
            ExeCommSpt.CommPort = CommPort;
            return true;
        }

        public bool SetDevices(string CommPort, ref XM_EquipVisa_Util Comm, string IntruAddr)
        {
            ExeCommSpt.CommPort = CommPort;
            ExeCommSpt.XmComm = Comm;
            return true;
        }

        public bool ExcuteCmd(string Command, XmPlusCmd XmPlus, ref string RdStr)
        {
            bool ret = true;
            if (XmPlus.Class == 0) ret = DealWithComm(Command, XmPlus, ref RdStr);
            if (XmPlus.Class == 1) ret = DealWithSystem(Command, XmPlus, ref RdStr);
            if (XmPlus.Class == 2) ret = DealWithEquip(Command, XmPlus, ref RdStr);
            if (XmPlus.Class == 3) ret = DealWithWol(Command, XmPlus, ref RdStr);
            if (XmPlus.Class == 4) ret = DealWithFor(Command, XmPlus);
            if (XmPlus.Class == 5) ret = DealWithKonica(Command, XmPlus, ref RdStr);
            if (XmPlus.Class == 6) ret = DealWithKlein(Command, XmPlus, ref RdStr);
            return ret;
        }

        public bool GetGammaComm() { return ExeKonicaSpt.Status(); }
        public bool IsScopeCmd() { return ExeSysSpt.bScopeCmd; }
        public void SetScope(bool Mode) { this.ExeSysSpt.bScopeCmd = Mode; }
        public bool IsPauseCmd() { return ExeSysSpt.bPauseCmd; }
        public void SetPause(bool Mode) { this.ExeSysSpt.bPauseCmd = Mode; }
        public bool IsGammaCmd() { return ExeSysSpt.bGammaCmd; }
        public void SetGamma(bool Mode) { this.ExeSysSpt.bGammaCmd = Mode; }
        public bool IsEndLoopCmd() { return this.ExeForSpt.bEndLoop; }
        public string GetCommName() { return ExamCmdLib.GetCommAddr(); }
        public string GetInstruName() { return ExamCmdLib.GetInstruAddr(); }
        public string GetXmCmd() { return ExamCmdLib.GetXmCmd(); }
        public string GetFullCmd() { return ExamCmdLib.GetFullCmd(); }
        public byte GetCmdType() { return ExamCmdLib.GetCmdType(); }
        public byte GetCmdClass() { return ExamCmdLib.GetCmdClass(); }
        public int GetCmdDelay() { return ExamCmdLib.GetCmdClass(); }
        public byte GetCmdReg() { return ExamCmdLib.GetCmdReg(); }
        public string ReadInfo(int Line, string Result) { return ExamCmdLib.ReadInfo(Line, Result); }
        public string ErrResult(string Info, int Line) { return ExamCmdLib.ErrResult(Info, Line); }
        public XmPlusCmd GetXmClass() { return ExamCmdLib.GetXmPlus(); }
        public bool SetCommDev(ref XM_EquipVisa_Util Comm) { ExeCommSpt.XmComm = Comm; return true; }
        public bool SetKonicaDev(ref XM_EquipVisa_Util Comm) { ExeKonicaSpt.XmComm = Comm; return true; }
        public bool SetKleinDev(ref KClmtrWrap kClmtr) { ExeKleinSpt.kClmtr = kClmtr; return true; }

        public bool SetKonicaClose()
        {
            if (GetGammaComm() && ExeKonicaSpt.XmComm != null)
            {
                ExeKonicaSpt.XmComm.CommClose();
                ExeKonicaSpt.XmComm = null;
                return true;
            }
            return false;
        }

        public bool CompleteLoop()
        {
            foreach (LoopLib Loop in RunInfo.FoundLoopList)
            {
                if (Loop.EndLine == 0) return false;
            }

            this.ExeForSpt.bEndLoop = false;
            if (RunInfo.FoundLoopList.Count > 0)
            {
                RunInfo.RunLoop = RunInfo.FoundLoopList[0];
                RunInfo.RunLoopList.Add(RunInfo.RunLoop);
                RunInfo.FoundLoopList.Clear();
            }
            return true;

        }

        public bool DebugScript(List<ScriptInfo> ScriptInfo)
        {
            foreach (ScriptInfo info in ScriptInfo)
            {
                Log.W(info.Line + "\t" + info.CleanCmd + "\t" + info.Result);
            }
            return true;
        }

        private bool DealWithEquip(string XmCmd, XmPlusCmd XmPlus, ref string RdStr)
        {
            ExeEquipSpt.SetRunInfo(RunInfo);
            return ExeEquipSpt.ExcuteCmd(XmCmd, XmPlus.Type, XmPlus.Category, ref RdStr);
        }

        private bool DealWithKlein(string XmCmd, XmPlusCmd XmPlus, ref string RdStr)
        {
            ExeKleinSpt.SetRunInfo(RunInfo);
            return ExeKleinSpt.ExcuteCmd(XmCmd, XmPlus.Type, XmPlus.Delay, XmPlus.Category, ref RdStr);
        }

        private bool DealWithKonica(string XmCmd, XmPlusCmd XmPlus, ref string RdStr)
        {
            ExeKonicaSpt.SetRunInfo(RunInfo);
            ExeKonicaSpt.SetKonica(true);
            return ExeKonicaSpt.ExcuteCmd(XmCmd, XmPlus.Type, XmPlus.Delay, XmPlus.Category, ref RdStr);
        }

        private bool DealWithComm(string XmCmd, XmPlusCmd XmPlus, ref string RdStr)
        {
            ExeCommSpt.SetRunInfo(RunInfo);
            ExeCommSpt.SetKonica(false);
            return ExeCommSpt.ExcuteCmd(XmCmd, XmPlus.Type, XmPlus.Delay, XmPlus.Category, ref RdStr);
        }

        private bool DealWithWol(string XmCmd, XmPlusCmd XmPlus, ref string RdStr)
        {
            ExeWolSpt.SetRunInfo(RunInfo);
            return ExeWolSpt.ExcuteCmd(XmCmd, XmPlus.Type, XmPlus.Category, ref RdStr);
        }

        private bool DealWithSystem(string SystemCmd, XmPlusCmd XmPlus, ref string RdStr)
        {
            ExeSysSpt.SetRunInfo(RunInfo);
            return ExeSysSpt.ExcuteCmd(SystemCmd, XmPlus.Type, XmPlus.Category, ref RdStr);
        }

        private bool DealWithFor(string ElecsCmd, XmPlusCmd XmPlus)
        {
            ExeForSpt.SetRunInfo(RunInfo);
            return ExeForSpt.ExcuteCmd(ElecsCmd, XmPlus.Type);
        }
    }
}
