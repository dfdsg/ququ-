
using FastColoredTextBoxNS;
using KClmtrBase.KClmtrWrapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    
    public partial class ScriptSetting_Form : Form
    {
        private char[] DelimiterChars = { ' ', ',', ':', '\t', '\n' };
        private readonly string WARNING, ERRMSG, DONEMSG, SAVELOG, SELMODE, NORMALMODE, BTNSTOP, BTNSEND/*,IMGMSG*/;
        private bool bStopRun = false;
        private int TabCount = 0;
  		private const int MaxItem = 20,SetIfType = 1;
        // private XM_ExeMainCmd ExeCmd = new XM_ExeMainCmd();
        public static XM_ExeMainCmd ExeCmd = new XM_ExeMainCmd();
        private string XmStr = null;
        enum MSG : int { MSG_TXCMD = 1, MSG_PAUSE, MSG_SCOPE, MSG_GAMMA, MSG_SEND, MSG_SHOW, MSG_DEV, MSG_IMGSEND, MSG_COMM, MSG_COLORDEV };
        TextStyle BlueStyle = null, BoldStyle = null, MagentaStyle = null, GreenStyle = null, BrownStyle, BlackStyle = null;
        List<XM_EquipVisa_Util.EquitDevice> EquitDeves = new List<XM_EquipVisa_Util.EquitDevice>();
        List<XmCmdList> lCmdInfo = new List<XmCmdList>();
        public static ScriptSetting_Form frmScript = null;
        public XM_EquipVisa_Util CommDev, ColorDev;
        public KClmtrWrap kClmtr;
        public XM_EquipVisa_Util XM_EquipVisa;
        private const int WM_VSCROLL = 0x115;
        private const int WM_SETREDRAW = 0x0B;
        private const int SB_BOTTOM = 0x0007;
        Thread XmThead = null;
        Image CloseImage, CloseImageAct;



        public ScriptSetting_Form()
        {
            InitializeComponent();           
            frmScript = this;
            WARNING = "WARNING"; ERRMSG = "ERROR"; BTNSEND = "Send";
            DONEMSG = "Done..." + DelimiterChars[4]; SAVELOG = "Log";
            SELMODE = "Selection Mode"; NORMALMODE = "Normal Mode"; BTNSTOP = "Stop";
            //kClmtr = new KClmtrWrap();
            SetupTabCtrl();
            SetupSystem();
            SetupToolTips();
        }

        private void SetupTabCtrl()
        {
            Size mysize = new System.Drawing.Size(20, 20); 
            Bitmap bt = new Bitmap(Properties.Resources.close);
            Bitmap btm = new Bitmap(bt, mysize);
            CloseImageAct = btm;
            Bitmap bt2 = new Bitmap(Properties.Resources.closeBlack);
            Bitmap btm2 = new Bitmap(bt2, mysize);
            CloseImage = btm2;
            Tctl_Pages.Padding = new Point(30);

        }


        private void SetupToolTips()
        {
            ToolTip ToolTips = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };

            ToolTips.SetToolTip(this.Btn_CommSend, "Shortcut Keys: Ctrl+F");
            ToolTips.SetToolTip(this.Btn_LoadSpt, "Shortcut Keys: Ctrl+L");
        }



        private void SetupSystem()
        {
            BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
            BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
            MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
            GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
            BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
            BlackStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);          
        }

        public void InvokeCommDev(int Command, string Msg)
        {
            MyMarshalToForm((int)MSG.MSG_COMM, Command, Msg);
        }

        public void InvokeColorDev(int Command, string Msg)
        {
            MyMarshalToForm((int)MSG.MSG_COLORDEV, Command, Msg);
        }

        public void InvokeDownload(int Line, string Msg)
        {
            MyMarshalToForm((int)MSG.MSG_IMGSEND, Line, Msg);
        }

        public void InvokeShowStr(int Line, string Msg)
        {
            MyMarshalToForm((int)MSG.MSG_SHOW, Line, Msg);
        }

        public void InvokeSend(int Line, string Msg)
        {
            MyMarshalToForm((int)MSG.MSG_SEND, Line, Msg);
        }

        public void InvokeTxMsg(int Line, string Msg)
        {
            MyMarshalToForm((int)MSG.MSG_TXCMD, Line, Msg);
        }

        public void InvokePause(int Line, string Msg)
        {
            MyMarshalToForm((int)MSG.MSG_PAUSE, Line, Msg);
        }

        public void InvokeScope(int Line, string Msg)
        {
            MyMarshalToForm((int)MSG.MSG_SCOPE, Line, Msg);
        }

        public void InvokeGamma(int Line, string Msg)
        {
            MyMarshalToForm((int)MSG.MSG_GAMMA, Line, Msg);
        }

        public void InvokeXmInstru(int Line, string Msg)
        {
            MyMarshalToForm((int)MSG.MSG_DEV, Line, Msg);
        }

        public delegate void MarshalToForm(int Action, int Line, string Msg);
        public void MyMarshalToForm(int action, int Line, string Msg)
        {
            try
            {
                object[] args = { action, Line, Msg };
                MarshalToForm MarshalToFormDelegate = null;

                //  The AccessForm routine contains the code that accesses the form.

                MarshalToFormDelegate = new MarshalToForm(ActionItem);

                //  Execute AccessForm, passing the parameters in args.

                base.Invoke(MarshalToFormDelegate, args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ActionItem(int Action, int Line, string Msg)
        {
            switch (Action)
            {
                case (int)MSG.MSG_TXCMD:
                    ShowMsg(Line, Msg);
                    break;
                case (int)MSG.MSG_PAUSE:
                    ShowPause(Line, Msg);
                    break;
                case (int)MSG.MSG_SCOPE:
                    ShowScope(Line, Msg);
                    break;
                case (int)MSG.MSG_GAMMA:
                    ShowGamma(Line, Msg);
                    break;
                case (int)MSG.MSG_SEND:
                    Btn_CommSend.Text = Msg;
                    bStopRun = false;
                    break;
                case (int)MSG.MSG_SHOW:
                    rtf_ElecsMsg.Text += Msg;
                    rtf_ElecsMsg.SelectionStart = rtf_ElecsMsg.Text.Length;
                    rtf_ElecsMsg.ScrollToCaret();
                    break;
                case (int)MSG.MSG_DEV:
                    ShowInstruDev(Line, Msg);
                    break;
                case (int)MSG.MSG_IMGSEND:
                    SendImg(Line, Msg);
                    break;
                case (int)MSG.MSG_COMM:
                    SetUpCommDev(Line, Msg);
                    break;
                case (int)MSG.MSG_COLORDEV:
                    SetUpColorDev(Line, Msg);
                    break;
                default:
                    break;
            }
        }

        private void ShowMsg(int Line, string ResultInfo)
        {
            
            XM_Sytem_API.SendMessage(rtf_ElecsMsg.Handle, WM_SETREDRAW, false, 0);
            rtf_ElecsMsg.AppendText(String.Format("Line[{0}]:{1}...Send\n", Line, ResultInfo));
            XM_Sytem_API.SendMessage(rtf_ElecsMsg.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
            XM_Sytem_API.SendMessage(rtf_ElecsMsg.Handle, WM_SETREDRAW, true, 0);
            rtf_ElecsMsg.Invalidate(true);
            rtf_ElecsMsg.Update();
        }
        private void ShowPause(int Line, string Msg)
        {
            string Temp = "Line: " + (Line + 1).ToString() + " Msg: " + Msg;
            DialogResult myResult = MessageBox.Show(Temp, "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bStopRun = (myResult == DialogResult.Yes) ? false : true;
        }
        private void ShowScope(int Line, string Msg)
        {
            new Scope_Form().ShowDialog();
            ExeCmd.SetScope(false);
        }
        private void ShowGamma(int Line, string Msg)
        {
            XmGammaTool GammaTool = new XmGammaTool(ExeCmd);
            GammaTool.Show();
            ExeCmd.SetGamma(false);
        }
        private void ShowInstruDev(int Line, string Msg)
        {
            for (int i = 0; i < EquitDeves.Count; i++)
            {
                XM_EquipVisa_Util.EquitDevice EquitDev = EquitDeves[i];
                trv_instru.Nodes.Add(EquitDev.VisaName);
                trv_instru.Nodes[i].Nodes.Add(EquitDev.Message);
            }
        }
        private void SendImg(int Line, string Msg)
        {
            Msg = string.Concat("image.show", " ", Msg);
            string[] Script = new string[1] { Msg };
            List<ScriptInfo> lScriptInfo = new List<ScriptInfo>();
            ExeCmd.ExamScript(Script, lScriptInfo);
            ExeCmd.RunInfo.lScriptInfo = lScriptInfo;
            if (ExeCmd.ExamCmd(lScriptInfo[0])) ExeCmd.ExcuteCmd(ExeCmd.GetXmCmd(), ExeCmd.GetXmClass(), ref Msg);
        }
        private void SetUpCommDev(int Command, string Msg)
        {
            XM_Ini_Util XmIni = new XM_Ini_Util(Setting.ExeSysIniPath);
            string CommPort = XmIni.IniReadValue(XMPLUSPARS.SECTION2, XMPLUSPARS.COMPORT);
            string CommBaudRate = XmIni.IniReadValue(XMPLUSPARS.SECTION2, XMPLUSPARS.BAUDRATE);
            string CommDatabit = XmIni.IniReadValue(XMPLUSPARS.SECTION2, XMPLUSPARS.DATABIT);
            string CommParity = XmIni.IniReadValue(XMPLUSPARS.SECTION2, XMPLUSPARS.PARITY);
            string CommStopBits = XmIni.IniReadValue(XMPLUSPARS.SECTION2, XMPLUSPARS.STOPBIT);
            CommDev = new XM_EquipVisa_Util(CommPort, CommBaudRate, CommDatabit, CommParity, CommStopBits);
            switch (Command)
            {
                case 0:
                    if (CommDev != null && CommDev.IsOpen()) CommDev.CommClose();
                    rtf_ElecsMsg.Text = string.Concat(Properties.Resources.COMM_MSG, " ", Properties.Resources.CLOSE_MSG);
                    Main_Form.frmMain.InvokeComm(Properties.Resources.CLOSE_MSG);
                    CommDev = null;
                    break;
                case 1:
                    if (CommDev.CommOpen())
                    {
                        Main_Form.frmMain.InvokeComm(Properties.Resources.OPEN_MSG);
                        ExeCmd.SetCommDev(ref CommDev);
                    }
                    else
                        Main_Form.frmMain.InvokeComm(Properties.Resources.CLOSE_MSG);
                    break;
                default:
                    break;
            }
        }

        private void SetUpColorDev(int Command, string Msg)
        {
            XM_Ini_Util XmIni = new XM_Ini_Util(Setting.ExeSysIniPath);
            string LightDev = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.COLORDEV);
            string CommPort = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.COMPORT);
            string CommBaudRate = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.BAUDRATE);
            string CommDatabit = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.DATABIT);
            string CommParity = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.PARITY);
            string CommStopBits = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.STOPBIT);
            if (!int.TryParse(LightDev, out int LightTmp)) return;
            if (LightTmp == 0) SetUpKleinDev(Command, CommPort);
            if (LightTmp == 1) SetUpKonicaDev(Command, CommPort, CommBaudRate, CommDatabit, CommParity, CommStopBits);
        }

        private void ShowResult(RichTextBox rtfResult, string title, string ResultInfo)
        {
            if (!String.IsNullOrEmpty(ResultInfo))
            {
                foreach (string Line in ResultInfo.Split(DelimiterChars[4]))
                {
                    string[] Token = Line.Split(DelimiterChars);
                    if (Token[0] == WARNING)
                        rtfResult.SelectionColor = Color.Green;
                    else if (Token[0] == ERRMSG)
                        rtfResult.SelectionColor = Color.Red;
                    else
                        rtfResult.SelectionColor = Color.Black;

                    rtfResult.AppendText(Line);
                }
            }
            if (!String.IsNullOrEmpty(title)) rtfResult.AppendText(title);
            rtfResult.ScrollToCaret();
        }

        private void SetUpKleinDev(int Command, string CommPort)
        {
            string Comm = System.Text.RegularExpressions.Regex.Replace(CommPort, @"[^0-9]+", "");
            if (!int.TryParse(Comm, out int CommNum)) return ;
            switch (Command)
            {
                case 0:
                    kClmtr.closePort();
                    rtf_ElecsMsg.Text = "K-80 Closed";
                    Main_Form.frmMain.InvokeColorDev("Close");
                    kClmtr = null;
                    break;
                case 1:
                    kClmtr = new KClmtrWrap
                    {
                        port = CommNum
                    };
                    if (kClmtr.connect())
                    {
                        Main_Form.frmMain.InvokeColorDev("Open");
                        ExeCmd.SetKleinDev(ref kClmtr);
                    }
                    else
                        Main_Form.frmMain.InvokeColorDev("Close");
                    break;
                default:
                    break;
            }
        }

        private void SetUpKonicaDev(int Command,string CommPort, string CommBaudRate, string CommDatabit, string CommParity, string CommStopBits)
        {
            switch (Command)
            {
                case 0:
                    if (ColorDev != null && ColorDev.IsCommOpen()) ColorDev.CommClose();
                    rtf_ElecsMsg.Text = "CA-210 Closed";
                    Main_Form.frmMain.InvokeColorDev(Properties.Resources.CLOSE_MSG);
                    ColorDev = null;
                    break;
                case 1:
                    ColorDev = new XM_EquipVisa_Util(CommPort, CommBaudRate, CommDatabit, CommParity, CommStopBits);
                    if (ColorDev.CommOpen())
                    {
                        Main_Form.frmMain.InvokeColorDev(Properties.Resources.OPEN_MSG);
                        ExeCmd.SetKonicaDev(ref ColorDev);
                    }
                    else
                        Main_Form.frmMain.InvokeColorDev(Properties.Resources.CLOSE_MSG);
                    break;
                default:
                    break;
            }
        }

        private void Btn_CommOpen_Click(object sender, EventArgs e)
        {
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];

            int Start = FastRichBox.Selection.Start.iLine;
            int End = FastRichBox.Selection.End.iLine;
            FastRichBox.RemoveLinePrefix("#");
        }

        private void Btn_LoadSpt_Click(object sender, EventArgs e)
        {
            LoadTxtFromFile();
        }
        /*
         * Return String : User Select Command or All Commands
        */
        private string WorthXmCmd(FastColoredTextBox ColoredCmdBox, ref bool bAll)
        {
            string innerTxt = null;
            int Temp = 0;
            Range SeletionRange = null;
            if (ColoredCmdBox.SelectionLength > 0)
            {
                int Start = ColoredCmdBox.Selection.Start.iLine;
                int End = ColoredCmdBox.Selection.End.iLine;

                if (Start > End) { Temp = End; End = Start; Start = Temp; }
                int Len = ColoredCmdBox.Lines[End].Length;
                SeletionRange = ColoredCmdBox.Selection;
                SeletionRange.Start = new Place(0, Start);
                SeletionRange.End = new Place(Len, End);
                ColoredCmdBox.Selection = SeletionRange;

                innerTxt = ColoredCmdBox.SelectedText;
                Main_Form.frmMain.InvokeSelInfo(SELMODE);
                Log.W(innerTxt);
                bAll = false;
            }
            else
            {
                innerTxt = ColoredCmdBox.Text;
                Main_Form.frmMain.InvokeSelInfo(NORMALMODE);
            }
            return innerTxt;
        }

        private bool ShowContinueDialog()
        {
            bool ret = true;
            string message = "Error,Would you continue to run it? \r\n (Yes: continue    No: Stop to modify)";
            string caption = "Warning!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            MessageBoxIcon Icon = MessageBoxIcon.Warning;
            result = MessageBox.Show(this, message, caption, buttons, Icon);
            if (result == DialogResult.Yes)
                ret = true;
            else
                ret = false;
            return ret;
        }

        private void PaintCmdColor(FastColoredTextBox rtfcmd, byte Result, int Line)
        {
            switch (Result)
            {
                case (byte)XM_Cmd_Lib.MSG.PASS:
                    rtfcmd[Line].BackgroundBrush = Brushes.White;
                    break;
                case (byte)XM_Cmd_Lib.MSG.ERRCMD:
                    rtfcmd[Line].BackgroundBrush = Brushes.LightPink;
                    break;
                case (byte)XM_Cmd_Lib.MSG.ERRPARM:
                    rtfcmd[Line].BackgroundBrush = Brushes.LightPink;
                    break;
                case (byte)XM_Cmd_Lib.MSG.WARN:
                    rtfcmd[Line].BackgroundBrush = Brushes.White;
                    break;
                case (byte)XM_Cmd_Lib.MSG.ERRFOR:
                    rtfcmd[Line].BackgroundBrush = Brushes.LightPink;
                    break;
                default:
                    rtfcmd[Line].BackgroundBrush = Brushes.White;
                    break;
            }
        }
        /*
         * If in Error pool, it mark to red.
         */
        private bool DealWithXmCmds(FastColoredTextBox RtfCmd, ref List<ScriptInfo> CmdInfo)
        {
            bool bErr = true;

            for (int i = 0; i < CmdInfo.Count; i++)
            {
                switch (CmdInfo[i].Result)
                {
                    case (byte)XM_Cmd_Lib.MSG.PASS:
                        PaintCmdColor(RtfCmd, (byte)XM_Cmd_Lib.MSG.PASS, i);
                        break;
                    case (byte)XM_Cmd_Lib.MSG.WARN:
                        PaintCmdColor(RtfCmd, (byte)XM_Cmd_Lib.MSG.WARN, i);
                        break;
                    case (byte)XM_Cmd_Lib.MSG.COMMENT:
                        PaintCmdColor(RtfCmd, (byte)XM_Cmd_Lib.MSG.COMMENT, i);
                        break;
                    case (byte)XM_Cmd_Lib.MSG.ERRCMD:
                        PaintCmdColor(RtfCmd, (byte)XM_Cmd_Lib.MSG.ERRCMD, i);
                        bErr = false;
                        break;
                    case (byte)XM_Cmd_Lib.MSG.ERRPARM:
                        PaintCmdColor(RtfCmd, (byte)XM_Cmd_Lib.MSG.ERRPARM, i);
                        bErr = false;
                        break;
                    case (byte)XM_Cmd_Lib.MSG.ERRFOR:
                        PaintCmdColor(RtfCmd, (byte)XM_Cmd_Lib.MSG.ERRFOR, i);
                        bErr = false;
                        break;
                    case (byte)XM_Cmd_Lib.MSG.SPACE:
                        PaintCmdColor(RtfCmd, (byte)XM_Cmd_Lib.MSG.COMMENT, i);
                        break;
                    default:
                        PaintCmdColor(RtfCmd, (byte)XM_Cmd_Lib.MSG.COMMENT, i);
                        break;
                }
            }
            return bErr;
        }
        private bool UsbConn()
        {
            bool bWhiskey = true;
            byte[] sysinfo = new byte[3];
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x02, 0x00);
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x00, sysinfo, 3);
            bWhiskey = sysinfo[0] == 0x16 && sysinfo[1] == 0x11 && sysinfo[2] == 0x29;
            if (!bWhiskey)Main_Form.frmMain.ClrUsbCon();
            return bWhiskey;
        }
        private bool ExeStatus(FastColoredTextBox FastColoredTxtBox)
        {
            bool ret = true;

            if (Btn_CommSend.Text == BTNSEND)
            {
                ExeCmd.RunInfo.FoundLoopList.Clear();
                ExeCmd.RunInfo.RealExeLine = 0;
                ExeCmd.RunInfo.RunLoop = null;
                ExeCmd.RunInfo.RunLoopList.Clear();
                FastColoredTxtBox.Focus();
                Btn_CommSend.Text = BTNSTOP;
                bStopRun = false;
            }
            else
            {
                Btn_CommSend.Text = BTNSEND;
                if (XmThead != null && XmThead.IsAlive) { bStopRun = true; XmThead.Abort(); }
                ret = false;
            }
            //if (!UsbConn()) ret = false;
            return ret;
        }
        private void Btn_CommSend_Click(object sender, EventArgs e)
        {
            SendXmCmd();
        }
        private void FibForLoop()
        {
            bool ret = true;
            string RdStr = null;
            ScriptInfo[] RunSptInfo = new ScriptInfo[ExeCmd.RunInfo.RunLoop.EndLine - ExeCmd.RunInfo.RunLoop.StartLine - 1];
            Array.Copy(ExeCmd.RunInfo.lScriptInfo.ToArray(), ExeCmd.RunInfo.RunLoop.StartLine + 1, RunSptInfo, 0, ExeCmd.RunInfo.RunLoop.EndLine - ExeCmd.RunInfo.RunLoop.StartLine - 1);
            if (ExeCmd.RunInfo.RunLoop.Formula.CompareTo("plus") == 0)
            {
                for (int i = ExeCmd.RunInfo.RunLoop.LoopStart; i <= ExeCmd.RunInfo.RunLoop.LoopEnd; i += ExeCmd.RunInfo.RunLoop.LoopStep)
                {
                    ExeCmd.RunInfo.RunLoopList[ExeCmd.RunInfo.RunLoopList.Count - 1].Index = i;
                    for (int j = 0; j < RunSptInfo.Length; j++)
                    {
                        if (ExeCmd.ExamCmd(RunSptInfo[j]))
                        {
                            ret = ExeCmd.ExcuteCmd(ExeCmd.GetXmCmd(), ExeCmd.GetXmClass(), ref RdStr);
                            if (Setting.TxCmd && ExeCmd.RunInfo.XmCmdInfo.Excute) InvokeTxMsg(j + 1, ExeCmd.RunInfo.XmCmdInfo.XmCmd);
                            DealWithSystemCmd(ExeCmd, j + 1, ref RdStr, ref XmStr);
                            if (ExeCmd.IsEndLoopCmd() && ExeCmd.CompleteLoop())
                            {
                                FibForLoop();
                                ExeCmd.RunInfo.RunLoop = ExeCmd.RunInfo.RunLoopList[ExeCmd.RunInfo.RunLoopList.Count - 1];
                            }
                            if (ExeCmd.IsPauseCmd()) { ExeCmd.SetPause(false); if (bStopRun) break; };//Check and Stop Running

                        }
                        Main_Form.frmMain.InvokePrgbPos(j + 1);
                    }
                    if (bStopRun) break;
                }
            }
            else
            {
				for (int i = ExeCmd.RunInfo.RunLoop.LoopStart; i >= ExeCmd.RunInfo.RunLoop.LoopEnd; i -= ExeCmd.RunInfo.RunLoop.LoopStep)
                {
                    ExeCmd.RunInfo.RunLoopList[ExeCmd.RunInfo.RunLoopList.Count - 1].Index = i;
                    for (int j = 0; j < RunSptInfo.Length; j++)
                    {
                        if (ExeCmd.ExamCmd(RunSptInfo[j]))
                        {
                            ret = ExeCmd.ExcuteCmd(ExeCmd.GetXmCmd(), ExeCmd.GetXmClass(), ref RdStr);
                            if (Setting.TxCmd && ExeCmd.RunInfo.XmCmdInfo.Excute) InvokeTxMsg(j + 1, ExeCmd.RunInfo.XmCmdInfo.XmCmd);
                            DealWithSystemCmd(ExeCmd, j + 1, ref RdStr, ref XmStr);
                            if (ExeCmd.IsEndLoopCmd() && ExeCmd.CompleteLoop())
                            {
                                FibForLoop();
                                ExeCmd.RunInfo.RunLoop = ExeCmd.RunInfo.RunLoopList[ExeCmd.RunInfo.RunLoopList.Count - 1];
                            }
                            if (ExeCmd.IsPauseCmd()) { ExeCmd.SetPause(false); if (bStopRun) break; };//Check and Stop Running

                        }
                        Main_Form.frmMain.InvokePrgbPos(j + 1);
                    }
                    if (bStopRun) break;
                }
            }
            ExeCmd.RunInfo.RunLoop = null;
            ExeCmd.RunInfo.RunLoopList.RemoveAt(ExeCmd.RunInfo.RunLoopList.Count - 1);
        }

        private void Run(object d)
        {
            bool ret = true;
            string RdStr = null;
            XmCmd XMCmds = (XmCmd)d;

            Main_Form.frmMain.InvokePrgbMax(XMCmds.lScriptInfo.Count);
            ExeCmd.RunInfo.lScriptInfo = XMCmds.lScriptInfo;

            for (int i = 0; i < XMCmds.lScriptInfo.Count; i++)
            {
                if (ExeCmd.ExamCmd(XMCmds.lScriptInfo[i]))
                {
                    ret = ExeCmd.ExcuteCmd(ExeCmd.GetXmCmd(), ExeCmd.GetXmClass(), ref RdStr);
                    if (Setting.TxCmd && ExeCmd.RunInfo.XmCmdInfo.Excute) InvokeTxMsg(i + 1, ExeCmd.RunInfo.XmCmdInfo.XmCmd);
                    DealWithSystemCmd(ExeCmd, i + 1, ref RdStr, ref XmStr);
                    if (ExeCmd.IsEndLoopCmd() && ExeCmd.CompleteLoop()) FibForLoop();
                    if (ExeCmd.IsPauseCmd()) { ExeCmd.SetPause(false); if (bStopRun) break; }; //Check and Stop Running
                }
                Main_Form.frmMain.InvokePrgbPos(i + 1);
                if (bStopRun) break;
            }
            InvokeSend(0, BTNSEND);
            if (!String.IsNullOrEmpty(XmStr))
            {
                XmStr = string.Concat(XmStr, "Process Finished");
                InvokeShowStr(0, XmStr);
                XmStr = null;
            }

            if (XM_SDCard_Util.EnaSDCardGen == true)
            {
                AppendImageNum();
                // if script command only image.show at last.
                if (XM_SDCard_Util.EnaSDImageGen)
                {
                    SaveSDCardBin(XM_SDCard_Util.CmdToBin, SAVELOG, true);
                    XM_SDCard_Util.EnaSDImageGen = false;
                }
                else  { SaveSDCardBin(XM_SDCard_Util.CmdToBin, SAVELOG, false); }

                XM_SDCard_Util.ImageNum = 0;
                XM_SDCard_Util.EnaSDCardGen = false;
                XM_Comm_Control.XM_Comm_Base = XM_Comm_Control.XM_Comm_Type[1];
            }
        }
        private void AppendImageNum()
        {
            if (XM_SDCard_Util.EnaSDCardGen == true)
            {
                XM_SDCard_Util.ImageNum += 1;
                // Due to MicroSD Block have 512 Bytes,  CmdToBin.Count need to be divisible by 512.
                if (XM_SDCard_Util.CmdToBin.Count % 512 != 0)
                {
                    int debugtest = 512 - (XM_SDCard_Util.CmdToBin.Count % 512);
                    for (uint i = 0; i < debugtest; i++)
                    {
                        XM_SDCard_Util.CmdToBin.Add(0x00);
                    }
                }
            }
        }

        private void SaveSDCardBin(List<byte> TempData, string FileName, bool AutoSave)
        {
            int Blocks = 0;
            string StringTemp = "";
            int Execute_Num = 0;
            ArrayList StringList = new ArrayList();
            XM_IO_Util IO_Util = new XM_IO_Util();
            int Remainder = 0;
            Remainder = (TempData.Count % 16) != 0 ? (16 - TempData.Count % 16) : 0;
            Execute_Num = TempData.Count + Remainder;
            Blocks = Execute_Num % 512 == 0 ? Execute_Num / 512 : Execute_Num / 512 + 1;

            //in order to Keep Document alway exist.
            if (!File.Exists(Setting.ExeSDCardDirPath))
            {
                IO_Util.CreateDir(Setting.ExeSDCardDirPath);
            }

            if (!AutoSave)
            {
                SaveFileDialog SaveFile = new SaveFileDialog()
                {
                    FileName = FileName,
                    Filter = "Text File | *.txt",
                    InitialDirectory = Setting.ExeSDCardDirPath,
                };
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < Execute_Num; i++)
                    {
                        if (i < TempData.Count)
                        {
                            StringTemp += string.Format("0x" + TempData[i].ToString("X02")) + " ";
                        }
                        else
                        { StringTemp += "0x00 "; }
                        if (((i + 1) % 16 == 0))
                        {
                            // StringTemp += "\r\n";
                            StringList.Add(StringTemp);
                            StringTemp = "";
                        }
                    }
                    if (File.Exists(SaveFile.FileName))
                    {
                        IO_Util.FileDelete(SaveFile.FileName);
                    }
                    IO_Util.OutputTxt(SaveFile.FileName, StringList);
                    // StringList.Clear();
                    InvokeShowStr(0, "SDCard Data Conver to Bin File and Save it Successfully!!");
                }
            }
            else
            {
                for (int i = 0; i < Execute_Num; i++)
                {
                    if (i < TempData.Count)
                    {
                        StringTemp += string.Format("0x" + TempData[i].ToString("X02")) + " ";
                    }
                    else
                    { StringTemp += "0x00 "; }
                    if (((i + 1) % 16 == 0))
                    {
                        // StringTemp += "\r\n";
                        StringList.Add(StringTemp);
                        StringTemp = "";
                    }
                }

                if (File.Exists(XM_SDCard_Util.ImageFileName))
                {
                    IO_Util.FileDelete(XM_SDCard_Util.ImageFileName);

                }
                IO_Util.OutputTxt(XM_SDCard_Util.ImageFileName, StringList);

                // StringList.Clear();
                InvokeShowStr(0, "SDCard Data Conver to Bin File and Save it Successfully!!");


            }
            StringList.Clear();
            XM_SDCard_Util.CmdToBin.Clear();
        }



        private void DealWithSystemCmd(XM_ExeMainCmd ExeCmd, int Line, ref string RdStr, ref string XmStr)
        {
            if (ExeCmd.RunInfo.XmCmdInfo.Excute && ExeCmd.IsPauseCmd()) { InvokePause(Line, ExeCmd.RunInfo.XmCmdInfo.XmCmd); }
            if (ExeCmd.RunInfo.XmCmdInfo.Excute && ExeCmd.IsScopeCmd()) InvokeScope(Line, ExeCmd.RunInfo.XmCmdInfo.XmCmd);
            if (ExeCmd.RunInfo.XmCmdInfo.Excute && ExeCmd.IsGammaCmd()) InvokeGamma(Line, ExeCmd.RunInfo.XmCmdInfo.XmCmd);
            if (ExeCmd.RunInfo.XmCmdInfo.Excute && !string.IsNullOrEmpty(RdStr)) { XmStr += String.Format("Read[{0}]: {1}\n", Line, RdStr); }
            RdStr = null;
        }

        private void SendXmCmd()
        {
            string[] CmdLines = null;
            bool ret = true, bAllCmd = true;
            string ErrInfo = null;
            List<ScriptInfo> lScriptInfo = new List<ScriptInfo>();
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];
            /*Verify USB Connection*/
            if (!ExeStatus(FastRichBox)) { MessageBox.Show("Stop Running!"); Btn_CommSend.Text = BTNSEND; return; }
            /*Selection or All*/
            CmdLines = WorthXmCmd(FastRichBox, ref bAllCmd).Split(DelimiterChars[4]);
            /*Verify and Exam Command*/
            ErrInfo = ExeCmd.ExamScript(CmdLines, lScriptInfo);
            /*Deal With Error And Present*/
            if (bAllCmd && !DealWithXmCmds(FastRichBox, ref lScriptInfo)) { FastRichBox.Focus(); ret = ShowContinueDialog(); }
            if (Setting.CmdMsg) rtf_ElecsMsg.Text = ErrInfo;

            if (ret)
            {
                XmCmd XMCmds = new XmCmd(lScriptInfo);
                XmThead = new Thread(new ParameterizedThreadStart(Run))
                {
                    IsBackground = true
                };
                XmThead.Start(XMCmds);
            }
            else
                ExeStatus(FastRichBox);
        }

        private void SDCardGenXmCmd()
        {
            XM_SDCard_Util.EnaSDCardGen = true;
            XM_Comm_Control.XM_Comm_Base = XM_Comm_Control.XM_Comm_Type[0];

            string[] CmdLines = null;
            bool ret = true, bAllCmd = true;
            string ErrInfo = null;
            List<ScriptInfo> lScriptInfo = new List<ScriptInfo>();
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];

            /*Selection or All*/
            CmdLines = WorthXmCmd(FastRichBox, ref bAllCmd).Split(DelimiterChars[4]);
            /*Verify and Exam Command*/
            ErrInfo = ExeCmd.ExamScript(CmdLines, lScriptInfo);
            /*Deal With Error And Present*/
            if (bAllCmd && !DealWithXmCmds(FastRichBox, ref lScriptInfo)) { FastRichBox.Focus(); ret = ShowContinueDialog(); }
            if (Setting.CmdMsg) rtf_ElecsMsg.Text = ErrInfo;

            int Image_num = 0;
            if (!ExeCmd.ExamScript(CmdLines, lScriptInfo, ref Image_num))
            {
                XM_Sytem_API.FindAndMoveMsgBox("Main_Form", "Error Generate", true);
                MessageBox.Show("Error Cmd in this Script to Generator MicroSD Download File!", "Error Generate");
            }
            else
            {
                if (ret)
                {
                    XmCmd XMCmds = new XmCmd(lScriptInfo);
                    XmThead = new Thread(new ParameterizedThreadStart(Run))
                    {
                        IsBackground = true
                    };
                    // Must to set ApartmentState.STA for SaveFile.
                    XmThead.SetApartmentState(ApartmentState.STA);
                    XmThead.Start(XMCmds);
                }
                else
                    ExeStatus(FastRichBox);
            }
        }

        private void DealWithShowMsg(int line, bool Result, string rdStr, ref string rdResult)
        {
            if (!String.IsNullOrEmpty(rdStr)) rdResult += (Result) ? ExeCmd.ReadInfo(line + 1, rdStr) : ExeCmd.ErrResult(rdStr, line + 1);
            if (Setting.TxCmd)
            {
                //rtf_ElecsMsg.Text += "Line[" + (line + 1).ToString() + "]" + ExeCmd.GetFullCmd() + "...Send\n";
                rtf_ElecsMsg.Text += String.Format("Line[{0}] {1}...Send\n", (line + 1), ExeCmd.GetFullCmd());
                rtf_ElecsMsg.SelectionStart = rtf_ElecsMsg.Text.Length;
                rtf_ElecsMsg.ScrollToCaret();
            }
            Application.DoEvents();
        }


        private void DealWithSysCmd(int Line, bool bloadCmd)
        {
            //Pause Command
            if (ExeCmd.IsPauseCmd())
            {
                string[] Cmds = ExeCmd.GetXmCmd().Split(DelimiterChars);
                string Temp = "Line: " + (Line + 1).ToString() + " Msg: " + Cmds[1];
                DialogResult myResult = MessageBox.Show(Temp, "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ExeCmd.SetPause(myResult == DialogResult.Yes ? true : false);
            }

            //Scope Command
            if (ExeCmd.IsScopeCmd())
            {
                new Scope_Form().ShowDialog();
                ExeCmd.SetScope(false);
            }

            //Gamma Tool
            if (ExeCmd.IsGammaCmd())
            {
                new XmGammaTool().Show();
                ExeCmd.SetGamma(false);
            }

            Application.DoEvents();
        }

        private void InstrumentInfo()
        {
            string[] EquitDev = new string[100];

            XM_EquipVisa = new XM_EquipVisa_Util();
            string InstruCmd = "*IDN?", RdStr = null;
            int Count = 0;
            EquitDeves.Clear();
            XM_EquipVisa.Find_MeasureResource(EquitDev, out uint DevNum);
            string[] SystemPorts = SerialPort.GetPortNames();
            if ((DevNum + SystemPorts.Length) == 0) return; // Deal With No Device

            Array.Resize(ref EquitDev, (int)DevNum);
            XM_EquipVisa_Util.EquitDevice[] EuqitDevices = new XM_EquipVisa_Util.EquitDevice[DevNum + SystemPorts.Length];
            for (int i = 0; i < EuqitDevices.Length; i++) EuqitDevices[i] = new XM_EquipVisa_Util.EquitDevice();

            Main_Form.frmMain.InvokePrgbMax(100);

            //Scan Keysight IO Lib
            for (int i = 0; i < DevNum; i++)
            {
                EuqitDevices[i].VisaName = EquitDev[i];
                if (EuqitDevices[i].VisaName.Contains("USB"))
                    EuqitDevices[i].Type = "USB";

                if (EuqitDevices[i].VisaName.Contains("ASRL"))
                {
                    EuqitDevices[i].Type = "Comm";
                    string[] SplitStr = EuqitDevices[i].VisaName.Split(':');
                    EuqitDevices[i].CommName = "COM" + SplitStr[0].Substring(4);
                }
            }

            //Scan System Comport 
            for (int i = 0; i < SystemPorts.Length; i++)
            {
                for (int j = Count = 0; j < EuqitDevices.Length; j++)
                {
                    if (SystemPorts[i].CompareTo(EuqitDevices[j].CommName) == 0)
                    {
                        if (String.IsNullOrEmpty(EuqitDevices[j].VisaName) && String.IsNullOrEmpty(EuqitDevices[j].CommName))
                        {
                            EuqitDevices[j].CommName = SystemPorts[i];
                            EuqitDevices[j].Speed = 0;
                            EuqitDevices[j].VisaFlag = false;
                            break;
                        }
                    }
                }
            }

            for (int i = Count = 0; i < EuqitDevices.Length; i++)
            {
                Count += 100 / EuqitDevices.Length;
                Main_Form.frmMain.InvokePrgbPos(Count);
                if (string.IsNullOrEmpty(EuqitDevices[i].CommName) && string.IsNullOrEmpty(EuqitDevices[i].VisaName)) continue;

                XM_EquipVisa = new XM_EquipVisa_Util(EuqitDevices[i].VisaName);
                //XM_EquipVisa.SetTimeoutSeconds("1");//3sec
                int nViStatus = XM_EquipVisa.VisaSendandRead(InstruCmd, out RdStr);
                string[] Msg = RdStr.Split(DelimiterChars[1]);
                //if (Msg !=null && Msg.Length > 1)
                if (nViStatus == 0)
                {
                    EuqitDevices[i].Message = Msg[1];
                    EquitDeves.Add(EuqitDevices[i]);
                }
                XM_EquipVisa.VisaClose();

            }
            Main_Form.frmMain.InvokePrgbPos(100);
            InvokeXmInstru(0, null);
        }

        //Clear 
        private void ScriptSetting_Form_Load(object sender, EventArgs e)
        {
            AddCmdPages();
        }

        private void Tsmi_CmdClear_Click(object sender, EventArgs e)
        {
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];
            DialogResult dialogResult = MessageBox.Show("Sure?", "Clear Text", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FastRichBox.Clear();
            }

        }

        private void Tsmi_MsgClear_Click(object sender, EventArgs e)
        {
            rtf_ElecsMsg.Clear();
        }

        private string SaveScript(string Text, string FileName)
        {
            SaveFileDialog SaveFile = new SaveFileDialog()
            {
                FileName = FileName,
                Filter = "Text File | *.txt",
                InitialDirectory = Setting.ExeSptDirPath,
            };

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(SaveFile.OpenFile());
                writer.Write(Text);
                writer.Dispose();
                writer.Close();
                MessageBox.Show("Save File Successfully");
            }

            return Path.GetFileName(SaveFile.FileName);
        }

       

       

        private void Tsmi_CmdPaste_Click(object sender, EventArgs e)
        {
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];
            FastRichBox.Paste();
        }

        private void Tsmi_CmdSaveAs_Click(object sender, EventArgs e)
        {
            SaveAsRichTxt();
        }

        private void Tsmi_MsgSaveAs_Click(object sender, EventArgs e)
        {
            SaveScript(rtf_ElecsMsg.Text, SAVELOG);
        }


        private void Trv_instru_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];
            if (e.Node.Parent == null)
            {
                FastRichBox.SelectedText = e.Node.Text;
                FastRichBox.Focus();
            }
        }

        private void Tsmi_CmdCopy_Click(object sender, EventArgs e)
        {
            CopyfromRichTxt();
        }

        private void Tsmi_MsgCopy_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string line in rtf_ElecsMsg.Lines)
                sb.AppendLine(line);

            Clipboard.SetText(sb.ToString());
        }

        private void Tsmi_CmdSend_Click(object sender, EventArgs e)
        {
            SendXmCmd();
        }
        
        private void SDCardGen_Click(object sender, EventArgs e)
        {         
            SDCardGenXmCmd();
        }

        private void RichTextBox_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            FastColoredTextBox FastRichBox = (FastColoredTextBox)sender;
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle,  MagentaStyle, GreenStyle, BrownStyle, BlackStyle);
            e.ChangedRange.SetStyle(GreenStyle, @"#.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\b0x[a-fA-F\d]+\b");
            e.ChangedRange.SetStyle(BrownStyle, @"\b[\d]+\b");
            e.ChangedRange.SetStyle(BlueStyle, @"\b[\w]+[\.]+bmp\b|\b[\w]+[\.]+png\b|\b[\w]+[\.]+jpg\b");
            e.ChangedRange.ClearFoldingMarkers();
        }



        private void Tctl_Pages_MouseClick(object sender, MouseEventArgs e)
        {
            XM_PageInfo_Util PageUtil = new XM_PageInfo_Util();
            for (int i = 0; i < Tctl_Pages.TabCount; i++)
            {
                // giong o DrawItem
                Rectangle rect = Tctl_Pages.GetTabRect(i);
                Rectangle imageRec = new Rectangle(rect.Right - CloseImage.Width,
                    rect.Top + (rect.Height - CloseImage.Height) / 2,
                    CloseImage.Width, CloseImage.Height);

                if (imageRec.Contains(e.Location))
                {
                    PageUtil.RemovePagetoList(lCmdInfo, Tctl_Pages.SelectedTab.Text);
                    Tctl_Pages.TabPages.Remove(Tctl_Pages.SelectedTab);
                }
            }
        }

        private void CommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];
            FastRichBox.InsertLinePrefix("#");

        }

        private void UnCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];
            FastRichBox.RemoveLinePrefix("#");
        }

        private void Tctl_Pages_DrawItem(object sender, DrawItemEventArgs e)
        {
            // minh viet san, khoi mat thoi gian
            Rectangle rect = Tctl_Pages.GetTabRect(e.Index);
            Rectangle imageRec = new Rectangle(rect.Right - CloseImage.Width,
                rect.Top + (rect.Height - CloseImage.Height) / 2,
                CloseImage.Width, CloseImage.Height);
            // tang size rect
            rect.Size = new Size(rect.Width + 20, 38);

            Font f;
            Brush br = Brushes.Black;
            StringFormat strF = new StringFormat(StringFormat.GenericDefault);
            // neu tab dang duoc chon
            if (Tctl_Pages.SelectedTab == Tctl_Pages.TabPages[e.Index])
            {
                // hinh mau do, hinh nay them tu properti
                e.Graphics.DrawImage(CloseImageAct, imageRec);
                f = new Font("Arial", 10, FontStyle.Bold);
                // Ten tabPage
                e.Graphics.DrawString(Tctl_Pages.TabPages[e.Index].Text,
                    f, br, rect, strF);
            }
            else
            {
                // Tap dang mo, nhung ko dc chon, hinh mau den
                e.Graphics.DrawImage(CloseImage, imageRec);
                f = new Font("Arial", 9, FontStyle.Regular);
                // Ten tabPage
                e.Graphics.DrawString(Tctl_Pages.TabPages[e.Index].Text,
                    f, br, rect, strF);
            }
        }

        private void IfSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCmdPages();
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];
            InterfaceSetting_Form IfForm = new InterfaceSetting_Form((byte)SetIfType);
            IfForm.ShowDialog();       
            FastRichBox.Text = Clipboard.GetText();

        }
        private void Btn_DelTabs_Click(object sender, EventArgs e)
        {
            SubCmdPages();
        }

        private void Btn_CtrlCenter_Click(object sender, EventArgs e)
        {
            Setting_Form SetCenter = new Setting_Form();
            SetCenter.ShowDialog();
        }

        private void Btn_AddPage_Click(object sender, EventArgs e)
        {
            AddCmdPages();
        }

        private void Btn_CloseAll_Click(object sender, EventArgs e)
        {
            Tctl_Pages.TabPages.Clear();
            TabCount = 0;
            lCmdInfo.Clear();
        }

        private void Btn_CommClose_Click(object sender, EventArgs e)
        {
            Epp2USB.GLWriteEPPAddressPort(0xfc);
            Epp2USB.GLWriteEPPDataPort(0xff);
        }

        private void Tctl_Pages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tctl_Pages.TabCount > 0)
            {
                string PageName = Tctl_Pages.SelectedTab.Text; 
                XmCmdList CmdList = lCmdInfo.Find(x => x.Name.Equals(Tctl_Pages.SelectedTab.Text));
                Main_Form.frmMain.InvokeSptName(CmdList.FileName);
            }
        }

        private void SubCmdPages()
        {
            if (Tctl_Pages.TabCount > 0 && Tctl_Pages.SelectedIndex > -1)
            {
                XM_PageInfo_Util PageUtil = new XM_PageInfo_Util();
                int record = Tctl_Pages.SelectedIndex - 1;
                PageUtil.RemovePagetoList(lCmdInfo, Tctl_Pages.SelectedTab.Text);               
                FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];
                Tctl_Pages.TabPages.Remove(Tctl_Pages.SelectedTab);
                if (record > -1) Tctl_Pages.SelectedIndex = record;  //restore to one before
            }
        }

        private void AddCmdPages()
        {
            XM_PageInfo_Util PageUtil = new XM_PageInfo_Util();
            int index = PageUtil.AddPagetoList(lCmdInfo);
         
            var newTabPage = new TabPage()
            {
                Text = "Page" + index.ToString(),
                Name = "Page" + index.ToString()
            };

            Tctl_Pages.TabPages.Add(newTabPage);

            var RichTextBox = new FastColoredTextBox()
            {
                Dock = DockStyle.Fill,
                Name = "FastColoredText",
                ContextMenuStrip = cms_elecscmd,                
            };

            RichTextBox.TextChanged += RichTextBox_TextChanged;
            newTabPage.Controls.Add(RichTextBox);
            TabCount = Tctl_Pages.TabCount;
            Tctl_Pages.SelectedTab = newTabPage;
        }

        private void Btn_Scan_Click(object sender, EventArgs e)
        {
            trv_instru.Nodes.Clear();
            Thread Thread_Scan = new Thread(InstrumentInfo)
            {
                IsBackground = true
            };
            Thread_Scan.Start();
        }

        private void SaveAsRichTxt()
        {
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];
            string FileName = SaveScript(FastRichBox.Text, lCmdInfo[Tctl_Pages.SelectedIndex].FileName);
            lCmdInfo[Tctl_Pages.SelectedIndex].FileName = FileName;
            Main_Form.frmMain.InvokeSptName(FileName);
        }

        private void CopyfromRichTxt()
        {
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];
            string InnerCmds = (FastRichBox.Selection.Text.Length == 0) ? FastRichBox.Text : FastRichBox.Selection.Text;
            Clipboard.SetText(InnerCmds);
        }

        private void LoadTxtFromFile()
        {
            XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSysIniPath);
            string FilePath = IniUtil.IniReadValue("System", "ScriptDir");
            FilePath = (FilePath == "NULL") ? Setting.ExeSptDirPath : FilePath;
            XM_PageInfo_Util PageUtil = new XM_PageInfo_Util();

            OpenFileDialog ScreenSpt = new OpenFileDialog
            {
                FileName = "AutoScript.txt",
                Filter = "Text Files|*.txt|*.text|*.spt",
                InitialDirectory = FilePath,
                DefaultExt = "*.txt"
            };

            if (ScreenSpt.ShowDialog() == DialogResult.OK)
            {
                AddCmdPages();
                FastColoredTextBox FastRichBox = (FastColoredTextBox)Tctl_Pages.TabPages[Tctl_Pages.SelectedIndex].Controls["FastColoredText"];
                FastRichBox.Focus(); //Clear Selection
                FastRichBox.OpenFile(ScreenSpt.FileName);
                ShowResult(rtf_ElecsMsg, "Read From ..." + ScreenSpt.FileName + "\n", null);
                Main_Form.frmMain.InvokeSptName(Path.GetFileName(ScreenSpt.FileName));
                IniUtil.IniWriteValue("System", "ScriptDir", Path.GetDirectoryName(ScreenSpt.FileName));
                //Record Script Name
                PageUtil.UpdateFileToList(lCmdInfo, Tctl_Pages.SelectedTab.Text, Path.GetFileName(ScreenSpt.FileName));
                FastRichBox.ClearSelected();
            }
            rtf_ElecsMsg.Clear();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                SendXmCmd();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                SaveAsRichTxt();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.L))
            {
                LoadTxtFromFile();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Add))
            {
                AddCmdPages();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Subtract))
            {
                SubCmdPages();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    public class XmCmd
    {
        public List<ScriptInfo> lScriptInfo;
        public XmCmd(List<ScriptInfo> ListCmds)
        {
            //XmExeCmd = ExeCmd;
            lScriptInfo = ListCmds;
        }
    }
}


