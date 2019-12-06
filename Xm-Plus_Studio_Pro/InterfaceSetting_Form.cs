using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using XM_Tek_Studio_Pro.StudioUtil;
/*
Reg[16]
Reg[0]  :0xa0 ; Reg[1]  :0xa1 ;
Reg[2]  :0x90 ; Reg[3]  :0x94 ;
Reg[4]  :0x95 ; Reg[5]  :0x96 ;

*/

namespace XM_Tek_Studio_Pro
{
    public partial class InterfaceSetting_Form : Form
    {
        private const string HSYNC = "txt_Hsync", HBP = "txt_Hbp", HACTIVE = "txt_Hactive";
        private const string HFP = "txt_Hfp", HTOTAL = "txt_Htotal", VSYNC = "txt_Vsync";
        private const string VBP = "txt_Vbp", VACTIVE = "txt_Vactive", VFP = "txt_Vfp", KeyEnd = "{F1}";
        private const string VTOTAL = "txt_Vtotal", PIXELCLK = "txt_PixelClk", SPISCKL = "txt_SpiSckL";
        private const string SPISCKH = "txt_SpiSckH", TXTI2CSCKL = "txt_i2cSckL", TXTI2CSCKH = "txt_i2cSckH";
        private const byte IF_SPI = 3;
        private string MsgLog = null,SptPath=null;
        private byte Fpag_If = 0, Cpu_Mode = 0, Cpu_DataBus = 0, DialogType = 0;
        private byte SystemClk = 60,SpiMode = 0,SpiWrHClk = 0, SpiWrLClk = 0,SpiRdHClk = 0, SpiRdLClk = 0, SpiRdDummy = 0, SpiSckInv =0, SpiCSCtrl = 0;
        private byte I2CSckH = 0, I2CSckL =0;
        TextStyle BlueStyle = null, MagentaStyle = null, GreenStyle = null, BrownStyle, BlackStyle = null;
        private bool[] SetIndex = new bool[4];
        private List<TabIfCtrl> TabIOCtrl = new List<TabIfCtrl>();
        private List<string> CpuLog = new List<string>(); /* 1.CPU Interface  2.CPU DataBus */
        private List<string> I2CLog = new List<string>();
        private List<string> SpiLog = new List<string>();
        private byte[] Reg = new byte[16];

        public InterfaceSetting_Form(byte DialogType)
        {
            InitializeComponent();
            SetCtrlText();
            SetCtrlItem();
            SetIFCtrl();
            SetRichTextBox();
            InitialLogMsg();
            this.DialogType = DialogType;
        }

        public InterfaceSetting_Form()
        {
            InitializeComponent();
            SetCtrlText();
            SetCtrlItem();
            SetIFCtrl();
            SetRichTextBox();
            InitialLogMsg();
        }

        /*Initial All Log System*/
        private void InitialLogMsg()
        {
            /*Create CPU Log*/
            CpuLog.Add("CPU , I80");
            CpuLog.Add("8bit [D7:D0]");

            /*Create SPI Log*/
            SpiLog.Add("SPI, 3 Wire");

            /*Create I2C Log*/
            I2CLog.Add("I2C");
        }

        private void SetRichTextBox()
        {
            BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
            MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
            GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
            BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
            BlackStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);

            var RichTextBox = new FastColoredTextBox()
            {
                Dock = DockStyle.Fill,
                Name = "FastColoredText",
                ContextMenuStrip = CmsGeneralSet
            };

            Gpx_IfCmd.Controls.Add(RichTextBox);
            RichTextBox.TextChanged += RichTextBox_TextChanged;
        }

        private void RichTextBox_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            FastColoredTextBox FastRichBox = (FastColoredTextBox)sender;
            e.ChangedRange.ClearStyle(BlueStyle,  MagentaStyle, GreenStyle, BrownStyle, BlackStyle);
            e.ChangedRange.SetStyle(BlueStyle, @"\b[\w]+[\.]+bmp\b|\b[\w]+[\.]+png\b|\b[\w]+[\.]+jpg\b");
            e.ChangedRange.SetStyle(GreenStyle, @"#.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(MagentaStyle, @"\b0x[a-fA-F\d]+\b");
            e.ChangedRange.SetStyle(BrownStyle, @"\b[\d]+\b");
            e.ChangedRange.ClearFoldingMarkers();
        }

        private void SetIFCtrl()
        {
            TabIOCtrl.Add(new TabIfCtrl(TabCtrlf.TabPages[0], 0, "Interface"));
            TabIOCtrl.Add(new TabIfCtrl(TabCtrlf.TabPages[1], 1, "CPU"));
            TabIOCtrl.Add(new TabIfCtrl(TabCtrlf.TabPages[2], 2, "RGB Timing"));
            TabIOCtrl.Add(new TabIfCtrl(TabCtrlf.TabPages[3], 3, "RGB Interface"));
            TabIOCtrl.Add(new TabIfCtrl(TabCtrlf.TabPages[4], 4, "SPI_1"));
            TabIOCtrl.Add(new TabIfCtrl(TabCtrlf.TabPages[5], 5, "SPI_2"));
            TabIOCtrl.Add(new TabIfCtrl(TabCtrlf.TabPages[6], 6, "I2C"));
            TabIOCtrl.Add(new TabIfCtrl(TabCtrlf.TabPages[7], 7, "Finish"));
        }

        private void SetCtrlText()
        {
            Rbtn_8bit.Text = "8 bit_[D7:D0]" + "\r\n" +
                                 "6 bit_[D5:D0]" + "\r\n" +
                                 "6 bit_[D7:D2]";

            Rbtn_16bitD17.Text = "16 bit_ " + "\r\n" +
                                 "[D17:D13,D11:D1]";

            Rbtn_16bitD21.Text = "16 bit_ " + "\r\n" +
                                 "[D21:D16,D13:D8,D5:D0]";

            Rbtn_18bitD21.Text = "18 bit_ " + "\r\n" +
                "[D21:D17,D13:D8,D5:D1]";

        }

        private void SetCtrlItem()
        {
            TrvInterface.SelectedNode = TrvInterface.Nodes[0];
            TrvInterface.ExpandAll();
            BtnPrev.Enabled = false;
            SetIndex[3] = SetIndex[2] = SetIndex[1] = SetIndex[0] = false;
            Pic_Pclk_Click(this, null);
            Pic_Hsync_Click(this, null);
            Pic_Vsync_Click(this, null);
            Pic_De_Click(this, null);
            TrvInterface.DrawMode = TreeViewDrawMode.OwnerDrawText;
            TxtI2CSysClk.Text = TxtSpiRdSysClk.Text = TxtSpiWrSysClk.Text =  SystemClk.ToString();
        }

        private void SelectIfNode(TreeNode tn, int index)
        {
            TrvInterface.SelectedNode = tn;
            TabCtrlf.SelectedIndex = index;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            int SumNode = TrvInterface.Nodes.Count - 1;
            int NowIndex = TrvInterface.SelectedNode.Index;
            TabCtrlf.SelectedIndexChanged -= TabCtrlf_SelectedIndexChanged;

            if (TrvInterface.SelectedNode.Index < SumNode)
                SelectIfNode(TrvInterface.Nodes[NowIndex + 1], NowIndex + 1);
            else //Finish
                Finished();
            TabCtrlf.SelectedIndexChanged += TabCtrlf_SelectedIndexChanged;
        }

        private bool Finished()
        {
            if (DialogType == 1)
            {
                CopyToClipBoard(true);
                this.Close();
            }
            else
                SendKeys.Send(KeyEnd);

            //Initial
            TabCtrlf.SelectedIndex = 0;
            TrvInterface.SelectedNode = TrvInterface.Nodes[0];
            SptPath = LblFileName.Text = "";
            return true;
        }

        private void Rbtn_8BitD7D0_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_8BitD7D0.Checked)
            {
                pic_DataBusDef.Image = XM_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_1;
                Cpu_DataBus = 0x00;
                CpuLog[1] = Rbtn_8BitD7D0.Text;
            }
            else if (Rbtn_8bitD17D10.Checked)
            {
                pic_DataBusDef.Image = XM_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_2;
                Cpu_DataBus = 0x01;
                CpuLog[1] = Rbtn_8bitD17D10.Text;
            }
            else if (Rbtn_9bitD8D0.Checked)
            {
                pic_DataBusDef.Image = XM_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_3;
                Cpu_DataBus = 0x02;
                CpuLog[1] = Rbtn_9bitD8D0.Text;
            }
            else if (Rbtn_9bitD17D9.Checked)
            {
                pic_DataBusDef.Image = XM_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_4;
                Cpu_DataBus = 0x03;
                CpuLog[1] = Rbtn_9bitD17D9.Text;
            }
            else if (Rbtn_16bitD15D0.Checked)
            {
                pic_DataBusDef.Image = XM_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_5;
                Cpu_DataBus = 0x04;
                CpuLog[1] = Rbtn_16bitD15D0.Text;
            }
            else if (Rbtn_16bitD17D10D8D1.Checked)
            {
                pic_DataBusDef.Image = XM_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_6;
                Cpu_DataBus = 0x05;
                CpuLog[1] = Rbtn_16bitD17D10D8D1.Text;
            }
            else if (Rbtn_18bitD17D0.Checked)
            {
                pic_DataBusDef.Image = XM_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_7;
                Cpu_DataBus = 0x06;
                CpuLog[1] = Rbtn_18bitD17D0.Text;

            }
            else if (Rbtn_18bitD23D0.Checked)
            {
                pic_DataBusDef.Image = XM_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_8;
                Cpu_DataBus = 0x07;
                CpuLog[1] = Rbtn_18bitD23D0.Text;
            }
            else
            {
                pic_DataBusDef.Image = XM_Tek_Studio_Pro.Properties.Resources.cpu_data_bus;
                Cpu_DataBus = 0x00;
                CpuLog[1] = Rbtn_8BitD7D0.Text;
            }
        }

        private void Pic_Pclk_Click(object sender, EventArgs e)
        {
            if (SetIndex[0])
            {
                pic_Pclk.Image = XM_Tek_Studio_Pro.Properties.Resources.pclk_p1;
                SetIndex[0] = !SetIndex[0];
            }
            else
            {
                pic_Pclk.Image = XM_Tek_Studio_Pro.Properties.Resources.pclk_p0;
                SetIndex[0] = !SetIndex[0];
            }
        }

        private void Pic_Hsync_Click(object sender, EventArgs e)
        {
            if (SetIndex[1])
            {
                pic_Hsync.Image = XM_Tek_Studio_Pro.Properties.Resources.hs_p1;
                SetIndex[1] = !SetIndex[1];
            }
            else
            {
                pic_Hsync.Image = XM_Tek_Studio_Pro.Properties.Resources.hs_p0;
                SetIndex[1] = !SetIndex[1];
            }
        }

        private void Pic_Vsync_Click(object sender, EventArgs e)
        {
            if (SetIndex[2])
            {
                pic_Vsync.Image = XM_Tek_Studio_Pro.Properties.Resources.vs_p1;
                SetIndex[2] = !SetIndex[2];
            }
            else
            {
                pic_Vsync.Image = XM_Tek_Studio_Pro.Properties.Resources.vs_p0;
                SetIndex[2] = !SetIndex[2];
            }
        }

        private void Pic_De_Click(object sender, EventArgs e)
        {
            if (SetIndex[3])
            {
                pic_De.Image = XM_Tek_Studio_Pro.Properties.Resources.de_p1;
                SetIndex[3] = !SetIndex[3];
            }
            else
            {
                pic_De.Image = XM_Tek_Studio_Pro.Properties.Resources.de_p0;
                SetIndex[3] = !SetIndex[3];
            }
        }

        private uint CountScanRate()
        {
            uint data = 0, PixelClk = 0, VTotal = 0, Val = 0;
            XM_Digital_Util verifyStr = new XM_Digital_Util();
            bool ret = true;

            ret = verifyStr.StrToNumber<uint>(TxtPixelClk.Text, ref data);
            if (!ret) return 0;
            PixelClk = data;

            ret = verifyStr.StrToNumber<uint>(TxtVSyncSum.Text, ref data);
            if (!ret) return 0;
            VTotal = data;

            Val = (PixelClk * 1000) / (VTotal);
            return Val;
        }

        private uint CountFrameRate()
        {
            uint data = 0, PixelClk = 0, HTotal = 0, VTotal = 0, Val = 0;
            XM_Digital_Util verifyStr = new XM_Digital_Util();
            bool ret = true;

            ret = verifyStr.StrToNumber<uint>(TxtPixelClk.Text, ref data);
            if (!ret) return 0;
            PixelClk = data;

            ret = verifyStr.StrToNumber<uint>(TxtHSyncSum.Text, ref data);
            if (!ret) return 0;
            HTotal = data;

            ret = verifyStr.StrToNumber<uint>(TxtVSyncSum.Text, ref data);
            if (!ret) return 0;
            VTotal = data;

            Val = (PixelClk * 1000000) / (HTotal * VTotal);
            return Val;
        }

        private string H_CountSum()
        {
            uint data = 0, htotal = 0;
            XM_Digital_Util verifyStr = new XM_Digital_Util();

            bool ret = verifyStr.StrToNumber<uint>(lbl_HsyncVal.Text, ref data);
            if (ret) htotal += data;

            ret = verifyStr.StrToNumber<uint>(lbl_HbpVal.Text, ref data);
            if (ret) htotal += data;

            ret = verifyStr.StrToNumber<uint>(lbl_HactiveVal.Text, ref data);
            if (ret) htotal += data;

            ret = verifyStr.StrToNumber<uint>(lbl_HfpVal.Text, ref data);
            if (ret) htotal += data;

            return htotal.ToString();

        }

        private string V_CountSum()
        {
            uint data = 0, vtotal = 0;
            XM_Digital_Util verifyStr = new XM_Digital_Util();

            bool ret = verifyStr.StrToNumber<uint>(lbl_VsyncVal.Text, ref data);
            if (ret) vtotal += data;

            ret = verifyStr.StrToNumber<uint>(lbl_VbpVal.Text, ref data);
            if (ret) vtotal += data;

            ret = verifyStr.StrToNumber<uint>(lbl_VactiveVal.Text, ref data);
            if (ret) vtotal += data;

            ret = verifyStr.StrToNumber<uint>(lbl_VfpVal.Text, ref data);
            if (ret) vtotal += data;

            return vtotal.ToString();

        }

        private void Rbtn_6bit_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_6bit.Checked)
                pic_showDataBus.Image = XM_Tek_Studio_Pro.Properties.Resources.RGB_d000;
            else if (Rbtn_8bit.Checked)
                pic_showDataBus.Image = XM_Tek_Studio_Pro.Properties.Resources.RGB_d001;
            else if (Rbtn_16bitD15.Checked)
                pic_showDataBus.Image = XM_Tek_Studio_Pro.Properties.Resources.RGB_d010;
            else if (Rbtn_16bitD17.Checked)
                pic_showDataBus.Image = XM_Tek_Studio_Pro.Properties.Resources.RGB_d011;
            else if (Rbtn_16bitD21.Checked)
                pic_showDataBus.Image = XM_Tek_Studio_Pro.Properties.Resources.RGB_d100;
            else if (Rbtn_18bitD17.Checked)
                pic_showDataBus.Image = XM_Tek_Studio_Pro.Properties.Resources.RGB_d101;
            else if (Rbtn_18bitD21.Checked)
                pic_showDataBus.Image = XM_Tek_Studio_Pro.Properties.Resources.RGB_d101;
            else if (Rbtn_24bitD23.Checked)
                pic_showDataBus.Image = XM_Tek_Studio_Pro.Properties.Resources.RGB_d111;
            else
                pic_showDataBus.Image = XM_Tek_Studio_Pro.Properties.Resources.RGB_DATA_BUS;
        }

        private void Rbtn_SpiIf_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_spi4wire.Checked)
            {
                PicSpiInterfaceType.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_4w8b;
                SpiMode = 0x00;
                SpiLog[0] = "SPI, 4 wire";
            }
            else if (Rbtn_spi3wire.Checked)
            {
                PicSpiInterfaceType.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_3w9b;
                SpiMode = 0x01;
                SpiLog[0] = "SPI, 3 wire";
            }
            else
            {
                PicSpiInterfaceType.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_4w8b;
                SpiMode = 0x00;
                SpiLog[0] = "SPI, 4 wire";
            }

        }

        private void Rbtn_SpiRdWandO_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_SpiFallingLatch.Checked)
                PicSpiLatchMode.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_rd_wodmy;
            else if (Rbtn_SpiRisingLatch.Checked)
                PicSpiLatchMode.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_rd_wdmy;
            else
                PicSpiLatchMode.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_rd_wodmy;
        }

        private Label FoundLabelWithSpiClk(TextBox TxtBox)
        {
            if (TxtBox.Name.Contains("Wr"))
                return lbl_SckWrFreqVal;
            else
                return lbl_SckRdFreqVal;
        }

        private TextBox FoundPairSpiClkTxt(TextBox TxtBox)
        {
            int index = 0;
            TextBox[] TxtBoxes = new TextBox[6];
            TxtBoxes[0] = TxtSpiWrSckL;
            TxtBoxes[1] = TxtSpiWrSckH;
            TxtBoxes[2] = TxtSpiRdSckL;
            TxtBoxes[3] = TxtSpiRdSckH;
            TxtBoxes[4] = TxtI2CSckL;
            TxtBoxes[5] = TxtI2CSckH;

            for (int i =0;i< TxtBoxes.Length;i++)
            {
                if (TxtBox.Name.ToString().CompareTo(TxtBoxes[i].Name.ToString()) == 0)
                {
                    index = i;
                    break;
                }
            }

            if (index % 2 == 0)
                index++;
            else
                index--;

            return TxtBoxes[index];
        }

        private void Txt_SpiWrAndRdClk_Leave(object sender, EventArgs e)
        {
            uint Val = 0, PariVal =0;
            double Clk = 0;
            TextBox TxtBox = (TextBox)sender;
            TextBox TxtPairBox = FoundPairSpiClkTxt((TextBox)sender);
            Label LblSpiClk = FoundLabelWithSpiClk((TextBox)sender);

            if (VerifyTxtBox(TxtBox,1,15, ref Val) && VerifyTxtBox(TxtPairBox, 1, 15, ref PariVal))
            {
                Clk = (double)SystemClk / (Val + PariVal);
            }
            LblSpiClk.Text = Clk.ToString();
        }

        private void TxtSysClk_TextChanged(object sender, EventArgs e)
        {
            uint Val = 0;
            TextBox txtbox = (TextBox)sender;
            if (VerifyTxtBox(txtbox, 0, 128, ref Val))
            {
                SystemClk = (byte)Val;
            }
            else
            {
                SystemClk = 60;
            }

            txtbox.Text =  TxtSpiRdSysClk.Text = TxtSpiWrSysClk.Text = SystemClk.ToString();
        }

        private void Rbtn_SpiCsSel_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_SpiCsByUser.Checked == true)
            {
                PicCsSelCtrl.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_csbyuser;
                SpiCSCtrl = 0x00;
            }
            else if (Rbtn_SpiCsIntSel.Checked == true)
            {
                PicCsSelCtrl.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_csbymodule;
                SpiCSCtrl = 0x01;
            }
            else
            {
                PicCsSelCtrl.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_csbyuser;
                SpiCSCtrl = 0x00;
            }
        }

        private void Rbtn_SpiLatch_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_SpiRisingLatch.Checked)
            {
                PicSpiLatchMode.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_ret;
                SpiSckInv = 0x00;
            }
            else if (Rbtn_SpiFallingLatch.Checked)
            {
                PicSpiLatchMode.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_fet;
                SpiSckInv = 0x01;
            }
            else
            {
                PicSpiLatchMode.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_ret;
                SpiSckInv = 0x00;
            }
        }

        private void Rbtn_RdWithNoDummy_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_RdWithDummyClk.Checked)
            {
                PicSpiRdMode.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_rd_wodmy;
                SpiRdDummy = 0x01;
            }
            else if (Rbtn_RdWithNoDummy.Checked)
            {
                PicSpiRdMode.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_rd_wdmy;
                SpiRdDummy = 0x00;
            }
            else
            {
                PicSpiRdMode.Image = XM_Tek_Studio_Pro.Properties.Resources.spi_rd_wodmy;
                SpiRdDummy = 0x00;
            }
        }

        private void InterfaceSetting_Form_Load(object sender, EventArgs e)
        {

        }

        private void Txt_SpiSck_Leave(object sender, EventArgs e)
        {
            uint Val = 0, PariVal = 0;
            double Clk = 0;
            TextBox TxtBox = (TextBox)sender;
            TextBox TxtPairBox = FoundPairSpiClkTxt((TextBox)sender);
            if (VerifyTxtBox(TxtBox, 1, 255, ref Val) && VerifyTxtBox(TxtPairBox, 1, 255, ref PariVal))
            {
                Clk = (double)SystemClk / (Val + PariVal);
            }
            LblI2cFreqVal.Text = Clk.ToString();
        }

        private void AutoCounSckFreq(Label ShwSckl, Label ShwSckh, TextBox SysClk, Label FreqVal)
        {
            uint Val = 0, Freq = 0;
            XM_Digital_Util verifyStr = new XM_Digital_Util();

            bool ret = verifyStr.StrToNumber<uint>(ShwSckl.Text, ref Val);
            if (!ret)
            {
                FreqVal.Text = "0";
                return;
            }

            Freq += Val;

            ret = verifyStr.StrToNumber<uint>(ShwSckh.Text, ref Val);
            if (!ret)
            {
                FreqVal.Text = "0";
                return;
            }

            Freq += Val;

            ret = verifyStr.StrToNumber<uint>(SysClk.Text, ref Val);
            if (ret)
                FreqVal.Text = (Val / Freq).ToString();
            else
                FreqVal.Text = "0";
        }

        private bool VerifyTxtBox(TextBox txtbox,uint Min, uint Max, ref uint Val)
        {
            XM_Digital_Util verifyStr = new XM_Digital_Util();
            bool ret = verifyStr.StrToNumber<uint>(txtbox.Text, ref Val);
            if(ret)
            {
                if (verifyStr.BoolWithinRange(Val, Min, Max))
                {
                    txtbox.BackColor = Color.White;
                    if (txtbox == TxtSpiWrSckL) SpiWrLClk = (byte)Val;
                    if (txtbox == TxtSpiWrSckH) SpiWrHClk = (byte)Val;
                    if (txtbox == TxtSpiRdSckL) SpiRdLClk = (byte)Val;
                    if (txtbox == TxtSpiRdSckH) SpiRdHClk = (byte)Val;
                    if (txtbox == TxtI2CSckL) I2CSckL = (byte)Val;
                    if (txtbox == TxtI2CSckH) I2CSckH = (byte)Val;
                }
                else
                {
                    txtbox.BackColor = Color.Pink;
                    ret = false;
                }
            }else
                txtbox.BackColor = Color.Pink;
            return ret;
        }

        private void TxtBox_TabKeySend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }


        private void Txt_Hsync_Leave(object sender, EventArgs e)
        {
            XM_IO_Util verifyStr = new XM_IO_Util();
            uint val = 0;
            TextBox txtbox = (TextBox)sender;
            if (VerifyTxtBox(txtbox, 0, 255, ref val))
            {
                ShowTxtolbl(txtbox.Name.ToString(), val);
                AutoCountSum();
            }
        }


        private void CopyToClipBoradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyToClipBoard(false);
        }

        /*Show Data to Label*/
        private void ShowTxtolbl(string TxtName, uint value)
        {
            if (TxtName == HSYNC)
                lbl_HsyncVal.Text = value.ToString();
            if (TxtName == HBP)
                lbl_HbpVal.Text = value.ToString();
            if (TxtName == HACTIVE)
                lbl_HactiveVal.Text = value.ToString();
            if (TxtName == HFP)
                lbl_HfpVal.Text = value.ToString();
            if (TxtName == VSYNC)
                lbl_VsyncVal.Text = value.ToString();
            if (TxtName == VBP)
                lbl_VbpVal.Text = value.ToString();
            if (TxtName == VACTIVE)
                lbl_VactiveVal.Text = value.ToString();
            if (TxtName == VFP)
                lbl_VfpVal.Text = value.ToString();
            if (TxtName == PIXELCLK)
                lbl_PixelClkVal.Text = value.ToString();
            if (TxtName == SPISCKL)
                lbl_shwSckL.Text = value.ToString();
            if (TxtName == SPISCKH)
                lbl_shwSckH.Text = value.ToString();
            if (TxtName == TXTI2CSCKL)
                lbl_i2csckH.Text = value.ToString();
            if (TxtName == TXTI2CSCKH)
                lbl_i2csckL.Text = value.ToString();
        }

        private void AutoCountSum()
        {
            TxtHSyncSum.Text = H_CountSum();
            TxtVSyncSum.Text = V_CountSum();

            lbl_fpRateVal.Text = CountFrameRate().ToString() + " HZ";
            lbl_ScanRateVal.Text = CountScanRate().ToString() + " KHZ";
        }

        private void Txt_sysClk_Leave(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            uint val = 0;
            if (VerifyTxtBox(txtbox,0,255, ref val))
            {
                TxtSpiWrSysClk.Text = val.ToString();
                TxtI2CSysClk.Text = val.ToString();
                TxtSpiWrSysClk.Enabled = false;
                TxtI2CSysClk.Enabled = false;
            }
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            int NowIndex = TrvInterface.SelectedNode.Index;
            if (NowIndex >= 0)
            {
                SelectIfNode(TrvInterface.Nodes[NowIndex - 1], NowIndex - 1);
            }
        }

        private void TrvInterface_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Index == 0)
            {
                BtnPrev.Enabled = false;
                BtnNext.Text = "Next";
                TabCtrlf.SelectedIndex = 0;
            }
            else if (e.Node.Index == TrvInterface.Nodes.Count - 1)
            {
                BtnPrev.Enabled = true;
                BtnNext.Text = "Finish";
                RtfShowCmdResult();
                TabCtrlf.SelectedIndex = e.Node.Index;
            }
            else
            {
                BtnPrev.Enabled = true;
                BtnNext.Text = "Next";
                TabCtrlf.SelectedIndex = e.Node.Index;
            }
        }

        private void TrvInterface_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null) return;

            // if treeview's HideSelection property is "True", 
            // this will always returns "False" on unfocused treeview
            var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            var unfocused = !e.Node.TreeView.Focused;

            // we need to do owner drawing only on a selected node
            // and when the treeview is unfocused, else let the OS do it for us
            if (selected && unfocused)
            {
                var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void ShowIfTabCtrl(bool bCpu, bool bRgbTime, bool bRgbIf, bool bSpi, bool bi2c)
        {
            TabCtrlf.TabPages.Clear();
            TabCtrlf.TabPages.Add(TabIOCtrl[0].CtrlPage);
            if (bCpu) TabCtrlf.TabPages.Add(TabIOCtrl[1].CtrlPage);
            if (bRgbTime) TabCtrlf.TabPages.Add(TabIOCtrl[2].CtrlPage);
            if (bRgbIf) TabCtrlf.TabPages.Add(TabIOCtrl[3].CtrlPage);
            if (bSpi) { TabCtrlf.TabPages.Add(TabIOCtrl[4].CtrlPage); TabCtrlf.TabPages.Add(TabIOCtrl[5].CtrlPage); }
            if (bi2c) TabCtrlf.TabPages.Add(TabIOCtrl[6].CtrlPage);
            TabCtrlf.TabPages.Add(TabIOCtrl[7].CtrlPage);
        }

        private void ShowTrvIfCtrl(bool bCpu, bool bRgbTime, bool bRgbIf, bool bSpi, bool bi2c)
        {
            int Index = 1;
            TrvInterface.Nodes.Clear();
            TrvInterface.Nodes.Add(string.Concat(Index++.ToString(), ". ", TabIOCtrl[0].Name));
            if (bCpu) TrvInterface.Nodes.Add(string.Concat(Index++.ToString(), ". ", TabIOCtrl[1].Name));
            if (bRgbTime) TrvInterface.Nodes.Add(string.Concat(Index++.ToString(), ". ", TabIOCtrl[2].Name));
            if (bRgbIf) TrvInterface.Nodes.Add(string.Concat(Index++.ToString(), ". ", TabIOCtrl[3].Name));
            if (bSpi)
            { 
                TrvInterface.Nodes.Add(string.Concat(Index++.ToString(), ". ", TabIOCtrl[4].Name));
                TrvInterface.Nodes.Add(string.Concat(Index++.ToString(), ". ", TabIOCtrl[5].Name));
            }
            if (bi2c) TrvInterface.Nodes.Add(string.Concat(Index++.ToString(), ". ", TabIOCtrl[6].Name));
            TrvInterface.Nodes.Add(string.Concat(Index++.ToString(), ". ", TabIOCtrl[7].Name));
        }

        private void CboFpgaIf_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CboSelectedIndex = CboFpgaIf.SelectedIndex;
            TabCtrlf.SelectedIndexChanged -= TabCtrlf_SelectedIndexChanged;
            TrvInterface.AfterSelect -= TrvInterface_AfterSelect;
            Array.Clear(Reg, 0, Reg.Length);
            switch (CboSelectedIndex)
            {
                case 0: //CPU
                    ShowIfTabCtrl(true, false, false, false, false);
                    ShowTrvIfCtrl(true, false, false, false, false);
                    Fpag_If = 0x00;
                    break;
                case 1: //SPI
                    ShowIfTabCtrl(false, false, false, true, false);
                    ShowTrvIfCtrl(false, false, false, true, false);
                    Fpag_If = 0x18;
                    break;
                case 2: //I2C
                    ShowIfTabCtrl(false, false, false, false, true);
                    ShowTrvIfCtrl(false, false, false, false, true);
                    Fpag_If = 0x20;
                    break;
                case 3://RGB+SPI
                    ShowIfTabCtrl(false, true, true, true, false);
                    ShowTrvIfCtrl(false, true, true, true, false);
                    break;
                case 4: //RGB+I2C
                    ShowIfTabCtrl(false, true, true, true, false);
                    ShowTrvIfCtrl(false, true, true, true, false);
                    break;
                default:
                    break;
            }


            TabCtrlf.SelectedIndexChanged += TabCtrlf_SelectedIndexChanged;
            TrvInterface.AfterSelect += TrvInterface_AfterSelect;
            TrvInterface.SelectedNode = TrvInterface.Nodes[0];
        }

        private void TabCtrlf_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectIfNode(TrvInterface.Nodes[TabCtrlf.SelectedIndex], TabCtrlf.SelectedIndex);
        }

        private void RtBtn_CpuIf_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton RdBtn = sender as RadioButton;
            if (RdBtn.Checked == true)
            {
                switch (RdBtn.Text)
                {
                    case "I80":
                        CpuLog[0] = Properties.Resources.LOG_CPU_I80; 
                         Cpu_Mode = 0x00;
                        break;
                    case "M68":
                        CpuLog[0] = Properties.Resources.LOG_CPU_M68;
                        Cpu_Mode = 0x08;
                        break;
                }
            }
        }

        private bool SetSpiUi(byte MainIf, byte SlaveIf)
        {
            if (MainIf != IF_SPI) return false;
            Rbtn_spi4wire.Checked = (SlaveIf == 0) ? true : false;
            Rbtn_spi3wire.Checked = (SlaveIf == 1) ? true : false;

            TxtSpiWrSckH.Text = SpiWrHClk.ToString();
            TxtSpiWrSckL.Text = SpiWrLClk.ToString();

            TxtSpiRdSckH.Text = SpiRdHClk.ToString();
            TxtSpiRdSckL.Text = SpiRdLClk.ToString();

            Rbtn_RdWithDummyClk.Checked = (SpiRdDummy == 0) ? true : false; 
            Rbtn_RdWithNoDummy.Checked = (SpiRdDummy == 1) ? true : false;

            Rbtn_SpiRisingLatch.Checked = (SpiSckInv==0) ? true : false;
            Rbtn_SpiFallingLatch.Checked = (SpiSckInv == 1) ? true : false;

            Rbtn_SpiCsByUser.Checked = (SpiCSCtrl == 0) ? true : false;
            Rbtn_SpiCsIntSel.Checked = (SpiCSCtrl == 1) ? true : false;

            return true;
        }

        private bool SetI2CUi(byte MainIf, byte SlaveIf)
        {
            TxtI2CSckH.Text = I2CSckH.ToString();
            TxtI2CSckL.Text = I2CSckL.ToString();
            return true;
        }


        private bool SetCpuUi(byte MainIf,byte SlaveIf)
        {
            //CPU Mode
            switch (MainIf)
            {
                case 0:
                    RbtnI80.Checked = true;
                    break;
                case 1:
                    RbtnM68.Checked = true;
                    break;
                default:
                    RbtnI80.Checked = true;
                    break;
            }
           
            //CPU Data Mode
            switch (SlaveIf)
            {
                case 0:
                    Rbtn_8BitD7D0.Checked = true;
                    break;
                case 1:
                    Rbtn_8bitD17D10.Checked = true;
                    break;
                case 2:
                    Rbtn_9bitD8D0.Checked = true;
                    break;
                case 3:
                    Rbtn_9bitD17D9.Checked = true;
                    break;
                case 4:
                    Rbtn_16bitD15D0.Checked = true;
                    break;
                case 5:
                    Rbtn_16bitD17D10D8D1.Checked = true;
                    break;
                case 6:
                    Rbtn_18bitD17D0.Checked = true;
                    break;
                case 7:
                    Rbtn_18bitD23D0.Checked = true;
                    break;
                default:
                    Rbtn_8BitD7D0.Checked = true;
                    break;
            }
            return true;
        }

        private void SetUIwithReg()
        {
            byte MainIf = (byte)(Reg[0] >> 3);
            byte SlaveIf = (byte)(Reg[0] & 0x07);
            switch (MainIf)
            {
                case 0:
                case 1:
                    CboFpgaIf.SelectedIndex = 0;
                    SetCpuUi(MainIf, SlaveIf);
                    break;
                case 2:

                    break;
                case 3:
                    CboFpgaIf.SelectedIndex = 1;
                    SetSpiUi(MainIf, SlaveIf);
                    break;
                case 4:
                    CboFpgaIf.SelectedIndex = 2;
                    SetI2CUi(MainIf, SlaveIf);
                    break;
                default:
                    break;
            }
        }


        private bool SetIfWithSpt(string FilePath)
        {
            string[] Script = null;
            byte WrClk = 0, RdClk = 0;
            XM_IO_Util XmUtil = new XM_IO_Util();
            XM_IFSpt_Util XmIFUtil = null ;
            if (XmUtil.FileExist(FilePath))
            { 
                Script = XmUtil.ReadFile(FilePath);
                XmIFUtil =  new XM_IFSpt_Util(Script);
                XmIFUtil.CmdRegWithSpt("fpga.set", 3, ref Reg[0]);
                XmIFUtil.CmdRegWithSpt("fpga.set", 4, ref Reg[1]);

                //SPI
                XmIFUtil.CmdRegWithSpt("spi.set", 1, ref SpiRdDummy);
                XmIFUtil.CmdRegWithSpt("spi.set", 2, ref SpiSckInv);
                XmIFUtil.CmdRegWithSpt("spi.set", 3, ref SpiCSCtrl);
                XmIFUtil.CmdRegWithSpt("spi.set", 4, ref WrClk);
                XmIFUtil.CmdRegWithSpt("spi.set", 5, ref RdClk);

                SpiWrHClk = (byte)(WrClk >> 4);
                SpiWrLClk = (byte)(WrClk & 0x0f);
                SpiRdHClk = (byte)(RdClk >> 4);
                SpiRdLClk = (byte)(RdClk & 0x0f);

                //I2C
                XmIFUtil.CmdRegWithSpt("i2c.set", 1, ref I2CSckH);
                XmIFUtil.CmdRegWithSpt("i2c.set", 2, ref I2CSckL);

                SetUIwithReg();
            }
            else
                return false;

            return true;
        }


        private void BtnLoadConfig_Click(object sender, EventArgs e)
        {
            /*Choose Ini File */
            OpenFileDialog OdlgScript = new OpenFileDialog
            {
                Filter = "*.txt|*.*",
                FileName = "default.txt",
                InitialDirectory = Setting.ExeSptDirPath,
            };

            if (OdlgScript.ShowDialog() == DialogResult.OK)
            {
                SptPath = OdlgScript.FileName;
                LblFileName.Text = Path.GetFileName(SptPath);
                SetIfWithSpt(SptPath);
            }
        }

        private void RtfShowCmdResult()
        {
            string Code = null;
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Gpx_IfCmd.Controls["FastColoredText"];
            if (Fpag_If == 0) Code = CreateCpuCode();
            if (Fpag_If == 0x18) Code = CreateSpiCode();
            if (Fpag_If == 0x20) Code = CreateI2cCode();
            FastRichBox.Text = Code;

        }

        private string CreateSpiCode()
        {
            byte RdClk = 0, WrClk = 0;
            Reg[0] = (byte)(Fpag_If | SpiMode );
            Reg[1] = 0x00;

            //Gererate Comment
            MsgLog = string.Concat("#", SpiLog[0]);

            //Create Code
            string StrFpgaSet = string.Concat(Properties.Resources.STR_FPGA_SET, " ", String.Format("0x{0:X2}", Reg[0])); //Reg[0] => 0xa0
            StrFpgaSet = string.Concat(StrFpgaSet, " ", String.Format("0x{0:X2}", Reg[1])); //Reg[0] => 0xa1
            StrFpgaSet = string.Concat(StrFpgaSet, " ", Properties.Resources.STR_NULL_HEX);

            WrClk = (byte)((SpiWrHClk << 4) + SpiWrLClk);
            RdClk = (byte)((SpiRdHClk << 4 )+ SpiRdLClk);

            //SPI Set
            string StrSpiSet = string.Concat(Properties.Resources.STR_SPI_SET, " ", string.Format("0x{0:X2}", SpiCSCtrl));
            StrSpiSet = string.Concat(StrSpiSet, " ", string.Format("0x{0:X2}", SpiSckInv));
            StrSpiSet = string.Concat(StrSpiSet, " ", string.Format("0x{0:X2}", SpiRdDummy));
            StrSpiSet = string.Concat(StrSpiSet, " ", string.Format("0x{0:X2}", WrClk));
            StrSpiSet = string.Concat(StrSpiSet, " ", string.Format("0x{0:X2}", RdClk));
            return string.Concat(MsgLog, "\r\n", StrFpgaSet, "\r\n", StrSpiSet);

        }

        private string CreateI2cCode()
        {
            byte RdClk = 0, WrClk = 0;
            Reg[0] = (byte)(Fpag_If);
            Reg[1] = 0x00;

            //Gererate Comment
            MsgLog = string.Concat("#", I2CLog[0]);

            //Create Code
            string StrFpgaSet = string.Concat(Properties.Resources.STR_FPGA_SET, " ", String.Format("0x{0:X2}", Reg[0])); //Reg[0] => 0xa0
            StrFpgaSet = string.Concat(StrFpgaSet, " ", String.Format("0x{0:X2}", Reg[1])); //Reg[0] => 0xa1
            StrFpgaSet = string.Concat(StrFpgaSet, " ", Properties.Resources.STR_NULL_HEX);

            WrClk = (byte)((SpiWrHClk << 4) + SpiWrLClk);
            RdClk = (byte)((SpiRdHClk << 4) + SpiRdLClk);

            //SPI Set
            string StrI2CSet = string.Concat(Properties.Resources.STR_I2C_SET, " ", string.Format("0x{0:X2}", I2CSckH));
            StrI2CSet = string.Concat(StrI2CSet, " ", string.Format("0x{0:X2}", I2CSckL));

            return string.Concat(MsgLog, "\r\n", StrFpgaSet, "\r\n", StrI2CSet);
        }

        private string CreateCpuCode()
        {
            string StrFpgaSet = null;

            //Initial Code
            Reg[0] = (byte)(Fpag_If | Cpu_Mode | Cpu_DataBus);
            Reg[1] = 0x00;

            //Gererate Comment
            MsgLog = string.Concat("#", CpuLog[0], " , ", CpuLog[1]);

            //Create Code
            StrFpgaSet = string.Concat(Properties.Resources.STR_FPGA_SET, " ", String.Format("0x{0:X2}", Reg[0])); //Reg[0] => 0xa0
            StrFpgaSet = string.Concat(StrFpgaSet, " ", String.Format("0x{0:X2}", Reg[1])); //Reg[0] => 0xa1
            StrFpgaSet = string.Concat(StrFpgaSet, " ", Properties.Resources.STR_NULL_HEX);
            return string.Concat(MsgLog, "\r\n", StrFpgaSet);
        }

        private void CopyToClipBoard(bool bAll)
        {
            FastColoredTextBox FastRichBox = (FastColoredTextBox)Gpx_IfCmd.Controls["FastColoredText"];
            string Code = (FastRichBox.Selection.Text.Length == 0) ? FastRichBox.Text : FastRichBox.Selection.Text;
            if (bAll) Code = FastRichBox.Text;
            Clipboard.SetText(Code);
        }


    }
    public class TabIfCtrl
    {
        public TabIfCtrl(TabPage CtrlPage, int TabIndex, string TabName)
        {
            this.CtrlPage = CtrlPage;
            this.Index = TabIndex;
            this.Name = TabName;
        }
        public TabPage CtrlPage { get; private set; }
        public int Index { get; private set; }
        public string Name { get; private set; }
    }
}
