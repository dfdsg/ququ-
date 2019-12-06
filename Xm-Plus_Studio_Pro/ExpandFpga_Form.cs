using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public partial class ExpandFpga_Form : Form
    {
        string _IniPath = null;

        public ExpandFpga_Form()
        {
            InitializeComponent();
        }

        private void SetAllofFpag_Form_Load(object sender, EventArgs e)
        {
            if (XM_Param_Util.ListRegInfo.Count == 0) new XM_Param_Util().FillInfoList();

        }

        private void BtnFpagRead_Click(object sender, EventArgs e)
        {
            ReadFpgaParam();
            ShowFpgaParam();
        }

        private void BntFpagWrite_Click(object sender, EventArgs e)
        {
            //TestPattern();
            WriteFPGAParam();
        }


        private void WriteFPGAParam()
        {
            uint Val = 0;

            XM_Param_Util ParmUtil = new XM_Param_Util();

            //RstCtrl
            if (ExamWrTxtBox(txtbox_rstctrl, ref Val))
            { 
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rstctrl.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rstctrl.Name.ToString()), Val);
            }

            //DSX_RGBDSX
            if (ExamWrTxtBox(txtbox_rgxdsx, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgxdsx.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgxdsx.Name.ToString()), Val);
            }

            //DDR3SEL
            if (ExamWrTxtBox(txtbox_ddr3sel, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_ddr3sel.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_ddr3sel.Name.ToString()), Val);
            }

            ////SPI_RDDUMMYCLK
            if (ExamWrTxtBox(txtbox_spirddummyclk, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_spirddummyclk.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_spirddummyclk.Name.ToString()), Val);
            }

            ////SPI_WRCLKH_L
            if (ExamWrTxtBox(txtbox_spiwrclkh, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_spiwrclkh.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_spiwrclkh.Name.ToString()), Val);
            }

            //REG_SPIRDCLKH
            if (ExamWrTxtBox(txtbox_spirdclkh, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_spirdclkh.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_spirdclkh.Name.ToString()), Val);
            }

            //REG_CS123SEL
            if (ExamWrTxtBox(txtbox_cs123sel, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_cs123sel.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_cs123sel.Name.ToString()), Val);
            }

            //REG_I2CSTOP
            if (ExamWrTxtBox(txtbox_i2cStop, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_i2cStop.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_i2cStop.Name.ToString()), Val);
            }

            //REG_I2CSCKH
            if (ExamWrTxtBox(txtbox_i2csckh, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_i2csckh.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_i2csckh.Name.ToString()), Val);
            }

            //REG_I2CRDBYTE_CNT
            if (ExamWrTxtBox(txtbox_i2crdbytecnt, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_i2crdbytecnt.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_i2crdbytecnt.Name.ToString()), Val);
            }

            //REG_INTERFACEMODE
            if (ExamWrTxtBox(txtbox_interfacemode, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_interfacemode.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_interfacemode.Name.ToString()), Val);
            }

            //RGBMODE_POLARITY
            if (ExamWrTxtBox(txtbox_rgbpolarity, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgbpolarity.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgbpolarity.Name.ToString()), Val);
            }

            //REG_RGB_TH
            if (ExamWrTxtBox(txtbox_rgbth, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgbth.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgbth.Name.ToString()), Val);
            }

            //REG_RGB_TV
            if (ExamWrTxtBox(txtbox_rgbtv, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgbtv.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgbtv.Name.ToString()), Val);
            }

            //REG_RGB_THDS
            if (ExamWrTxtBox(txtbox_rgbthds, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgbthds.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgbthds.Name.ToString()), Val);
            }

            //REG_RGB_TVDS
            if (ExamWrTxtBox(txtbox_rgbtvds, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgbtvds.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgbtvds.Name.ToString()), Val);
            }

            //REG_RGB_THBP
            if (ExamWrTxtBox(txtbox_rgbthbp, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgbthbp.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgbthbp.Name.ToString()), Val);
            }

            //REG_RGB_TVBP
            if (ExamWrTxtBox(txtbox_rgbtvbp, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgbtvbp.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgbtvbp.Name.ToString()), Val);
            }

            //REG_RGB_THPW
            if (ExamWrTxtBox(txtbox_rgbthpw, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgbthpw.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgbthpw.Name.ToString()), Val);
            }

            //REG_RGB_TVPW
            if (ExamWrTxtBox(txtbox_rgbtvpw, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgbtvpw.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgbtvpw.Name.ToString()), Val);
            }

            //DDR3_1ADDR
            if (ExamWrTxtBox(txtbox_ddr3_1addr, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_ddr3_1addr.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_ddr3_1addr.Name.ToString()), Val);
            }

            //DDR3_3ADDR
            if (ExamWrTxtBox(txtbox_ddr3_3addr, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_ddr3_3addr.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_ddr3_3addr.Name.ToString()), Val);
            }

            //REG_RGBNORMALDATA
            if (ExamWrTxtBox(txtbox_rgbnormaldata, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgbnormaldata.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgbnormaldata.Name.ToString()), Val);
            }

            //SSD2828_BANKEN_MODESET
            if (ExamWrTxtBox(txtbox_2828_bankmode, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_2828_bankmode.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_2828_bankmode.Name.ToString()), Val);
            }

            //SSD2828_BANKCOLOR_SHUTDOWN
            if (ExamWrTxtBox(txtbox_2828_bankcolor, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_2828_bankcolor.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_2828_bankcolor.Name.ToString()), Val);
            }

            //REG_2828BX_WRRDEN
            if (ExamWrTxtBox(txtbox_2828bx_wrrden, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_2828bx_wrrden.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_2828bx_wrrden.Name.ToString()), Val);
            }

            //REG_2828BX_SPICSX
            if (ExamWrTxtBox(txtbox_2828bx_spicsx, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_2828bx_spicsx.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_2828bx_spicsx.Name.ToString()), Val);
            }

            //RGB_TH_2828BX
            if (ExamWrTxtBox(txtbox_rgb_th_2828bx, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgb_th_2828bx.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgb_th_2828bx.Name.ToString()), Val);
            }

            //RGB_TV_2828BX
            if (ExamWrTxtBox(txtbox_rgb_tv_2828bx, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgb_tv_2828bx.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgb_tv_2828bx.Name.ToString()), Val);
            }

            //RGB_THDS_2828BX
            if (ExamWrTxtBox(txtbox_rgb_thds_2828bx, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgb_thds_2828bx.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgb_thds_2828bx.Name.ToString()), Val);
            }

            //RGB_TVDS_2828BX
            if (ExamWrTxtBox(txtbox_rgb_tvds_2828bx, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgb_tvds_2828bx.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgb_tvds_2828bx.Name.ToString()), Val);
            }

            //RGB_THBP_2828BX
            if (ExamWrTxtBox(txtbox_rgb_thbp_2828bx, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgb_thbp_2828bx.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgb_thbp_2828bx.Name.ToString()), Val);
            }

            //RGB_TVBP_2828BX
            if (ExamWrTxtBox(txtbox_rgb_tvbp_2828bx, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgb_tvbp_2828bx.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgb_tvbp_2828bx.Name.ToString()), Val);
            }

            //RGB_THPW_2828BX
            if (ExamWrTxtBox(txtbox_thpw_2828bx, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_thpw_2828bx.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_thpw_2828bx.Name.ToString()), Val);
            }

            //RGB_TVPW_2828BX
            if (ExamWrTxtBox(txtbox_tvpw_2828bx, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_tvpw_2828bx.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_tvpw_2828bx.Name.ToString()), Val);
            }

            //RGB_RGBDSX_2828BX
            if (ExamWrTxtBox(txtbox_rgbdsx_2828bx, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_rgbdsx_2828bx.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_rgbdsx_2828bx.Name.ToString()), Val);
            }

            //LCD_LED_POWER_SET
            if (ExamWrTxtBox(txtbox_lcdledpowerset, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_lcdledpowerset.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_lcdledpowerset.Name.ToString()), Val);
            }

            //DCM_EN_RST
            if (ExamWrTxtBox(txtbox_dcm_en_rst, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_dcm_en_rst.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_dcm_en_rst.Name.ToString()), Val);
            }

            //DCM_MULTIPLY
            if (ExamWrTxtBox(txtbox_dcmmultiply, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_dcmmultiply.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_dcmmultiply.Name.ToString()), Val);
            }

            //DCM_DIVIDE
            if (ExamWrTxtBox(txtbox_dcmdivide, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_dcmdivide.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_dcmdivide.Name.ToString()), Val);
            }


            //PLLEN_RST
            if (ExamWrTxtBox(txtbox_pll_en_rst, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_pll_en_rst.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_pll_en_rst.Name.ToString()), Val);
            }

            //GPIO_DIR
            if (ExamWrTxtBox(txtbox_gpio_dir, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_gpio_dir.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_gpio_dir.Name.ToString()), Val);
            }

            //GPIOA_HB
            if (ExamWrTxtBox(txtbox_gpioa_hb, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_gpioa_hb.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_gpioa_hb.Name.ToString()), Val);
            }

            //GPIOA_LB
            if (ExamWrTxtBox(txtbox_gpioa_lb, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_gpioa_lb.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_gpioa_lb.Name.ToString()), Val);
            }

            //REG_GPIO
            if (ExamWrTxtBox(txtbox_dcmdivide, ref Val))
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(ParmUtil.GetRegNameByTxtName(txtbox_dcmdivide.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.GetRegNameByTxtName(txtbox_dcmdivide.Name.ToString()), Val);
            }

        }

        private bool ExamWrTxtBox( TextBox TxtBox, ref uint Value)
        {
            XM_Digital_Util strUtil = new XM_Digital_Util();
            uint HighBit = new XM_Param_Util().GetRangeByTxtName(TxtBox.Name.ToString());
            bool ret = strUtil.StrToNumber<uint>(TxtBox.Text, ref Value);
            if (!ret) { TxtBox.BackColor = Color.LightPink; return false; }
            ret = strUtil.BoolInnerRange(Value, 0,  Math.Pow(2, HighBit));
            if (!ret)
                TxtBox.BackColor = Color.LightPink;
            else
                TxtBox.BackColor = Color.White;
            return ret;
        }

        private void ShowFpgaParam()
        {

            string Tag = "0x";
            XM_Param_Util ParmUtil = new XM_Param_Util();

            txtbox_rstctrl.BackColor = Color.White;
            txtbox_rstctrl.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.CS_RST_PINCTRL), 16);

            txtbox_rgxdsx.BackColor = Color.White;
            txtbox_rgxdsx.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.DSX_RGBDSX), 16);

            txtbox_ddr3sel.BackColor = Color.White;
            txtbox_ddr3sel.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.DDR3SEL), 16);

            txtbox_spirddummyclk.BackColor = Color.White;
            txtbox_spirddummyclk.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.SPI_RDDUMMYCLK), 16);

            txtbox_spiwrclkh.BackColor = Color.White;
            txtbox_spiwrclkh.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.SPI_WRCLKH_L), 16);

            /*****Divide*****/
            txtbox_spirdclkh.BackColor = Color.White;
            txtbox_spirdclkh.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.SPI_RDCLKH_L), 16);

            txtbox_cs123sel.BackColor = Color.White;
            txtbox_cs123sel.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.CS123SEL), 16);

            txtbox_i2cStop.BackColor = Color.White;
            txtbox_i2cStop.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.I2C_STOP_START), 16);

            txtbox_i2csckh.BackColor = Color.White;
            txtbox_i2csckh.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.I2C_SCKH_L), 16);

            txtbox_i2crdbytecnt.BackColor = Color.White;
            txtbox_i2crdbytecnt.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.I2C_RDBYTE_CNT), 16);

            /*****Divide*****/
            txtbox_interfacemode.BackColor = Color.White;
            txtbox_interfacemode.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.INTERFACEMODE), 16);

            txtbox_rgbpolarity.BackColor = Color.White;
            txtbox_rgbpolarity.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGBMODE_POLARITY), 16);

            txtbox_rgbth.BackColor = Color.White;
            txtbox_rgbth.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TH), 16);

            txtbox_rgbtv.BackColor = Color.White;
            txtbox_rgbtv.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TV), 16);

            txtbox_rgbthds.BackColor = Color.White;
            txtbox_rgbthds.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_THDS), 16);

            /*****Divide*****/
            txtbox_rgbtvds.BackColor = Color.White;
            txtbox_rgbtvds.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TVDS), 16);

            txtbox_rgbthbp.BackColor = Color.White;
            txtbox_rgbthbp.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_THBP), 16);

            txtbox_rgbtvbp.BackColor = Color.White;
            txtbox_rgbtvbp.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TVBP), 16);

            txtbox_rgbthpw.BackColor = Color.White;
            txtbox_rgbthpw.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_THPW), 16);

            txtbox_rgbtvpw.BackColor = Color.White;
            txtbox_rgbtvpw.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TVPW), 16);

            /*****Divide*****/
            txtbox_ddr3_1addr.BackColor = Color.White;
            txtbox_ddr3_1addr.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.DDR3_1ADDR), 16);

            txtbox_ddr3_3addr.BackColor = Color.White;
            txtbox_ddr3_3addr.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.DDR3_3ADDR), 16);

            txtbox_rgbnormaldata.BackColor = Color.White;
            txtbox_rgbnormaldata.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_NORMALDATA), 16);

            txtbox_2828_bankmode.BackColor = Color.White;
            txtbox_2828_bankmode.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.SSD2828_BANKEN_MODESET), 16);

            txtbox_2828_bankcolor.BackColor = Color.White;
            txtbox_2828_bankcolor.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.SSD2828_BANKCOLOR_SHUTDOWN), 16);

            /*****Divide*****/
            txtbox_2828bx_wrrden.BackColor = Color.White;
            txtbox_2828bx_wrrden.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.REG_2828BX_WRRDEN), 16);

            txtbox_2828bx_spicsx.BackColor = Color.White;
            txtbox_2828bx_spicsx.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.REG_2828BX_SPICSX), 16);

            txtbox_rgb_th_2828bx.BackColor = Color.White;
            txtbox_rgb_th_2828bx.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TH_2828BX), 16);

            txtbox_rgb_tv_2828bx.BackColor = Color.White;
            txtbox_rgb_tv_2828bx.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TV_2828BX), 16);

            txtbox_rgb_thds_2828bx.BackColor = Color.White;
            txtbox_rgb_thds_2828bx.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_THDS_2828BX), 16);

            /*****Divide*****/
            txtbox_rgbtv.BackColor = Color.White;
            txtbox_rgbtv.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TV), 16);

            txtbox_rgbthds.BackColor = Color.White;
            txtbox_rgbthds.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_THDS), 16);

            txtbox_rgbtvds.BackColor = Color.White;
            txtbox_rgbtvds.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TVDS), 16);

            txtbox_rgbthbp.BackColor = Color.White;
            txtbox_rgbthbp.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_THBP), 16);

            txtbox_rgbtvbp.BackColor = Color.White;
            txtbox_rgbtvbp.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TVBP), 16);

            /*****Divide*****/
            txtbox_rgb_tvds_2828bx.BackColor = Color.White;
            txtbox_rgb_tvds_2828bx.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TVDS_2828BX), 16);

            txtbox_rgb_thbp_2828bx.BackColor = Color.White;
            txtbox_rgb_thbp_2828bx.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_THBP_2828BX), 16);

            txtbox_rgb_tvbp_2828bx.BackColor = Color.White;
            txtbox_rgb_tvbp_2828bx.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TVBP_2828BX), 16);

            txtbox_thpw_2828bx.BackColor = Color.White;
            txtbox_thpw_2828bx.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_THPW_2828BX), 16);

            txtbox_tvpw_2828bx.BackColor = Color.White;
            txtbox_tvpw_2828bx.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_TVPW_2828BX), 16);


            /*****Divide*****/
            txtbox_rgbdsx_2828bx.BackColor = Color.White;
            txtbox_rgbdsx_2828bx.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.RGB_RGBDSX_2828BX), 16);

            txtbox_lcdledpowerset.BackColor = Color.White;
            txtbox_lcdledpowerset.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.LCD_LED_POWER_SET), 16);

            txtbox_dcm_en_rst.BackColor = Color.White;
            txtbox_dcm_en_rst.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.DCM_EN_RST), 16);

            txtbox_dcmmultiply.BackColor = Color.White;
            txtbox_dcmmultiply.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.DCM_MULTIPLY), 16);

            txtbox_dcmdivide.BackColor = Color.White;
            txtbox_dcmdivide.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.DCM_DIVIDE), 16);

            /*****Divide*****/
            txtbox_pll_en_rst.BackColor = Color.White;
            txtbox_pll_en_rst.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.PLLEN_RST), 16);

            txtbox_gpio_dir.BackColor = Color.White;
            txtbox_gpio_dir.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.GPIO_DIR), 16);

            txtbox_gpioa_hb.BackColor = Color.White;
            txtbox_gpioa_hb.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.GPIOA_HB), 16);

            txtbox_gpioa_lb.BackColor = Color.White;
            txtbox_gpioa_lb.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.GPIOA_LB), 16);

            txtbox_reg_gpio.BackColor = Color.White;
            txtbox_reg_gpio.Text = Tag + Convert.ToString(ParmUtil.GetValueByName(XMREGNAME.REG_GPIO), 16);
        }
    

        private void ReadFpgaParam()
        {

            ushort xferData = 0;
            byte[] Val = new byte[8];
            XM_Param_Util ParmUtil = new XM_Param_Util();

            //*CS_RST_PINCTRL
            bool ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.CS_RST_PINCTRL, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.CS_RST_PINCTRL, xferData);

            //DSX_RGBDSX
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.DSX_RGBDSX, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.DSX_RGBDSX, xferData);

            //DDR3SEL
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.DDR3SEL, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.DDR3SEL, xferData);

            //SPI_RDDUMMYCLK
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.SPI_RDDUMMYCLK, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.SPI_RDDUMMYCLK, xferData);

            //SPI_WRCLKH_L
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.SPI_WRCLKH_L, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.SPI_WRCLKH_L, xferData);

            //*SPI_RDCLKH_L
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.SPI_RDCLKH_L, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.SPI_RDCLKH_L, xferData);

            //CS123SEL
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.CS123SEL, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.CS123SEL, xferData);

            //I2C_STOP_START
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.I2C_STOP_START, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.I2C_STOP_START, xferData);

            //I2C_SCKH_L
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.I2C_SCKH_L, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.I2C_SCKH_L, xferData);

            //I2C_RDBYTE_CNT
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.I2C_RDBYTE_CNT, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.I2C_RDBYTE_CNT, xferData);

            //*INTERFACEMODE
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.INTERFACEMODE, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.INTERFACEMODE, xferData);

            //RGBMODE_POLARITY
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGBMODE_POLARITY, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGBMODE_POLARITY, xferData);

            //RGB_TH
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_TH, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_TH, xferData);

            //RGB_TV
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_TV, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_TV, xferData);

            //RGB_THDS
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_THDS, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_THDS, xferData);

            //*RGB_TVDS
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_TVDS, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_TVDS, xferData);

            //RGB_THBP
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_THBP, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_THBP, xferData);

            //RGB_TVBP
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_TVBP, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_TVBP, xferData);

            //RGB_THPW
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_THPW, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_THPW, xferData);

            //RGB_TVPW
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_TVPW, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_TVPW, xferData);

            //*DDR3_1ADDR
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.DDR3_1ADDR, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.DDR3_1ADDR, xferData);

            //DDR3_3ADDR
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.DDR3_3ADDR, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.DDR3_3ADDR, xferData);

            //RGB_NORMALDATA
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_NORMALDATA, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_NORMALDATA, xferData);

            //SSD2828_BANKEN_MODESET
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.SSD2828_BANKEN_MODESET, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.SSD2828_BANKEN_MODESET, xferData);

            //SSD2828_BANKCOLOR_SHUTDOWN
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.SSD2828_BANKCOLOR_SHUTDOWN, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.SSD2828_BANKCOLOR_SHUTDOWN, xferData);

            //*REG_2828BX_WRRDEN
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.REG_2828BX_WRRDEN, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.REG_2828BX_WRRDEN, xferData);

            //REG_2828BX_SPICSX
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.REG_2828BX_SPICSX, ref xferData);
            if (ret ) ParmUtil.UpdateRegValue(XMREGNAME.REG_2828BX_SPICSX, xferData);

            //RGB_TH_2828BX
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_TH_2828BX, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_TH_2828BX, xferData);

            //RGB_TV_2828BX
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_TV_2828BX, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_TV_2828BX, xferData);

            //RGB_THDS_2828BX
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_THDS_2828BX, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_THDS_2828BX, xferData);

            //*RGB_TVDS_2828BX
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_TVDS_2828BX, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_TVDS_2828BX, xferData);

            //RGB_THBP_2828BX
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_THBP_2828BX, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_THBP_2828BX, xferData);

            //RGB_TVBP_2828BX
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_TVBP_2828BX, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_TVBP_2828BX, xferData);

            //RGB_THPW_2828BX
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_THPW_2828BX, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_THPW_2828BX, xferData);

            //RGB_TVPW_2828BX
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_TVPW_2828BX, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_TVPW_2828BX, xferData);

            //*RGB_RGBDSX_2828BX
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.RGB_RGBDSX_2828BX, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.RGB_RGBDSX_2828BX, xferData);

            //LCD_LED_POWER_SET
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.LCD_LED_POWER_SET, ref xferData);
            if (ret ) ParmUtil.UpdateRegValue(XMREGNAME.LCD_LED_POWER_SET, xferData);

            //DCM_EN_RST
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.DCM_EN_RST, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.DCM_EN_RST, xferData);

            //DCM_MULTIPLY
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.DCM_MULTIPLY, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.DCM_MULTIPLY, xferData);

            //DCM_DIVIDE
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.DCM_DIVIDE, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.DCM_DIVIDE, xferData);

            //*PLLEN_RST
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.PLLEN_RST, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.PLLEN_RST, xferData);

            //GPIO_DIR
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.GPIO_DIR, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.GPIO_DIR, xferData);

            //GPIOA_HB
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.GPIOA_HB, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.GPIOA_HB, xferData);

            //GPIOA_LB
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.GPIOA_LB, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.GPIOA_LB, xferData);

            //REG_GPIO
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(XMREGADDR.REG_GPIO, ref xferData);
            if (ret) ParmUtil.UpdateRegValue(XMREGNAME.REG_GPIO, xferData);

          
        }



        private void TestPattern()
        {
            string Tag = "0xff";

            txtbox_rstctrl.Text = Tag;
            txtbox_rgxdsx.Text = Tag;
            txtbox_ddr3sel.Text = Tag;
            //txtbox_vspw.Text = Tag;
            //txtbox_vstem.Text = Tag;
            //txtbox_vstee.Text = Tag;
            //txtbox_dsx.Text = Tag;
            //txtbox_rgbdsx.Text = Tag;
            //txtbox_srammode.Text = Tag;
            txtbox_spirddummyclk.Text = Tag;
            txtbox_spiwrclkh.Text = Tag;
            //txtbox_spiwrclkl.Text = Tag;
            //txtbox_spirdclkh.Text = Tag;
            //txtbox_spirdclkl.Text = Tag;
            //txtbox_sramcnt.Text = Tag;
            txtbox_cs123sel.Text = Tag;
            //txtbox_BacklightDcount.Text = Tag;
            //txtbox_backlightRatio.Text = Tag;
            txtbox_i2cStop.Text = Tag;
            //txtbox_i2cStart.Text = Tag;
            txtbox_i2csckh.Text = Tag;
            //txtbox_i2cSckl.Text = Tag;
            txtbox_i2crdbytecnt.Text = Tag;
            txtbox_interfacemode.Text = Tag;
            txtbox_rgbpolarity.Text = Tag;
            //txtbox_rgbMp.Text = Tag;
            //txtbox_rgbEp.Text = Tag;
            //txtbox_rgbHsp.Text = Tag;
            //txtbox_rgbVsp.Text = Tag;
            txtbox_rgbth.Text = Tag;
            txtbox_rgbtv.Text = Tag;
            txtbox_rgbthds.Text = Tag;
            txtbox_rgbtvds.Text = Tag;
            txtbox_rgbthbp.Text = Tag;
            txtbox_rgbtvbp.Text = Tag;
            txtbox_rgbthpw.Text = Tag;
            txtbox_rgbtvpw.Text = Tag;
            //txtbox_sramHbaddr.Text = Tag;
            //txtbox_sramlbaddr.Text = Tag;
            txtbox_rgbnormaldata.Text = Tag;
            //txtbox_sramAddrautoen.Text = Tag;
            //txtbox_sramAddrautoCnt.Text = Tag;
            txtbox_lcdledpowerset.Text = Tag;
            txtbox_dcm_en_rst.Text = Tag;
            //txtbox_dcmRst.Text = Tag;
            //txtbox_dcmEn.Text = Tag;
            txtbox_dcmmultiply.Text = Tag;
            txtbox_dcmdivide.Text = Tag;
            txtbox_reg_gpio.Text = Tag;
        }

        private void ReadConfig(XM_Ini_Util iniUtil)
        {
            XM_Param_Util ParaUtil = new XM_Param_Util();
            txtbox_rstctrl.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.CS_RST_PINCTRL), XMREGNAME.CS_RST_PINCTRL);
            txtbox_rgxdsx.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.DSX_RGBDSX), XMREGNAME.DSX_RGBDSX);
            txtbox_ddr3sel.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.DDR3SEL), XMREGNAME.DDR3SEL);
            txtbox_spirddummyclk.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.SPI_RDDUMMYCLK), XMREGNAME.SPI_RDDUMMYCLK);
            txtbox_spiwrclkh.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.SPI_WRCLKH_L), XMREGNAME.SPI_WRCLKH_L);

            txtbox_spirdclkh.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.SPI_RDCLKH_L), XMREGNAME.SPI_RDCLKH_L);
            txtbox_cs123sel.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.CS123SEL), XMREGNAME.CS123SEL);
            txtbox_i2cStop.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.I2C_STOP_START), XMREGNAME.I2C_STOP_START);
            txtbox_i2csckh.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.I2C_SCKH_L), XMREGNAME.I2C_SCKH_L);
            txtbox_i2crdbytecnt.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.I2C_RDBYTE_CNT), XMREGNAME.I2C_RDBYTE_CNT);

            txtbox_interfacemode.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.INTERFACEMODE), XMREGNAME.INTERFACEMODE);
            txtbox_rgbpolarity.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGBMODE_POLARITY), XMREGNAME.RGBMODE_POLARITY);
            txtbox_rgbth.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TH), XMREGNAME.RGB_TH);
            txtbox_rgbtv.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TV), XMREGNAME.RGB_TV);
            txtbox_rgbthds.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THDS), XMREGNAME.RGB_THDS);

            txtbox_rgbtvds.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVDS), XMREGNAME.RGB_TVDS);
            txtbox_rgbthbp.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THBP), XMREGNAME.RGB_THBP);
            txtbox_rgbtvbp.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVBP), XMREGNAME.RGB_TVBP);
            txtbox_rgbthpw.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THPW), XMREGNAME.RGB_THPW);
            txtbox_rgbtvpw.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVPW), XMREGNAME.RGB_TVPW);

            txtbox_ddr3_1addr.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.DDR3_1ADDR), XMREGNAME.DDR3_1ADDR);
            txtbox_ddr3_3addr.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.DDR3_3ADDR), XMREGNAME.DDR3_3ADDR);
            txtbox_rgbnormaldata.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_NORMALDATA), XMREGNAME.RGB_NORMALDATA);
            txtbox_2828_bankmode.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.SSD2828_BANKEN_MODESET), XMREGNAME.SSD2828_BANKEN_MODESET);
            txtbox_2828_bankcolor.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.SSD2828_BANKCOLOR_SHUTDOWN), XMREGNAME.SSD2828_BANKCOLOR_SHUTDOWN);

            txtbox_2828bx_wrrden.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.REG_2828BX_WRRDEN), XMREGNAME.REG_2828BX_WRRDEN);
            txtbox_2828bx_spicsx.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.REG_2828BX_SPICSX), XMREGNAME.REG_2828BX_SPICSX);
            txtbox_rgb_th_2828bx.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TH_2828BX), XMREGNAME.RGB_TH_2828BX);
            txtbox_rgb_tv_2828bx.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TV_2828BX), XMREGNAME.RGB_TV_2828BX);
            txtbox_rgb_thds_2828bx.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THDS_2828BX), XMREGNAME.RGB_THDS_2828BX);

            txtbox_rgb_tvds_2828bx.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVDS_2828BX), XMREGNAME.RGB_TVDS_2828BX);
            txtbox_rgb_thbp_2828bx.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THBP_2828BX), XMREGNAME.RGB_THBP_2828BX);
            txtbox_rgb_tvbp_2828bx.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVBP_2828BX), XMREGNAME.RGB_TVBP_2828BX);
            txtbox_thpw_2828bx.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THPW_2828BX), XMREGNAME.RGB_THPW_2828BX);
            txtbox_tvpw_2828bx.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVPW_2828BX), XMREGNAME.RGB_TVPW_2828BX);

            txtbox_rgbdsx_2828bx.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.RGB_RGBDSX_2828BX), XMREGNAME.RGB_RGBDSX_2828BX);
            txtbox_lcdledpowerset.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.LCD_LED_POWER_SET), XMREGNAME.LCD_LED_POWER_SET);
            txtbox_dcm_en_rst.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.DCM_EN_RST), XMREGNAME.DCM_EN_RST);
            txtbox_dcmmultiply.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.DCM_MULTIPLY), XMREGNAME.DCM_MULTIPLY);
            txtbox_dcmdivide.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.DCM_DIVIDE), XMREGNAME.DCM_DIVIDE);

            txtbox_pll_en_rst.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.PLLEN_RST), XMREGNAME.PLLEN_RST);
            txtbox_gpio_dir.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.GPIO_DIR), XMREGNAME.GPIO_DIR);
            txtbox_gpioa_hb.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.GPIOA_HB), XMREGNAME.GPIOA_HB);
            txtbox_gpioa_lb.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.GPIOA_LB), XMREGNAME.GPIOA_LB);
            txtbox_reg_gpio.Text = iniUtil.IniReadValue(ParaUtil.GetRootByName(XMREGNAME.REG_GPIO), XMREGNAME.REG_GPIO);


        }


        private void BtnLoad_Click(object sender, EventArgs e)
        {
            /*Choose Ini File */
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "*.ini|*.*",
                FileName = "default.ini",
                InitialDirectory = Setting.ExeSptDirPath,
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Setting.ExeWolConfigPath = _IniPath = openFileDialog.FileName;
                XM_Ini_Util iniUtil = new XM_Ini_Util(_IniPath);
                txtBox_Path.Text = Path.GetFileName(_IniPath);
                label_info.Text = "* Load INI Path";
                ReadConfig(iniUtil);
            }

        }


        private void WriteConfig(XM_Ini_Util IniUtil)
        {
            XM_Param_Util ParaUtil = new XM_Param_Util();
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.CS_RST_PINCTRL), XMREGNAME.CS_RST_PINCTRL, txtbox_rstctrl.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.DSX_RGBDSX), XMREGNAME.DSX_RGBDSX, txtbox_rgxdsx.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.DDR3SEL), XMREGNAME.DDR3SEL, txtbox_ddr3sel.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.SPI_RDDUMMYCLK), XMREGNAME.SPI_RDDUMMYCLK, txtbox_spirddummyclk.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.SPI_WRCLKH_L), XMREGNAME.SPI_WRCLKH_L, txtbox_spiwrclkh.Text);

            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.SPI_RDCLKH_L), XMREGNAME.SPI_RDCLKH_L, txtbox_spirdclkh.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.CS123SEL), XMREGNAME.CS123SEL, txtbox_cs123sel.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.I2C_STOP_START), XMREGNAME.I2C_STOP_START, txtbox_i2cStop.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.I2C_SCKH_L), XMREGNAME.I2C_SCKH_L, txtbox_i2csckh.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.I2C_RDBYTE_CNT), XMREGNAME.I2C_RDBYTE_CNT, txtbox_i2crdbytecnt.Text);

            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.INTERFACEMODE), XMREGNAME.INTERFACEMODE, txtbox_interfacemode.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGBMODE_POLARITY), XMREGNAME.RGBMODE_POLARITY, txtbox_rgbpolarity.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TH), XMREGNAME.RGB_TH, txtbox_rgbth.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TV), XMREGNAME.RGB_TV, txtbox_rgbtv.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THDS), XMREGNAME.RGB_THDS, txtbox_rgbthds.Text);

            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVDS), XMREGNAME.RGB_TVDS, txtbox_rgbtvds.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THBP), XMREGNAME.RGB_THBP, txtbox_rgbthbp.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVBP), XMREGNAME.RGB_TVBP, txtbox_rgbtvbp.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THPW), XMREGNAME.RGB_THPW, txtbox_rgbthpw.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVPW), XMREGNAME.RGB_TVPW, txtbox_rgbtvpw.Text);

            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.DDR3_1ADDR), XMREGNAME.DDR3_1ADDR, txtbox_ddr3_1addr.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.DDR3_3ADDR), XMREGNAME.DDR3_3ADDR, txtbox_ddr3_3addr.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_NORMALDATA), XMREGNAME.RGB_NORMALDATA, txtbox_rgbnormaldata.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.SSD2828_BANKEN_MODESET), XMREGNAME.SSD2828_BANKEN_MODESET, txtbox_2828_bankmode.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.SSD2828_BANKCOLOR_SHUTDOWN), XMREGNAME.SSD2828_BANKCOLOR_SHUTDOWN, txtbox_2828_bankcolor.Text);

            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.REG_2828BX_WRRDEN), XMREGNAME.REG_2828BX_WRRDEN, txtbox_2828bx_wrrden.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.REG_2828BX_SPICSX), XMREGNAME.REG_2828BX_SPICSX, txtbox_2828bx_spicsx.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TH_2828BX), XMREGNAME.RGB_TH_2828BX, txtbox_rgb_th_2828bx.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TV_2828BX), XMREGNAME.RGB_TV_2828BX, txtbox_rgb_tv_2828bx.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THDS_2828BX), XMREGNAME.RGB_THDS_2828BX, txtbox_rgb_thds_2828bx.Text);

            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVDS_2828BX), XMREGNAME.RGB_TVDS_2828BX, txtbox_rgb_tvds_2828bx.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THBP_2828BX), XMREGNAME.RGB_THBP_2828BX, txtbox_rgb_thbp_2828bx.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVBP_2828BX), XMREGNAME.RGB_TVBP_2828BX, txtbox_rgb_tvbp_2828bx.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_THPW_2828BX), XMREGNAME.RGB_THPW_2828BX, txtbox_thpw_2828bx.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_TVPW_2828BX), XMREGNAME.RGB_TVPW_2828BX, txtbox_tvpw_2828bx.Text);

            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.RGB_RGBDSX_2828BX), XMREGNAME.RGB_RGBDSX_2828BX, txtbox_rgbdsx_2828bx.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.LCD_LED_POWER_SET), XMREGNAME.LCD_LED_POWER_SET, txtbox_lcdledpowerset.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.DCM_EN_RST), XMREGNAME.DCM_EN_RST, txtbox_dcm_en_rst.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.DCM_MULTIPLY), XMREGNAME.DCM_MULTIPLY, txtbox_dcmmultiply.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.DCM_DIVIDE), XMREGNAME.DCM_DIVIDE, txtbox_dcmdivide.Text);

            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.PLLEN_RST), XMREGNAME.PLLEN_RST, txtbox_pll_en_rst.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.GPIO_DIR), XMREGNAME.GPIO_DIR, txtbox_gpio_dir.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.GPIOA_HB), XMREGNAME.GPIOA_HB, txtbox_gpioa_hb.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.GPIOA_LB), XMREGNAME.GPIOA_LB, txtbox_gpioa_lb.Text);
            IniUtil.IniWriteValue(ParaUtil.GetRootByName(XMREGNAME.REG_GPIO), XMREGNAME.REG_GPIO, txtbox_reg_gpio.Text);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Ini files (*.ini)|*.ini",
                FilterIndex = 2,
                RestoreDirectory = true,
                Title = "Save XmPlus INI",
                InitialDirectory = Setting.ExeSptDirPath
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Setting.ExeWolConfigPath = _IniPath = saveFileDialog1.FileName;
                XM_Ini_Util iniUtil = new XM_Ini_Util(_IniPath);
                label_info.Text = "* Save INI Path";
                WriteConfig(iniUtil);
            }
        }
    }
}
