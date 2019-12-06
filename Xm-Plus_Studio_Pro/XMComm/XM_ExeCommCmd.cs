using System;
using System.Threading;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    class XM_ExeCommCmd_Util : XM_ExeCmd
    {
        private char[] DelimiterChars = { ' ', ',', '\t', '\r', '\n' };
        enum CmdType { Read, Write, WrAndRd }
        public XM_EquipVisa_Util XmComm = null;
        public string CommPort = null;
        private bool bKonica = false;
        private string RemoteCmd = "COM, 1\r\n", SplictStr ="\r\n";
        private const int DelayTime = 500; 
        public void SetKonica(bool DevPtr)
        {
            bKonica = DevPtr;
            if(DevPtr) XmComm.Write(RemoteCmd, 50); 
        }
        public bool ExcuteCmd(string XMCmd, byte XMType, int Delay, byte XmCategory, ref string RdStr)
        {
            bool ret = false;
            if (XmComm == null) { RdStr = "Comm Err"; return false; }

            if (RunInfo.FoundLoopList.Count > 0) { RunInfo.XmCmdInfo.Excute = false; return false; }
            if (RunInfo.RunLoop == null && RunInfo.RunLoopList.Count > 0) { RunInfo.XmCmdInfo.Excute = false; return false; };

            string[] XmCmd = (string[])MergeXMCmds(XMCmd.Trim()).ToArray(typeof(string));
            string[] XmPlusData = ExchangeXmData(RunInfo.RunLoopList, XmCmd, RunInfo.XmCmdInfo, XmCategory);

            //CA210,CA310
            if (XmCmd[0] == XM_Cmd_Lib.xmd[49]) ret = KonicaSend(XmPlusData, Delay, ref RdStr);
            if (XmCmd[0] == XM_Cmd_Lib.xmd[50]) ret = KonicaWrAndRd(XmPlusData, Delay, ref RdStr);
            if (XmCmd[0] == XM_Cmd_Lib.xmd[51]) ret = KonicaRd(XmPlusData, Delay, ref RdStr);
            //Chamber Control/
            if (XmCmd[0] == XM_Cmd_Lib.xmd[52]) ret = ChamberSend(XmPlusData, Delay, ref RdStr);
            if (XmCmd[0] == XM_Cmd_Lib.xmd[53]) ret = ChamberWrAndRd(XmPlusData, Delay, ref RdStr);
            if (XmCmd[0] == XM_Cmd_Lib.xmd[54]) ret = ChamberRd(XmPlusData, Delay, ref RdStr);
            if (XmCmd[0] == XM_Cmd_Lib.xmd[55]) ret = ChamberOn(XmPlusData, Delay, ref RdStr);
            if (XmCmd[0] == XM_Cmd_Lib.xmd[56]) ret = ChamberOff(XmPlusData, Delay, ref RdStr);
            if (XmCmd[0] == XM_Cmd_Lib.xmd[57]) ret = ChamberTemp(XmPlusData, Delay, ref RdStr);
            if (XmCmd[0] == XM_Cmd_Lib.xmd[58]) ret = ChamberHumidity(XmPlusData, Delay, ref RdStr);
            return ret;
        }

        private bool WaitTimeCtrlProgBar(int Seconds)
        {
            ScriptSetting_Form.frmScript.InvokeShowStr(0, string.Concat("Please Wait ",Seconds, " Seconds!", "\n"));
            int Times = Seconds * 1000/ 100;
            for (int i = 0; i < 100; i++)
            {
                Main_Form.frmMain.InvokePrgbPos(i);
                Thread.Sleep(Times);
            }
            return true;
        }

        private bool ChamberOn(string[] XmPlusData, int Delay, ref string RdStr)
        {
            string OpCmd = string.Concat("@001,%,313=", "0");
            string OnCmd = string.Concat("@001,%,217=", "1");
            Main_Form.frmMain.InvokePrgbMax(100);
            bool ret = XmComm.WriteAndRead(AppendCheckSum(OpCmd), Delay, ref RdStr);
            ret = RdStr.IndexOf("Ok") > 0 ? true : false;
            ret = XmComm.WriteAndRead(AppendCheckSum(OnCmd), Delay, ref RdStr);
            ret = RdStr.IndexOf("Ok") > 0 ? true : false;
            WaitTimeCtrlProgBar(90);
            return ret;
        }

        private bool ChamberOff(string[] XmPlusData, int Delay, ref string RdStr)
        {
            string OpOnMode = string.Concat("@001,%,313=", "0");
            string OffCmd = string.Concat("@001,%,217=", "0");
            bool ret = XmComm.WriteAndRead(AppendCheckSum(OpOnMode), Delay, ref RdStr);
            Main_Form.frmMain.InvokePrgbMax(100);
            ret = RdStr.IndexOf("Ok") > 0 ? true : false;
            if (!SetChamberTemperature(25,false)) return false;
            for (int i = 0; i < 2; i++)
            {
                ret = XmComm.WriteAndRead(AppendCheckSum(OffCmd), Delay, ref RdStr);
                ret = RdStr.IndexOf("Ok") > 0 ? true : false;
                Thread.Sleep(1000);
            }

            return ret;
        }

        private bool SetChamberTemperature(double Temperature,bool bWait)
        {
            string RdStr = null;
            string SetTempCmd = Temperature > 0 ? string.Concat("@001,!,101=", "+", Temperature) : string.Concat("@001,!,101=", Temperature);
            double RdTemp = 0;

       
            bool ret = XmComm.WriteAndRead(AppendCheckSum(SetTempCmd), DelayTime, ref RdStr);
            ret = RdStr.IndexOf("Ok") > 0 ? true : false;


            while (true)
            {
                RdStr = null;
                ret = XmComm.WriteAndRead(AppendCheckSum("@001,!,100"), DelayTime, ref RdStr);
                RdTemp = GetTempValue(RdStr);
             
                if (IsCloseVal(RdTemp, Temperature))
                {
                    ScriptSetting_Form.frmScript.InvokeShowStr(0, string.Concat("Temperature:", RdTemp, " Success", "\n"));
                    break;
                }
                else
                    ScriptSetting_Form.frmScript.InvokeShowStr(0, string.Concat("Temperature:", RdTemp, "\n"));

                Thread.Sleep(10000);
            }

            //Waiting
            if( bWait) WaitTimeCtrlProgBar(1800);

            return true;
        }

        private bool IsCloseVal(double Measure,double Setting)
        {
            double Diff = Measure - Setting;
            return Math.Abs(Diff) < 0.5  ? true : false;
        }

        private bool ChamberTemp(string[] XmPlusData, int Delay, ref string RdStr)
        {
            string OpCmd = string.Concat("@001,%,313=", "0"); //定值運轉
            double  Temperature = 0;
            Main_Form.frmMain.InvokePrgbMax(100);
            Temperature = new XM_Digital_Util().StrToNumber<double>(XmPlusData[0], ref Temperature) ? Temperature : 0;
            bool ret = XmComm.WriteAndRead(AppendCheckSum(OpCmd), Delay, ref RdStr);
            ret = RdStr.IndexOf("Ok") > 0 ? true : false;
            ret = SetChamberTemperature(Temperature,true);
            return ret;
        }

        private bool SetChamberHumidity(double Humidity, bool bWait)
        {
            string RdStr = null;
            string SetHumCmd = string.Concat("@001,!,101=", "+", Math.Abs(Humidity));
            double RdTemp = 0;


            bool ret = XmComm.WriteAndRead(AppendCheckSum(SetHumCmd), DelayTime, ref RdStr);
            ret = RdStr.IndexOf("Ok") > 0 ? true : false;


            while (true)
            {
                RdStr = null;
                ret = XmComm.WriteAndRead(AppendCheckSum("@001,!,200"), DelayTime, ref RdStr);
                RdTemp = GetTempValue(RdStr);

                if (IsCloseVal(RdTemp, Math.Abs(Humidity)))
                {
                    ScriptSetting_Form.frmScript.InvokeShowStr(0, string.Concat("Temperature:", RdTemp, " Success", "\n"));
                    break;
                }
                else
                    ScriptSetting_Form.frmScript.InvokeShowStr(0, string.Concat("Temperature:", RdTemp, "\n"));
            }


            if (bWait) WaitTimeCtrlProgBar(600);

            return true;
        }

        private bool ChamberHumidity(string[] XmPlusData, int Delay, ref string RdStr)
        {
            string RdHumidityCtrl = "@001,%,200";
            string OpCmd = string.Concat(RdHumidityCtrl, "1");
            double Temperature = 0;
            Main_Form.frmMain.InvokePrgbMax(100);
            Temperature = new XM_Digital_Util().StrToNumber<double>(XmPlusData[0], ref Temperature) ? Temperature : 0;
            bool ret = XmComm.WriteAndRead(AppendCheckSum(OpCmd), Delay, ref RdStr);
            ret = RdStr.IndexOf("Ok") > 0 ? true : false;
            ret = SetChamberHumidity(Temperature,true);
            return ret;
        }

        private double GetTempValue(string Str)
        {
            double OutTemp = 0;
            XM_Digital_Util Utility = new XM_Digital_Util();
            string[] Temp = Str.Split(new char[] { '=', ',' });

            if (Temp[Temp.Length - 1].Contains("Ok"))
                Utility.StrToNumber<double>(Temp[Temp.Length - 2], ref OutTemp);

            OutTemp = OutTemp / 100;//Real temperature

            return OutTemp;

        }

        private bool ChamberSend(string[] XmPlusData, int Delay, ref string RdStr)
        {
            string XMCmd = XmPlusData[0].Trim() + DelimiterChars[3] + DelimiterChars[4];
            return XmComm.Write(XMCmd, Delay);
        }

        private bool KonicaSend(string[] XmPlusData, int Delay, ref string RdStr)
        {
            string XMCmd = XmPlusData[0].Trim() + DelimiterChars[3] + DelimiterChars[4];
            return XmComm.Write(XMCmd, Delay);
        }

        private bool ChamberWrAndRd(string[] XmPlusData, int Delay, ref string RdStr)
        {
            string XMCmd = XmPlusData[0].Trim() ;
            if (XmPlusData.Length > 1 && !int.TryParse(XmPlusData[1], out Delay)) { Delay = 130; }
            return XmComm.WriteAndRead(AppendCheckSum(XMCmd), Delay, ref RdStr);
        }

        private string AppendCheckSum(string Cmd)
        {
            try
            {
                char[] Cmdchar = Cmd.ToCharArray();
                int SumValue = 0;
                string CheckSum = "";
                for (int i = 0; i < Cmdchar.Length; i++)
                {
                    SumValue = SumValue + Cmdchar[i];
                }
                CheckSum = (SumValue % 255).ToString("X02");
                Cmd = Cmd + CheckSum + SplictStr;
                return Cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool KonicaWrAndRd(string[] XmPlusData, int Delay, ref string RdStr)
        {
            string XMCmd = XmPlusData[0].Trim() + DelimiterChars[3] + DelimiterChars[4];
            if (XmPlusData.Length > 1 && !int.TryParse(XmPlusData[1], out Delay)) { Delay = 130; }
            bool ret = bKonica ? XmComm.KonicaWrAndRd(XMCmd, Delay, ref RdStr) : XmComm.WriteAndRead(XMCmd, Delay, ref RdStr);
            if (ret) SaveKonicaMsgToFile(XmPlusData[XmPlusData.Length - 1], "", RdStr);
            return ret;
        }

        private bool KonicaRd(string[] XmPlusData, int Delay, ref string RdStr)
        {
            bool ret = bKonica ? XmComm.KonicaRd(Delay, ref RdStr) : XmComm.Read(Delay, ref RdStr);
            if (ret) SaveKonicaMsgToFile(XmPlusData[XmPlusData.Length - 1], "", RdStr);
            return ret;
        }
        private bool ChamberRd(string[] XmPlusData, int Delay, ref string RdStr)
        {
            bool ret = bKonica ? XmComm.KonicaRd(Delay, ref RdStr) : XmComm.Read(Delay, ref RdStr);
            if (ret) SaveKonicaMsgToFile(XmPlusData[XmPlusData.Length - 1], "", RdStr);
            return ret;
        }

        public bool Open(string CommAddr, string Baudrate, string Parity, string DataBit, string StopBit)
        {
            XmComm = new XM_EquipVisa_Util(CommAddr, Baudrate, DataBit, Parity, StopBit);
            return XmComm.CommOpen();
        }

        public bool Close()
        {
            XmComm.CommClose();
            XmComm = null;
            return true;
        }

        public bool Write(string Command)
        {
            string[] Token = Command.Trim().Split(DelimiterChars);
            if (Command.LastIndexOf(DelimiterChars[3]) < 0) Command = Command + DelimiterChars[3];
            return XmComm.Write(Command);

        }

        public bool Read(ref string RdCmd)
        {
            return XmComm.Read(ref RdCmd);
        }

        public bool WriteRead(string Command, ref string RdCmd)
        {
            if (Command.LastIndexOf(DelimiterChars[3]) < 0) Command = Command + DelimiterChars[3];
            return XmComm.WriteAndRead(Command, ref RdCmd);
        }

        public bool Status()
        {
            if (XmComm == null) return false;
            return XmComm.IsCommOpen();
        }

        private void RemoteMode()
        {

        }

    }
}
