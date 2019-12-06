
using DataGridViewNumericUpDownElements;
using KClmtrBase.KClmtrWrapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public partial class XmGammaTool : Form
    {
        public XM_EquipVisa_Util KonicaDev;
        public KClmtrWrap kClmtr;
        public XM_ExeWol_Util XmUtil = new XM_ExeWol_Util();
        public XmGamma[] XmGammaVal = new XmGamma[MAX_GRAYLEVEL];
        private int ColorDevIndex = 0;
        private const int TestNum = 5;
        private float MinSpec = 0, MaxSpec = 0;
        private readonly string KonicaMeasure = "ca210.xfer MES";
        private readonly string KleinMeasure = "k80.bright.read";
        private string _IniPath = null;
        private string _ExpTxt = null;
        private string _SptPath = null;
        private string _ImgPath;
        private XM_ExeMainCmd GammaExeCmd = null;
        private readonly string[] ImageCmds = new string[512];
        private const int MAX_GRAYLEVEL = 256;
        private const string GAMMACURVE = "Curve";
        private const string GAMMASPEC = "Spec";
        private const string INIGAMMA = "GAMMA";
        private const string NODE = "NODE";
        private const string BRIGHT = "Bright";
        private const string BRIGHTRATIO = "BrightRatio";
        private const string IDEALBRIGHT = "IdealBright";
        private const string DIFFBRIGHT = "Difference";
        private const string R_POSTIVE = "R+";
        private const string R_NEGTIVE = "R-";
        private const string G_POSTIVE = "G+";
        private const string G_NEGTIVE = "G-";
        private const string B_POSTIVE = "B+";
        private const string B_NEGTIVE = "B-";
        private const string IDEALVALUE = "IdealValue";
        private const string IDEALRATIO = "IdealRatio";
        private const string SPEC_MIN_VALUE = "SPEC_MIN_VALUE";
        private const string SPEC_MIN_RATIO = "SPEC_MIN_RATIO";
        private const string SPEC_MAX_VALUE = "SPEC_MAX_VALUE";
        private const string SPEC_MAX_RATIO = "SPEC_MAX_RATIO";
        private const string SPEC_DELTA_LOG = "SPEC_ANTI_LOG";
        private const string MIPI_HS_CMD_REG = "mipi.write.hs 0x23 0x00";
        private const string MIPI_HS_CMD_DATA = "mipi.write.hs 0x29 ";
        private const string MIPI_LP_CMD_REG = "mipi.write 0x23 0x00 0x80";
        private const string MIPI_LP_CMD_DATA = "mipi.write 0x29";
        private const string MIPI_IMAGE_SHOW = "image.show";
        private const int BRIGHT_COL = 2;
        private const int BRIGHTRATIO_COL = 3;
        private const int IDEALBRIGHT_COL = 4;
        private const int DIFFBRIGHT_COL = 5;
        private const int R_POSTIVE_COL = 7;
        private const int R_NEGTIVE_COL = 8;
        private const int G_POSTIVE_COL = 9;
        private const int G_NEGTIVE_COL = 10;
        private const int B_POSTIVE_COL = 11;
        private const int B_NEGTIVE_COL = 12;

        private const int GAMMA_SCMDMEASURE_COL = 6;
        private const int GAMMA_SCMD_COL = 13;
        private const int GAMMA_MES_COL = 14;

        private const int GAMMA_NODE_INDEX = 0;
        private const int BRIGHT_INDEX = 1;
        private const int BRIGHT_RATIO_INDEX = 2;
        private const int IDEALBRIGHT_INDEX = 3;
        private const int DIFFBRIGHT_INDEX = 4;
        private const int R_POSTIVE_INDEX = 5;
        private const int R_NEGTIVE_INDEX = 6;
        private const int G_POSTIVE_INDEX = 7;
        private const int G_NEGTIVE_INDEX = 8;
        private const int B_POSTIVE_INDEX = 9;
        private const int B_NEGTIVE_INDEX = 10;
        private const int IDEALVALUE_INDEX = 11;
        private const int IDEAL_RATIO_INDEX = 12;
        private const int SPEC_MAXVALUE_INDEX = 13;
        private const int SPEC_MAXRATIO_INDEX = 14;
        private const int SPEC_MINVALUE_INDEX = 15;
        private const int SPEC_MINRATIO_INDEX = 16;
        private const int GAMMA_ANTILOG_INDEX = 17;
        private const int GAMMA_BASE = 0x80;
        private const int GAMMA_EXT = 0x9E;
        private int TestMax = 5;
        private bool bStopBright = true;

        public XmGammaTool(XM_ExeMainCmd ExeCmd)
        {
            GammaExeCmd = ExeCmd;
            InitializeComponent();
        }
        public XmGammaTool()
        {
            XM_ExeMainCmd GammaExeCmd = ScriptSetting_Form.ExeCmd;
            InitializeComponent();
        }

        private void XmGammaTool_Load(object sender, EventArgs e)
        {
            InitialXmGammaVal();
            InitialCommCbx();
            InitialGammaCurve();
            InitialGammaSpec();
            InitialDgvGamma();
            InitialPgsBar();
            ExeSystemInfo();
            InitialXmGammaVal();

        }

        private void InitialXmGammaVal()
        {
            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                XmGammaVal[i] = new XmGamma
                {
                    Item = new ArrayList()
                };
            }

            XmGammaVal[0].Name = NODE;
            XmGammaVal[0].Reg = "0";
            XmGammaVal[0].Column = 0;
            XmGammaVal[0].Index = 0;

            XmGammaVal[1].Name = BRIGHT;
            XmGammaVal[1].Reg = "0";
            XmGammaVal[1].Column = BRIGHT_COL;
            XmGammaVal[1].Index = 1;

            XmGammaVal[2].Name = BRIGHTRATIO;
            XmGammaVal[2].Reg = "0";
            XmGammaVal[2].Column = BRIGHTRATIO_COL;
            XmGammaVal[2].Index = 2;

            XmGammaVal[3].Name = IDEALBRIGHT;
            XmGammaVal[3].Reg = "0";
            XmGammaVal[3].Column = IDEALBRIGHT_COL;
            XmGammaVal[3].Index = 3;

            XmGammaVal[4].Name = DIFFBRIGHT;
            XmGammaVal[4].Reg = "0";
            XmGammaVal[4].Column = DIFFBRIGHT_COL;
            XmGammaVal[4].Index = 4;

            XmGammaVal[5].Name = R_POSTIVE;
            XmGammaVal[5].Reg = "0xD4";
            XmGammaVal[5].Column = R_POSTIVE_COL;
            XmGammaVal[5].Index = 5;

            XmGammaVal[6].Name = R_NEGTIVE;
            XmGammaVal[6].Reg = "0xD5";
            XmGammaVal[6].Column = R_NEGTIVE_COL;
            XmGammaVal[6].Index = 6;

            XmGammaVal[7].Name = G_POSTIVE;
            XmGammaVal[7].Reg = "0xD6";
            XmGammaVal[7].Column = G_POSTIVE_COL;
            XmGammaVal[7].Index = 7;

            XmGammaVal[8].Name = G_NEGTIVE;
            XmGammaVal[8].Reg = "0xD7";
            XmGammaVal[8].Column = G_NEGTIVE_COL;
            XmGammaVal[8].Index = 8;

            XmGammaVal[9].Name = B_POSTIVE;
            XmGammaVal[9].Reg = "0xD8";
            XmGammaVal[9].Column = B_POSTIVE_COL;
            XmGammaVal[9].Index = 9;

            XmGammaVal[10].Name = B_NEGTIVE;
            XmGammaVal[10].Reg = "0xD9";
            XmGammaVal[10].Column = B_NEGTIVE_COL;
            XmGammaVal[10].Index = 10;

            XmGammaVal[11].Name = IDEALVALUE;
            XmGammaVal[11].Column = 0;
            XmGammaVal[11].Index = 11;

            XmGammaVal[12].Name = IDEALRATIO;
            XmGammaVal[12].Column = 0;
            XmGammaVal[12].Index = 12;

            XmGammaVal[13].Name = SPEC_MAX_VALUE;
            XmGammaVal[13].Column = 0;
            XmGammaVal[13].Index = 13;

            XmGammaVal[14].Name = SPEC_MAX_RATIO;
            XmGammaVal[14].Column = 0;
            XmGammaVal[14].Index = 14;

            XmGammaVal[15].Name = SPEC_MIN_VALUE;
            XmGammaVal[15].Column = 0;
            XmGammaVal[15].Index = 15;

            XmGammaVal[16].Name = SPEC_MIN_RATIO;
            XmGammaVal[16].Column = 0;
            XmGammaVal[16].Index = 16;

            XmGammaVal[17].Name = SPEC_DELTA_LOG;
            XmGammaVal[17].Column = 0;
            XmGammaVal[17].Index = 17;
        }

        private void ExeSystemInfo()
        {
            if (GammaExeCmd.GetGammaComm())
            {
                BtnCommOpen.Enabled = false;
                BtnCommClose.Enabled = true;
                BtnCommOpen.BackColor = Color.GreenYellow;
                ToolStripSystemInfo.Text = "CA-210 has Opened";
            }
            else
            {
                BtnCommClose.Enabled = false;
                ToolStripSystemInfo.Text = "Please Open CA-210";
                BtnCommOpen.BackColor = Color.Blue;
            }

        }


        private string SetupGammaCode(int i )
        {
            string ColorCmd;
            if (ColorDevIndex == 1)
                ColorCmd = (i == 0) ? string.Concat(KonicaMeasure, " 500\r\n") : string.Concat(KonicaMeasure, " 500\r\n");
            else
                ColorCmd = KleinMeasure;

            return ColorCmd;
        }

        private void SetupColorCmd()
        {
            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                ImageCmds[i * 2] = string.Concat("image.fill ", i.ToString(), " ", i.ToString(), " ", i.ToString(), " ");
                ImageCmds[i * 2 + 1] = SetupGammaCode(i);
            }

        }

        private void InitialPgsBar()
        {
            GammaPgsBar.Maximum = 100;
            GammaPgsBar.Minimum = 0;
            ToolStripSystemInfo.Text = "";
        }

        private void InitialTiePoint()
        {
            //Build up the retangle and Calculate the location for inserting the gridview
            Rectangle rect = Dgv_Gamma.GetCellDisplayRectangle(0, -1, true);
            rect.X = rect.Location.X + (rect.Width / 2 + 25);
            rect.Y = rect.Location.Y + (rect.Height / 2 - 9);

            //Control CheckBox
            CheckBox CbCtrl = new CheckBox
            {
                Name = "ChkTiePoint",
                Size = new Size(18, 18),
                Location = rect.Location
            };

            //Add CheckBox Into dataGridView and Name
            Dgv_Gamma.Controls.Add(CbCtrl);
            CbCtrl.CheckedChanged += new EventHandler(ChkTiePoint_CheckedChanged);
        }

        private void InitialDgvGamma()
        {
            Dgv_Gamma.RowCount = MAX_GRAYLEVEL + 1;
            Dgv_Gamma.AllowUserToAddRows = false;
            Dgv_Gamma.AllowUserToOrderColumns = false;
            Dgv_Gamma.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Gamma.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Gamma.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Gamma.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Gamma.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn column in Dgv_Gamma.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i < MAX_GRAYLEVEL; i++) Dgv_Gamma[1, i].Value = i.ToString();
            InitialTiePoint();
            Dgv_Gamma.CellValueChanged += new DataGridViewCellEventHandler(Dgv_Gamma_CellValueChanged);
            Dgv_Gamma.CellClick += new DataGridViewCellEventHandler(Dgv_Gamma_CellClick);
        }

        private void MeasureSingleBright(int Index, int GrayLevel)
        {

            string RdStr = null;
            List<ScriptInfo> lScriptInfo = new List<ScriptInfo>();
            GammaExeCmd.ExamScript(ImageCmds, lScriptInfo);
            GammaExeCmd.ExamCmd(lScriptInfo[GrayLevel * 2]);
            SendCmd(lScriptInfo[GrayLevel * 2], false, ref RdStr);
            Thread.Sleep(100);
            GammaExeCmd.ExamCmd(lScriptInfo[GrayLevel * 2 + 1]);
            for(int i =0;i<TestMax;i++)
            { 
                SendCmd(lScriptInfo[GrayLevel * 2 + 1], true, ref RdStr);
                Thread.Sleep(1000);
                if (string.IsNullOrEmpty(RdStr))
                    SendCmd(lScriptInfo[GrayLevel * 2 + 1], true, ref RdStr);           
                if (i > 0 && !string.IsNullOrEmpty(RdStr)) break;

            }
            Dgv_Gamma.Rows[GrayLevel].Cells[XmGammaVal[Index].Column].Value = RdStr;
            SyncGridViewAndMatrix(Index, false);
        }

        private ArrayList GenerateGammaCode(string Mipi_Cmd_Reg, string Mipi_Cmd_Data, int GrayItem)
        {
            ArrayList GammaCode = new ArrayList();
            SyncGridViewAndMatrix(R_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(R_NEGTIVE_INDEX, true);
            SyncGridViewAndMatrix(G_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(G_NEGTIVE_INDEX, true);
            SyncGridViewAndMatrix(B_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(B_NEGTIVE_INDEX, true);

            string[] R_Pos_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, R_POSTIVE_INDEX, XmGammaVal[5].Reg, GrayItem);
            string[] R_Neg_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, R_NEGTIVE_INDEX, XmGammaVal[6].Reg, GrayItem);
            string[] G_Pos_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, G_POSTIVE_INDEX, XmGammaVal[7].Reg, GrayItem);
            string[] G_Neg_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, G_NEGTIVE_INDEX, XmGammaVal[8].Reg, GrayItem);
            string[] B_Pos_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, B_POSTIVE_INDEX, XmGammaVal[9].Reg, GrayItem);
            string[] B_Neg_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, B_NEGTIVE_INDEX, XmGammaVal[10].Reg, GrayItem);

            foreach (string Code in R_Pos_Gamma) GammaCode.Add(Code);
            foreach (string Code in R_Neg_Gamma) GammaCode.Add(Code);
            foreach (string Code in G_Pos_Gamma) GammaCode.Add(Code);
            foreach (string Code in G_Neg_Gamma) GammaCode.Add(Code);
            foreach (string Code in B_Pos_Gamma) GammaCode.Add(Code);
            foreach (string Code in B_Neg_Gamma) GammaCode.Add(Code);

            return GammaCode;
        }

        private bool SendGammaCmd(int GrayLevel)
        {
            bool bMatch = false;
            int GammItem = 0;
            if (XmGammaVal[GAMMA_NODE_INDEX].Item.Count == 0) return false;
            for (int i = 0; i < XmGammaVal[GAMMA_NODE_INDEX].Item.Count; i++)
            {
                int Value = Convert.ToInt32(XmGammaVal[GAMMA_NODE_INDEX].Item[i]);
                if (Value == GrayLevel) { bMatch = true; GammItem = i; break; }
            }
            if (!bMatch) return false;


            ArrayList GammaCode = GenerateGammaCode(MIPI_HS_CMD_REG, MIPI_HS_CMD_DATA, GammItem);

            foreach (string Code in GammaCode) Log.W(Code);

            if (SendScript((string[])GammaCode.ToArray(typeof(string))))
                ToolStripSystemInfo.Text = string.Concat("Gray: ", GrayLevel.ToString(), " Finished");
            else
                ToolStripSystemInfo.Text = "Send Error";

            return true;
        }

        private void Dgv_Gamma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GAMMA_MES_COL)
            {
                MeasureSingleBright(BRIGHT_INDEX, e.RowIndex);
                CalculateAndPlot();
                Rtf_Msg.Text = "Measure Finished";
            }

            if (e.ColumnIndex == GAMMA_SCMD_COL)
            {
                if (!SendGammaCmd(e.RowIndex)) ToolStripSystemInfo.Text = Rtf_Msg.Text = "Not Gamma node"; 
                Rtf_Msg.Text = "Send Cmd Finished";
            }

            if (e.ColumnIndex == GAMMA_SCMDMEASURE_COL)
            {
                if (SendGammaCmd(e.RowIndex))
                {
                    MeasureSingleBright(BRIGHT_INDEX, e.RowIndex);
                    CalculateAndPlot();
                    ToolStripSystemInfo.Text = Rtf_Msg.Text = string.Concat("Measure & Send Cmd Finished , Gray: ", e.RowIndex.ToString());
                }
                else
                    ToolStripSystemInfo.Text = Rtf_Msg.Text = "Not Gamma node";

            }
        }

        private void Dgv_Gamma_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (Dgv_Gamma.IsCurrentCellDirty) Dgv_Gamma.CommitEdit(DataGridViewDataErrorContexts.Commit);

        }

        private void Dgv_Gamma_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Dgv_Gamma.Rows[0].Index && e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell Chk = Dgv_Gamma.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;
                bool Checked = Convert.ToBoolean(Chk.Value);
                Dgv_Gamma.Rows[e.RowIndex].DefaultCellStyle.BackColor = Checked ? Color.LightPink : Color.White;
            }

            if (e.ColumnIndex >= R_POSTIVE_COL && e.ColumnIndex <= B_NEGTIVE_COL) UpdateGammaIntoDgv(e.ColumnIndex);
        }

        private void ChkTiePoint_CheckedChanged(object sender, EventArgs e)
        {
            bool Checked = ((CheckBox)Dgv_Gamma.Controls.Find("ChkTiePoint", true)[0]).Checked;
            foreach (DataGridViewRow dr in Dgv_Gamma.Rows)
            {
                dr.Cells[0].Value = Checked;
                dr.DefaultCellStyle.BackColor = (Checked) ? Color.LightPink : Color.White;
            }
        }

        private void StoreCommSetting()
        {
            string BaudRate = "38400", Databit = "7", Parity = "Even", StopBit = "2";
            XM_Ini_Util XmIni = new XM_Ini_Util(Setting.ExeSysIniPath);
            string CommPort = Cbx_CommPort.SelectedItem.ToString();
            XmIni.IniWriteValue(XMPLUSPARS.SECTION3, XMPLUSPARS.COMPORT, CommPort);
            XmIni.IniWriteValue(XMPLUSPARS.SECTION3, XMPLUSPARS.BAUDRATE, BaudRate);
            XmIni.IniWriteValue(XMPLUSPARS.SECTION3, XMPLUSPARS.DATABIT, Databit);
            XmIni.IniWriteValue(XMPLUSPARS.SECTION3, XMPLUSPARS.PARITY, Parity);
            XmIni.IniWriteValue(XMPLUSPARS.SECTION3, XMPLUSPARS.STOPBIT, StopBit);
        }

        private void OpenCA210Dev()
        {
            if (Cbx_CommPort.SelectedIndex < 0) { MessageBox.Show("Please Choose the Comport!"); return; }
            string CommPort = Cbx_CommPort.SelectedItem.ToString();
            string BaudRate = "38400", Databit = "7", Parity = "Even", StopBit = "2";
            if (KonicaDev == null) KonicaDev = new XM_EquipVisa_Util(CommPort, BaudRate, Databit, Parity, StopBit);
            if (!KonicaDev.IsCommOpen())
            {
                if (KonicaDev.CommOpen())
                {
                    StoreCommSetting();
                    BtnCommOpen.BackColor = Color.GreenYellow;
                    GammaExeCmd.SetKonicaDev(ref KonicaDev);
                    BtnCommClose.Enabled = true;
                    Rtf_Msg.Text = ToolStripSystemInfo.Text = "Open CA-210 Successfully";
                    ColorDevIndex = 1;
                    SetupColorCmd();
                }
                else
                    BtnCommClose.Enabled = false;

            }
            else
            {
                BtnCommClose.Enabled = true;
                Rtf_Msg.Text = ToolStripSystemInfo.Text = " CA-210 has Opended";
            }
        }

        private void OpenK80Dev()
        {
            string CommPort = Cbx_CommPort.SelectedItem.ToString();
            string Comm = System.Text.RegularExpressions.Regex.Replace(CommPort, @"[^0-9]+", "");
            if (!int.TryParse(Comm, out int CommNum)) return;
            if (kClmtr == null) kClmtr = new KClmtrWrap();
            kClmtr.port = CommNum;
            if (kClmtr.connect())
            {
                BtnCommOpen.BackColor = Color.GreenYellow;
                BtnCommClose.Enabled = true;
                ColorDevIndex = 0;
                GammaExeCmd.SetKleinDev(ref kClmtr);
                SetupColorCmd();
                Rtf_Msg.Text = ToolStripSystemInfo.Text = "Open K-80 Successfully";
            }
            else
                BtnCommClose.Enabled = false;
        }


        private void Btn_CommOpen_Click(object sender, EventArgs e)
        {
            if (CboColorDev.SelectedIndex == 0)
                OpenK80Dev();
            else
                OpenCA210Dev();
        }

        private void Btn_AutoTune_Click(object sender, EventArgs e)
        {
            bStopBright = true;
            string RdStr = null;
            Rtf_Msg.Text = ToolStripSystemInfo.Text = "Measure Ongoing...";
            List<ScriptInfo> lScriptInfo = new List<ScriptInfo>();
             GammaExeCmd.ExamScript(ImageCmds, lScriptInfo);
            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                GammaExeCmd.ExamCmd(lScriptInfo[i * 2]);
                SendCmd(lScriptInfo[i * 2], false, ref RdStr);
                Thread.Sleep(200);
                GammaExeCmd.ExamCmd(lScriptInfo[i * 2 + 1]);
                for (int j =0;j< TestNum; j++)
                {
                    RdStr = null;
                    if (i == 0)
                    {
                        SendCmd(lScriptInfo[i * 2 + 1], true, ref RdStr);
                        Thread.Sleep(300);
                    }
                    Thread.Sleep(300);
                    SendCmd(lScriptInfo[i * 2 + 1], true, ref RdStr);
 
                    if (!string.IsNullOrEmpty(RdStr))break;
                    if(j >= 1) Thread.Sleep(j * 100+1500);
                }

                Dgv_Gamma.Rows[i].Cells[2].Value = RdStr;
                Application.DoEvents();
                GammaPgsBar.Value = (int)(i * 0.39);
                RdStr = null;
                if (!bStopBright) break;
            }

            SyncGridViewAndMatrix(BRIGHT_INDEX, false);

            Rtf_Msg.Text = ToolStripSystemInfo.Text = "Measure Successfully";
        }

        private void Show(int Row, int Column, string Value)
        {
            Dgv_Gamma.Rows[Row].Cells[Column].Value = Value;
        }

        private string ReadFromK80(string Message)
        {
            string Bright = null;
            if(!string.IsNullOrEmpty(Message))
            {
                string[] RdStr = Message.Split(',');
                Bright = (RdStr.Length > 1) ? RdStr[2]:  null;
            }
            return Bright;
        }

        private string ReadFromCa210(string Message)
        {

            string Pat = @"OK\d+,P\d+\s*(\d+);(\d+);\s*(\S+)";
            Regex r = new Regex(Pat, RegexOptions.IgnoreCase);
            Match m = r.Match(Message);
            return m.Success && m.Groups.Count > 2 ? m.Groups[3].ToString() : null;
        }

        private bool SendCmd(ScriptInfo CmdInfo, bool bRdColorDev, ref string RdStr)
        {
            bool ret = GammaExeCmd.ExcuteCmd(GammaExeCmd.GetXmCmd(), GammaExeCmd.GetXmClass(), ref RdStr);
            if(bRdColorDev) RdStr =  ColorDevIndex == 0 ? ReadFromK80(RdStr) : ReadFromCa210(RdStr);              
            return ret;
        }

        private void InitialGammaCurve()
        {
            Cbx_GammaCurve.Items.Add("1.7");
            Cbx_GammaCurve.Items.Add("1.8");
            Cbx_GammaCurve.Items.Add("1.9");
            Cbx_GammaCurve.Items.Add("2.0");
            Cbx_GammaCurve.Items.Add("2.1");
            Cbx_GammaCurve.Items.Add("2.2");
            Cbx_GammaCurve.Items.Add("2.3");
            Cbx_GammaCurve.Items.Add("2.4");
            Cbx_GammaCurve.Items.Add("2.5");
            Cbx_GammaCurve.SelectedIndex = 5;
        }

        private void InitialGammaSpec()
        {
            Cbx_Spec.Items.Add("0.2");
            Cbx_Spec.Items.Add("0.1");
            Cbx_Spec.Items.Add("0.05");
            Cbx_Spec.SelectedIndex = 1;
        }

        private void InitialCommCbx()
        {
            XM_Ini_Util XmIni = new XM_Ini_Util(Setting.ExeSysIniPath);
            string[] Ports = SerialPort.GetPortNames();
            string Comport = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.COMPORT);

            if (Ports.Length > 0)
            {
                foreach (string port in Ports) Cbx_CommPort.Items.Add(port);
            }
            else
                Cbx_CommPort.Items.Add("Null");

            if (!string.IsNullOrEmpty(Comport))
            {
                Cbx_CommPort.SelectedIndex = Cbx_CommPort.FindString(Comport);
            }
        }

        private bool CalculateLogSpec()
        {
            double Value = 0;
            XM_Digital_Util Util = new XM_Digital_Util();
            if (XmGammaVal[BRIGHT_RATIO_INDEX].Item.Count == 0) return false;
            XmGammaVal[GAMMA_ANTILOG_INDEX].Item.Clear();
            for (int i = 0; i < XmGammaVal[BRIGHT_RATIO_INDEX].Item.Count; i++)
            {
                if (!Util.StrToNumber<double>(XmGammaVal[BRIGHT_RATIO_INDEX].Item[i].ToString(), ref Value)) return false;
                XmGammaVal[GAMMA_ANTILOG_INDEX].Item.Add(Math.Log(Value / 100, (double)i / 255));
            }

            return true;
        }

        private bool CalculateGammaSpec()
        {
            if (!float.TryParse(Cbx_GammaCurve.Text, out float Curve)) { MessageBox.Show("Please Choose the Right Curve!"); return false; }
            if (!float.TryParse(Cbx_Spec.Text, out float Spec)) { MessageBox.Show("Please Choose the Right Spec!"); return false; }
            XmGammaVal[SPEC_MAXVALUE_INDEX].Item.Clear();
            XmGammaVal[SPEC_MAXRATIO_INDEX].Item.Clear();
            XmGammaVal[SPEC_MINVALUE_INDEX].Item.Clear();
            XmGammaVal[SPEC_MINRATIO_INDEX].Item.Clear();
            MaxSpec = (float)Math.Round(Curve + Spec, 1);
            MinSpec = (float)Math.Round(Curve - Spec, 1);

            //IdealValue
            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                XmGammaVal[SPEC_MAXVALUE_INDEX].Item.Add(Math.Round(Math.Pow(i, MaxSpec), 2));
                XmGammaVal[SPEC_MINVALUE_INDEX].Item.Add(Math.Round(Math.Pow(i, MinSpec), 2));
            }

            //IdealRatio
            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                XmGammaVal[SPEC_MAXRATIO_INDEX].Item.Add(Math.Round(double.Parse(XmGammaVal[13].Item[i].ToString()) / double.Parse(XmGammaVal[13].Item[255].ToString()) * 100, 2));
                XmGammaVal[SPEC_MINRATIO_INDEX].Item.Add(Math.Round(double.Parse(XmGammaVal[15].Item[i].ToString()) / double.Parse(XmGammaVal[15].Item[255].ToString()) * 100, 2));
            }
            return true;
        }

        private void CalculateBrightDiff()
        {
            if (XmGammaVal[IDEALBRIGHT_INDEX].Item.Count != MAX_GRAYLEVEL) return;
            if (XmGammaVal[BRIGHT_INDEX].Item.Count != MAX_GRAYLEVEL) return;
            XmGammaVal[DIFFBRIGHT_INDEX].Item.Clear();

            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                double Ideal = double.Parse(XmGammaVal[IDEALBRIGHT_INDEX].Item[i].ToString());
                double Mes = double.Parse(XmGammaVal[BRIGHT_INDEX].Item[i].ToString());
                string Data = Math.Round(Ideal - Mes, 3).ToString();
                XmGammaVal[DIFFBRIGHT_INDEX].Item.Add((Ideal - Mes < 0) ? string.Concat("-", Data) : Data.ToString());
            }
        }

        private bool CalculateIdealBright()
        {
            XmGammaVal[IDEALBRIGHT_INDEX].Item.Clear();
            XmGammaVal[IDEALVALUE_INDEX].Item.Clear();
            XmGammaVal[IDEAL_RATIO_INDEX].Item.Clear();
            if (XmGammaVal[BRIGHT_INDEX].Item.Count != MAX_GRAYLEVEL) return false;
            if (!float.TryParse(Cbx_GammaCurve.Text, out float Curve)) { MessageBox.Show("Please Choose the Right Curve!"); return false; }

            //IdealValue
            for (int i = 0; i < MAX_GRAYLEVEL; i++) XmGammaVal[IDEALVALUE_INDEX].Item.Add(Math.Round(Math.Pow(i, Curve), 3));
            //IdealRatio
            for (int i = 0; i < MAX_GRAYLEVEL; i++) XmGammaVal[IDEAL_RATIO_INDEX].Item.Add(Math.Round(double.Parse(XmGammaVal[11].Item[i].ToString()) / double.Parse(XmGammaVal[11].Item[255].ToString()) * 100, 3));

            //Ideal Bright
            double Max_b = double.Parse(XmGammaVal[BRIGHT_INDEX].Item[255].ToString());
            double Min_b = double.Parse(XmGammaVal[BRIGHT_INDEX].Item[0].ToString());
            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                double Percent = double.Parse(XmGammaVal[IDEAL_RATIO_INDEX].Item[i].ToString());
                XmGammaVal[IDEALBRIGHT_INDEX].Item.Add(Math.Round(((Max_b - Min_b) * (Percent / 100) + Min_b), 3).ToString());
            }

            return true;
        }

        private bool CalculateBrightRatio()
        {
            if (XmGammaVal[BRIGHT_INDEX].Item.Count != MAX_GRAYLEVEL) return false;
            XmGammaVal[BRIGHT_RATIO_INDEX].Item.Clear();

            if(XmGammaVal[BRIGHT_INDEX].Item[255] == null )return false;
            if (XmGammaVal[BRIGHT_INDEX].Item[0] == null) return false;

            if (!double.TryParse(XmGammaVal[BRIGHT_INDEX].Item[255].ToString(), out double MaxBright)) {Rtf_Msg.Text = "Bright Column Format Err!"; return false; }
            if (!double.TryParse(XmGammaVal[BRIGHT_INDEX].Item[0].ToString(), out double MinBright)) { Rtf_Msg.Text = "Bright Column Format Err!"; return false; }
            if (!ExamineArrayAsDouble(BRIGHT_INDEX)) { Rtf_Msg.Text = "Bright Coloumn Error"; return false; }

            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                if (!double.TryParse(XmGammaVal[BRIGHT_INDEX].Item[i].ToString(), out double Value)) { Rtf_Msg.Text = "Bright Column Format Err!"; return false; }
                XmGammaVal[BRIGHT_RATIO_INDEX].Item.Add(Math.Round((Value - MinBright) / (MaxBright - MinBright) * 100, 3));
            }

            return true;
        }

        private void PlotChartAntiLog()
        {
            double Value = 0;
            if (XmGammaVal[GAMMA_ANTILOG_INDEX].Item.Count == 0) return;
            XM_Digital_Util Tool = new XM_Digital_Util();
            LogChart.Series.Clear();
            Series AntiLogSeries = new Series("AntiLog Chart", 256)
            {
                Color = Color.Green,
                ChartType = SeriesChartType.Line
            };

            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                Value = !Tool.StrToNumber<double>((string)XmGammaVal[GAMMA_ANTILOG_INDEX].Item[i].ToString(), ref Value) ? 0 : Value;
                Value = double.IsInfinity(Value) ? 0 : Value;
                AntiLogSeries.Points.AddXY(i, Value);

            }

            LogChart.Series.Add(AntiLogSeries);
            LogChart.ChartAreas[0].AxisY.Minimum = 0;//設定Y軸最小值
            LogChart.ChartAreas[0].AxisY.Maximum = 5;//設定Y軸最大值
            LogChart.ChartAreas[0].AxisX.Minimum = 0;//設定Y軸最小值
            LogChart.ChartAreas[0].AxisX.Maximum = 256;//設定Y軸最大值

            LogChart.Legends[0].Docking = Docking.Top; //自訂顯示位置
        }

        private bool PlotChartGamma()
        {

            if (XmGammaVal[BRIGHT_RATIO_INDEX].Item.Count == 0) return false;
            if (XmGammaVal[IDEAL_RATIO_INDEX].Item.Count == 0) return false;
            if (XmGammaVal[SPEC_MAXRATIO_INDEX].Item.Count == 0) return false;
            if (XmGammaVal[SPEC_MINRATIO_INDEX].Item.Count == 0) return false;

            GammaChart.Series.Clear();

            Series IdealSeries = new Series("Bright Ratio", 100)
            {
                Color = Color.Red,
                ChartType = SeriesChartType.Line
            };

            Series BrightSeries = new Series("Ideal Ratio", 100)
            {
                Color = Color.Blue,
                ChartType = SeriesChartType.Line
            };

            Series Spec_Max_Series = new Series(Math.Round(MaxSpec, 2).ToString(), 100)
            {
                Color = Color.DarkOrange,
                ChartType = SeriesChartType.Line
            };

            Series Spec_Min_Series = new Series(Math.Round(MinSpec, 2).ToString(), 100)
            {
                Color = Color.Green,
                ChartType = SeriesChartType.Line
            };

            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                IdealSeries.Points.AddXY(i, XmGammaVal[BRIGHT_RATIO_INDEX].Item[i]);
                BrightSeries.Points.AddXY(i, XmGammaVal[IDEAL_RATIO_INDEX].Item[i]);
                Spec_Max_Series.Points.AddXY(i, XmGammaVal[SPEC_MAXRATIO_INDEX].Item[i]);
                Spec_Min_Series.Points.AddXY(i, XmGammaVal[SPEC_MINRATIO_INDEX].Item[i]);
            }

            GammaChart.Series.Add(IdealSeries);
            GammaChart.Series.Add(BrightSeries);
            GammaChart.Series.Add(Spec_Max_Series);
            GammaChart.Series.Add(Spec_Min_Series);
            GammaChart.ChartAreas[0].AxisY.Minimum = 0;//設定Y軸最小值
            GammaChart.ChartAreas[0].AxisY.Maximum = 100;//設定Y軸最大值
            GammaChart.ChartAreas[0].AxisX.Minimum = 0;//設定Y軸最小值
            GammaChart.ChartAreas[0].AxisX.Maximum = 256;//設定Y軸最大值       
            GammaChart.ChartAreas[0].AxisX.Interval = 10;

            GammaChart.Legends[0].Docking = Docking.Top; //自訂顯示位置
            return true;
        }

        private void FillOutData()
        {
            UpdateGridViewWithIndex(BRIGHT_RATIO_INDEX, false);
            UpdateGridViewWithIndex(IDEALBRIGHT_INDEX, false);
            UpdateGridViewWithIndex(DIFFBRIGHT_INDEX, false);
        }

        private void CalculateAndPlot()
        {
            if (CalculateBrightRatio())
            {
                CalculateIdealBright();
                CalculateBrightDiff();
                CalculateLogSpec();
            }else
            {
                GammaChart.Series.Clear();
                GammaChart.Series.Clear();
                LogChart.Series.Clear();
            }
            CalculateGammaSpec();
            FillOutData();
            PlotChartGamma();
            PlotChartAntiLog();
        }


        private void Btn_IdealChart_Click(object sender, EventArgs e)
        {
            CalculateAndPlot();
        }

        private void BtnReadGamma_Click(object sender, EventArgs e)
        {
            Dgv_Gamma.CellValueChanged -= new DataGridViewCellEventHandler(Dgv_Gamma_CellValueChanged);
            Dgv_Gamma.CellClick -= new DataGridViewCellEventHandler(Dgv_Gamma_CellClick);

            if (Chk_R_Pos.Checked == true)
            {
                if (RdPolarityGamma(R_POSTIVE_INDEX)) {
                    Rtf_Msg.Text = "Read R+ Gamma Ongoing...";
                    UpdateGridViewWithIndex(R_POSTIVE_INDEX, true);
                    GammaPgsBar.Value = 100;
                }
            }

            if (Chk_R_Neg.Checked == true)
            {
                if (RdPolarityGamma(R_NEGTIVE_INDEX))
                {
                    Rtf_Msg.Text = "Read R- Gamma Ongoing...";
                    UpdateGridViewWithIndex(R_NEGTIVE_INDEX, true);
                    GammaPgsBar.Value = 100;
                }
            }

            if (Chk_G_Pos.Checked == true)
            {
                if (RdPolarityGamma(G_POSTIVE_INDEX))
                {
                    Rtf_Msg.Text = "Read G+ Gamma Ongoing...";
                    UpdateGridViewWithIndex(G_POSTIVE_INDEX, true);
                    GammaPgsBar.Value = 100;
                }
            }

            if (Chk_G_Neg.Checked == true)
            {
                if (RdPolarityGamma(G_NEGTIVE_INDEX))
                {
                    Rtf_Msg.Text = "Read G- Gamma Ongoing...";
                    UpdateGridViewWithIndex(G_NEGTIVE_INDEX, true);
                    GammaPgsBar.Value = 100;
                }
            }

            if (Chk_B_Pos.Checked == true)
            {
                if (RdPolarityGamma(B_POSTIVE_INDEX))
                {
                    Rtf_Msg.Text = "Read B+ Gamma Ongoing...";
                    UpdateGridViewWithIndex(B_POSTIVE_INDEX, true);
                    GammaPgsBar.Value = 100;
                }
            }

            if (Chk_B_Neg.Checked == true)
            {
                if (RdPolarityGamma(B_NEGTIVE_INDEX))
                {
                    Rtf_Msg.Text = "Read B- Gamma Ongoing...";
                    UpdateGridViewWithIndex(B_NEGTIVE_INDEX, true);
                    GammaPgsBar.Value = 100;
                }
            }

            Dgv_Gamma.CellValueChanged += new DataGridViewCellEventHandler(Dgv_Gamma_CellValueChanged);
            Dgv_Gamma.CellClick += new DataGridViewCellEventHandler(Dgv_Gamma_CellClick);
        }

        private void BtnLoadSetting_Click(object sender, EventArgs e)
        {
            Dgv_Gamma.CellValueChanged -= new DataGridViewCellEventHandler(Dgv_Gamma_CellValueChanged);
            Dgv_Gamma.CellClick -= new DataGridViewCellEventHandler(Dgv_Gamma_CellClick);

            /*Choose Ini File */
            OpenFileDialog OpenFileDialog = new OpenFileDialog
            {
                Filter = "*.ini|*.*",
                FileName = "default.ini",
                InitialDirectory = Setting.ExeSptDirPath,
            };

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Setting.ExeWolConfigPath = _IniPath = OpenFileDialog.FileName;
                TxtBox_Path.Text = Path.GetFileName(_IniPath);
                LoadParaFromIni();
            }

            Chk_PosEqNeg.Checked = false;
            ChkGamma_PosEqNeg.Checked = false;
            Dgv_Gamma.CellValueChanged += new DataGridViewCellEventHandler(Dgv_Gamma_CellValueChanged);
            Dgv_Gamma.CellClick += new DataGridViewCellEventHandler(Dgv_Gamma_CellClick);
        }

        private void BtnSaveSetting_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog = new SaveFileDialog
            {
                Filter = "*.ini|*.*",
                FileName = "default.ini",
                InitialDirectory = Setting.ExeSptDirPath,
            };

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Setting.ExeWolConfigPath = _IniPath = SaveFileDialog.FileName;
                TxtBox_Path.Text = Path.GetFileName(_IniPath);
                SetParaFromIni();
            }
        }

        private void SetParaFromIni()
        {
            XM_Ini_Util IniUtil = new XM_Ini_Util(_IniPath);

            //Node
            IniUtil.IniWriteValue(INIGAMMA, NODE, GetGammaNode());

            //Brightness
            IniUtil.IniWriteValue(INIGAMMA, BRIGHT, ColumnValue(BRIGHT_COL,false));

            //R+
            IniUtil.IniWriteValue(INIGAMMA, R_POSTIVE, ColumnValue(R_POSTIVE_COL,true));
            //R-
            IniUtil.IniWriteValue(INIGAMMA, R_NEGTIVE, ColumnValue(R_NEGTIVE_COL, true));

            //G+
            IniUtil.IniWriteValue(INIGAMMA, G_POSTIVE, ColumnValue(G_POSTIVE_COL, true));
            //G-
            IniUtil.IniWriteValue(INIGAMMA, G_NEGTIVE, ColumnValue(G_NEGTIVE_COL, true));

            //B+
            IniUtil.IniWriteValue(INIGAMMA, B_POSTIVE, ColumnValue(B_POSTIVE_COL, true));
            //B-
            IniUtil.IniWriteValue(INIGAMMA, B_NEGTIVE, ColumnValue(B_NEGTIVE_COL, true));

            //GammaCurve
            IniUtil.IniWriteValue(INIGAMMA, GAMMACURVE, Cbx_GammaCurve.SelectedItem.ToString());
            //GammaSpec
            IniUtil.IniWriteValue(INIGAMMA, GAMMASPEC, Cbx_Spec.SelectedItem.ToString());
        }

        private void LoadParaFromIni()
        {
            XM_Ini_Util IniUtil = new XM_Ini_Util(_IniPath);
            SetGammaNode(IniUtil.IniReadValue(INIGAMMA, NODE));
            SetGammaPolarityData(IniUtil.IniReadValue(INIGAMMA, BRIGHT), BRIGHT, true);
            SetGammaPolarityData(IniUtil.IniReadValue(INIGAMMA, R_POSTIVE), R_POSTIVE, false);
            SetGammaPolarityData(IniUtil.IniReadValue(INIGAMMA, R_NEGTIVE), R_NEGTIVE, false);
            SetGammaPolarityData(IniUtil.IniReadValue(INIGAMMA, G_POSTIVE), G_POSTIVE, false);
            SetGammaPolarityData(IniUtil.IniReadValue(INIGAMMA, G_NEGTIVE), G_NEGTIVE, false);
            SetGammaPolarityData(IniUtil.IniReadValue(INIGAMMA, B_POSTIVE), B_POSTIVE, false);
            SetGammaPolarityData(IniUtil.IniReadValue(INIGAMMA, B_NEGTIVE), B_NEGTIVE, false);
            string Cureve = IniUtil.IniReadValue(INIGAMMA, GAMMACURVE);
            string Spec = IniUtil.IniReadValue(INIGAMMA, GAMMASPEC);

            int IndexOfCurve = Cbx_GammaCurve.Items.IndexOf(Cureve);
            int IndexOfSpec = Cbx_Spec.Items.IndexOf(Spec);

            Cbx_GammaCurve.SelectedIndex = (IndexOfCurve > 0) ? IndexOfCurve : 0;
            Cbx_Spec.SelectedIndex = (IndexOfSpec > 0) ? IndexOfSpec : 0;
        }

        private void SetGammaPolarityData(string GammaVal, string Name, bool All)
        {
            if (string.IsNullOrEmpty(GammaVal)) return;
            string[] GammaNode = GammaVal.Split(',');
            int Column = GetColWithName(Name), j = 0;

            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                if (All)
                    Dgv_Gamma.Rows[i].Cells[Column].Value = GammaNode[i];
                else
                {
                    DataGridViewCheckBoxCell Chk = Dgv_Gamma.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                    bool Checked = Convert.ToBoolean(Chk.Value);
                    Dgv_Gamma.Rows[i].Cells[Column].Value = (Checked) ? GammaNode[j++] : "0";
                }
            }

            SetDataWithName(Name, GammaNode);
        }

        private void SetGammaNode(string Node)
        {
            XmGammaVal[GAMMA_NODE_INDEX].Item.Clear();
            string[] GammaNode = Node.Split(',');
            foreach (string Temp in GammaNode) XmGammaVal[0].Item.Add(Temp);
            SetGammaNode(XmGammaVal[0].Item);
        }

        private void SetGammaNode(ArrayList GammaPoint)
        {
            for (int i = 0; i < GammaPoint.Count; i++)
            {
                if (!int.TryParse((string)GammaPoint[i], out int Index)) break;
                ((DataGridViewCheckBoxCell)Dgv_Gamma.Rows[Index].Cells[0]).Value = true;
                Dgv_Gamma.Rows[Index].DefaultCellStyle.BackColor = Color.LightPink;
            }
        }

        private string GetGammaNode()
        {
            string GammaNode = null;
            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                DataGridViewCheckBoxCell Chk = Dgv_Gamma.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                bool Checked = Convert.ToBoolean(Chk.Value);
                GammaNode += (Checked) ? string.Concat(i.ToString(), ",") : "";
            }
            return GammaNode.Remove(GammaNode.Length - 1, 1);
        }

        private string ColumnValue(int Column,bool MatchGamma)
        {
            string GammaVal = null;
            if(MatchGamma)
            {
                for (int i = 0; i < MAX_GRAYLEVEL; i++)
                {
                    DataGridViewCheckBoxCell Chk = Dgv_Gamma.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                    bool Checked = Convert.ToBoolean(Chk.Value);
                    GammaVal += (Checked) ? string.Concat(Dgv_Gamma.Rows[i].Cells[Column].Value, ",") : "";
                }
            
            }else
            {
                for (int i = 0; i < MAX_GRAYLEVEL; i++)
                    GammaVal +=  string.Concat(Dgv_Gamma.Rows[i].Cells[Column].Value, ",");
            }
            
            return GammaVal.Remove(GammaVal.Length - 1, 1);
        }

        private string[] RdMipiData(string Reg)
        {
            string WrMipi = "mipi.write 0x23 0x00", RdMipi = "mipi.read";
            string Temp1 ,Temp2; 
            ArrayList Commands = new ArrayList();
            for (int i = 0; i < 30; i++)
            {
                Temp1 = string.Concat("0x", Convert.ToString(i + 128, 16));
                Temp1 = string.Concat(WrMipi, " ", Temp1);
                Temp2 = string.Concat(RdMipi, " ", Reg, " ", "1");
                Commands.Add(Temp1);
                Commands.Add(Temp2);
            }
            for (int i = 0; i < 8; i++)
            {
                Temp1 = string.Concat("0x", Convert.ToString(i + 158, 16));
                Temp1 = string.Concat(WrMipi, " ", Temp1);
                Temp2 = string.Concat(RdMipi, " ", Reg, " ", "1");
                Commands.Add(Temp1);
                Commands.Add(Temp2);
            }

            return (string[])Commands.ToArray(typeof(string));
        }

        private bool RegexGamma(string Gamma, ref byte Value)
        {
            XM_Digital_Util DigUtil = new XM_Digital_Util();
            string[] SplitData = Gamma.Split('=');
            if (SplitData.Length < 2) return false;
            if (!DigUtil.StrToNumber<byte>(SplitData[1].Trim(), ref Value)) return false;
            return true;
        }

        private ArrayList MergeGamma(string RdStr, string RdStr1, string RdStr2, string RdStr3, string RdStrL, bool Final)
        {
            if (string.IsNullOrEmpty(RdStr)) return null;
            if (string.IsNullOrEmpty(RdStr1)) return null;
            if (string.IsNullOrEmpty(RdStrL)) return null;

            byte Val = 0, Val1 = 0, Val2 = 0, Val3 = 0, Val_L = 0;
            ArrayList Point = new ArrayList();
            if (Final)
            {
                if (RegexGamma(RdStr, ref Val) && RegexGamma(RdStr1, ref Val1) && RegexGamma(RdStrL, ref Val_L))
                {
                    int Reg0 = (Val << 2) + ((Val_L & 0xC0) >> 6);
                    int Reg1 = (Val1 << 2) + ((Val_L & 0x30) >> 4);
                    Point.Add(Convert.ToString(Reg0));
                    Point.Add(Convert.ToString(Reg1));
                }
            }
            else
            {
                if (RegexGamma(RdStr, ref Val) && RegexGamma(RdStr1, ref Val1) && RegexGamma(RdStr2, ref Val2) && RegexGamma(RdStr3, ref Val3) && RegexGamma(RdStrL, ref Val_L))
                {
                    int Reg0 = (Val << 2) + ((Val_L & 0xC0) >> 6);
                    int Reg1 = (Val1 << 2) + ((Val_L & 0x30) >> 4);
                    int Reg2 = (Val2 << 2) + ((Val_L & 0x0C) >> 2);
                    int Reg3 = (Val3 << 2) + ((Val_L & 0x03));
                    Point.Add(Convert.ToString(Reg0));
                    Point.Add(Convert.ToString(Reg1));
                    Point.Add(Convert.ToString(Reg2));
                    Point.Add(Convert.ToString(Reg3));
                }
            }
            return Point;
        }

        private bool RdPolarityGamma(int Index)
        {
            string RdStr = null, RdStr1 = null, RdStr2 = null, RdStr3 = null, RdStrL = null;
            ArrayList GammaTemp;
            string Reg = XmGammaVal[Index].Reg; ;
            string[] Cmds = RdMipiData(Reg);
            List<ScriptInfo> lScriptInfo = new List<ScriptInfo>();
           GammaExeCmd.ExamScript(Cmds, lScriptInfo);
            XmGammaVal[Index].Item.Clear();

            for (int i = 0; i < 8; i++)
            {
                if (i == 7)
                {
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8])) SendCmd(lScriptInfo[i * 8], false, ref RdStr);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8 + 1])) SendCmd(lScriptInfo[i * 8 + 1], false, ref RdStr);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8 + 2])) SendCmd(lScriptInfo[i * 8 + 2], false, ref RdStr1);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8 + 3])) SendCmd(lScriptInfo[i * 8 + 3], false, ref RdStr1);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[60 + i * 2])) SendCmd(lScriptInfo[60 + i * 2], false, ref RdStrL);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[61 + i * 2])) SendCmd(lScriptInfo[61 + i * 2], false, ref RdStrL);
                    GammaTemp = MergeGamma(RdStr, RdStr1, RdStr2, RdStr3, RdStrL, true);
                    if (GammaTemp == null) continue;
                    foreach (string GammaVal in GammaTemp) XmGammaVal[Index].Item.Add(GammaVal);

                }
                else
                {
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8])) SendCmd(lScriptInfo[i * 8], false, ref RdStr);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8 + 1])) SendCmd(lScriptInfo[i * 8 + 1], false, ref RdStr);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8 + 2])) SendCmd(lScriptInfo[i * 8 + 2], false, ref RdStr1);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8 + 3])) SendCmd(lScriptInfo[i * 8 + 3], false, ref RdStr1);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8 + 4])) SendCmd(lScriptInfo[i * 8 + 4], false, ref RdStr2);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8 + 5])) SendCmd(lScriptInfo[i * 8 + 5], false, ref RdStr2);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8 + 6])) SendCmd(lScriptInfo[i * 8 + 6], false, ref RdStr3);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[i * 8 + 7])) SendCmd(lScriptInfo[i * 8 + 7], false, ref RdStr3);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[60 + i * 2])) SendCmd(lScriptInfo[60 + i * 2], false, ref RdStrL);
                    if (GammaExeCmd.ExamCmd(lScriptInfo[61 + i * 2])) SendCmd(lScriptInfo[61 + i * 2], false, ref RdStrL);
                    GammaTemp = MergeGamma(RdStr, RdStr1, RdStr2, RdStr3, RdStrL, false);
                    if (GammaTemp == null) continue;
                    foreach (string GammaVal in GammaTemp) XmGammaVal[Index].Item.Add(GammaVal);
                }

                RdStr = RdStr1 = RdStr2 = RdStr3 = RdStrL = null;
                GammaPgsBar.Value = (int)(100 / 12 * (i+1));
                Application.DoEvents();
            }

            return true;
        }

        private bool ExchangeBetweenData(int Master, int IndexA, int IndexB)
        {

            ArrayList Temp = new ArrayList();
            int LenA = XmGammaVal[IndexA].Item.Count, LenB = XmGammaVal[IndexB].Item.Count, MasterIndex = 0;
            if (LenA == 0 || LenB == 0 || LenA != LenB) return false;

            if (Master > 0 && Master == IndexA) MasterIndex = IndexA;
            if (Master > 0 && Master == IndexB) MasterIndex = IndexB;
            if(Master == 0) MasterIndex = IndexA; //prontection


            for (int i = 0; i < LenA; i++)
            {
                string StrA = string.IsNullOrEmpty((string)XmGammaVal[IndexA].Item[i]) ? "0" : XmGammaVal[IndexA].Item[i].ToString();
                string StrB = string.IsNullOrEmpty((string)XmGammaVal[IndexB].Item[i])? "0": XmGammaVal[IndexB].Item[i].ToString();
                string StrMaster = string.IsNullOrEmpty((string)XmGammaVal[MasterIndex].Item[i]) ? "0" : XmGammaVal[MasterIndex].Item[i].ToString();

                if (Master > 0)
                    Temp.Add(StrMaster);
                else
                {
                    if (!string.IsNullOrEmpty(StrA))
                    {
                        Temp.Add(StrA);
                        continue;
                    }
                    else
                        Temp.Add(StrB);
                }
            }

            XmGammaVal[IndexA].Item.Clear();
            XmGammaVal[IndexB].Item.Clear();

            foreach (string Str in Temp)
            {
                XmGammaVal[IndexA].Item.Add(Str);
                XmGammaVal[IndexB].Item.Add(Str);
            }
            return true;
        }

        private bool ExchangeAmongData(int Master, int IndexA, int IndexB, int IndexC)
        {
            ArrayList Temp = new ArrayList();
            int LenA = XmGammaVal[IndexA].Item.Count, LenB = XmGammaVal[IndexB].Item.Count;
            int LenC = XmGammaVal[IndexC].Item.Count, MasterIndex = 0;

            if (LenA == 0 || LenB == 0 || LenC == 0 || LenA != LenB || LenA != LenC || LenB != LenC) return false;

            if (Master == 0) Master = IndexA;
            if (Master > 0 && Master == IndexA) MasterIndex = IndexA;
            if (Master > 0 && Master == IndexB) MasterIndex = IndexB;
            if (Master > 0 && Master == IndexC) MasterIndex = IndexC;
   

            for (int i = 0; i < LenA; i++)
            {
                string ValA = string.IsNullOrEmpty((string)XmGammaVal[IndexA].Item[i]) ? "0" : XmGammaVal[IndexA].Item[i].ToString();
                string ValB = string.IsNullOrEmpty((string)XmGammaVal[IndexB].Item[i]) ? "0" : XmGammaVal[IndexB].Item[i].ToString();
                string ValC = string.IsNullOrEmpty((string)XmGammaVal[IndexC].Item[i]) ? "0" : XmGammaVal[IndexC].Item[i].ToString();
                string StrMaster = XmGammaVal[MasterIndex].Item[i].ToString();
                if (MasterIndex > 0)
                {
                    Temp.Add(StrMaster);
                    continue;
                }
                else
                {
                    if (!string.IsNullOrEmpty(ValA)) { Temp.Add(ValA); continue; }
                    if (!string.IsNullOrEmpty(ValB)) { Temp.Add(ValB); continue; }
                    if (!string.IsNullOrEmpty(ValC)) { Temp.Add(ValC); continue; }
                }
            }

            XmGammaVal[IndexA].Item.Clear();
            XmGammaVal[IndexB].Item.Clear();
            XmGammaVal[IndexC].Item.Clear();

            foreach (string Str in Temp)
            {
                XmGammaVal[IndexA].Item.Add(Str);
                XmGammaVal[IndexB].Item.Add(Str);
                XmGammaVal[IndexC].Item.Add(Str);
            }
            return true;
        }

        //R+ = R-, G+ = G-, B+ =B-
        private void Chk_PosEqNeg_CheckedChanged(object sender, EventArgs e)
        {
            Dgv_Gamma.CellValueChanged -= new DataGridViewCellEventHandler(Dgv_Gamma_CellValueChanged);
            Dgv_Gamma.CellClick -= new DataGridViewCellEventHandler(Dgv_Gamma_CellClick);
            if (Chk_PosEqNeg.Checked)
            {
                SyncGridViewAndMatrix(R_POSTIVE_INDEX, true);
                SyncGridViewAndMatrix(R_NEGTIVE_INDEX, true);
                SyncGridViewAndMatrix(G_POSTIVE_INDEX, true);
                SyncGridViewAndMatrix(G_NEGTIVE_INDEX, true);
                SyncGridViewAndMatrix(B_POSTIVE_INDEX, true);
                SyncGridViewAndMatrix(B_NEGTIVE_INDEX, true);

                //R+ <-> R-
                ExchangeBetweenData(0, R_POSTIVE_INDEX, R_NEGTIVE_INDEX);

                //G+ <-> G- 
                ExchangeBetweenData(0, G_POSTIVE_INDEX, G_NEGTIVE_INDEX);

                //B+ <-> B- 
                ExchangeBetweenData(0, B_POSTIVE_INDEX, B_NEGTIVE_INDEX);

                UpdateGridViewWithIndex(R_POSTIVE_INDEX, true);
                UpdateGridViewWithIndex(R_NEGTIVE_INDEX, true);
                UpdateGridViewWithIndex(G_POSTIVE_INDEX, true);
                UpdateGridViewWithIndex(G_NEGTIVE_INDEX, true);
                UpdateGridViewWithIndex(B_POSTIVE_INDEX, true);
                UpdateGridViewWithIndex(B_NEGTIVE_INDEX, true);

            }

            Dgv_Gamma.CellValueChanged += new DataGridViewCellEventHandler(Dgv_Gamma_CellValueChanged);
            Dgv_Gamma.CellClick += new DataGridViewCellEventHandler(Dgv_Gamma_CellClick);
        }

        //R+ = B+ = G+ ,R- = B- = G-
        private void ChkGamma_PosEqNeg_CheckedChanged(object sender, EventArgs e)
        {
            Dgv_Gamma.CellValueChanged -= new DataGridViewCellEventHandler(Dgv_Gamma_CellValueChanged);
            Dgv_Gamma.CellClick -= new DataGridViewCellEventHandler(Dgv_Gamma_CellClick);

            if (ChkGamma_PosEqNeg.Checked)
            {
                SyncGridViewAndMatrix(R_POSTIVE_INDEX, true);
                SyncGridViewAndMatrix(R_NEGTIVE_INDEX, true);
                SyncGridViewAndMatrix(G_POSTIVE_INDEX, true);
                SyncGridViewAndMatrix(G_NEGTIVE_INDEX, true);
                SyncGridViewAndMatrix(B_POSTIVE_INDEX, true);
                SyncGridViewAndMatrix(B_NEGTIVE_INDEX, true);

                //R+ <-> R-
                ExchangeAmongData(0,R_POSTIVE_INDEX, G_POSTIVE_INDEX, B_POSTIVE_INDEX);

                //G+ <-> G- 
                ExchangeAmongData(0, R_NEGTIVE_INDEX, G_NEGTIVE_INDEX, B_NEGTIVE_INDEX);

                UpdateGridViewWithIndex(R_POSTIVE_INDEX, true);
                UpdateGridViewWithIndex(R_NEGTIVE_INDEX, true);
                UpdateGridViewWithIndex(G_POSTIVE_INDEX, true);
                UpdateGridViewWithIndex(G_NEGTIVE_INDEX, true);
                UpdateGridViewWithIndex(B_POSTIVE_INDEX, true);
                UpdateGridViewWithIndex(B_NEGTIVE_INDEX, true);
            }

            Dgv_Gamma.CellValueChanged += new DataGridViewCellEventHandler(Dgv_Gamma_CellValueChanged);
            Dgv_Gamma.CellClick += new DataGridViewCellEventHandler(Dgv_Gamma_CellClick);
        }

        private void MipiLpGammaCmd()
        {
            SyncGridViewAndMatrix(R_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(R_NEGTIVE_INDEX, true);
            SyncGridViewAndMatrix(G_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(G_NEGTIVE_INDEX, true);
            SyncGridViewAndMatrix(B_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(B_NEGTIVE_INDEX, true);

        }
        /*
            GrayItem: Node 
        */
        private string[] MipiGammaShortCmd(string Mipi_Cmd_Reg, string Mipi_Cmd_Data, int Index, string GammaAddr, int GrayItem)
        {

            int Addr = GrayItem / 4, Count = XmGammaVal[Index].Item.Count;
            string[] GammaCmd = new string[4];

            //Low Btye, D49Dh
            int Val_0 = (Count > 4 * Addr) ? Convert.ToInt32(XmGammaVal[Index].Item[4 * Addr].ToString()) : 0;
            int Val_1 = (Count > 4 * Addr + 1) ? Convert.ToInt32(XmGammaVal[Index].Item[4 * Addr + 1].ToString()) : 0;
            int Val_2 = (Count > 4 * Addr + 2) ? Convert.ToInt32(XmGammaVal[Index].Item[4 * Addr + 2].ToString()) : 0;
            int Val_3 = (Count > 4 * Addr + 3) ? Convert.ToInt32(XmGammaVal[Index].Item[4 * Addr + 3].ToString()) : 0;

            //Low Btye, D49Dh
            int GammaVal = Convert.ToInt32(XmGammaVal[Index].Item[GrayItem].ToString());

            int Data_H = GammaVal >> 2;
            int Data_L = ((Val_0 & 0x03) << 6) + ((Val_1 & 0x03) << 4) + ((Val_2 & 0x03) << 2) + (Val_3 & 0x03);

            GammaCmd[0] = string.Concat(Mipi_Cmd_Reg, " 0x", Convert.ToString(GAMMA_BASE + GrayItem, 16).PadLeft(2, '0'));
            GammaCmd[1] = string.Concat(Mipi_Cmd_Data, GammaAddr, " 0x", Convert.ToString(Data_H, 16).PadLeft(2, '0'));
            GammaCmd[2] = string.Concat(Mipi_Cmd_Reg, " 0x", Convert.ToString(GAMMA_EXT + Addr, 16).PadLeft(2, '0'));
            GammaCmd[3] = string.Concat(Mipi_Cmd_Data, GammaAddr, " 0x", Convert.ToString(Data_L, 16).PadLeft(2, '0'));

            return GammaCmd;
        }

        /*
           GrayItem: Node 
       */
        private bool MipiGammaLongCmd(int Index, int GrayItem,ArrayList Value_H_List,ArrayList Value_L_List)
        {
            int Addr = GrayItem / 4, Count = XmGammaVal[Index].Item.Count;
            //string[] GammaCmd = new string[4];

            //Low Btye, D49Dh
            int Val_0 = (Count > 4 * Addr) ? Convert.ToInt32(XmGammaVal[Index].Item[4 * Addr].ToString()) : 0;
            int Val_1 = (Count > 4 * Addr + 1) ? Convert.ToInt32(XmGammaVal[Index].Item[4 * Addr + 1].ToString()) : 0;
            int Val_2 = (Count > 4 * Addr + 2) ? Convert.ToInt32(XmGammaVal[Index].Item[4 * Addr + 2].ToString()) : 0;
            int Val_3 = (Count > 4 * Addr + 3) ? Convert.ToInt32(XmGammaVal[Index].Item[4 * Addr + 3].ToString()) : 0;

            //Low Btye, D49Dh
            int GammaVal = Convert.ToInt32(XmGammaVal[Index].Item[GrayItem].ToString());

            int Data_H = GammaVal >> 2;
            int Data_L = ((Val_0 & 0x03) << 6) + ((Val_1 & 0x03) << 4) + ((Val_2 & 0x03) << 2) + (Val_3 & 0x03);

            Value_H_List.Add(Data_H);
            Value_L_List.Add(Data_L);

            return true;
        }


        private bool UpdateGridViewWithIndex(int Index, bool MatchGamma)
        {

            int  j = 0;

            if (MatchGamma && XmGammaVal[GAMMA_NODE_INDEX].Item.Count != XmGammaVal[Index].Item.Count) { return false; }
            if (!MatchGamma && XmGammaVal[Index].Item.Count != MAX_GRAYLEVEL) { return false; }

            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                if (MatchGamma)
                {
                    if (XmGammaVal[GAMMA_NODE_INDEX].Item.Count == 0) continue;
                    int RowIndex = Convert.ToInt32((string)XmGammaVal[GAMMA_NODE_INDEX].Item[j]);
                    if (RowIndex == i)
                    {
                        Dgv_Gamma.Rows[RowIndex].Cells[XmGammaVal[Index].Column].Value = XmGammaVal[Index].Item[j];
                        j++;
                    }
                }
                else
                    Dgv_Gamma.Rows[i].Cells[XmGammaVal[Index].Column].Value = XmGammaVal[Index].Item[i];
            }

            return true;
        }



        private bool SyncGridViewAndMatrix(int Index, bool isMatchGamma)
        {
            int j = 0;
            XmGammaVal[Index].Item.Clear();

            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                if (isMatchGamma)
                {
                    if (XmGammaVal[0].Item.Count == 0) continue;
                    int GammaIndex = Convert.ToInt32((string)XmGammaVal[0].Item[j]);

                    if (GammaIndex == i)
                    {
                        XmGammaVal[Index].Item.Add(Dgv_Gamma.Rows[GammaIndex].Cells[XmGammaVal[Index].Column].Value);
                        j++;
                    }
                }
                else
                    XmGammaVal[Index].Item.Add(Dgv_Gamma.Rows[i].Cells[XmGammaVal[Index].Column].Value);
            }

            return true;

        }

        private bool SendScript(string[] GammaCommands)
        {
            double Ratio = (double)100 / GammaCommands.Length;
            string  RdStr = null;
            List<ScriptInfo> lScriptInfo = new List<ScriptInfo>();
            _ = GammaExeCmd.ExamScript(GammaCommands, lScriptInfo);
            for (int i = 0; i < lScriptInfo.Count; i++)
            {
                if (GammaExeCmd.ExamCmd(lScriptInfo[i]))
                {
                    SendCmd(lScriptInfo[i], false, ref RdStr);
                    RdStr = null;
                }
                Application.DoEvents();
                GammaPgsBar.Value = (int)(i * Ratio);
            }
            return true;
        }

        private void FillOutGammaData(ArrayList Data, int Column)
        {
            int j = 0;
            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                int Temp = Convert.ToInt32(XmGammaVal[0].Item[j]);
                if (Temp == i) Dgv_Gamma.Rows[i].Cells[Column].Value = Data[j++];
            }
        }



        private int GetColWithName(string Name)
        {
            foreach (XmGamma XmGammaData in XmGammaVal)
            {
                if (string.Compare(XmGammaData.Name, Name) == 0)
                    return XmGammaData.Column;
            }
            return 0;
        }

        private void Btn_Text_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog
            {
                Filter = "*.txt|*.*",
                FileName = "default.txt",
                FilterIndex = 2,
                RestoreDirectory = true,
                Title = "Save XmPlus Gamma Setting",
                InitialDirectory = Setting.ExeLogDirPath,
            };

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                _ExpTxt = SaveFile.FileName;
                Rtf_Msg.Text = Path.GetFileName(_ExpTxt);
                RecordDataData(_ExpTxt);
            }


        }

        private void Btn_Excel_Click(object sender, EventArgs e)
        {
            SaveFileDialog Save = new SaveFileDialog
            {
                InitialDirectory = Setting.ExeLogDirPath,
                FileName = "Excel_Gamma_Data",
                Filter = "*.xlsx|*.xlsx"
            };
            if (Save.ShowDialog() != DialogResult.OK) return;


            Microsoft.Office.Interop.Excel.Application xls = null;
            try
            {
                xls = new Microsoft.Office.Interop.Excel.Application();
                // Excel WorkBook
                Microsoft.Office.Interop.Excel.Workbook W_Value = xls.Workbooks.Add();

                Microsoft.Office.Interop.Excel.Worksheet Sheet = (Microsoft.Office.Interop.Excel.Worksheet)W_Value.Worksheets[1];
                Sheet.Name = "Gamma";

                W_Value.Worksheets.Add(After: Sheet);
                Sheet = (Microsoft.Office.Interop.Excel.Worksheet)W_Value.Worksheets[2];
                Sheet.Name = "Code";

                W_Value.Worksheets.Add(After: Sheet);
                Sheet = (Microsoft.Office.Interop.Excel.Worksheet)W_Value.Worksheets[3];
                Sheet.Name = "Temp";

                int Count = W_Value.Worksheets.Count;

                // 把 DataGridView 資料塞進 Excel 內
                Sheet = (Microsoft.Office.Interop.Excel.Worksheet)W_Value.Worksheets[1];
                StoreGammaToExcel(Sheet);
                AdjustStyles(Sheet);
                ExportChartToExcel(Sheet);
                Sheet = (Microsoft.Office.Interop.Excel.Worksheet)W_Value.Worksheets[2];
                ExportCodeToExcel(Sheet);
                // Store Data
                W_Value.SaveAs(Save.FileName);
            }
            catch (Exception ex)
            {
                throw ex ;
            }
            finally
            {

                xls.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xls);
            }
        }

        private void AdjustStyles(Microsoft.Office.Interop.Excel.Worksheet Sheet)
        {

            string Range = "A1:L257";  //Set Range
            Sheet.get_Range(Range).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            //Set Location to Center
            Sheet.get_Range(Range).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


        }

        private void ExportCodeToExcel(Microsoft.Office.Interop.Excel.Worksheet Sheet)
        {
            int j = 1;
            ArrayList R_Pos_List = new ArrayList();
            ArrayList R_Neg_List = new ArrayList();
            ArrayList G_Pos_List = new ArrayList();
            ArrayList G_Neg_List = new ArrayList();
            ArrayList B_Pos_List = new ArrayList();
            ArrayList B_Neg_List = new ArrayList();

            if(Rad_HsMipi.Checked)
                GenerateGammaShortCode(R_Pos_List, R_Neg_List, G_Pos_List, G_Neg_List, B_Pos_List, B_Neg_List);
            else
                GenerateGammaLongCode(R_Pos_List, R_Neg_List, G_Pos_List, G_Neg_List, B_Pos_List, B_Neg_List);

            if (R_Pos_List != null) for (int i = 0; i < R_Pos_List.Count; i++) { Sheet.Cells[j++, 1] = R_Pos_List[i]; }
            if (R_Neg_List != null) for (int i = 0; i < R_Neg_List.Count; i++) { Sheet.Cells[j++, 1] = R_Neg_List[i]; }
            if (G_Pos_List != null) for (int i = 0; i < G_Pos_List.Count; i++) { Sheet.Cells[j++, 1] = G_Pos_List[i]; }
            if (G_Neg_List != null) for (int i = 0; i < G_Neg_List.Count; i++) { Sheet.Cells[j++, 1] = G_Neg_List[i]; }
            if (B_Pos_List != null) for (int i = 0; i < G_Pos_List.Count; i++) { Sheet.Cells[j++, 1] = B_Pos_List[i]; }
            if (B_Neg_List != null) for (int i = 0; i < G_Neg_List.Count; i++) { Sheet.Cells[j++, 1] = B_Neg_List[i]; }
        }

        private void ExportChartToExcel(Microsoft.Office.Interop.Excel.Worksheet Sheet)
        {
            string IdealImg = string.Concat(Setting.ExeImgDirPath + "\\" + ".Ideal.bmp");
            string AntiLogImg = string.Concat(Setting.ExeImgDirPath + "\\" + ".AntiLog.bmp");
            XM_IO_Util ImgUtil = new XM_IO_Util();
            if (ImgUtil.FileExist(IdealImg)) ImgUtil.FileDelete(IdealImg);
            if (ImgUtil.FileExist(AntiLogImg)) ImgUtil.FileDelete(AntiLogImg);
            GammaChart.SaveImage(IdealImg, ChartImageFormat.Bmp);
            LogChart.SaveImage(AntiLogImg, ChartImageFormat.Bmp);
            //Sheet.Shapes.AddPicture(IdealImg, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 800, 0, -1, -1);
            //Sheet.Shapes.AddPicture(AntiLogImg, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 800, 200, -1, -1);
        }

        private void StoreGammaToExcel(Microsoft.Office.Interop.Excel.Worksheet Sheet)
        {

            ArrayList ValArrayList = new ArrayList();
            for (int i = 0; i < XmGammaVal.Length; i++) ValArrayList.Add(i.ToString());
            MarkColorForGamma(Sheet, "Index", ValArrayList, 1, 1, false);

            ValArrayList.Clear();
            if (XmGammaVal[0].Item.Count > 0) ValArrayList.AddRange(XmGammaVal[0].Item);
            MarkColorForGamma(Sheet, "Gamma", ValArrayList, 2, 0, true);

            ValArrayList.Clear();
            if (XmGammaVal[1].Item.Count > 0) ValArrayList.AddRange(XmGammaVal[1].Item);
            MarkColorForGamma(Sheet, "Bright", ValArrayList, 3, 1, false);

            ValArrayList.Clear();
            if (XmGammaVal[2].Item.Count > 0) ValArrayList.AddRange(XmGammaVal[2].Item);
            MarkColorForGamma(Sheet, "Bright Ratio", ValArrayList, 4, 1, false);

            ValArrayList.Clear();
            if (XmGammaVal[3].Item.Count > 0) ValArrayList.AddRange(XmGammaVal[3].Item);
            MarkColorForGamma(Sheet, "Ideal Bright", ValArrayList, 5, 1, false);

            ValArrayList.Clear();
            if (XmGammaVal[4].Item.Count > 0) ValArrayList.AddRange(XmGammaVal[4].Item);
            MarkColorForGamma(Sheet, "Difference", ValArrayList, 6, 1, false);


            ValArrayList.Clear();
            if (XmGammaVal[5].Item.Count > 0) ValArrayList.AddRange(XmGammaVal[5].Item);
            MarkColorForGamma(Sheet, "R+", ValArrayList, 7, 2, true);

            ValArrayList.Clear();
            if (XmGammaVal[6].Item.Count > 0) ValArrayList.AddRange(XmGammaVal[6].Item);
            MarkColorForGamma(Sheet, "R-", ValArrayList, 8, 2, true);


            ValArrayList.Clear();
            if (XmGammaVal[7].Item.Count > 0) ValArrayList.AddRange(XmGammaVal[7].Item);
            MarkColorForGamma(Sheet, "G+", ValArrayList, 9, 2, true);


            ValArrayList.Clear();
            if (XmGammaVal[8].Item.Count > 0) ValArrayList.AddRange(XmGammaVal[8].Item);
            MarkColorForGamma(Sheet, "G-", ValArrayList, 10, 2, true);

            ValArrayList.Clear();
            if (XmGammaVal[9].Item.Count > 0) ValArrayList.AddRange(XmGammaVal[9].Item);
            MarkColorForGamma(Sheet, "B+", ValArrayList, 11, 2, true);


            ValArrayList.Clear();
            if (XmGammaVal[10].Item.Count > 0) ValArrayList.AddRange(XmGammaVal[10].Item);
            MarkColorForGamma(Sheet, "B-", ValArrayList, 12, 2, true);

        }
        //Sheet.Cells[i + 1, j], I = Row, J = Column
        private void MarkColorForGamma(Microsoft.Office.Interop.Excel.Worksheet Sheet, string NodeName, ArrayList Items, int Column, int Classify, bool PaintColor)
        {
            int j = 0;
            Sheet.Cells[1, Column] = NodeName;
            Microsoft.Office.Interop.Excel.Range Gamma = Sheet.UsedRange.Columns[2];
            Array GammaValue = (System.Array)Gamma.Cells.Value;


            if (Items.Count == 0) return;
            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                string Value;
                switch (Classify)
                {
                    case 0:
                        Value = (string)Items[j];
                        if (int.Parse(Value) == i)
                        {
                            Microsoft.Office.Interop.Excel.Range RowCell = Sheet.Rows[i + 2];
                            Sheet.Cells[i + 2, Column] = "G";
                            RowCell.Interior.Color = Color.Pink;
                            j++;
                        }

                        break;
                    case 1:
                        Value = Items[i].ToString();
                        Sheet.Cells[i + 2, Column] = Value;
                        break;
                    case 2:
                        if (GammaValue.Length > 0 && string.Compare("G", (string)GammaValue.GetValue(i + 2, 1)) == 0)
                        {
                            Value = (string)Items[j++];
                            Sheet.Cells[i + 2, Column] = Value;
                        }
                        break;
                    default:
                        break;
                }

            }
        }

        private void GammaChart_Click(object sender, EventArgs e)
        {
            XmChart ChartDialog = new XmChart(XmGammaVal[BRIGHT_RATIO_INDEX].Item, XmGammaVal[IDEAL_RATIO_INDEX].Item, XmGammaVal[SPEC_MAXRATIO_INDEX].Item, XmGammaVal[SPEC_MINRATIO_INDEX].Item, MaxSpec, MinSpec);
            ChartDialog.ShowDialog();
        }

        private void LogChart_Click(object sender, EventArgs e)
        {
            XmChart ChartDialog = new XmChart(XmGammaVal[GAMMA_ANTILOG_INDEX].Item);
            ChartDialog.ShowDialog();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            XM_IO_Util SptUtil = new XM_IO_Util();
            if (SptUtil.IsFileExist(_SptPath))
            {
                string[] SptCmds = SptUtil.ReadFile(_SptPath);
                SendScript(SptCmds);
            }

        }

        private void Btn_SptSend_Click(object sender, EventArgs e)
        {
            /*Choose Ini File */
            OpenFileDialog OpenFileDialog = new OpenFileDialog
            {
                Filter = "*.txt|*.*",
                FileName = "default.txt",
                InitialDirectory = Setting.ExeSptDirPath,
            };

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _SptPath = OpenFileDialog.FileName;
                txtbox_SptPath.Text = Path.GetFileName(_SptPath);
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            bStopBright = false;
  
        }

  

        private void BtnCommClose_Click(object sender, EventArgs e)
        {
            if (KonicaDev != null && KonicaDev.IsCommOpen())
            {
                KonicaDev.CommClose();
                KonicaDev = null;
                BtnCommOpen.BackColor = Color.Blue;
                Rtf_Msg.Text = ToolStripSystemInfo.Text = "Close CA-210 Successfully";
            }

            if(kClmtr !=null && kClmtr.isPortOpen)
            {
                kClmtr.closePort();
                kClmtr = null;
                BtnCommOpen.BackColor = Color.Blue;
                Rtf_Msg.Text = ToolStripSystemInfo.Text = "Close K-80 Successfully";
            }
        }

        private bool UpdateGammaIntoDgv(int Coloumn)
        {
            if (Coloumn < R_POSTIVE_COL || Coloumn > B_NEGTIVE_COL) return false;
            int MasterIndex = GetIndexInXmGammaVal(Coloumn);

            SyncGridViewAndMatrix(R_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(R_NEGTIVE_INDEX, true);
            SyncGridViewAndMatrix(G_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(G_NEGTIVE_INDEX, true);
            SyncGridViewAndMatrix(B_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(B_NEGTIVE_INDEX, true);

            if (Chk_PosEqNeg.Checked)
            {
                //R+ <-> R-
                if (MasterIndex == R_POSTIVE_INDEX || MasterIndex == R_NEGTIVE_INDEX) ExchangeBetweenData(MasterIndex, R_POSTIVE_INDEX, R_NEGTIVE_INDEX);

                //G+ <-> G- 
                if (MasterIndex == G_POSTIVE_INDEX || MasterIndex == G_NEGTIVE_INDEX) ExchangeBetweenData(MasterIndex, G_POSTIVE_INDEX, G_NEGTIVE_INDEX);

                //B+ <-> B- 
                if (MasterIndex == B_POSTIVE_INDEX || MasterIndex == B_NEGTIVE_INDEX) ExchangeBetweenData(MasterIndex, B_POSTIVE_INDEX, B_NEGTIVE_INDEX);
            }

            if (ChkGamma_PosEqNeg.Checked)
            {
                //R+ <-> G+ <-> B+
                if (MasterIndex == R_POSTIVE_INDEX || MasterIndex == G_POSTIVE_INDEX || MasterIndex == B_POSTIVE_INDEX)
                    ExchangeAmongData(MasterIndex, R_POSTIVE_INDEX, G_POSTIVE_INDEX, B_POSTIVE_INDEX);

                //R- <-> G- <-> B- 
                if (MasterIndex == R_NEGTIVE_INDEX || MasterIndex == G_NEGTIVE_INDEX || MasterIndex == B_NEGTIVE_INDEX)
                    ExchangeAmongData(MasterIndex, R_NEGTIVE_INDEX, G_NEGTIVE_INDEX, B_NEGTIVE_INDEX);
            }

            UpdateGridViewWithIndex(R_POSTIVE_INDEX, true);
            UpdateGridViewWithIndex(R_NEGTIVE_INDEX, true);
            UpdateGridViewWithIndex(G_POSTIVE_INDEX, true);
            UpdateGridViewWithIndex(G_NEGTIVE_INDEX, true);
            UpdateGridViewWithIndex(B_POSTIVE_INDEX, true);
            UpdateGridViewWithIndex(B_NEGTIVE_INDEX, true);


            return true;
        }

        private bool GenerateGammaLongCode(ArrayList R_Pos_List, ArrayList R_Neg_List, ArrayList G_Pos_List, ArrayList G_Neg_List, ArrayList B_Pos_List, ArrayList B_Neg_List)
        {
            ArrayList R_Pos_H  = new ArrayList();
            ArrayList R_Pos_L = new ArrayList();
            ArrayList R_Neg_H = new ArrayList();
            ArrayList R_Neg_L = new ArrayList();
            ArrayList G_Pos_H = new ArrayList();
            ArrayList G_Pos_L = new ArrayList();
            ArrayList G_Neg_H = new ArrayList();
            ArrayList G_Neg_L = new ArrayList();
            ArrayList B_Pos_H = new ArrayList();
            ArrayList B_Pos_L = new ArrayList();
            ArrayList B_Neg_H = new ArrayList();
            ArrayList B_Neg_L = new ArrayList();
 
            SyncGridViewAndMatrix(R_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(R_NEGTIVE_INDEX, true);
            SyncGridViewAndMatrix(G_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(G_NEGTIVE_INDEX, true);
            SyncGridViewAndMatrix(B_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(B_NEGTIVE_INDEX, true);

            R_Pos_List.Add("# Gamma R+");
            R_Neg_List.Add("# Gamma R-");
            G_Pos_List.Add("# Gamma G+");
            G_Neg_List.Add("# Gamma G-");
            B_Pos_List.Add("# Gamma B+");
            B_Neg_List.Add("# Gamma B-");

            for (int i = 0; i < XmGammaVal[GAMMA_NODE_INDEX].Item.Count; i++)
            {
                MipiGammaLongCmd(R_POSTIVE_INDEX, i, R_Pos_H, R_Pos_L);
                MipiGammaLongCmd(R_NEGTIVE_INDEX, i, R_Neg_H, R_Neg_L);
                MipiGammaLongCmd(G_POSTIVE_INDEX, i, G_Pos_H, G_Pos_L);
                MipiGammaLongCmd(G_NEGTIVE_INDEX, i, G_Neg_H, G_Neg_L);
                MipiGammaLongCmd(B_POSTIVE_INDEX, i, B_Pos_H, B_Pos_L);
                MipiGammaLongCmd(B_NEGTIVE_INDEX, i, B_Neg_H, B_Neg_L);
            }

            //R+
            R_Pos_List.Add(MIPI_LP_CMD_REG);
            R_Pos_List.Add(string.Concat(MIPI_LP_CMD_DATA, " ", XmGammaVal[R_POSTIVE_INDEX].Reg, " ", MergeGammaValue(R_Pos_H, R_Pos_L)));

            //R-
            R_Neg_List.Add(MIPI_LP_CMD_REG);
            R_Neg_List.Add(string.Concat(MIPI_LP_CMD_DATA, " ", XmGammaVal[R_NEGTIVE_INDEX].Reg, " ", MergeGammaValue(R_Neg_H, R_Neg_L)));

            //G+
            G_Pos_List.Add(MIPI_LP_CMD_REG);
            G_Pos_List.Add(string.Concat(MIPI_LP_CMD_DATA, " ", XmGammaVal[G_POSTIVE_INDEX].Reg, " ", MergeGammaValue(G_Pos_H, G_Pos_L)));

            //G-
            G_Neg_List.Add(MIPI_LP_CMD_REG);
            G_Neg_List.Add(string.Concat(MIPI_LP_CMD_DATA, " ", XmGammaVal[G_NEGTIVE_INDEX].Reg, " ", MergeGammaValue(G_Neg_H, G_Neg_L)));

            //B+
            B_Pos_List.Add(MIPI_LP_CMD_REG);
            B_Pos_List.Add(string.Concat(MIPI_LP_CMD_DATA, " ", XmGammaVal[B_POSTIVE_INDEX].Reg, " ", MergeGammaValue(B_Pos_H, B_Pos_L)));

            //B-
            B_Neg_List.Add(MIPI_LP_CMD_REG);
            B_Neg_List.Add(string.Concat(MIPI_LP_CMD_DATA, " ", XmGammaVal[B_NEGTIVE_INDEX].Reg, " ", MergeGammaValue(B_Neg_H, B_Neg_L)));
            return true;
        }

        private bool GenerateGammaShortCode(ArrayList R_Pos_List, ArrayList R_Neg_List, ArrayList G_Pos_List, ArrayList G_Neg_List, ArrayList B_Pos_List, ArrayList B_Neg_List)
        {
            string[] R_Pos_Gamma, R_Neg_Gamma, G_Pos_Gamma, G_Neg_Gamma, B_Pos_Gamma, B_Neg_Gamma;
            string Mipi_Cmd_Reg = MIPI_HS_CMD_REG ;
            string Mipi_Cmd_Data =  MIPI_HS_CMD_DATA ;

            SyncGridViewAndMatrix(R_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(R_NEGTIVE_INDEX, true);
            SyncGridViewAndMatrix(G_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(G_NEGTIVE_INDEX, true);
            SyncGridViewAndMatrix(B_POSTIVE_INDEX, true);
            SyncGridViewAndMatrix(B_NEGTIVE_INDEX, true);

            R_Pos_List.Add("# Gamma R+");
            R_Neg_List.Add("# Gamma R-");
            G_Pos_List.Add("# Gamma G+");
            G_Neg_List.Add("# Gamma G-");
            B_Pos_List.Add("# Gamma B+");
            B_Neg_List.Add("# Gamma B-");

            for (int i = 0; i < XmGammaVal[GAMMA_NODE_INDEX].Item.Count; i++)
            {
                R_Pos_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, R_POSTIVE_INDEX, XmGammaVal[R_POSTIVE_INDEX].Reg, i);
                R_Neg_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, R_NEGTIVE_INDEX, XmGammaVal[R_NEGTIVE_INDEX].Reg, i);
                G_Pos_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, G_POSTIVE_INDEX, XmGammaVal[G_POSTIVE_INDEX].Reg, i);
                G_Neg_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, G_NEGTIVE_INDEX, XmGammaVal[G_NEGTIVE_INDEX].Reg, i);
                B_Pos_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, B_POSTIVE_INDEX, XmGammaVal[B_POSTIVE_INDEX].Reg, i);
                B_Neg_Gamma = MipiGammaShortCmd(Mipi_Cmd_Reg, Mipi_Cmd_Data, B_NEGTIVE_INDEX, XmGammaVal[B_NEGTIVE_INDEX].Reg, i);
                foreach (string Str in R_Pos_Gamma) R_Pos_List.Add(Str);
                foreach (string Str in R_Neg_Gamma) R_Neg_List.Add(Str);
                foreach (string Str in G_Pos_Gamma) G_Pos_List.Add(Str);
                foreach (string Str in G_Neg_Gamma) G_Neg_List.Add(Str);
                foreach (string Str in B_Pos_Gamma) B_Pos_List.Add(Str);
                foreach (string Str in B_Neg_Gamma) B_Neg_List.Add(Str);
            }
            return true;
        }

        private string MergeGammaValue(ArrayList Value_H, ArrayList Value_L)
        {
            string Str = null;
            ArrayList Temp = new ArrayList();
            for (int i = 0; i < XmGammaVal[GAMMA_NODE_INDEX].Item.Count; i += 4)
                Temp.Add(Value_L[i]);

            for (int i = 0; i < Temp.Count; i++)  Value_H.Add(Temp[i]);
            for(int i =0;i<Value_H.Count;i++)  Str += string.Concat("0x", Convert.ToString((int)Value_H[i], 16).PadLeft(2, '0')," ");          
            return Str.Trim();
        }

        private bool SendImage(string Path)
        {
            ArrayList ImageScript = new ArrayList();
            string ImgCmd = string.Concat(MIPI_IMAGE_SHOW, " ", Path);
            ImageScript.Add(ImgCmd);

            if (SendScript((string[])ImageScript.ToArray(typeof(string))))
                Rtf_Msg.Text =Rtf_Msg.Text = ToolStripSystemInfo.Text = "Send Image Finished";
            else
                Rtf_Msg.Text = ToolStripSystemInfo.Text = "Send Image Error";
            return true;
        }

        private void XmGammaTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            GammaExeCmd.SetKonicaClose();
        }

        private void BtnImageSend_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog
            {
                Filter = "*.bmp|*.*",
                FileName = "default.bmp",
                InitialDirectory = Setting.ExeImgDirPath,
            };

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _ImgPath = OpenFileDialog.FileName;
                TxtImgPath.Text = Path.GetFileName(_ImgPath);
                SendImage(_ImgPath);
            }
        }

        private bool RecordDataData(string _ExpTxt)
        {
            XM_IO_Util ExpTool = new XM_IO_Util(_ExpTxt);
            if (ExpTool.IsFileExist(_ExpTxt)) ExpTool.FileDelete(_ExpTxt);

            ArrayList R_Pos_List = new ArrayList();
            ArrayList R_Neg_List = new ArrayList();
            ArrayList G_Pos_List = new ArrayList();
            ArrayList G_Neg_List = new ArrayList();
            ArrayList B_Pos_List = new ArrayList();
            ArrayList B_Neg_List = new ArrayList();

            if(Rad_HsMipi.Checked)
                GenerateGammaShortCode(R_Pos_List, R_Neg_List, G_Pos_List, G_Neg_List, B_Pos_List, B_Neg_List);
            else
                GenerateGammaLongCode(R_Pos_List, R_Neg_List, G_Pos_List, G_Neg_List, B_Pos_List, B_Neg_List);

            ExpTool.AppendTxt(_ExpTxt, R_Pos_List);
            ExpTool.AppendTxt(_ExpTxt, R_Neg_List);
            ExpTool.AppendTxt(_ExpTxt, G_Pos_List);
            ExpTool.AppendTxt(_ExpTxt, G_Neg_List);
            ExpTool.AppendTxt(_ExpTxt, B_Pos_List);
            ExpTool.AppendTxt(_ExpTxt, B_Neg_List);
            return true;
        }


        //Update Data according to Name
        private bool SetDataWithName(string Name, string[] Data)
        {
            int Index = -1;
            foreach (XmGamma XmGammaData in XmGammaVal)
            {
                if (string.Compare(XmGammaData.Name, Name) == 0)
                {
                    Index = XmGammaData.Index;
                    break;
                }
            }
            if (Index > 0)
            {
                XmGammaVal[Index].Item.Clear();
                foreach (string Tmep in Data) XmGammaVal[Index].Item.Add(Tmep);
            }
            return false;
        }

        private int GetIndexInXmGammaVal(int Coloumn)
        {
            int MasterIndex = 0;
            foreach (XmGamma Temp in XmGammaVal)
            {
                if (Temp.Column == Coloumn)
                {
                    MasterIndex = Temp.Index;
                    break;
                }
            }
            return MasterIndex;
        }

        private bool ExamineArrayAsDouble(int index)
        {
            if (XmGammaVal[index].Item.Count != MAX_GRAYLEVEL) return false;
            for(int i=0;i<MAX_GRAYLEVEL;i++)
            {
                if (XmGammaVal[index].Item[i] == null) return false;
                if (!double.TryParse(XmGammaVal[index].Item[i].ToString(), out _))
                    return false;
            }
            return true;
        }    
    }

    public class XmGamma
    {
        public string Name { get; set; }
        public int Column { get; set; }
        public string Reg { get; set; }
        public int Index { get; set; }
        public ArrayList Item { get; set; }
    }
}
