#define DEBUG 
using System;
using System.Linq;
using System.Threading;
using XM_Tek_Studio_Pro.StudioUtil;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace XM_Tek_Studio_Pro
{
    class XM_ExeWolCmd_Util : XM_ExeCmd
    {
        private const double FPGA_OSC = 40.0;
        private char[] DelimiterChars = { ' ', ',', ':', '\t' };
        XM_ExeWol_Util XmPlusUtil = new XM_ExeWol_Util();

        public bool ExcuteCmd(string Cmd, byte CmdType, byte XmCategory, ref string RdStr)
        {
            bool ret = true;
            if (RunInfo.FoundLoopList.Count > 0) { RunInfo.XmCmdInfo.Excute = false; return false; }
            if (RunInfo.RunLoop == null && RunInfo.RunLoopList.Count > 0) { RunInfo.XmCmdInfo.Excute = false; return false; };

            string[] XmCmd = (string[])MergeXMCmds(Cmd.Trim()).ToArray(typeof(string));
            string[] XmPlusData = ExchangeXmData(RunInfo.RunLoopList, XmCmd, RunInfo.XmCmdInfo, XmCategory);

            if (XM_Cmd_Lib.xmd[0] == XmCmd[0]) ret = XmFpgaID(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[1] == XmCmd[0]) ret = XmFpgaParm(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[2] == XmCmd[0]) ret = XmFpgaWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[3] == XmCmd[0]) ret = XmFpgaRead(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[4] == XmCmd[0]) ret = XmBridgeSelect(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[5] == XmCmd[0]) ret = XmBrigeWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[6] == XmCmd[0]) ret = XmBrigeRead(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[7] == XmCmd[0]) ret = XmGpioDir(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[8] == XmCmd[0]) ret = XmGpioWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[9] == XmCmd[0]) ret = XmGpioSet(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[10] == XmCmd[0]) ret = XmGpioHSet(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[11] == XmCmd[0]) ret = XmGpioLSet(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[12] == XmCmd[0]) ret = XmGpioRd(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[13] == XmCmd[0]) ret = XmGpioClr(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[14] == XmCmd[0]) ret = SetMipiDsi(XmPlusData);
            if (XM_Cmd_Lib.xmd[15] == XmCmd[0]) ret = SetMipiVideo(XmPlusData);
            if (XM_Cmd_Lib.xmd[16] == XmCmd[0]) ret = XmMipiWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[17] == XmCmd[0]) ret = XmMipiRead(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[18] == XmCmd[0]) ret = XmHighMipiWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[19] == XmCmd[0]) ret = XmHighMipiRead(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[20] == XmCmd[0]) ret = XmMipiBta(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[21] == XmCmd[0]) ret = XmMipiUlp(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[22] == XmCmd[0]) ret = XmImageFill(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[23] == XmCmd[0]) ret = XmImageWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[24] == XmCmd[0]) ret = XmImageShow(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[32] == XmCmd[0]) ret = XmFpgaCmdWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[33] == XmCmd[0]) ret = XmFpgaCmdWriteGpio(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[34] == XmCmd[0]) ret = XmFpgaVer(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[35] == XmCmd[0]) ret = XmFpgaDelay(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[36] == XmCmd[0]) ret = XmFpgaSleep(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[61] == XmCmd[0]) ret = XmPMIC_0_WR(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[62] == XmCmd[0]) ret = XmPMIC_2_WR(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[63] == XmCmd[0]) ret = XmPMIC_0_RD(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[64] == XmCmd[0]) ret = XmPMIC_2_RD(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[65] == XmCmd[0]) ret = XMPmic_0_EnLcd(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[66] == XmCmd[0]) ret = XMPmic_0_EnLed(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[67] == XmCmd[0]) ret = XMPmic_0_PWM(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[68] == XmCmd[0]) ret = XMPmic_0_BL(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[69] == XmCmd[0]) ret = XMPmic_0_VOL(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[70] == XmCmd[0]) ret = XMPmic_0_RST(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[71] == XmCmd[0]) ret = XMPmic_0_DELAY(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[72] == XmCmd[0]) ret = XMPmic_0_Set(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[73] == XmCmd[0]) ret = XMPmic_0_Bright(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[74] == XmCmd[0]) ret = XMPmic_0_Vsp(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[75] == XmCmd[0]) ret = XMPmic_0_Vsn(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[76] == XmCmd[0]) ret = XMPmic_2_EnLcd(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[77] == XmCmd[0]) ret = XMPmic_2_EnLed(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[78] == XmCmd[0]) ret = XMPmic_2_PWM(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[79] == XmCmd[0]) ret = XMPmic_2_BL(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[80] == XmCmd[0]) ret = XMPmic_2_VOL(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[81] == XmCmd[0]) ret = XMPmic_2_RST(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[82] == XmCmd[0]) ret = XMPmic_2_DELAY(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[83] == XmCmd[0]) ret = XMPmic_2_Set(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[84] == XmCmd[0]) ret = XMPmic_2_Bright(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[85] == XmCmd[0]) ret = XMPmic_2_Vsp(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[86] == XmCmd[0]) ret = XMPmic_2_Vsn(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[87] == XmCmd[0]) ret = XmRstEn(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[88] == XmCmd[0]) ret = XmRstPolarity(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[89] == XmCmd[0]) ret = XmRstTrigger(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[90] == XmCmd[0]) ret = XmRstSet(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[91] == XmCmd[0]) ret = XmRstReset(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[92] == XmCmd[0]) ret = XM_DDR_Img(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[93] == XmCmd[0]) ret = XMGeneralSet(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[94] == XmCmd[0]) ret = XMCpuWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[95] == XmCmd[0]) ret = XMDevAddrMode(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[96] == XmCmd[0]) ret = XMCpuAddrWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[97] == XmCmd[0]) ret = XMCpuDataWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[98] == XmCmd[0]) ret = XMSpiSet(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[99] == XmCmd[0]) ret = XMSpiWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[100] == XmCmd[0]) ret = XMSpiAddrWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[101] == XmCmd[0]) ret = XMSpiDataWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[102] == XmCmd[0]) ret = XMSpiCsCtrl_High(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[103] == XmCmd[0]) ret = XMSpiCsCtrl_Low(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[104] == XmCmd[0]) ret = XMI2CSet(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[105] == XmCmd[0]) ret = XMI2CWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[106] == XmCmd[0]) ret = XMI2CRead(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[107] == XmCmd[0]) ret = XMI2CRdNum(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[108] == XmCmd[0]) ret = XMI2CDevDataWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[109] == XmCmd[0]) ret = XMI2CDevAddrWrite(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[110] == XmCmd[0]) ret = XMI2CSlaveAddr(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[112] == XmCmd[0]) ret = XMDevStatusRead(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[113] == XmCmd[0]) ret = XMDevRead(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[114] == XmCmd[0]) ret = XMDevDummyRead(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[115] == XmCmd[0]) ret = XMMcuCsCtrl_High(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[116] == XmCmd[0]) ret = XMMcuCsCtrl_Low(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[117] == XmCmd[0]) ret = XMMcuCsCtrl_Clr(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[118] == XmCmd[0]) ret = RamRead(XmPlusData, ref RdStr);
            return ret;
        }

        private bool RamRead(string[] XmPlusData, ref string RdStr)
        {
            bool ret = true;
            int[] XmPlusVal = StrToInt(XmPlusData);
            ret = XmPlusUtil.ramRead(XmPlusVal[0], XmPlusVal[1], ref RdStr);
            return ret;
        }

        private bool XMDevStatusRead(string[] XmPlusData, ref string RdStr)
        {
            XM_Comm_Control.XM_Comm_Base.AddrWr(0x82);
            byte Data = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            RdStr = string.Concat("0x", Data.ToString("X2"));
            if (XmPlusData.Length > 0 && XmPlusData[XmPlusData.Length - 1].EndsWith("txt"))
                SaveMsgToFile(XmPlusData[XmPlusData.Length - 1], RdStr);
            return true;
        }

        private bool XMDevDummyRead(string[] XmPlusData, ref string RdStr)
        {
            XM_Comm_Control.XM_Comm_Base.AddrWr(0x83);
            byte Value = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            RdStr = string.Concat(RdStr, " 0x", Value.ToString("X2"), " ");
            if (XmPlusData.Length > 0 && XmPlusData[XmPlusData.Length - 1].EndsWith("txt"))
                SaveMsgToFile(XmPlusData[XmPlusData.Length - 1], RdStr);
            return true;
        }

        private bool XMDevRead(string[] XmPlusData, ref string RdStr)
        {
            XM_Comm_Control.XM_Comm_Base.AddrWr(0x83);
            byte Value = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            RdStr = string.Concat(RdStr, " 0x", Value.ToString("X2"));
            if (XmPlusData.Length > 0 && XmPlusData[XmPlusData.Length - 1].EndsWith("txt"))
                SaveMsgToFile(XmPlusData[XmPlusData.Length - 1], RdStr);
            return true;
        }


        private bool XMI2CSlaveAddr(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            XmPlusUtil.SetI2CAddress(XmPlusVal[0]);
            return true;
        }

        private bool XMI2CDevAddrWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte[] XmBlockData = new byte[XmPlusVal.Length + 1];
            Array.Clear(XmBlockData, 0, XmBlockData.Length);
            Array.Copy(XmPlusVal, 0, XmBlockData, 1, XmPlusVal.Length);
            return XmPlusUtil.I2CWrite(XmBlockData);
        }

        private bool XMI2CDevDataWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte[] XmBlockData = Enumerable.Repeat((byte)0x40, (XmPlusVal.Length)).ToArray();
            Array.Copy(XmPlusVal, 0, XmBlockData, 0, XmPlusVal.Length);
            return XmPlusUtil.I2CWrite(XmBlockData);
        }

        private bool XMI2CSet(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9C, XmPlusVal[0], XmPlusVal[1]);
            return true;
        }

        private bool XMI2CWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.I2CWrite(XmPlusVal);
        }

        private bool XMI2CRead(string[] XmPlusData, ref string RdStr)
        {
            return true;
        }

        private bool XMI2CRdNum(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9d, XmPlusVal[0], XmPlusVal[1], XmPlusVal[2]);
            return true;
        }

        private bool XMSpiCsCtrl_Low(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmBlockData = new byte[2];
            XmBlockData[0] = 0x90;
            XmBlockData[1] = 0x02;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(XmBlockData, XmBlockData.Length);
            return true;
        }

        private bool XMSpiCsCtrl_High(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmBlockData = new byte[2];
            XmBlockData[0] = 0x90;
            XmBlockData[1] = 0x03;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(XmBlockData, XmBlockData.Length);
            return true;
        }

        private bool XMMcuCsCtrl_High(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmBlockData = new byte[2];
            XmBlockData[0] = 0x90;
            XmBlockData[1] = 0x13;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(XmBlockData, XmBlockData.Length);
            XmBlockData[1] = 0x10;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(XmBlockData, XmBlockData.Length);
            return true;
        }

        private bool XMMcuCsCtrl_Low(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmBlockData = new byte[2];
            XmBlockData[0] = 0x90;
            XmBlockData[1] = 0x12;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(XmBlockData, XmBlockData.Length);
            return true;
        }

        private bool XMMcuCsCtrl_Clr(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmBlockData = new byte[2];
            XmBlockData[0] = 0x90;
            XmBlockData[1] = 0x10;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(XmBlockData, XmBlockData.Length);
            return true;
        }


        private bool XMSpiDataWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte[] XmBlockData = Enumerable.Repeat((byte)0x81, XmPlusVal.Length * 2).ToArray();
            for (int i = 0; i < XmPlusVal.Length; i++) XmBlockData[i * 2 + 1] = XmPlusVal[i];
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(XmBlockData, XmBlockData.Length);
            return true;
        }

        private bool XMSpiAddrWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte[] XmBlockData = Enumerable.Repeat((byte)0x80, XmPlusVal.Length * 2).ToArray();
            for (int i = 0; i < XmPlusVal.Length; i++) XmBlockData[i * 2 + 1] = XmPlusVal[i];
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(XmBlockData, XmBlockData.Length);
            return true;
        }

        private bool XMSpiWrite(string[] XmPlusData, ref string RdStr)
        {
            return true;
        }

        private bool XMSpiSet(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte[] XmBlockData = new byte[(XmPlusVal.Length - 1) * 2];
            XmBlockData[0] = 0x90;
            XmBlockData[1] = XmPlusVal[0] == 0 ? (byte)0x03 : (byte)0x00;
            XmBlockData[2] = 0x94;
            XmBlockData[3] = (byte)(((XmPlusVal[1] & 0x01) << 4) + (XmPlusVal[2] & 0x01));
            XmBlockData[4] = 0x95;
            XmBlockData[5] = XmPlusVal[3];
            XmBlockData[6] = 0x96;
            XmBlockData[7] = XmPlusVal[4];
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(XmBlockData, XmBlockData.Length);
            return true;
        }

        private bool XMDevAddrMode(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            XmPlusUtil.SetDevAddrMode(XmPlusVal[0]);
            return true;
        }

        private bool XMGeneralSet(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return true;
        }

        private bool XMCpuAddrWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte[] XmBlockData = Enumerable.Repeat((byte)0x80, XmPlusVal.Length * 2).ToArray();
            for (int i = 0; i < XmPlusVal.Length; i++) XmBlockData[i * 2 + 1] = XmPlusVal[i];
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(XmBlockData, XmBlockData.Length);
            return true;
        }

        private bool XMCpuDataWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte[] XmBlockData = Enumerable.Repeat((byte)0x81, XmPlusVal.Length * 2).ToArray();
            for (int i = 0; i < XmPlusVal.Length; i++) XmBlockData[i * 2 + 1] = XmPlusVal[i];
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(XmBlockData, XmBlockData.Length);
            return true;
        }

        private bool XMCpuWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return true;
        }

        private bool XMPmic_0_Vsn(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Data = 0;
            float Vsn = 0;
            byte VolVSN = 0;

            if (!new XM_Digital_Util().StrToNumber<float>(XmPlusData[0], ref Vsn)) return false;
            XmPlusUtil.PMIC_0_Read(0x0F, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSN = (byte)((Math.Abs(Vsn) - 4) / 0.05);
            VolVSN = (byte)((Data & 0xc0) | VolVSN);
            XmPlusUtil.PMIC_0_Write(0x0F, VolVSN, ref RdStr);

            Reg = null;
            XmPlusUtil.PMIC_0_Read(0x0C, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            if (string.Compare(XmPlusData[1], "gnd") == 0)
                Data = (byte)(Data | 0x04);
            else
                Data = (byte)(Data & 0xfb);
            XmPlusUtil.PMIC_0_Write(0x0C, Data, ref RdStr);
            return true;
        }
        private bool XMPmic_2_Vsn(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Data = 0;
            float Vsn = 0;
            byte VolVSN = 0;

            if (!new XM_Digital_Util().StrToNumber<float>(XmPlusData[0], ref Vsn)) return false;
            XmPlusUtil.PMIC_2_Read(0x0F, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSN = (byte)((Math.Abs(Vsn) - 4) / 0.05);
            VolVSN = (byte)((Data & 0xc0) | VolVSN);
            XmPlusUtil.PMIC_2_Write(0x0F, VolVSN, ref RdStr);

            Reg = null;
            XmPlusUtil.PMIC_2_Read(0x0C, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            if (string.Compare(XmPlusData[1], "gnd") == 0)
                Data = (byte)(Data | 0x04);
            else
                Data = (byte)(Data & 0xfb);
            XmPlusUtil.PMIC_2_Write(0x0C, Data, ref RdStr);
            return true;
        }

        private bool XMPmic_0_Vsp(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Data = 0;
            float Vsp = 0;
            byte VolVSP = 0;

            if (!new XM_Digital_Util().StrToNumber<float>(XmPlusData[0], ref Vsp)) return false;
            XmPlusUtil.PMIC_0_Read(0x0E, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSP = (byte)((Vsp - 4) / 0.05);
            VolVSP = (byte)((Data & 0xc0) | VolVSP);
            XmPlusUtil.PMIC_0_Write(0x0E, VolVSP, ref RdStr);

            Reg = null;
            XmPlusUtil.PMIC_0_Read(0x0C, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            if (string.Compare(XmPlusData[1], "gnd") == 0)
                Data = (byte)((Data & 0xdf) | 0x20);
            else
                Data = (byte)(Data & 0xdf);
            XmPlusUtil.PMIC_0_Write(0x0C, Data, ref RdStr);
            return true;
        }
        private bool XMPmic_2_Vsp(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Data = 0;
            float Vsp = 0;
            byte VolVSP = 0;

            if (!new XM_Digital_Util().StrToNumber<float>(XmPlusData[0], ref Vsp)) return false;
            XmPlusUtil.PMIC_2_Read(0x0E, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSP = (byte)((Vsp - 4) / 0.05);
            VolVSP = (byte)((Data & 0xc0) | VolVSP);
            XmPlusUtil.PMIC_2_Write(0x0E, VolVSP, ref RdStr);

            Reg = null;
            XmPlusUtil.PMIC_2_Read(0x0C, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            if (string.Compare(XmPlusData[1], "gnd") == 0)
                Data = (byte)((Data & 0xdf) | 0x20);
            else
                Data = (byte)(Data & 0xdf);
            XmPlusUtil.PMIC_2_Write(0x0C, Data, ref RdStr);
            return true;

        }

        private bool XMPmic_0_Bright(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Data = 0;
            int[] XmPlusVal = StrToInt(XmPlusData);

            XmPlusUtil.PMIC_0_Read(0x03, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)((Data & 0xfe) | XmPlusVal[0]);
            XmPlusUtil.PMIC_0_Write(0x03, Data, ref RdStr);

            Reg = null;
            XmPlusUtil.PMIC_0_Read(0x04, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)((Data & 0xf8) | (XmPlusVal[1] >> 8));
            XmPlusUtil.PMIC_0_Write(0x04, Data, ref RdStr);

            Reg = null;
            XmPlusUtil.PMIC_0_Read(0x05, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)(XmPlusVal[1] & 0xff);
            XmPlusUtil.PMIC_0_Write(0x05, Data, ref RdStr);
            return true;
        }

        private bool XMPmic_2_Bright(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Data = 0;
            int[] XmPlusVal = StrToInt(XmPlusData);

            XmPlusUtil.PMIC_2_Read(0x03, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)((Data & 0xfe) | XmPlusVal[0]);
            XmPlusUtil.PMIC_2_Write(0x03, Data, ref RdStr);

            Reg = null;
            XmPlusUtil.PMIC_2_Read(0x04, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)((Data & 0xf7) | (XmPlusVal[1] >> 8));
            XmPlusUtil.PMIC_2_Write(0x04, Data, ref RdStr);

            Reg = null;
            XmPlusUtil.PMIC_2_Read(0x05, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)(XmPlusVal[1] & 0xff);
            XmPlusUtil.PMIC_2_Write(0x05, Data, ref RdStr);
            return true;
        }

        private bool XMPmic_0_Set(string[] XmPlusData, ref string RdStr)
        {
            string[] PwrVol = new string[2];
            string[] EnPmic = new string[1];
            string[] BLMode = new string[1];

            Array.Copy(XmPlusData, 0, PwrVol, 0, 2);
            Array.Copy(XmPlusData, 2, BLMode, 0, 1);
            EnPmic[0] = "0";
            XMPmic_0_EnLed(EnPmic, ref RdStr);
            XMPmic_0_EnLcd(EnPmic, ref RdStr);
            XMPmic_0_VOL(PwrVol, ref RdStr);
            XMPmic_0_BL(BLMode, ref RdStr);
            EnPmic[0] = "1";
            XMPmic_0_EnLed(EnPmic, ref RdStr);
            XMPmic_0_EnLcd(EnPmic, ref RdStr);
            return true;
        }

        private bool XMPmic_2_Set(string[] XmPlusData, ref string RdStr)
        {
            string[] PwrVol = new string[2];
            string[] EnPmic = new string[1];
            string[] BLMode = new string[1];

            Array.Copy(XmPlusData, 0, PwrVol, 0, 2);
            Array.Copy(XmPlusData, 2, BLMode, 0, 1);
            EnPmic[0] = "0";
            XMPmic_2_EnLed(EnPmic, ref RdStr);
            XMPmic_2_EnLcd(EnPmic, ref RdStr);
            XMPmic_2_VOL(PwrVol, ref RdStr);
            XMPmic_2_BL(BLMode, ref RdStr);
            EnPmic[0] = "1";
            XMPmic_2_EnLed(EnPmic, ref RdStr);
            XMPmic_2_EnLcd(EnPmic, ref RdStr);
            return true;

        }

        private bool XMPmic_0_DELAY(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Data = 0;
            byte[] XmPlusVal = StrToByte(XmPlusData);

            XmPlusUtil.PMIC_0_Read(0x0d, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)((Data & 0x3f) | (XmPlusVal[0] << 6));
            XmPlusUtil.PMIC_0_Write(0x0d, Data, ref RdStr);

            return true;
        }

        private bool XMPmic_2_DELAY(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Data = 0;
            byte[] XmPlusVal = StrToByte(XmPlusData);

            XmPlusUtil.PMIC_2_Read(0x0d, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)((Data & 0x3f) | (XmPlusVal[0] << 6));
            XmPlusUtil.PMIC_2_Write(0x0d, Data, ref RdStr);

            return true;
        }


        private bool XMPmic_0_RST(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Data = 0;

            XmPlusUtil.PMIC_0_Read(0x09, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)(Data | 0x80);
            XmPlusUtil.PMIC_0_Write(0x09, Data, ref RdStr);

            return true;
        }

        private bool XMPmic_2_RST(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Data = 0;

            XmPlusUtil.PMIC_2_Read(0x09, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)(Data | 0x80);
            XmPlusUtil.PMIC_2_Write(0x09, Data, ref RdStr);

            return true;

        }

        private bool XMPmic_0_VOL(string[] XmPlusData, ref string RdStr)
        {
            float[] XmPlusVal = StrToFloat(XmPlusData);
            string Reg = null;
            byte VolVSN = 0, VolVSP = 0, Data = 0;

            if ((XmPlusVal[0] < 4 || XmPlusVal[0] > 6) || (XmPlusVal[1] > -4 || XmPlusVal[1] < -6)) { RdStr += "Target Voltage Error"; return false; }

            //VSP
            XmPlusUtil.PMIC_0_Read(0x0e, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSP = (byte)((XmPlusVal[0] - 4) / 0.05);
            VolVSP = (byte)((Data & 0xc0) | VolVSP);
            XmPlusUtil.PMIC_0_Write(0x0e, VolVSP, ref RdStr);

            //VSN
            Reg = null;
            XmPlusUtil.PMIC_0_Read(0x0f, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSN = (byte)((Math.Abs(XmPlusVal[1]) - 4) / 0.05);
            VolVSN = (byte)((Data & 0xc0) | VolVSN);
            XmPlusUtil.PMIC_0_Write(0x0f, VolVSN, ref RdStr);

            return true;
        }

        private bool XMPmic_2_VOL(string[] XmPlusData, ref string RdStr)
        {
            float[] XmPlusVal = StrToFloat(XmPlusData);
            string Reg = null;
            byte VolVSN = 0, VolVSP = 0, Data = 0;

            if ((XmPlusVal[0] < 4 || XmPlusVal[0] > 6) || (XmPlusVal[1] > -4 || XmPlusVal[1] < -6)) { RdStr += "Target Voltage Error"; return false; }
            //VSP
            XmPlusUtil.PMIC_2_Read(0x0e, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSP = (byte)((XmPlusVal[0] - 4) / 0.05);
            VolVSP = (byte)((Data & 0xc0) | VolVSP);
            XmPlusUtil.PMIC_2_Write(0x0e, VolVSP, ref RdStr);
            //VSP
            Reg = null;
            XmPlusUtil.PMIC_2_Read(0x0f, ref Reg);
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSN = (byte)((Math.Abs(XmPlusVal[1]) - 4) / 0.05);
            VolVSN = (byte)((Data & 0xc0) | VolVSN);
            XmPlusUtil.PMIC_2_Write(0x0f, VolVSN, ref RdStr);

            return true;
        }

        private bool XMPmic_0_BL(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Val = 0;

            //Disable BackLight
            XmPlusUtil.PMIC_0_Read(0x0A, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            Val = (byte)(Val & 0xfe);
            XmPlusUtil.PMIC_0_Write(0x0A, Val, ref RdStr);

            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            if (XmPlusData[0].ToLower().CompareTo("dual") == 0)
                Val = (byte)((Val & 0xe6) | 0x18);
            else
                Val = (byte)((Val & 0xe6) | 0x10);
            XmPlusUtil.PMIC_0_Write(0x0a, Val, ref RdStr);

            return true;

        }

        private bool XMPmic_2_BL(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Val = 0;

            //Disable BackLight
            XmPlusUtil.PMIC_2_Read(0x0A, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            Val = (byte)(Val & 0xfe);
            XmPlusUtil.PMIC_2_Write(0x0A, Val, ref RdStr);

            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            if (XmPlusData[0].ToLower().CompareTo("dual") == 0)
                Val = (byte)((Val & 0xe6) | 0x18);
            else
                Val = (byte)((Val & 0xe6) | 0x10);
            XmPlusUtil.PMIC_2_Write(0x0a, Val, ref RdStr);

            return true;
        }

        private bool XMPmic_0_PWM(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Val = 0;
            byte[] XmPlusVal = StrToByte(XmPlusData);

            XmPlusUtil.PMIC_0_Read(0x09, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            Val = (byte)((Val & 0xbf) | (XmPlusVal[0] << 6));
            XmPlusUtil.PMIC_0_Write(0x09, Val, ref RdStr);

            return true;
        }

        private bool XMPmic_2_PWM(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Val = 0;
            byte[] XmPlusVal = StrToByte(XmPlusData);

            XmPlusUtil.PMIC_2_Read(0x09, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            Val = (byte)((Val & 0xbf) | (XmPlusVal[0] << 6));
            XmPlusUtil.PMIC_2_Write(0x09, Val, ref RdStr);

            return true;
        }

        private bool XMPmic_0_EnLcd(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Val = 0;
            byte[] XmPlusVal = StrToByte(XmPlusData);

            //BLED OVP
            XmPlusUtil.PMIC_0_Write(0x02, 0x50, ref RdStr);
            //VSN, VSP Enable
            Reg = null;

            XmPlusUtil.PMIC_0_Read(0x0C, ref Reg);

            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            Val = (byte)((Val & 0xB7) | ((XmPlusVal[0] << 6) + (XmPlusVal[0] << 3)));
            XmPlusUtil.PMIC_0_Write(0x0C, Val, ref RdStr);
            return true;
        }

        private bool XMPmic_2_EnLcd(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Val = 0;
            byte[] XmPlusVal = StrToByte(XmPlusData);

            XmPlusUtil.PMIC_2_Read(0x02, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            XmPlusUtil.PMIC_2_Write(0x02, Val, ref RdStr);

            //VSN, VSP Enable
            Reg = null;
            XmPlusUtil.PMIC_2_Read(0x0C, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            Val = (byte)((Val & 0xB7) | ((XmPlusVal[0] << 6) + (XmPlusVal[0] << 3)));
            XmPlusUtil.PMIC_2_Write(0x0C, Val, ref RdStr);
            return true;
        }

        private bool XMPmic_0_EnLed(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Val = 0;
            byte[] XmPlusVal = StrToByte(XmPlusData);


            XmPlusUtil.PMIC_0_Read(0x02, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            //XmPlusUtil.PMIC_0_Write(0x02, Val, ref RdStr);

            //BackLight Enable
            Reg = null;
            XmPlusUtil.PMIC_0_Read(0x0A, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            Val = (byte)((Val & 0xfe) | XmPlusVal[0]);
            XmPlusUtil.PMIC_0_Write(0x0A, Val, ref RdStr);
            return true;
        }

        private bool XMPmic_2_EnLed(string[] XmPlusData, ref string RdStr)
        {
            string Reg = null;
            byte Val = 0;
            byte[] XmPlusVal = StrToByte(XmPlusData);

            XmPlusUtil.PMIC_2_Read(0x02, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            XmPlusUtil.PMIC_2_Write(0x02, Val, ref RdStr);

            //BackLight Enable
            Reg = null;
            XmPlusUtil.PMIC_2_Read(0x0A, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Val)) return false;
            Val = (byte)((Val & 0xfe) | XmPlusVal[0]);
            XmPlusUtil.PMIC_2_Write(0x0A, Val, ref RdStr);
            return true;
        }

        private bool XmRstSet(string[] XmPlusData, ref string RdStr)
        {
            byte[] Value = new byte[2] { 0, 0 };
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte Reg = 0;
            Array.Copy(XmPlusVal, 0, Value, 1, 1);

            XmPlusUtil.FpgaWrite(0x9f, Value);
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x9e, ref Reg);
            Reg = (byte)((Reg & 0x80) | (XmPlusVal[1] << 4));
            return XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, Reg);
        }

        private bool XmRstReset(string[] XmPlusData, ref string RdStr)
        {
            byte Value = 0;
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x9e, ref Value);
            Value = (byte)((Value & 0x10) | 0x81);
            return XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, Value);
        }

        private bool XmRstTrigger(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte Value = 0;
            XmPlusUtil.FpgaWrite(0x9f, XmPlusVal);
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x9e, ref Value);
            Value = (byte)((Value & 0xf0) | 0x01);
            return XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, Value);
        }

        private bool XmRstEn(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte Value = 0;
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x9e, ref Value);
            XmPlusVal[0] = (byte)((Value & 0x7f) | ((XmPlusVal[0] & 0x01) << 7));
            return XmPlusUtil.FpgaWrite(0x9e, XmPlusVal);
        }


        private bool XmRstPolarity(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte Value = 0;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9f, 0x00, 0x00);
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x9e, ref Value);
            XmPlusVal[0] = (byte)((Value & 0xef) | ((XmPlusVal[0] & 0x01) << 4));
            return XmPlusUtil.FpgaWrite(0x9e, XmPlusVal);
        }

        private bool XM_DDR_Img(string[] XmPlusData, ref string RdStr)
        {
            return XmPlusUtil.ReadFromDDRToImage(XmPlusData[0], XmPlusData[1]);
        }

        private bool XmGpioHSet(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.FpgaWrite(0xfb, XmPlusVal);
        }

        private bool XmGpioLSet(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.FpgaWrite(0xfc, XmPlusVal);
        }

        private bool XmGpioDir(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.FpgaWrite(0xfa, XmPlusVal);
        }

        private bool XmGpioWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, XmPlusVal[0]);
            return XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, XmPlusVal[1]);
        }

        private bool XmGpioSet(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(XmPlusVal[0], XmPlusVal[1]);
        }

        private bool XmGpioRd(string[] XmPlusData, ref string RdStr)
        {
            byte hbyte = 0, lbyte = 0;
            int Value = hbyte;
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xfb, ref hbyte);
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xfc, ref lbyte);
            Value = hbyte << 8 + lbyte;
            RdStr = "0x" + Convert.ToString(Value, 16);
            return true;
        }

        private bool XmGpioClr(string[] XmPlusData, ref string RdStr)
        {
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, 0x00);
            return XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x00);
        }

        private bool XmFpgaID(string[] XmPlusData, ref string RdStr)
        {
            uint Val = 0;
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x00, ref Val, 1);
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x00, ref Val, 1);
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x00, ref Val, 1);
            RdStr = "0x" + Convert.ToString(Val, 16);
            return true;
        }

        private bool XmFpgaVer(string[] XmPlusData, ref string RdStr)
        {
            byte Val = 0;
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x01, ref Val);
            RdStr = "0x" + Convert.ToString(Val, 16);
            return true;
        }

        private bool XmFpgaDelay(string[] XmPlusData, ref string RdStr)
        {
            int[] XmPlusVal = StrToInt(XmPlusData);
            XM_Comm_Control.XM_Comm_Base.CommDelay(XmPlusVal[0]);
            return true;
        }

        private bool XmFpgaSleep(string[] XmPlusData, ref string RdStr)
        {
            int[] XmPlusVal = StrToInt(XmPlusData);
            Thread.Sleep(XmPlusVal[0]);
            return true;
        }
        private bool XmBridgeSelect(string[] XmPlusData, ref string RdStr)
        {
            return true;
        }
        private bool XmFpgaRead(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.FpgaRead(XmPlusVal[0], XmPlusVal[1], ref RdStr);
        }

        private bool XmFpgaWrite(string[] XmPlusData, ref string RdStr)
        {
            if (XmPlusData.Length > 5) { RdStr = "Much Parameter\n"; return false; }
            byte[] XmPlusVal = StrToByte(XmPlusData);
            byte[] RegData = new byte[XmPlusVal.Length - 1];
            Array.Copy(XmPlusVal, 1, RegData, 0, RegData.Length);
            return XmPlusUtil.FpgaWrite(XmPlusVal[0], RegData);
        }

        private bool XmFpgaCmdWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.UsbCmdWrite(XmPlusVal);
        }

        private bool XmFpgaCmdWriteGpio(string[] XmPlusData, ref string RdStr)
        {
            List<string> StringList = new List<string>();
            int Repeat = 0;
            for (int i = 0; i < XmPlusData.Length; i++)
            {
                if (XmPlusData[i].ToString().StartsWith(":"))
                {
                    string[] Parameter = XmPlusData[i].ToString().Split(DelimiterChars);

                    if (Parameter[1].Length >= 2)
                    {
                        if (Parameter[1].Substring(0, 2).ToLower().CompareTo("0x") == 0)
                            Repeat = Convert.ToInt32(Parameter[1], 16);
                        else
                            Repeat = Convert.ToInt32(Parameter[1], 10);
                    }

                    for (int j = 0; j < Repeat; j++)
                    {
                        // StringList.Add(XmPlusData[i - 2]);
                        StringList.Add(XmPlusData[i - 1]);
                    }
                }
                else { StringList.Add(XmPlusData[i]); }
            }
            string[] test = StringList.ToArray();
            byte[] XmPlusVal = StrToByte(test);
            return XmPlusUtil.UsbCmdWriteGpio(XmPlusVal);
        }
        private bool XmImageWrite(string[] XmPlusData, ref string RdStr)
        {
            if (XmPlusData.Length == 1)
                return XmPlusUtil.ImageWrite(null, XmPlusData[0], ref RdStr);
            else
                return XmPlusUtil.ImageWrite(XmPlusData[0], XmPlusData[1], ref RdStr);

        }
        private bool XmImageShow(string[] XmPlusData, ref string RdStr)
        {
            if (XmPlusData.Length == 1)
                return XmPlusUtil.ImageShow(null, XmPlusData[0], ref RdStr);
            else
                return XmPlusUtil.ImageShow(XmPlusData[0], XmPlusData[1], ref RdStr);
        }

        private bool XmMipiBta(string[] XmPlusData, ref string RdStr)
        {
            return XmPlusUtil.MipiBta();
        }

        private bool XmMipiUlp(string[] XmPlusData, ref string RdStr)
        {
            return XmPlusUtil.MipiUlp();
        }

        private bool XmMipiRead(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            bool ret = XmPlusUtil.MipiRead(XmPlusVal[0], XmPlusVal[1], ref RdStr);
            return ret;
        }

        private bool XmHighMipiRead(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            bool ret = XmPlusUtil.MipiHSRead(XmPlusVal[0], XmPlusVal[1], ref RdStr);
            return ret;
        }

        private bool XmImageFill(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            XmPlusUtil.ImageFill(XmPlusVal[0], XmPlusVal[1], XmPlusVal[2]);
            string rgbStr = string.Format("RGB {0} {1} {2} ", XmPlusVal[0], XmPlusVal[1], XmPlusVal[2]);
            if (XmPlusVal.Length > 3) SaveMsgToFile(XmPlusData[3], rgbStr);
            return true;
        }

        private bool XmPMIC_0_WR(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.PMIC_0_Write(XmPlusVal[0], XmPlusVal[1], ref RdStr);
        }

        private bool XmPMIC_2_WR(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.PMIC_2_Write(XmPlusVal[0], XmPlusVal[1], ref RdStr);
        }

        private bool XmPMIC_0_RD(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.PMIC_0_Read(XmPlusVal[0], ref RdStr);
        }

        private bool XmPMIC_2_RD(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.PMIC_0_Read(XmPlusVal[0], ref RdStr);
        }


        private bool XmMipiWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.MipiWrite(XmPlusVal);
        }

        private bool XmHighMipiWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.MipiHSWrite(XmPlusVal);
        }

        //private bool XmBridgeSelect(string[] XmPlusData, ref string RdStr)
        //{
        //    byte[] XmPlusVal = StrToByte(XmPlusData);
        //    XmPlusUtil.MipiBridgeSelect(XmPlusVal[0]);
        //    return true;
        //}

        private bool XmBrigeRead(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.BridgeRead(XmPlusVal[0], XmPlusVal[1], ref RdStr);
        }

        private bool XmBrigeWrite(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            if (XmPlusVal.Length == 2)
                return XmPlusUtil.BridgeWrite(XmPlusVal[0], XmPlusVal[1]);
            else
                return XmPlusUtil.BridgeWrite(XmPlusVal[0], XmPlusVal[1], XmPlusVal[2]);
        }

        private bool XmFpgaParm(string[] XmPlusData, ref string RdStr)
        {
            byte[] XmPlusVal = StrToByte(XmPlusData);
            return XmPlusUtil.SetFpgaTiming(XmPlusVal[0], XmPlusVal[1], XmPlusVal[2], XmPlusVal[3], XmPlusVal[4], XmPlusVal[5], ref RdStr);
        }

        private bool SetMipiDsi(string[] XmPlusData)
        {
            int MipiLane = 4, MipiSpeed = 1000;
            if (int.TryParse(XmPlusData[0], out int Value)) MipiLane = Value;
            if (int.TryParse(XmPlusData[1], out Value)) MipiSpeed = Value;
            return XmPlusUtil.SetMipiDsi(MipiLane, MipiSpeed, XmPlusData[2]);

        }

        private bool SetMipiVideo(string[] XmPlusData)
        {
            int[] XmPlusVal = StrToInt(XmPlusData);
            return XmPlusUtil.SetMipiVideo(XmPlusVal[0], XmPlusVal[1], (byte)XmPlusVal[2], (byte)XmPlusVal[3], (byte)XmPlusVal[4], (byte)XmPlusVal[5], (byte)XmPlusVal[6], (byte)XmPlusVal[7], (byte)XmPlusVal[8]);
        }

        private float[] StrToFloat(string[] WiskeyData)
        {
            float Value = 0;
            float[] XmPlusVal = new float[WiskeyData.Length];
            for (int i = 0; i < XmPlusVal.Length; i++)
            {
                if (new XM_Digital_Util().StrToNumber<float>(WiskeyData[i], ref Value))
                    XmPlusVal[i] = Value;
                else
                    XmPlusVal[i] = 0;
            }
            return XmPlusVal;
        }


        private byte[] StrToByte(string[] WiskeyData)
        {
            byte Value = 0;
            int Val = 0;
            byte[] XmPlusVal = new byte[WiskeyData.Length];
            XM_Digital_Util DigtalUtil = new XM_Digital_Util();
            for (int i = 0; i < XmPlusVal.Length; i++)
            {
                if (DigtalUtil.StrToNumber<byte>(WiskeyData[i], ref Value))
                    XmPlusVal[i] = Value;
                else
                {
                    if (DigtalUtil.StrToNumber<int>(WiskeyData[i], ref Val))
                        Value = (byte)(Val & 0xff);
                    else
                        Value = 0;
                    XmPlusVal[i] = Value;
                }
            }
            return XmPlusVal;
        }


        private int[] StrToInt(string[] WiskeyData)
        {
            int Value = 0;
            int[] XmPlusVal = new int[WiskeyData.Length];
            for (int i = 0; i < XmPlusVal.Length; i++)
            {
                if (new XM_Digital_Util().StrToNumber<int>(WiskeyData[i], ref Value))
                    XmPlusVal[i] = Value;
                else
                    XmPlusVal[i] = 0;
            }
            return XmPlusVal;
        }
    }
}
