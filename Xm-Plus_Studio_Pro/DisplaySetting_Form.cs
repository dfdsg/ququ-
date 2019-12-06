using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SC_Tek_Studio_Pro
{
    public partial class DisplaySetting_Form : Form
    {
        private int TotalCountNode = 0;
        private const string INTERFACE = "Interface";
        private const string CPU = "2.CPU";
        private const string RGB = "3.RGB";
        private const string MIPI = "4.MIPI";
        private const string SPI = "5.SPI";
        private const string I2C = "6.I2C";
        private const string HSYNC = "txt_Hsync";
        private const string HBP = "txt_Hbp";
        private const string HACTIVE = "txt_Hactive";
        private const string HFP = "txt_Hfp";
        private const string HTOTAL = "txt_Htotal";
        private const string VSYNC = "txt_Vsync";
        private const string VBP = "txt_Vbp";
        private const string VACTIVE = "txt_Vactive";
        private const string VFP = "txt_Vfp";
        private const string VTOTAL = "txt_Vtotal";
        private const string PIXELCLK = "txt_PixelClk";
        private const string SPISCKL = "txt_SpiSckL";
        private const string SPISCKH = "txt_SpiSckH";
        private const string I2CSCKL = "txt_i2cSckL";
        private const string I2CSCKH = "txt_i2cSckH";

        private bool[] SetIndex = new bool[4];
        public DisplaySetting_Form()
        {
            InitializeComponent();
            SetCtrlText();
            SetControlItem(); 
        }

        private void SetCtrlText()
        {
            rbtn_8bit.Text = "8 bit_[D7:D0]" + "\r\n" +
                                 "6 bit_[D5:D0]" + "\r\n" +
                                 "6 bit_[D7:D2]";

            rbtn_16bitD17.Text = "16 bit_ "+ "\r\n" +
                                 "[D17:D13,D11:D1]" ;

            rbtn_16bitD21.Text = "16 bit_ " + "\r\n" +
                                 "[D21:D16,D13:D8,D5:D0]";

            rbtn_18bitD21.Text = "18 bit_ " + "\r\n" +
                "[D21:D17,D13:D8,D5:D1]";

        }

        private void SetControlItem()
        {
            //Setting
            /*
            tabCtrlConfig.SizeMode = TabSizeMode.Fixed;
            tabCtrlConfig.Appearance = TabAppearance.FlatButtons;
            tabCtrlConfig.ItemSize = new Size(0, 1);
            */
            //TreeView
            TotalCountNode = tvw_SysConfig.Nodes[0].GetNodeCount(true);

            TreeNode tn = tvw_SysConfig.Nodes[0].Nodes[0];
            tvw_SysConfig.SelectedNode = tn;
            tvw_SysConfig.ExpandAll();
            btnPrev.Enabled = false;
            //tabCtrlConfig.TabPages.Add(new MyTabPage(new SubTabPage()));
            //tabCtrlConfig.TabPages.Remove(tabCtrlConfig.TabPages[0]);
            SetIndex[3] = SetIndex[2] = SetIndex[1] = SetIndex[0] = false;
            pic_Pclk_Click(this, null);
            pic_Hsync_Click(this, null);
            pic_Vsync_Click(this, null);
            pic_De_Click(this, null);
        }



        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Index == 0 && e.Node.Parent == null)
            {
                tabCtrlConfig.SelectedIndex = 0;
                btnPrev.Enabled = false;
                btnNext.Enabled = true;
                btnNext.Text = "Next";
            }
            else if (e.Node.Index == 0 && e.Node.Parent.Text == INTERFACE)
            {
                btnPrev.Enabled = false;
                btnNext.Text = "Next";
                tabCtrlConfig.SelectedIndex = 0;
            }
            else if (e.Node.Index == 1 && e.Node.Parent.Text == INTERFACE)
            {
                btnPrev.Enabled = true;
                btnNext.Text = "Next";
                tabCtrlConfig.SelectedIndex = 1;
            }
            else if (e.Node.Index == 2 )
            {
                btnPrev.Enabled = true;
                btnNext.Text = "Next";
                tabCtrlConfig.SelectedIndex = 2;
            }
            else if (e.Node.Index == 0 && e.Node.Parent.Text == RGB)
            {
                btnPrev.Enabled = true;
                btnNext.Text = "Next";
                tabCtrlConfig.SelectedIndex = 2;
            }
            else if(e.Node.Index == 1 && e.Node.Parent.Text == RGB)
            {
                btnPrev.Enabled = true;
                btnNext.Text = "Next";
                tabCtrlConfig.SelectedIndex = 3;
            }
            else if (e.Node.Index == 3)
            {
                btnPrev.Enabled = true;
                btnNext.Text = "Next";
                tabCtrlConfig.SelectedIndex = 4;
            }
            else if (e.Node.Index == 4 )
            {
                btnPrev.Enabled = true;
                btnNext.Text = "Next";
                tabCtrlConfig.SelectedIndex = 5;
            }
            else if (e.Node.Index == 5)
            {
                tabCtrlConfig.SelectedIndex = 6;
                btnPrev.Enabled = true;
                btnNext.Enabled = true;
                btnNext.Text = "Finish";
            }
            else
                tabCtrlConfig.SelectedIndex = 0;

       
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            TreeNode PrevTn, NowTn;
            int NowIndex = tvw_SysConfig.SelectedNode.Index, tabCtrlIndex = 0;
            NowTn = tvw_SysConfig.SelectedNode;
            if (NowIndex >= 0)
            {
                if (NowIndex == 0 && NowTn.Parent == null)
                {
                    PrevTn = tvw_SysConfig.Nodes[0].Nodes[0];
                    tabCtrlIndex = 0;
                }
                else if (NowIndex == 0 && NowTn.Parent.Text == INTERFACE)
                {
                    PrevTn = tvw_SysConfig.Nodes[0].Nodes[0];
                    tabCtrlIndex = 0;
                }
                else if (NowIndex == 1 && NowTn.Parent.Text == INTERFACE)
                {
                    PrevTn = tvw_SysConfig.Nodes[0].Nodes[0];
                    tabCtrlIndex = 0;
                }
                else if (NowIndex == 2 && NowTn.Parent.Text == INTERFACE)
                {
                    PrevTn = tvw_SysConfig.Nodes[0].Nodes[1];
                    tabCtrlIndex = 1;
                }
                else if (NowIndex == 0 && NowTn.Parent.Text == RGB)
                {
                    PrevTn = tvw_SysConfig.Nodes[0].Nodes[1];
                    tabCtrlIndex = 1;
                }
                else if (NowIndex == 1 && NowTn.Parent.Text == RGB)
                {
                    PrevTn = tvw_SysConfig.Nodes[0].Nodes[2].Nodes[0];
                    tabCtrlIndex = 2;
                }
                else if (NowIndex == 3 && NowTn.Parent.Text == INTERFACE)
                {
                    PrevTn = tvw_SysConfig.Nodes[0].Nodes[2].Nodes[1];
                    tabCtrlIndex = 3;
                }
                /*
                else if (NowIndex == 4 && NowTn.Parent.Text == INTERFACE)
                {
                    PrevTn = treeView1.Nodes[0].Nodes[3];
                    tabCtrlIndex = 4;
                }
                else if (NowIndex == 5 && NowTn.Parent.Text == INTERFACE)
                {
                    PrevTn = treeView1.Nodes[0].Nodes[4];
                    tabCtrlIndex = 5;
                }
                */
                else
                {
                    PrevTn = tvw_SysConfig.Nodes[0].Nodes[NowIndex -1];
                    tabCtrlIndex = NowIndex;
                }

                tvw_SysConfig.SelectedNode = PrevTn;
                tabCtrlConfig.SelectedIndex = tabCtrlIndex;

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TreeNode NextTn,NowTn;
            int NowIndex = tvw_SysConfig.SelectedNode.Index,tabCtrlIndex = 0;
            NowTn = tvw_SysConfig.SelectedNode;
            if (tvw_SysConfig.SelectedNode.Index < (TotalCountNode-1)  )
            {
                if (NowIndex == 0 && NowTn.Parent == null)
                {
                    NextTn = tvw_SysConfig.Nodes[0].Nodes[1];
                    tabCtrlIndex = 1;
                }
                else if (NowIndex == 0 && NowTn.Parent.Text == INTERFACE)
                { 
                    NextTn = tvw_SysConfig.Nodes[0].Nodes[1];
                    tabCtrlIndex = 1;
                }
                else if (NowIndex == 1 && NowTn.Parent.Text == INTERFACE)
                { 
                    NextTn = tvw_SysConfig.Nodes[0].Nodes[2].Nodes[0];
                    tabCtrlIndex = 2;
                }
                else if(NowIndex == 0 && NowTn.Parent.Text == RGB)
                {
                    NextTn = tvw_SysConfig.Nodes[0].Nodes[2].Nodes[1];
                    tabCtrlIndex = 3;
                }
                else if (NowIndex == 1 && NowTn.Parent.Text == RGB)
                {
                    NextTn = tvw_SysConfig.Nodes[0].Nodes[3];
                    tabCtrlIndex = 4;
                }
                else if (NowIndex == 1 && NowTn.Parent.Text == INTERFACE)
                {
                    NextTn = tvw_SysConfig.Nodes[0].Nodes[3];
                    tabCtrlIndex = 4;
                }
                else if (NowIndex == 5 && NowTn.Parent.Text == INTERFACE)
                {
                    NextTn = tvw_SysConfig.Nodes[0].Nodes[5];
                    tabCtrlIndex = 6;
                }
                else
                {
                    NextTn = tvw_SysConfig.Nodes[0].Nodes[NowIndex + 1];
                    tabCtrlIndex = NowIndex+2;
                } 

                tvw_SysConfig.SelectedNode = NextTn;
                tabCtrlConfig.SelectedIndex = tabCtrlIndex;

            }
        }

        private void tabCtrlConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label_info.Text = tabCtrlConfig.SelectedIndex.ToString();
        }

        private void rbtn_8BitD7D0_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_8BitD7D0.Checked)
                pic_DataBusDef.Image = SC_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_1;
            else if (rbtn_8bitD17D10.Checked)
                pic_DataBusDef.Image = SC_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_2;
            else if(rbtn_9bitD8D0.Checked)
                pic_DataBusDef.Image = SC_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_3;
            else if(rbtn_9bitD17D9.Checked)
                pic_DataBusDef.Image = SC_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_4;
            else if(rbtn_16bitD15D0.Checked)
                pic_DataBusDef.Image = SC_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_5;
            else if(rbtn_17bitD17D10.Checked)
                pic_DataBusDef.Image = SC_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_6;
            else if (rbtn_18bitD17D0.Checked)
                pic_DataBusDef.Image = SC_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_7;
            else if(rbtn_18bitD23D0.Checked)
                pic_DataBusDef.Image = SC_Tek_Studio_Pro.Properties.Resources.cpu_data_bus_8;
            else
                pic_DataBusDef.Image = SC_Tek_Studio_Pro.Properties.Resources.cpu_data_bus;
        }

        private void pic_Pclk_Click(object sender, EventArgs e)
        {
            if(SetIndex[0])
            {
                pic_Pclk.Image = SC_Tek_Studio_Pro.Properties.Resources.pclk_p1;
                SetIndex[0] = !SetIndex[0];
            }
            else
            {
                pic_Pclk.Image = SC_Tek_Studio_Pro.Properties.Resources.pclk_p0;
                SetIndex[0] = !SetIndex[0];
            }
        }

        private void pic_Hsync_Click(object sender, EventArgs e)
        {
            if (SetIndex[1])
            {
                pic_Hsync.Image = SC_Tek_Studio_Pro.Properties.Resources.hs_p1;
                SetIndex[1] = !SetIndex[1];
            }
            else
            {
                pic_Hsync.Image = SC_Tek_Studio_Pro.Properties.Resources.hs_p0;
                SetIndex[1] = !SetIndex[1];
            }
        }

        private void pic_Vsync_Click(object sender, EventArgs e)
        {
            if (SetIndex[2])
            {
                pic_Vsync.Image = SC_Tek_Studio_Pro.Properties.Resources.vs_p1;
                SetIndex[2] = !SetIndex[2];
            }
            else
            {
                pic_Vsync.Image = SC_Tek_Studio_Pro.Properties.Resources.vs_p0;
                SetIndex[2] = !SetIndex[2];
            }
        }

        private void pic_De_Click(object sender, EventArgs e)
        {
            if (SetIndex[3])
            {
                pic_De.Image = SC_Tek_Studio_Pro.Properties.Resources.de_p1;
                SetIndex[3] = !SetIndex[3];
            }
            else
            {
                pic_De.Image = SC_Tek_Studio_Pro.Properties.Resources.de_p0;
                SetIndex[3] = !SetIndex[3];
            }
        }

        private uint CountScanRate()
        {
            uint data = 0, PixelClk = 0, VTotal = 0, Val = 0;
            SC_IO_Util verifyStr = new SC_IO_Util();
            bool ret = true;

            ret = verifyStr.isStrtoInt(txt_PixelClk.Text, ref data);
            if (!ret) return 0;
            PixelClk = data;

            ret = verifyStr.isStrtoInt(txt_Vtotal.Text, ref data);
            if (!ret) return 0;
            VTotal = data;

            Val = (PixelClk * 1000) / ( VTotal);
            return Val;
        }

        private uint CountFrameRate()
        {
            uint data = 0, PixelClk = 0,HTotal =0 , VTotal=0,Val=0;
            SC_IO_Util verifyStr = new SC_IO_Util();
            bool ret = true;

            ret = verifyStr.isStrtoInt(txt_PixelClk.Text, ref data);
            if (!ret) return 0;
            PixelClk = data;

            ret = verifyStr.isStrtoInt(txt_Htotal.Text, ref data);
            if (!ret) return 0;
            HTotal = data;

            ret = verifyStr.isStrtoInt(txt_Vtotal.Text, ref data);
            if (!ret) return 0;
            VTotal = data;

            Val = (PixelClk * 1000000) / (HTotal * VTotal);
            return Val;
        }
        
        private string H_CountSum()
        {
            uint data = 0, htotal = 0;
            SC_IO_Util verifyStr = new SC_IO_Util();

            bool ret = verifyStr.isStrtoInt(lbl_HsyncVal.Text, ref data);
            if (ret) htotal += data;

            ret = verifyStr.isStrtoInt(lbl_HbpVal.Text, ref data);
            if (ret) htotal += data;

            ret = verifyStr.isStrtoInt(lbl_HactiveVal.Text, ref data);
            if (ret) htotal += data;

            ret = verifyStr.isStrtoInt(lbl_HfpVal.Text, ref data);
            if (ret) htotal += data;

            return htotal.ToString();

        }

        private string V_CountSum()
        {
            uint data = 0, vtotal = 0;
            SC_IO_Util verifyStr = new SC_IO_Util();

            bool ret  = verifyStr.isStrtoInt(lbl_VsyncVal.Text, ref data);
            if (ret) vtotal += data;

            ret = verifyStr.isStrtoInt(lbl_VbpVal.Text, ref data);
            if (ret) vtotal += data;

            ret = verifyStr.isStrtoInt(lbl_VactiveVal.Text, ref data);
            if (ret) vtotal += data;

            ret = verifyStr.isStrtoInt(lbl_VfpVal.Text, ref data);
            if (ret) vtotal += data;

            return vtotal.ToString();

        }

        private void rbtn_6bit_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_6bit.Checked)
                pic_showDataBus.Image = SC_Tek_Studio_Pro.Properties.Resources.RGB_d000;
            else if (rbtn_8bit.Checked)
                pic_showDataBus.Image = SC_Tek_Studio_Pro.Properties.Resources.RGB_d001;
            else if(rbtn_16bitD15.Checked)
                pic_showDataBus.Image = SC_Tek_Studio_Pro.Properties.Resources.RGB_d010;
            else if(rbtn_16bitD17.Checked)
                pic_showDataBus.Image = SC_Tek_Studio_Pro.Properties.Resources.RGB_d011;
            else if(rbtn_16bitD21.Checked)
                pic_showDataBus.Image = SC_Tek_Studio_Pro.Properties.Resources.RGB_d100;
            else if(rbtn_18bitD17.Checked)
                pic_showDataBus.Image = SC_Tek_Studio_Pro.Properties.Resources.RGB_d101;
            else if(rbtn_18bitD21.Checked)
                pic_showDataBus.Image = SC_Tek_Studio_Pro.Properties.Resources.RGB_d101;
            else if(rbtn_24bitD23.Checked)
                pic_showDataBus.Image = SC_Tek_Studio_Pro.Properties.Resources.RGB_d111;
            else
                pic_showDataBus.Image = SC_Tek_Studio_Pro.Properties.Resources.RGB_DATA_BUS;
        }

        private void rbtn_spi4wire_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_spi4wire.Checked)
                pic_showSpiType.Image = SC_Tek_Studio_Pro.Properties.Resources.spi_4w8b;
            else if(rbtn_spi3wire.Checked)
                pic_showSpiType.Image = SC_Tek_Studio_Pro.Properties.Resources.spi_3w9b;
            else
                pic_showSpiType.Image = SC_Tek_Studio_Pro.Properties.Resources.spi_4w8b;
        }

        private void rbtn_SpiRdWandO_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_SpiRdWandO.Checked)
                pic_showSpi.Image = SC_Tek_Studio_Pro.Properties.Resources.spi_rd_wodmy;
            else if (rbtn_SpiRdW.Checked)
                pic_showSpi.Image = SC_Tek_Studio_Pro.Properties.Resources.spi_rd_wdmy;
            else
                pic_showSpi.Image = SC_Tek_Studio_Pro.Properties.Resources.spi_rd_wodmy;
        }

        private void txt_SpiSckL_Leave(object sender, EventArgs e)
        {
            uint val = 0;
            SC_IO_Util verifyStr = new SC_IO_Util();
            TextBox txtbox = (TextBox)sender;
            if(VerifyTxtBox(txtbox,ref val))
            { 
                showTxtolbl(txtbox.Name.ToString(), val);
                if (txtbox.Name.Contains("i2c"))
                    AutoCounSckFreq(lbl_i2csckH, lbl_i2csckL, txt_i2cSysClk, lbl_shwI2cFreqVal);
                else
                    AutoCounSckFreq(lbl_shwSckL, lbl_shwSckH, txt_SpiSysClk, lbl_SckFreqVal);
            }
        }

        private void AutoCounSckFreq(Label ShwSckl, Label ShwSckh, TextBox SysClk, Label FreqVal)
        {

            uint Val = 0, Freq = 0;
            SC_IO_Util verifyStr = new SC_IO_Util();

            bool ret = verifyStr.isStrtoInt(ShwSckl.Text, ref Val);
            if (!ret)
            {
                FreqVal.Text = "0";
                return;
            }

            Freq += Val;

            ret = verifyStr.isStrtoInt(ShwSckh.Text, ref Val);
            if (!ret)
            {
                FreqVal.Text = "0";
                return;
            }

            Freq += Val;

            ret = verifyStr.isStrtoInt(SysClk.Text, ref Val);
            if (ret)
                FreqVal.Text = (Val / Freq).ToString();
            else
                FreqVal.Text = "0";
        }

        private bool VerifyTxtBox(TextBox txtbox,ref uint Val)
        {
            SC_IO_Util verifyStr = new SC_IO_Util();
            bool ret = verifyStr.isStrtoInt(txtbox.Text, ref Val);
            if (!ret)
            { 
                txtbox.BackColor = Color.Pink;
                return false;
            }
            else
            {
                txtbox.BackColor = Color.White;
                return true;
            }
        }

        private void txt_Hsync_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txt_Hsync_Leave(object sender, EventArgs e)
        {
            SC_IO_Util verifyStr = new SC_IO_Util();
            uint val = 0;
            TextBox txtbox = (TextBox)sender;
            if (VerifyTxtBox(txtbox, ref val))
            {
                showTxtolbl(txtbox.Name.ToString(), val);
                AutoCountSum();
            }
        }



        /*Show Data to Label*/
        private void showTxtolbl(string txtName, uint value)
        {
            if (txtName == HSYNC)
                lbl_HsyncVal.Text = value.ToString();
            if (txtName == HBP)
                lbl_HbpVal.Text = value.ToString();
            if (txtName == HACTIVE)
                lbl_HactiveVal.Text = value.ToString();
            if (txtName == HFP)
                lbl_HfpVal.Text = value.ToString();
            if (txtName == VSYNC)
                lbl_VsyncVal.Text = value.ToString();
            if (txtName == VBP)
                lbl_VbpVal.Text = value.ToString();
            if (txtName == VACTIVE)
                lbl_VactiveVal.Text = value.ToString();
            if (txtName == VFP)
                lbl_VfpVal.Text = value.ToString();
            if (txtName == PIXELCLK)
                lbl_PixelClkVal.Text = value.ToString();
            if(txtName == SPISCKL)
                lbl_shwSckL.Text = value.ToString(); 
            if(txtName == SPISCKH)
                lbl_shwSckH.Text = value.ToString();
            if(txtName == I2CSCKL)
                lbl_i2csckH.Text = value.ToString();
            if (txtName == I2CSCKH)
                lbl_i2csckL.Text = value.ToString();
        }

        private void AutoCountSum()
        {
            txt_Htotal.Text = H_CountSum();
            txt_Vtotal.Text = V_CountSum();

            lbl_fpRateVal.Text = CountFrameRate().ToString() + " HZ";
            lbl_ScanRateVal.Text = CountScanRate().ToString() + " KHZ";
        }

        private void txt_sysClk_Leave(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            uint val = 0;
            if (VerifyTxtBox(txtbox, ref val))
            {
                txt_SpiSysClk.Text = val.ToString();
                txt_i2cSysClk.Text = val.ToString();
                txt_SpiSysClk.Enabled = false;
                txt_i2cSysClk.Enabled = false;
            }
        }
    }
}
