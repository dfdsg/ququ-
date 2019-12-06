using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SC_Tek_Studio_Pro
{
    public partial class SetAllofFpag_Form : Form
    {
        string _IniPath = null;

        public SetAllofFpag_Form()
        {
            InitializeComponent();
        }

        private void SetAllofFpag_Form_Load(object sender, EventArgs e)
        {
            if (SC_Param_Util.ListRegInfo.Count == 0) new SC_Param_Util().FillInfoList();

        }

        private void btnFpagRead_Click(object sender, EventArgs e)
        {
            ReadFpgaParam();
            showFpgaParam();
        }

        private void bntFpagWrite_Click(object sender, EventArgs e)
        {
            //TestPattern();
            WriteFPGAParam();
        }


        private void WriteFPGAParam()
        {
            uint Val = 0;

            SC_Param_Util ParmUtil = new SC_Param_Util();

            //REG_CSB
            if (ExamWrTxtBox(txtbox_csb, ref Val))
            { 
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_csb.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_csb.Name.ToString()), Val);
            }

            //REG_CSC
            if (ExamWrTxtBox(txtbox_csc, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_csc.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_csc.Name.ToString()), Val);
            }

            //REG_RESB
            if (ExamWrTxtBox(txtbox_resb, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_resb.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_resb.Name.ToString()), Val);
            }

            //REG_VSPW
            if (ExamWrTxtBox(txtbox_vspw, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_vspw.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_vspw.Name.ToString()), Val);
            }

            //REG_VSTEM
            if (ExamWrTxtBox(txtbox_vstem, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_vstem.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_vstem.Name.ToString()), Val);
            }

            //REG_VSTEE
            if (ExamWrTxtBox(txtbox_vstee, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_vstee.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_vstee.Name.ToString()), Val);
            }

            //REG_DSX
            if (ExamWrTxtBox(txtbox_dsx, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_dsx.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_dsx.Name.ToString()), Val);
            }

            //REG_RGBDSX
            if (ExamWrTxtBox(txtbox_rgbdsx, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbdsx.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbdsx.Name.ToString()), Val);
            }

            //REG_SRAMMODE
            if (ExamWrTxtBox(txtbox_srammode, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_srammode.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_srammode.Name.ToString()), Val);
            }

            //REG_SPIRDDUMMYCLK
            if (ExamWrTxtBox(txtbox_spirddummyclk, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_spirddummyclk.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_spirddummyclk.Name.ToString()), Val);
            }

            //REG_SPIWRCLKH
            if (ExamWrTxtBox(txtbox_spiwrclkh, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_spiwrclkh.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_spiwrclkh.Name.ToString()), Val);
            }

            //REG_SPIWRCLKL
            if (ExamWrTxtBox(txtbox_spiwrclkl, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_spiwrclkl.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_spiwrclkl.Name.ToString()), Val);
            }

            //REG_SPIRDCLKH
            if (ExamWrTxtBox(txtbox_spirdclkh, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_spirdclkh.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_spirdclkh.Name.ToString()), Val);
            }

            //REG_SPIRDCLKL
            if (ExamWrTxtBox(txtbox_spirdclkl, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_spirdclkl.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_spirdclkl.Name.ToString()), Val);
            }

            //REG_SRAMCNT
            if (ExamWrTxtBox(txtbox_sramcnt, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_sramcnt.Name.ToString()), Val,3);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_sramcnt.Name.ToString()), Val);
            }

            //REG_CS123SEL
            if (ExamWrTxtBox(txtbox_cs123sel, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_cs123sel.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_cs123sel.Name.ToString()), Val);
            }

            //REG_BACKLIGHT_Dcount
            if (ExamWrTxtBox(txtbox_BacklightDcount, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_BacklightDcount.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_BacklightDcount.Name.ToString()), Val);
            }

            //REG_BACKLIGHT_RATIO
            if (ExamWrTxtBox(txtbox_backlightRatio, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_backlightRatio.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_backlightRatio.Name.ToString()), Val);
            }

            //REG_I2CSTOP
            if (ExamWrTxtBox(txtbox_i2cStop, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_i2cStop.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_i2cStop.Name.ToString()), Val);
            }

            //REG_I2CSTART
            if (ExamWrTxtBox(txtbox_i2cStart, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_i2cStart.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_i2cStart.Name.ToString()), Val);
            }

            //REG_I2CSCKH
            if (ExamWrTxtBox(txtbox_i2cSckh, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_i2cSckh.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_i2cSckh.Name.ToString()), Val);
            }

            //REG_I2CSCKL
            if (ExamWrTxtBox(txtbox_i2cSckl, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_i2cSckl.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_i2cSckl.Name.ToString()), Val);
            }

            //REG_I2CRDBYTE_CNT
            if (ExamWrTxtBox(txtbox_i2cRdbyteCnt, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_i2cRdbyteCnt.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_i2cRdbyteCnt.Name.ToString()), Val);
            }

            //REG_INTERFACEMODE
            if (ExamWrTxtBox(txtbox_InterfaceMode, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_InterfaceMode.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_InterfaceMode.Name.ToString()), Val);
            }

            //REG_RGBRMX
            if (ExamWrTxtBox(txtbox_rgbRmx, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbRmx.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbRmx.Name.ToString()), Val);
            }

            //REG_RGB_MP
            if (ExamWrTxtBox(txtbox_rgbMp, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbMp.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbMp.Name.ToString()), Val);
            }

            //REG_RGB_EP
            if (ExamWrTxtBox(txtbox_rgbEp, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbEp.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbEp.Name.ToString()), Val);
            }

            //REG_RGB_HSP
            if (ExamWrTxtBox(txtbox_rgbHsp, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbHsp.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbHsp.Name.ToString()), Val);
            }

            //REG_RGB_VSP
            if (ExamWrTxtBox(txtbox_rgbVsp, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbVsp.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbVsp.Name.ToString()), Val);
            }

            //REG_RGB_TH
            if (ExamWrTxtBox(txtbox_rgbTh, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbTh.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbTh.Name.ToString()), Val);
            }

            //REG_RGB_TV
            if (ExamWrTxtBox(txtbox_rgbTv, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbTv.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbTv.Name.ToString()), Val);
            }

            //REG_RGB_THDS
            if (ExamWrTxtBox(txtbox_rgbThds, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbThds.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbThds.Name.ToString()), Val);
            }

            //REG_RGB_TVDS
            if (ExamWrTxtBox(txtbox_rgbTvds, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbTvds.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbTvds.Name.ToString()), Val);
            }

            //REG_RGB_THBP
            if (ExamWrTxtBox(txtbox_rgbThbp, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbThbp.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbThbp.Name.ToString()), Val);
            }

            //REG_RGB_TVBP
            if (ExamWrTxtBox(txtbox_rgbTvbp, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbTvbp.Name.ToString()), Val, 2);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbTvbp.Name.ToString()), Val);
            }

            //REG_RGB_THPW
            if (ExamWrTxtBox(txtbox_rgbThpw, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbThpw.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbThpw.Name.ToString()), Val);         
            }

            //REG_RGB_TVPW
            if (ExamWrTxtBox(txtbox_rgbTvpw, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbTvpw.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbTvpw.Name.ToString()), Val);           
            }

            //REG_SRAMHABADDR
            if (ExamWrTxtBox(txtbox_sramHbaddr, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_sramHbaddr.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_sramHbaddr.Name.ToString()), Val);
            }

            //REG_SRAMLBADDR
            if (ExamWrTxtBox(txtbox_sramlbaddr, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_sramlbaddr.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_sramlbaddr.Name.ToString()), Val);
            }

            //REG_RGBNORMALDATA
            if (ExamWrTxtBox(txtbox_rgbNormaldata, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_rgbNormaldata.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_rgbNormaldata.Name.ToString()), Val);
            }

            //REG_SRAMADDRAUTOEN
            if (ExamWrTxtBox(txtbox_sramAddrautoen, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_sramAddrautoen.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_sramAddrautoen.Name.ToString()), Val);
            }

            //REG_SRAMADDRAUTOCNT
            if (ExamWrTxtBox(txtbox_sramAddrautoCnt, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_sramAddrautoCnt.Name.ToString()), Val,2);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_sramAddrautoCnt.Name.ToString()), Val);
            }

            //REG_SRAMADDROFFSET
            if (ExamWrTxtBox(txtbox_sramAddroffset, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_sramAddroffset.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_sramAddroffset.Name.ToString()), Val);
            }

            //REG_SRAMADDREND
            if (ExamWrTxtBox(txtbox_sramAddrend, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_sramAddrend.Name.ToString()), Val, 3);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_sramAddrend.Name.ToString()), Val);
            }

            //REG_DCMRST
            if (ExamWrTxtBox(txtbox_dcmRst, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_dcmRst.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_dcmRst.Name.ToString()), Val);
            }

            //REG_DCMEN
            if (ExamWrTxtBox(txtbox_dcmEn, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_dcmEn.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_dcmEn.Name.ToString()), Val);
            }

            //REG_DCM_MULTIPLY
            if (ExamWrTxtBox(txtbox_dcmMultiply, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_dcmMultiply.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_dcmMultiply.Name.ToString()), Val);
            }


            //REG_DCM_DIVIDE
            if (ExamWrTxtBox(txtbox_dcmDivide, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_dcmDivide.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_dcmDivide.Name.ToString()), Val);
            }

            //REG_GPIO
            if (ExamWrTxtBox(txtbox_regGpio, ref Val))
            {
                SC_Comm_Base.SC_CommBase_WriteReg(ParmUtil.getRegNameByTxtName(txtbox_regGpio.Name.ToString()), (byte)Val);
                ParmUtil.AutoUpdateListValue(ParmUtil.getRegNameByTxtName(txtbox_regGpio.Name.ToString()), Val);
            }

        }

        private bool ExamWrTxtBox( TextBox TxtBox, ref uint Value)
        {
            SC_IO_Util strUtil = new SC_IO_Util();
            uint HighBit = new SC_Param_Util().getRangeByTxtName(TxtBox.Name.ToString());
            bool ret = strUtil.isStrtoInt(TxtBox.Text, ref Value);
            if (!ret) { TxtBox.BackColor = Color.LightPink; return false; }
            ret = strUtil.isInnerRange(Value, 0,  Math.Pow(2, HighBit));
            if (!ret)
                TxtBox.BackColor = Color.LightPink;
            else
                TxtBox.BackColor = Color.White;
            return ret;
        }

        private void showFpgaParam()
        {

            string Tag = "0x";
            SC_Param_Util ParmUtil = new SC_Param_Util();

            txtbox_csb.BackColor = Color.White;
            txtbox_csb.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.CSB.ToString()), 16);

            txtbox_csc.BackColor = Color.White;
            txtbox_csc.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.CSC), 16);

            txtbox_resb.BackColor = Color.White;
            txtbox_resb.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RESB), 16);

            txtbox_vspw.BackColor = Color.White;
            txtbox_vspw.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.VSPW), 16);

            txtbox_vstem.BackColor = Color.White;
            txtbox_vstem.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.VSTEM), 16);

            txtbox_vstee.BackColor = Color.White;
            txtbox_vstee.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.VSTEE), 16);

            txtbox_dsx.BackColor = Color.White;
            txtbox_dsx.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.DSX), 16);

            txtbox_rgbdsx.BackColor = Color.White;
            txtbox_rgbdsx.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGBDSX), 16);

            txtbox_srammode.BackColor = Color.White;
            txtbox_srammode.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SRAMMODE), 16);

            txtbox_spirddummyclk.BackColor = Color.White;
            txtbox_spirddummyclk.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SPIRDDUMMYCLK), 16);

            txtbox_spiwrclkh.BackColor = Color.White;
            txtbox_spiwrclkh.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SPIWRCLKH), 16);

            txtbox_spiwrclkl.BackColor = Color.White;
            txtbox_spiwrclkl.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SPIWRCLKL), 16);

            txtbox_spirdclkh.BackColor = Color.White;
            txtbox_spirdclkh.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SPIRDCLKH), 16);

            txtbox_spirdclkl.BackColor = Color.White;
            txtbox_spirdclkl.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SPIRDCLKL), 16);

            txtbox_sramcnt.BackColor = Color.White;
            txtbox_sramcnt.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SRAMCNT), 16);

            txtbox_cs123sel.BackColor = Color.White;
            txtbox_cs123sel.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.CS123SEL), 16);

            txtbox_BacklightDcount.BackColor = Color.White;
            txtbox_BacklightDcount.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.BACKLIGHT_DCOUNT), 16);

            txtbox_backlightRatio.BackColor = Color.White;
            txtbox_backlightRatio.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.BACKLIGHT_RATIO), 16);

            txtbox_i2cStop.BackColor = Color.White;
            txtbox_i2cStop.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.I2C_STOP), 16);

            txtbox_i2cStart.BackColor = Color.White;
            txtbox_i2cStart.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.I2C_START), 16);

            txtbox_i2cSckh.BackColor = Color.White;
            txtbox_i2cSckh.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.I2C_SCKH), 16);

            txtbox_i2cSckl.BackColor = Color.White;
            txtbox_i2cSckl.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.I2C_START), 16);

            txtbox_i2cRdbyteCnt.BackColor = Color.White;
            txtbox_i2cRdbyteCnt.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.I2C_RDBYTE_CNT), 16);

            txtbox_InterfaceMode.BackColor = Color.White;
            txtbox_InterfaceMode.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.INTERFACEMODE), 16);

            txtbox_rgbRmx.BackColor = Color.White;
            txtbox_rgbRmx.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_RMX), 16);

            txtbox_rgbMp.BackColor = Color.White;
            txtbox_rgbMp.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_MP), 16);

            txtbox_rgbEp.BackColor = Color.White;
            txtbox_rgbEp.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_EP), 16);

            txtbox_rgbHsp.BackColor = Color.White;
            txtbox_rgbHsp.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_HSP), 16);

            txtbox_rgbVsp.BackColor = Color.White;
            txtbox_rgbVsp.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_VSP), 16);

            txtbox_rgbTh.BackColor = Color.White;
            txtbox_rgbTh.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_TH), 16);

            txtbox_rgbTv.BackColor = Color.White;
            txtbox_rgbTv.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_TV), 16);

            txtbox_rgbThds.BackColor = Color.White;
            txtbox_rgbThds.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_THDS), 16);

            txtbox_rgbTvds.BackColor = Color.White;
            txtbox_rgbTvds.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_TVDS), 16);

            txtbox_rgbThbp.BackColor = Color.White;
            txtbox_rgbThbp.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_THBP), 16);

            txtbox_rgbTvbp.BackColor = Color.White;
            txtbox_rgbTvbp.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_TVBP), 16);

            txtbox_rgbThpw.BackColor = Color.White;
            txtbox_rgbThpw.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_THPW), 16);

            txtbox_rgbTvpw.BackColor = Color.White;
            txtbox_rgbTvpw.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_TVPW), 16);

            txtbox_sramHbaddr.BackColor = Color.White;
            txtbox_sramHbaddr.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SRAM_HBADDR), 16);

            txtbox_sramlbaddr.BackColor = Color.White;
            txtbox_sramlbaddr.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SRAM_LBADDR), 16);

            txtbox_rgbNormaldata.BackColor = Color.White;
            txtbox_rgbNormaldata.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.RGB_NORMALDATA), 16);

            txtbox_sramAddrautoen.BackColor = Color.White;
            txtbox_sramAddrautoen.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SRAM_ADDRAUTOEN), 16);

            txtbox_sramAddrautoCnt.BackColor = Color.White;
            txtbox_sramAddrautoCnt.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SRAM_ADDRAUTOCNT), 16);

            txtbox_sramAddroffset.BackColor = Color.White;
            txtbox_sramAddroffset.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SRAM_ADDROFFSET), 16);

            txtbox_sramAddrend.BackColor = Color.White;
            txtbox_sramAddrend.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.SRAM_ADDREND), 16);

            txtbox_dcmRst.BackColor = Color.White;
            txtbox_dcmRst.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.DCM_RST), 16);

            txtbox_dcmEn.BackColor = Color.White;
            txtbox_dcmEn.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.DCM_EN), 16);

            txtbox_dcmMultiply.BackColor = Color.White;
            txtbox_dcmMultiply.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.DCM_MULTIPLY), 16);

            txtbox_dcmDivide.BackColor = Color.White;
            txtbox_dcmDivide.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.DCM_DIVIDE), 16);

            txtbox_regGpio.BackColor = Color.White;
            txtbox_regGpio.Text = Tag + Convert.ToString(ParmUtil.getValueByName(FPGAREGNAME.GPIO), 16);
        }

        private void ReadFpgaParam()
        {

            uint xferData = 0;
            byte[] Val = new byte[8];
            SC_Param_Util ParmUtil = new SC_Param_Util();

            //reg_csb
            int ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.CSB, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.CSB, xferData);

            ////reg_csc
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.CSC, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.CSC, xferData);

            ////reg_resb
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RESB, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RESB, xferData);

            ////reg_vspw
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.VSPW, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.VSPW, xferData);

            ////reg_vstem
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.VSTEM, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.VSTEM, xferData);

            ////reg_vstee
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.VSTEE, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.VSTEE, xferData);

            ////reg_dsx
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.DSX, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.DSX, xferData);

            ////reg_rgbdsx
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGBDSX, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGBDSX, xferData);

            ////reg_srammode
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SRAMMODE, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SRAMMODE, xferData);

            ////reg_spirddummyclk
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SPIRDDUMMYCLK, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SPIRDDUMMYCLK, xferData);

            ////reg_spiwrclkh
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SPIWRCLKH, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SPIWRCLKH, xferData);

            ////reg_spiwrclkl
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SPIWRCLKL, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SPIWRCLKL, xferData);

            ////reg_spirdclkh
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SPIRDCLKH, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SPIRDCLKH, xferData);

            ////reg_spirdclkl
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SPIRDCLKL, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SPIRDCLKL, xferData);

            ////reg_sramcnt
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SRAMCNT, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SRAMCNT, xferData);


            ////reg_cs123sel
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.CS123SEL, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.CS123SEL, xferData);

            ////reg_backlight_dcount
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.BACKLIGHT_DCOUNT, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.BACKLIGHT_DCOUNT, xferData);

            ////reg_backlight_ratio
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.BACKLIGHT_RATIO, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.BACKLIGHT_RATIO, xferData);

            ////reg_i2c_stop
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.I2C_STOP, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.I2C_STOP, xferData);

            ////reg_i2c_start
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.I2C_START, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.I2C_START, xferData);

            ////reg_i2c_sckh
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.I2C_SCKH, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.I2C_SCKH, xferData);

            ////reg_i2c_sckl
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.I2C_SCKL, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.I2C_SCKL, xferData);

            ////reg_i2c_rdbyte_cnt
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.I2C_RDBYTE_CNT, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.I2C_RDBYTE_CNT, xferData);

            ////reg_interfacemode
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.INTERFACEMODE, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.INTERFACEMODE, xferData);

            ////reg_rgb_rmx
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_RMX, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_RMX, xferData);

            ////reg_rgb_mp
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_MP, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_MP, xferData);

            ////reg_rgb_ep
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_EP, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_EP, xferData);

            ////reg_rgb_hsp
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_HSP, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_HSP, xferData);

            ////reg_rgb_vsp
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_VSP, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_VSP, xferData);

            ////reg_rgb_th
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_TH, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_TH, xferData);

            ////reg_rgb_tv
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_TV, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_TV, xferData);

            ////reg_rgb_thds
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_THDS, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_THDS, xferData);

            ////reg_rgb_tvds
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_TVDS, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_TVDS, xferData);

            ////reg_rgb_thbp
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_THBP, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_THBP, xferData);

            ////reg_rgb_tvbp
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_TVBP, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_TVBP, xferData);

            ////reg_rgb_thpw
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_THPW, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_THPW, xferData);

            ////reg_rgb_tvpw
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_TVPW, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_TVPW, xferData);

            ////reg_sram_hbaddr
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SRAM_HBADDR, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SRAM_HBADDR, xferData);

            ////reg_sram_lbaddr
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SRAM_LBADDR, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SRAM_LBADDR, xferData);

            ////reg_rgb_normaldata
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.RGB_NORMALDATA, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.RGB_NORMALDATA, xferData);

            ////reg_sram_addrautoen
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SRAM_ADDRAUTOEN, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SRAM_ADDRAUTOEN, xferData);

            ////reg_sram_addrautocnt
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SRAM_ADDRAUTOCNT, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SRAM_ADDRAUTOCNT, xferData);

            ////reg_sram_addroffset
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SRAM_ADDROFFSET, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SRAM_ADDROFFSET, xferData);

            ////reg_sram_addrend
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.SRAM_ADDREND, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.SRAM_ADDREND, xferData);

            ////reg_dcm_rst
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.DCM_RST, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.DCM_RST, xferData);

            ////reg_dcm_en
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.DCM_EN, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.DCM_EN, xferData);

            ////reg_dcm_multiply
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.DCM_MULTIPLY, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.DCM_MULTIPLY, xferData);

            ////reg_dcm_divide
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.DCM_DIVIDE, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.DCM_DIVIDE, xferData);

            ////reg_gpio
            ret = SC_Comm_Base.SC_CommBase_ReadReg(FPGAREGNAME.GPIO, ref xferData);
            if (ret == Chip.ERROR_RESULT_OK) ParmUtil.UpdateRegValue(FPGAREGNAME.GPIO, xferData);
        

        }



        private void TestPattern()
        {
            string Tag = "0xff";

            txtbox_csb.Text = Tag;
            txtbox_csc.Text = Tag;
            txtbox_resb.Text = Tag;
            txtbox_vspw.Text = Tag;
            txtbox_vstem.Text = Tag;
            txtbox_vstee.Text = Tag;
            txtbox_dsx.Text = Tag;
            txtbox_rgbdsx.Text = Tag;
            txtbox_srammode.Text = Tag;
            txtbox_spirddummyclk.Text = Tag;
            txtbox_spiwrclkh.Text = Tag;
            txtbox_spiwrclkl.Text = Tag;
            txtbox_spirdclkh.Text = Tag;
            txtbox_spirdclkl.Text = Tag;
            txtbox_sramcnt.Text = Tag;
            txtbox_cs123sel.Text = Tag;
            txtbox_BacklightDcount.Text = Tag;
            txtbox_backlightRatio.Text = Tag;
            txtbox_i2cStop.Text = Tag;
            txtbox_i2cStart.Text = Tag;
            txtbox_i2cSckh.Text = Tag;
            txtbox_i2cSckl.Text = Tag;
            txtbox_i2cRdbyteCnt.Text = Tag;
            txtbox_InterfaceMode.Text = Tag;
            txtbox_rgbRmx.Text = Tag;
            txtbox_rgbMp.Text = Tag;
            txtbox_rgbEp.Text = Tag;
            txtbox_rgbHsp.Text = Tag;
            txtbox_rgbVsp.Text = Tag;
            txtbox_rgbTh.Text = Tag;
            txtbox_rgbTv.Text = Tag;
            txtbox_rgbThds.Text = Tag;
            txtbox_rgbTvds.Text = Tag;
            txtbox_rgbThbp.Text = Tag;
            txtbox_rgbTvbp.Text = Tag;
            txtbox_rgbThpw.Text = Tag;
            txtbox_rgbTvpw.Text = Tag;
            txtbox_sramHbaddr.Text = Tag;
            txtbox_sramlbaddr.Text = Tag;
            txtbox_rgbNormaldata.Text = Tag;
            txtbox_sramAddrautoen.Text = Tag;
            txtbox_sramAddrautoCnt.Text = Tag;
            txtbox_sramAddroffset.Text = Tag;
            txtbox_sramAddrend.Text = Tag;
            txtbox_dcmRst.Text = Tag;
            txtbox_dcmEn.Text = Tag;
            txtbox_dcmMultiply.Text = Tag;
            txtbox_dcmDivide.Text = Tag;
            txtbox_regGpio.Text = Tag;
        }

        private void ReadConfig(SC_Ini_Util iniUtil)
        {
            SC_Param_Util ParaUtil = new SC_Param_Util();
            txtbox_csb.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.CSB), FPGAREGNAME.CSB);
            txtbox_csc.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.CSC), FPGAREGNAME.CSC);
            txtbox_resb.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RESB), FPGAREGNAME.RESB);
            txtbox_vspw.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.VSPW), FPGAREGNAME.VSPW);
            txtbox_vstem.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.VSTEM), FPGAREGNAME.VSTEM);
            txtbox_vstee.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.VSTEE), FPGAREGNAME.VSTEE);
            txtbox_dsx.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.DSX), FPGAREGNAME.DSX);
            txtbox_rgbdsx.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGBDSX), FPGAREGNAME.RGBDSX);
            txtbox_srammode.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SRAMMODE), FPGAREGNAME.SRAMMODE);
            txtbox_spirddummyclk.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SPIRDDUMMYCLK), FPGAREGNAME.SPIRDDUMMYCLK);
            txtbox_spiwrclkh.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SPIWRCLKH), FPGAREGNAME.SPIWRCLKH);
            txtbox_spiwrclkl.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SPIWRCLKL), FPGAREGNAME.SPIWRCLKL);
            txtbox_spirdclkh.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SPIRDCLKH), FPGAREGNAME.SPIRDCLKH);
            txtbox_spirdclkl.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SPIRDCLKL), FPGAREGNAME.SPIRDCLKL);
            txtbox_sramcnt.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SRAMCNT), FPGAREGNAME.SRAMCNT);
            txtbox_cs123sel.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.CS123SEL), FPGAREGNAME.CS123SEL);
            txtbox_BacklightDcount.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.BACKLIGHT_DCOUNT), FPGAREGNAME.BACKLIGHT_DCOUNT);
            txtbox_backlightRatio.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.BACKLIGHT_RATIO), FPGAREGNAME.BACKLIGHT_RATIO);
            txtbox_i2cStop.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.I2C_STOP), FPGAREGNAME.I2C_STOP);
            txtbox_i2cStart.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.I2C_START), FPGAREGNAME.I2C_START);
            txtbox_i2cSckh.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.I2C_SCKH), FPGAREGNAME.I2C_SCKH);
            txtbox_i2cSckl.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.I2C_SCKL), FPGAREGNAME.I2C_SCKL);
            txtbox_i2cRdbyteCnt.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.I2C_RDBYTE_CNT), FPGAREGNAME.I2C_RDBYTE_CNT);
            txtbox_InterfaceMode.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.INTERFACEMODE), FPGAREGNAME.INTERFACEMODE);
            txtbox_rgbRmx.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_RMX), FPGAREGNAME.RGB_RMX);
            txtbox_rgbMp.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_MP), FPGAREGNAME.RGB_MP);
            txtbox_rgbEp.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_EP), FPGAREGNAME.RGB_EP);
            txtbox_rgbHsp.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_HSP), FPGAREGNAME.RGB_HSP);
            txtbox_rgbVsp.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_VSP), FPGAREGNAME.RGB_VSP);
            txtbox_rgbTh.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_TH), FPGAREGNAME.RGB_TH);
            txtbox_rgbTv.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_TV), FPGAREGNAME.RGB_TV);
            txtbox_rgbThds.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_THDS), FPGAREGNAME.RGB_THDS);
            txtbox_rgbTvds.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_TVDS), FPGAREGNAME.RGB_TVDS);
            txtbox_rgbThbp.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_THBP), FPGAREGNAME.RGB_THBP);
            txtbox_rgbTvbp.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_TVBP), FPGAREGNAME.RGB_TVBP);
            txtbox_rgbThpw.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_THPW), FPGAREGNAME.RGB_THPW);
            txtbox_rgbTvpw.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_TVPW), FPGAREGNAME.RGB_TVPW);
            txtbox_sramHbaddr.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_HBADDR), FPGAREGNAME.SRAM_HBADDR);
            txtbox_sramlbaddr.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_LBADDR), FPGAREGNAME.SRAM_LBADDR);
            txtbox_rgbNormaldata.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_NORMALDATA), FPGAREGNAME.RGB_NORMALDATA);
            txtbox_sramAddrautoen.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_ADDRAUTOEN), FPGAREGNAME.SRAM_ADDRAUTOEN);
            txtbox_sramAddrautoCnt.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_ADDRAUTOCNT), FPGAREGNAME.SRAM_ADDRAUTOCNT);
            txtbox_sramAddroffset.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_ADDROFFSET), FPGAREGNAME.SRAM_ADDROFFSET);
            txtbox_sramAddrend.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_ADDREND), FPGAREGNAME.SRAM_ADDREND);
            txtbox_dcmRst.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.DCM_RST), FPGAREGNAME.DCM_RST);
            txtbox_dcmEn.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.DCM_EN), FPGAREGNAME.DCM_EN);
            txtbox_dcmMultiply.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.DCM_MULTIPLY), FPGAREGNAME.DCM_MULTIPLY);
            txtbox_dcmDivide.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.DCM_DIVIDE), FPGAREGNAME.DCM_DIVIDE);
            txtbox_regGpio.Text = iniUtil.IniReadValue(ParaUtil.getRootByName(FPGAREGNAME.GPIO), FPGAREGNAME.GPIO);
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            /*Choose Ini File */
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.ini|*.*";
            openFileDialog.FileName = "default.ini";
            openFileDialog.InitialDirectory = Setting.ExeConfigDirPath;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Setting.ExeConfigDefaultPath = _IniPath = openFileDialog.FileName;
                SC_Ini_Util iniUtil = new SC_Ini_Util(_IniPath);
                txtBox_Path.Text = Path.GetFileName(_IniPath);
                label_info.Text = "* Load INI Path";
                ReadConfig(iniUtil);
            }

        }


        private void WriteConfig(SC_Ini_Util iniUtil)
        {
            SC_Param_Util ParaUtil = new SC_Param_Util();
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.CSB), FPGAREGNAME.CSB, txtbox_csb.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.CSC), FPGAREGNAME.CSC, txtbox_csc.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RESB), FPGAREGNAME.RESB, txtbox_resb.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.VSPW), FPGAREGNAME.VSPW, txtbox_vspw.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.VSTEM), FPGAREGNAME.VSTEM, txtbox_vstem.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.VSTEE), FPGAREGNAME.VSTEE, txtbox_vstee.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.DSX), FPGAREGNAME.DSX, txtbox_dsx.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGBDSX), FPGAREGNAME.RGBDSX, txtbox_rgbdsx.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SRAMMODE), FPGAREGNAME.SRAMMODE, txtbox_srammode.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SPIRDDUMMYCLK), FPGAREGNAME.SPIRDDUMMYCLK, txtbox_spirddummyclk.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SPIWRCLKH), FPGAREGNAME.SPIWRCLKH, txtbox_spiwrclkh.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SPIWRCLKL), FPGAREGNAME.SPIWRCLKL, txtbox_spiwrclkl.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SPIRDCLKH), FPGAREGNAME.SPIRDCLKH, txtbox_spirdclkh.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SPIRDCLKL), FPGAREGNAME.SPIRDCLKL, txtbox_spirdclkl.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SRAMCNT), FPGAREGNAME.SRAMCNT, txtbox_sramcnt.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.CS123SEL), FPGAREGNAME.CS123SEL, txtbox_cs123sel.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.BACKLIGHT_DCOUNT), FPGAREGNAME.BACKLIGHT_DCOUNT, txtbox_BacklightDcount.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.BACKLIGHT_RATIO), FPGAREGNAME.BACKLIGHT_RATIO, txtbox_backlightRatio.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.I2C_STOP), FPGAREGNAME.I2C_STOP, txtbox_i2cStop.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.I2C_START), FPGAREGNAME.I2C_START, txtbox_i2cStart.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.I2C_SCKH), FPGAREGNAME.I2C_SCKH, txtbox_i2cSckh.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.I2C_SCKL), FPGAREGNAME.I2C_SCKL, txtbox_i2cSckl.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.I2C_RDBYTE_CNT), FPGAREGNAME.I2C_RDBYTE_CNT, txtbox_i2cRdbyteCnt.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.INTERFACEMODE), FPGAREGNAME.INTERFACEMODE, txtbox_InterfaceMode.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_RMX), FPGAREGNAME.RGB_RMX, txtbox_rgbRmx.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_MP), FPGAREGNAME.RGB_MP, txtbox_rgbMp.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_EP), FPGAREGNAME.RGB_EP, txtbox_rgbEp.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_HSP), FPGAREGNAME.RGB_HSP, txtbox_rgbHsp.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_VSP), FPGAREGNAME.RGB_VSP, txtbox_rgbVsp.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_TH), FPGAREGNAME.RGB_TH, txtbox_rgbTh.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_TV), FPGAREGNAME.RGB_TV, txtbox_rgbTv.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_THDS), FPGAREGNAME.RGB_THDS, txtbox_rgbThds.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_TVDS), FPGAREGNAME.RGB_TVDS, txtbox_rgbTvds.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_THBP), FPGAREGNAME.RGB_THBP, txtbox_rgbThbp.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_TVBP), FPGAREGNAME.RGB_TVBP, txtbox_rgbTvbp.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_THPW), FPGAREGNAME.RGB_THPW, txtbox_rgbThpw.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_TVPW), FPGAREGNAME.RGB_TVPW, txtbox_rgbTvpw.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_HBADDR), FPGAREGNAME.SRAM_HBADDR, txtbox_sramHbaddr.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_LBADDR), FPGAREGNAME.SRAM_LBADDR, txtbox_sramlbaddr.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.RGB_NORMALDATA), FPGAREGNAME.RGB_NORMALDATA, txtbox_rgbNormaldata.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_ADDRAUTOEN), FPGAREGNAME.SRAM_ADDRAUTOEN, txtbox_sramAddrautoen.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_ADDRAUTOCNT), FPGAREGNAME.SRAM_ADDRAUTOCNT, txtbox_sramAddrautoCnt.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_ADDROFFSET), FPGAREGNAME.SRAM_ADDROFFSET, txtbox_sramAddroffset.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.SRAM_ADDREND), FPGAREGNAME.SRAM_ADDREND, txtbox_sramAddrend.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.DCM_RST), FPGAREGNAME.DCM_RST, txtbox_dcmRst.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.DCM_EN), FPGAREGNAME.DCM_EN, txtbox_dcmEn.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.DCM_MULTIPLY), FPGAREGNAME.DCM_MULTIPLY, txtbox_dcmMultiply.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.DCM_DIVIDE), FPGAREGNAME.DCM_DIVIDE, txtbox_dcmDivide.Text);
            iniUtil.IniWriteValue(ParaUtil.getRootByName(FPGAREGNAME.GPIO), FPGAREGNAME.GPIO, txtbox_regGpio.Text);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Ini files (*.ini)|*.ini";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Save SocleTech INI";
            saveFileDialog1.InitialDirectory = Setting.ExeConfigDirPath;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Setting.ExeConfigDefaultPath = _IniPath = saveFileDialog1.FileName;
                SC_Ini_Util iniUtil = new SC_Ini_Util(_IniPath);
                label_info.Text = "* Save INI Path";
                WriteConfig(iniUtil);
            }
        }


    }
}
