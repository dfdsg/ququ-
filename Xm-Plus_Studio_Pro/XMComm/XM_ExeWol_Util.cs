#define DEBUG 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.IO;
using XM_Tek_Studio_Pro.StudioUtil;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace XM_Tek_Studio_Pro
{
    public class XM_ExeWol_Util
    {
        private byte VSA = 0, HSA = 0, VBP = 0;
        private byte HBP = 0, VFP = 0, HFP = 0;
        private byte HD_H = 0, HD_L = 0, VD_H = 0;
        private byte VD_L = 0, DEVADDRMODE = 2, I2CADDR = 0;
        private const byte POWERCTRL_ADDR = 0x7c;
        private const double FPGA_OSC = 60.0;
        private byte WolIfCtrl = 0, WolBankEn = 0;
        public static byte modeselect;
        private static int Hsize = 0, Wsize = 0;
        XM_Comm_Mipi Mipi = new XM_Comm_Mipi();
        XM_Cpu_Util Cpu = new XM_Cpu_Util();
        XM_Spi_Util Spi = new XM_Spi_Util();
        XM_I2C_Util I2C = new XM_I2C_Util();
        XMBaseIfCtrl BaseIfCtrl = null;
        ISetI2CCtrl II2CIfCtrl = null;

        public void SetDevAddrMode(byte Mode) { DEVADDRMODE = Mode; }
        public void SetI2CAddress(byte I2CAddress)
        {
            I2CADDR = I2CAddress;
            if (BaseIfCtrl is ISetI2CCtrl)
            {
                II2CIfCtrl = BaseIfCtrl as ISetI2CCtrl;
                II2CIfCtrl.SetI2CSlaveAddr(I2CADDR);
            }
        }
        //public bool MipiBridgeSelect(byte SelVal)
        //{
        //    Mipi.MipiBridgeSelect(SelVal);
        //    return true;
        //}

        public bool MipiWrite(byte type, byte data)
        {
            byte[] MipiData = new byte[2];
            MipiData[0] = type;
            MipiData[1] = data;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1)
        {
            byte[] MipiData = new byte[3];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2)
        {
            byte[] MipiData = new byte[4];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3)
        {
            byte[] MipiData = new byte[5];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4)
        {
            byte[] MipiData = new byte[6];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5)
        {
            byte[] MipiData = new byte[7];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6)
        {
            byte[] MipiData = new byte[8];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7)
        {
            byte[] MipiData = new byte[9];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            return Mipi.MipiWrite(MipiData);
        }


        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8)
        {
            byte[] MipiData = new byte[10];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9)
        {
            byte[] MipiData = new byte[11];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10)
        {
            byte[] MipiData = new byte[12];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11)
        {
            byte[] MipiData = new byte[13];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            return Mipi.MipiWrite(MipiData);
        }


        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12)
        {
            byte[] MipiData = new byte[14];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13)
        {
            byte[] MipiData = new byte[15];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13, byte data14)
        {
            byte[] MipiData = new byte[16];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            MipiData[15] = data14;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13, byte data14, byte data15)
        {
            byte[] MipiData = new byte[17];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            MipiData[15] = data14;
            MipiData[16] = data15;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13, byte data14, byte data15, byte data16)
        {
            byte[] MipiData = new byte[18];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            MipiData[15] = data14;
            MipiData[16] = data15;
            MipiData[17] = data16;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13, byte data14, byte data15, byte data16, byte data17)
        {
            byte[] MipiData = new byte[19];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            MipiData[15] = data14;
            MipiData[16] = data15;
            MipiData[17] = data16;
            MipiData[18] = data17;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13, byte data14, byte data15, byte data16, byte data17, byte data18)
        {
            byte[] MipiData = new byte[20];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            MipiData[15] = data14;
            MipiData[16] = data15;
            MipiData[17] = data16;
            MipiData[18] = data17;
            MipiData[19] = data18;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13, byte data14, byte data15, byte data16, byte data17, byte data18, byte data19)
        {
            byte[] MipiData = new byte[21];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            MipiData[15] = data14;
            MipiData[16] = data15;
            MipiData[17] = data16;
            MipiData[18] = data17;
            MipiData[19] = data18;
            MipiData[20] = data19;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13, byte data14, byte data15, byte data16, byte data17, byte data18, byte data19, byte data20)
        {
            byte[] MipiData = new byte[22];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            MipiData[15] = data14;
            MipiData[16] = data15;
            MipiData[17] = data16;
            MipiData[18] = data17;
            MipiData[19] = data18;
            MipiData[20] = data19;
            MipiData[21] = data20;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13, byte data14, byte data15, byte data16, byte data17, byte data18, byte data19, byte data20, byte data21)
        {
            byte[] MipiData = new byte[23];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            MipiData[15] = data14;
            MipiData[16] = data15;
            MipiData[17] = data16;
            MipiData[18] = data17;
            MipiData[19] = data18;
            MipiData[20] = data19;
            MipiData[21] = data20;
            MipiData[22] = data21;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13, byte data14, byte data15, byte data16, byte data17, byte data18, byte data19, byte data20, byte data21, byte data22)
        {
            byte[] MipiData = new byte[24];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            MipiData[15] = data14;
            MipiData[16] = data15;
            MipiData[17] = data16;
            MipiData[18] = data17;
            MipiData[19] = data18;
            MipiData[20] = data19;
            MipiData[21] = data20;
            MipiData[22] = data21;
            MipiData[23] = data22;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13, byte data14, byte data15, byte data16, byte data17, byte data18, byte data19, byte data20, byte data21, byte data22, byte data23)
        {
            byte[] MipiData = new byte[25];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            MipiData[15] = data14;
            MipiData[16] = data15;
            MipiData[17] = data16;
            MipiData[18] = data17;
            MipiData[19] = data18;
            MipiData[20] = data19;
            MipiData[21] = data20;
            MipiData[22] = data21;
            MipiData[23] = data22;
            MipiData[24] = data23;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte type, byte data, byte data1, byte data2, byte data3, byte data4, byte data5, byte data6, byte data7, byte data8, byte data9, byte data10, byte data11, byte data12, byte data13, byte data14, byte data15, byte data16, byte data17, byte data18, byte data19, byte data20, byte data21, byte data22, byte data23, byte data24)
        {
            byte[] MipiData = new byte[26];
            MipiData[0] = type;
            MipiData[1] = data;
            MipiData[2] = data1;
            MipiData[3] = data2;
            MipiData[4] = data3;
            MipiData[5] = data4;
            MipiData[6] = data5;
            MipiData[7] = data6;
            MipiData[8] = data7;
            MipiData[9] = data8;
            MipiData[10] = data9;
            MipiData[11] = data10;
            MipiData[12] = data11;
            MipiData[13] = data12;
            MipiData[14] = data13;
            MipiData[15] = data14;
            MipiData[16] = data15;
            MipiData[17] = data16;
            MipiData[18] = data17;
            MipiData[19] = data18;
            MipiData[20] = data19;
            MipiData[21] = data20;
            MipiData[22] = data21;
            MipiData[23] = data22;
            MipiData[24] = data23;
            MipiData[25] = data24;
            return Mipi.MipiWrite(MipiData);
        }

        public bool MipiWrite(byte[] Mipidata)
        {
            return Mipi.MipiWrite(Mipidata);
        }

        public bool MipiHSWrite(byte[] Mipidata)
        {
            return Mipi.MipiHSWrite(Mipidata);
        }

        public bool MipiRead(byte Addr, byte RdNum, ref byte[] RdVal)
        {
            byte RdNumH = 0, RdNumeL = 0, C2_1 = 0, C2_2 = 0, C6_1 = 0, C6_2 = 0, Ready = 0, BTAR = 0, LPTO = 0, DST = 0, CST = 0;
            int i = 0, k = 0, l = 0, j = 2;
            uint Value = 0;
            bool ret = true;

            if (RdVal.Length != RdNum) return false;
            XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb8, 0x00, 0x00);
            XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb7, 0x02, 0x80);
            XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xbd, 0x00, 0x00);
            XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xbc, 0x00, 0x01);
            XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xd1, 0xff, 0xff); // Rx TimeOut

            RdNumH = (byte)(RdNum >> 8);
            RdNumeL = (byte)(RdNum & 0xff);

            XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xc1, RdNumH, RdNumeL);

            XM_Comm_Control.XM_Comm_Base.Bridge_AddrWr(0xbf);
            XM_Comm_Control.XM_Comm_Base.Bridge_DataWr(Addr);
            Thread.Sleep(20);

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb3, 0x10);
            XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc2);
            Thread.Sleep(1);
            XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xfa);
            XM_Comm_Control.XM_Comm_Base.AddrWr(XM_Comm_Control.XM_Comm_Base.DATARDMODE_2828);
            C2_1 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            C2_2 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            XM_Comm_Control.XM_Comm_Base.UnBgeSel();
            Thread.Sleep(20);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb3, 0x10);
            XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc6);
            Thread.Sleep(1);
            XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xfa);
            XM_Comm_Control.XM_Comm_Base.AddrWr(XM_Comm_Control.XM_Comm_Base.DATARDMODE_2828);
            C6_1 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            C6_2 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            XM_Comm_Control.XM_Comm_Base.UnBgeSel();
            Thread.Sleep(10);
            CST = (byte)((C6_2 & 0x8) >> 3);
            DST = (byte)((C6_2 & 0x4) >> 2);
            LPTO = (byte)((C6_1 & 0x40) >> 6);
            BTAR = (byte)((C6_1 & 0x04) >> 2);
            Ready = (byte)(C6_1 & 0x01);

            if (LPTO == 1) XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xc0, 0x00, 0x01);

            if (Ready == 1)
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb3, 0x10);

                i = ((C2_2 * 256) + C2_1);

                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xff);

                l = 16 * (1 + i / 16);

                for (k = 0; k < l; k++)
                {
                    if (j == 2)
                    {
                        XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xFA);
                        XM_Comm_Control.XM_Comm_Base.AddrWr(XM_Comm_Control.XM_Comm_Base.DATARDMODE_2828);
                        j = 0;
                    }
                    Value = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                    if (k < i)
                    {
                        RdVal[k] = (byte)Value;
                    }
                    j++;
                }

                XM_Comm_Control.XM_Comm_Base.UnBgeSel();
                ret = true;
            }
            else
                ret = false;
            return ret;
        }
        public int Cnt = 0;
        public static List<byte> dataread = new List<byte>();
        public bool MipiRead(byte Addr, byte RdNum, ref string RdStr)
        {
            byte RdNumH = 0, RdNumeL = 0, C2_1 = 0, C2_2 = 0, C6_1 = 0, C6_2 = 0, Ready = 0, BTAR = 0, LPTO = 0, DST = 0, CST = 0;
            int i = 0, k = 0, l = 0, j = 2;
            uint Value = 0;
            bool ret = true;
            RdStr = null;
            RdNumeL = (byte)(RdNum & 0xff);
            RdNumH = (byte)(RdNum >> 8);
            if (modeselect == 0x03)
            {
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb8, 0x00, 0x00);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb7, 0x02, 0x80);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xbd, 0x00, 0x00);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xbc, 0x00, 0x01);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xd1, 0xff, 0xff); // Rx TimeOut
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xc1, RdNumH, RdNumeL);

                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWr(0xbf);
                XM_Comm_Control.XM_Comm_Base.Bridge_DataWr(Addr);
                Thread.Sleep(20);

                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb3, 0x10);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc2);
                Thread.Sleep(1);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xfa);
                XM_Comm_Control.XM_Comm_Base.AddrWr(XM_Comm_Control.XM_Comm_Base.DATARDMODE_2828);
                C2_1 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                C2_2 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                XM_Comm_Control.XM_Comm_Base.UnBgeSel();

                Thread.Sleep(20);

                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb3, 0x10);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc6);
                Thread.Sleep(1);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xfa);
                XM_Comm_Control.XM_Comm_Base.AddrWr(XM_Comm_Control.XM_Comm_Base.DATARDMODE_2828);
                C6_1 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                C6_2 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                XM_Comm_Control.XM_Comm_Base.UnBgeSel();

                Thread.Sleep(10);

                CST = (byte)((C6_2 & 0x8) >> 3);
                DST = (byte)((C6_2 & 0x4) >> 2);
                LPTO = (byte)((C6_1 & 0x40) >> 6);
                BTAR = (byte)((C6_1 & 0x04) >> 2);
                Ready = (byte)(C6_1 & 0x01);

                if (LPTO == 1) { XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xc0, 0x00, 0x01); Thread.Sleep(50); }
                if (Ready == 1)
                {
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb3, 0x10);
                    i = ((C2_2 * 256) + C2_1);
                    XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xff);
                    l = 16 * (1 + i / 16);

                    for (k = 0; k < l; k++)
                    {
                        if (j == 2)
                        {
                            XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xFA);
                            XM_Comm_Control.XM_Comm_Base.AddrWr(XM_Comm_Control.XM_Comm_Base.DATARDMODE_2828);
                            j = 0;
                        }

                        Value = XM_Comm_Control.XM_Comm_Base.DataDummyRd();

                        if (k < i)
                        {
                            RdStr += "Rd[" + k + "]= 0x" + Convert.ToString(Value, 16) + " ";
                        }
                        j++;
                    }
                    XM_Comm_Control.XM_Comm_Base.UnBgeSel();
                    ret = true;
                }
                else
                {
                    ret = false;
                    RdStr = "Mipi Read Not Ready";
                }
                return ret;
            }
            else
            {               
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb7, 0x00, 0x02, 0x80);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbc, 0x00, 0x00, 0x01);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbd, 0x00, 0x00, 0x00);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xd1, 0x00, 0xff, 0xff);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xc1, 0x00, RdNumH, RdNumeL);
                Thread.Sleep(20);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xbf);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, 0x00, 0x00, Addr);

                Thread.Sleep(1);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc2);
                Thread.Sleep(1);
                XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                C2_1 = XM_Comm_Control.XM_Comm_Base.DataRd();
                C2_2 = XM_Comm_Control.XM_Comm_Base.DataRd();
                Thread.Sleep(20);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc6);
                Thread.Sleep(1);
                XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                C6_1 = XM_Comm_Control.XM_Comm_Base.DataRd();   //高位
                C6_2 = XM_Comm_Control.XM_Comm_Base.DataRd(); //低位
                Thread.Sleep(10);
                CST = (byte)((C6_1 & 0x8) >> 3);
                DST = (byte)((C6_1 & 0x4) >> 2);
                LPTO = (byte)((C6_2 & 0x40) >> 6);
                BTAR = (byte)((C6_2 & 0x04) >> 2);
                Ready = (byte)(C6_2 & 0x01);
                int RdCount = Convert.ToInt32(C2_1 << 8) + Convert.ToInt32(C2_2);

                if (LPTO == 1) { XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xc0, 0x00, 0x00, 0x01); Thread.Sleep(50); }
                if (Ready == 1)
                {
                    XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xff);

                    switch (RdCount % 3)
                    {
                        case 0:
                            {
                                   for (i = 0; i < RdCount; i += 3)
                                    {
                                        XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                                        XM_Comm_Control.XM_Comm_Base.DataRd();
                                        Value = (XM_Comm_Control.XM_Comm_Base.DataRd() + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 8) + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 16));
                                        RdStr += " 0x" + Value.ToString("x6");
                                    }
                               
                                
                            }
                            break;
                        case 1:
                            {
                                for (i = 0; i < RdCount - 1; i += 3)
                                {
                                    XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                                    XM_Comm_Control.XM_Comm_Base.DataRd();
                                    Value = (XM_Comm_Control.XM_Comm_Base.DataRd() + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 8) + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 16));
                                    RdStr += " 0x" + Value.ToString("x6");
                                }
                                XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                                XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                                RdStr += " 0x" + XM_Comm_Control.XM_Comm_Base.DataDummyRd().ToString("x2");
                            }
                            break;
                        case 2:
                            {
                                for (i = 0; i < RdCount - 2; i += 3)
                                {
                                    XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                                    XM_Comm_Control.XM_Comm_Base.DataRd();
                                    Value = (XM_Comm_Control.XM_Comm_Base.DataRd() + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 8) + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 16));
                                    RdStr += " 0x" + Value.ToString("x6");
                                }
                                XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                                XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                                Value = XM_Comm_Control.XM_Comm_Base.DataRd() + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 8);
                                RdStr += " 0x" + Value.ToString("x4");
                            }
                            break;
                    }
                }
                else
                {
                    ret = false;
                    RdStr = "Mipi Read Not Ready";
                }
            }
            return ret;
        }
        public bool MipiHSRead(byte Addr, byte RdNum, ref string RdStr)
        {
            byte RdNumH = 0, RdNumeL = 0, C2_1 = 0, C2_2 = 0, C6_1 = 0, C6_2 = 0, Ready = 0, BTAR = 0, LPTO = 0, DST = 0, CST = 0;
            int i = 0, k = 0, l = 0, j = 2;
            uint Value = 0;
            bool ret = true;
            RdStr = null;

            RdNumH = (byte)(RdNum >> 8);
            RdNumeL = (byte)(RdNum & 0xff);

            if (modeselect == 0x03)
            {
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb8, 0x00, 0x00);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb7, 0x02, 0x89);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xbd, 0x00, 0x00);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xbc, 0x00, 0x01);

                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xc1, RdNumH, RdNumeL);

                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWr(0xbf);
                XM_Comm_Control.XM_Comm_Base.Bridge_DataWr(Addr);
                Thread.Sleep(20);

                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb3, 0x10);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc2);
                Thread.Sleep(1);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xfa);
                XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                C2_1 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                C2_2 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                XM_Comm_Control.XM_Comm_Base.UnBgeSel();

                Thread.Sleep(20);

                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb3, 0x10);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc6);
                Thread.Sleep(1);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xfa);
                XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                C6_1 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                C6_2 = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                XM_Comm_Control.XM_Comm_Base.UnBgeSel();

                Thread.Sleep(20);

                CST = (byte)((C6_2 & 0x8) >> 3);
                DST = (byte)((C6_2 & 0x4) >> 2);
                LPTO = (byte)((C6_1 & 0x40) >> 6);
                BTAR = (byte)((C6_1 & 0x04) >> 2);
                Ready = (byte)(C6_1 & 0x01);

                if (LPTO == 1) { XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xc0, 0x00, 0x01); Thread.Sleep(50); }

                Thread.Sleep(10);

                if (Ready == 1)
                {
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb3, 0x10);

                    i = ((C2_2 * 256) + C2_1);

                    XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xff);

                    l = 16 * (1 + i / 16);

                    for (k = 0; k < l; k++)
                    {
                        if (j == 2)
                        {
                            XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xFA);
                            XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                            j = 0;
                        }

                        Value = XM_Comm_Control.XM_Comm_Base.DataDummyRd();

                        if (k < i)
                        {
                            RdStr += "Rd[" + k + "]= 0x" + Convert.ToString(Value, 16) + " ";
                        }
                        j++;
                    }

                    XM_Comm_Control.XM_Comm_Base.UnBgeSel();
                    ret = true;
                }
                else
                {
                    ret = false;
                    RdStr = "Mipi Read Not Ready";
                }
                return ret;
            }
            else
            {
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb7, 0x00, 0x02, 0x59);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbc, 0x00, 0x00, 0x01);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbd, 0x00, 0x00, 0x00);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xd1, 0x00, 0xff, 0xff);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xc1, 0x00, RdNumH, RdNumeL);
                Thread.Sleep(20);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xbf);
                XM_Comm_Control.XM_Comm_Base.Bridge_DataWrNoCs(Addr);
                Thread.Sleep(1);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc2);
                Thread.Sleep(1);
                XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                C2_1 = XM_Comm_Control.XM_Comm_Base.DataRd();
                C2_2 = XM_Comm_Control.XM_Comm_Base.DataRd();
                Thread.Sleep(20);
                XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc6);
                Thread.Sleep(1);
                XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                C6_1 = XM_Comm_Control.XM_Comm_Base.DataRd();   //高位
                C6_2 = XM_Comm_Control.XM_Comm_Base.DataRd(); //低位
                Thread.Sleep(10);
                CST = (byte)((C6_1 & 0x8) >> 3);
                DST = (byte)((C6_1 & 0x4) >> 2);
                LPTO = (byte)((C6_2 & 0x40) >> 6);
                BTAR = (byte)((C6_2 & 0x04) >> 2);
                Ready = (byte)(C6_2 & 0x01);
                if (LPTO == 1) { XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xc0, 0x00, 0x00, 0x01); Thread.Sleep(50); }
                if (Ready == 1)
                {
                    XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xff);

                    switch (RdNum % 3)
                    {
                        case 0:
                            {
                                for (i = 0; i < RdNum; i += 3)
                                {
                                    XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                                    XM_Comm_Control.XM_Comm_Base.DataRd();
                                    Value = (XM_Comm_Control.XM_Comm_Base.DataRd() + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 8) + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 16));
                                    RdStr += " 0x" + Value.ToString("x6");
                                }

                            }
                            break;
                        case 1:
                            {
                                for (i = 0; i < RdNum - 1; i += 3)
                                {
                                    XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                                    XM_Comm_Control.XM_Comm_Base.DataRd();
                                    Value = (XM_Comm_Control.XM_Comm_Base.DataRd() + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 8) + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 16));
                                    RdStr += " 0x" + Value.ToString("x6");
                                }
                                XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                                XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                                RdStr += " 0x" + XM_Comm_Control.XM_Comm_Base.DataDummyRd().ToString("x2");

                            }
                            break;
                        case 2:
                            {
                                for (i = 0; i < RdNum - 2; i += 3)
                                {
                                    XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                                    XM_Comm_Control.XM_Comm_Base.DataRd();
                                    Value = (XM_Comm_Control.XM_Comm_Base.DataRd() + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 8) + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 16));
                                    RdStr += " 0x" + Value.ToString("x6");
                                }
                                XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                                XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                                Value = XM_Comm_Control.XM_Comm_Base.DataRd() + ((uint)XM_Comm_Control.XM_Comm_Base.DataRd() << 8);
                                RdStr += " 0x" + Value.ToString("x4");

                            }
                            break;
                    }
                }
                else
                {
                    ret = false;
                    RdStr = "Mipi Read Not Ready";
                }
                return ret;
            }
        }

        public bool ramRead(int NumX, int NumY, ref string RdStr)
        {
            byte RdNumH = 0, RdNumeL = 0, C2_1 = 0, C2_2 = 0, C6_1 = 0, C6_2 = 0, Ready = 0, BTAR = 0, LPTO = 0, DST = 0, CST = 0;
            bool ret = true;
            int RdCount = 0;
            int a = NumX * 3;
            RdNumH = (byte)(a >> 8);
            RdNumeL = (byte)(a & 0xff);

            for (int i = 0; i < NumY; i++)
            {
                if (i == 0)
                {
                    XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb7, 0x00, 0x02, 0x80);
                    XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbc, 0x00, 0x00, 0x01);
                    XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbd, 0x00, 0x00, 0x00);
                    XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xd1, 0x00, 0xff, 0xff);
                    XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xc1, 0x00, RdNumH, RdNumeL);
                    Thread.Sleep(20);
                    XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xbf);
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, 0x00, 0x00, 0x2e);

                    Thread.Sleep(1);
                    XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc2);
                    Thread.Sleep(1);
                    XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                    XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                    C2_1 = XM_Comm_Control.XM_Comm_Base.DataRd();
                    C2_2 = XM_Comm_Control.XM_Comm_Base.DataRd();
                    Thread.Sleep(20);
                    XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc6);
                    Thread.Sleep(1);
                    XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                    XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                    C6_1 = XM_Comm_Control.XM_Comm_Base.DataRd();   //高位
                    C6_2 = XM_Comm_Control.XM_Comm_Base.DataRd(); //低位
                    Thread.Sleep(10);
                    CST = (byte)((C6_1 & 0x8) >> 3);
                    DST = (byte)((C6_1 & 0x4) >> 2);
                    LPTO = (byte)((C6_2 & 0x40) >> 6);
                    BTAR = (byte)((C6_2 & 0x04) >> 2);
                    Ready = (byte)(C6_2 & 0x01);
                    RdCount = Convert.ToInt32(C2_1 << 8) + Convert.ToInt32(C2_2);

                    if (LPTO == 1) { XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xc0, 0x00, 0x00, 0x01); Thread.Sleep(50); }
                    if (Ready == 1)
                    {
                        XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xff);

                        for (int k = 0; k < RdCount; k += 3)
                        {
                            XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                            XM_Comm_Control.XM_Comm_Base.DataRd();
                            byte ValueL = XM_Comm_Control.XM_Comm_Base.DataRd();
                            byte ValueM = XM_Comm_Control.XM_Comm_Base.DataRd();
                            byte ValueH = XM_Comm_Control.XM_Comm_Base.DataRd();
                            dataread.Add(ValueH);
                            dataread.Add(ValueM);
                            dataread.Add(ValueL);
                        }
                    }
                }
                else
                {
                    XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb7, 0x00, 0x02, 0x80);
                    XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbc, 0x00, 0x00, 0x01);
                    XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbd, 0x00, 0x00, 0x00);
                    XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xd1, 0x00, 0xff, 0xff);
                    XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xc1, 0x00, RdNumH, RdNumeL);
                    Thread.Sleep(20);
                    XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xbf);
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, 0x00, 0x00, 0x3e);

                    Thread.Sleep(1);
                    XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc2);
                    Thread.Sleep(1);
                    XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                    XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                    C2_1 = XM_Comm_Control.XM_Comm_Base.DataRd();
                    C2_2 = XM_Comm_Control.XM_Comm_Base.DataRd();
                    Thread.Sleep(20);
                    XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xc6);
                    Thread.Sleep(1);
                    XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                    XM_Comm_Control.XM_Comm_Base.DataDummyRd();
                    C6_1 = XM_Comm_Control.XM_Comm_Base.DataRd();   //高位
                    C6_2 = XM_Comm_Control.XM_Comm_Base.DataRd(); //低位
                    Thread.Sleep(10);
                    CST = (byte)((C6_1 & 0x8) >> 3);
                    DST = (byte)((C6_1 & 0x4) >> 2);
                    LPTO = (byte)((C6_2 & 0x40) >> 6);
                    BTAR = (byte)((C6_2 & 0x04) >> 2);
                    Ready = (byte)(C6_2 & 0x01);
                    RdCount = Convert.ToInt32(C2_1 << 8) + Convert.ToInt32(C2_2);

                    if (LPTO == 1) { XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xc0, 0x00, 0x00, 0x01); Thread.Sleep(50); }
                    if (Ready == 1)
                    {
                        XM_Comm_Control.XM_Comm_Base.Bridge_AddrWrNoCs(0xff);
                        for (int m = 0; m < RdCount; m += 3)
                        {
                            XM_Comm_Control.XM_Comm_Base.AddrWr(0x8d);
                            XM_Comm_Control.XM_Comm_Base.DataRd();
                            byte ValueL = XM_Comm_Control.XM_Comm_Base.DataRd();
                            byte ValueM = XM_Comm_Control.XM_Comm_Base.DataRd();
                            byte ValueH = XM_Comm_Control.XM_Comm_Base.DataRd();
                            dataread.Add(ValueH);
                            dataread.Add(ValueM);
                            dataread.Add(ValueL);
                        }
                    }

                }
            }
            string SaveFile_Path = string.Concat(Setting.ExeLogDirPath, "\\", "ReadData" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv");
            FileStream fs = new FileStream(SaveFile_Path, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("Big5")))
            {
                for (int q = 0; q < dataread.Count; q++)
                {
                    if (q % (Wsize * 3) == 0 && q != 0)
                    {
                        sw.Write("\r\n");
                    }
                    sw.Write(dataread[q] + ",");
                }
                sw.Close();
                fs.Close();
                Cnt = 0;
                dataread.Clear();
            }
            RdStr = "Read Finish";
            return ret;
        }
        public bool ImageFill(byte R, byte G, byte B)
        {
            if (modeselect == 0x03)
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbc, 0x00);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xad, R, G, B);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb7, 0x02, 0x59);
                return true;
            }
            else
            {

                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbc, 0x00, (byte)((Hsize * Wsize * 3) >> 8 & 0xff), (byte)((Hsize * Wsize * 3) & 0xff));
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbd, 0x00, (byte)((Hsize * Wsize * 3) >> 24 & 0xff), (byte)((Hsize * Wsize * 3) >> 16 & 0xff));
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbe, 0x00, (byte)((Wsize * 3) >> 8 & 0xff), (byte)((Wsize * 3) & 0xff));
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb7, 0x00, 0x06, 0x59);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbc, 0x00);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xad, B, G, R);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8b, 0x2c);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbc, 0x11);  //data  source

                return true;
            }
        }

        public bool MipiUlp()
        {
            return BridgeWrite(0xb7, 0x03, 0x04);
        }

        public bool MipiBta()
        {
            return BridgeWrite(0xc4, 0x00, 0x08); ;
        }

        public bool SetFpgaTiming(byte BankEn, byte BankWrRd, byte Interface, byte RgbMode, byte DcmMul, byte DcmDiv)
        {
            return SetBoardTiming(BankEn, BankWrRd, Interface, RgbMode, DcmMul, DcmDiv);
        }

        private void SetIfImgCtrl(byte IfCtrl, byte BankEn)
        {
            byte BankEn2 = (byte)((BankEn >> 4) & 0x01);
            byte BankEn0 = (byte)(BankEn & 0x01);
            WolIfCtrl = IfCtrl;
            WolBankEn = (BankEn2 > 0 || BankEn0 > 0) ? (byte)1 : (byte)0;
            if (IfCtrl == 0 || IfCtrl == 8) BaseIfCtrl = Cpu;
            if (IfCtrl == 0x18 || IfCtrl == 0x19) BaseIfCtrl = Spi;
            if (IfCtrl == 0x20) { BaseIfCtrl = I2C; }
        }


        public bool SetFpgaTiming(byte BankEn, byte BankWrRd, byte Interface, byte RegMode, byte DcmMul, byte DcmDiv, ref string RdStr)
        {
            double Value = 0;
            bool ret = SetBoardTiming(BankEn, BankWrRd, Interface, RegMode, DcmMul, DcmDiv);
            SetIfImgCtrl(Interface, BankEn);
            if (DcmMul == 0 || DcmDiv == 0) return ret;
            Value = FPGA_OSC * DcmMul / DcmDiv; //Pixel Clock for 2828
            RdStr = "DCM Freq: " + Value.ToString() + "M";
            Thread.Sleep(2);
            return ret;
        }

        public bool SetMipiDsi(int LaneCout, int MipiSpeed, string Mode)
        {
            double HS = Convert.ToDouble(MipiSpeed) / 10;
            int LaneNum = Convert.ToInt32(LaneCout);
            byte Lane = 0, LpVal = 0, FR = 0;

            if (HS > 6.25 && HS <= 12.5) FR = 0x02;
            if (HS > 12.6 && HS <= 25) FR = 0x42;
            if (HS > 25.1 && HS <= 50) FR = 0x82;
            if (HS > 50.1) FR = 0xC2;

            Lane = (LaneNum >= 1 && LaneNum <= 4) ? (byte)(LaneNum - 1) : (byte)0x03;
            LpVal = (byte)(MipiSpeed / 8 / 6); //Original: MipiSpeed / 8 / 6


            if (modeselect == 0x03)
            {
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb9, 0x00, 0x00); //PLL disable
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb8, 0x00, 0x00); //VC(Virtual ChannelID) Control Register
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xde, 0x00, Lane); //DSI lane setting,0x00:1 data lane ,0x01:2 data lane 0x02:3 data lane ,0x03:4 data lane

                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb7, 0x02, 0x50);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xba, FR, (byte)HS);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xbb, 0x00, LpVal);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb9, 0x00, 0x01);

                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xd6, 0x00, 0x05);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xc9, 0x1c, 0x07); // data1: HS-ZERO, data2: HS-PRE
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xca, 0x28, 0x0a); // data1: CK-ZERO, data2: CK-PRE
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xcc, 0x0f, 0x0f); // data1: CK-TRAIL, data2: HS-TRAIL

                if (Mode.CompareTo("syncpulse") == 0)
                {
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb1, VSA, HSA);    //VICR1=> VSA,HSA
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb2, VBP, HBP);    //VICR2=> VBP,HBP
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb3, VFP, HFP);    //VICR3=> VFP,HFP
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb4, HD_H, HD_L);  //VICR4=> HACT HDISP
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb5, VD_H, VD_L);  //VICR5=> VACT VDISP

                    // -----------clk lane in HS,when no data send--------------
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb6, 0x00, 0x03);  // 24bit Non burst mode with Sync pulses
                                                                                     //SSD2825_spi_reg_data_wr(0xb6,0x00,0x02);	// 18bit Non burst mode with Sync pulses, loosely packed
                                                                                     //SSD2825_spi_reg_data_wr(0xb6,0x00,0x01);	// 18bit Non burst mode with Sync pulses, packed                                                           //SSD2825_spi_reg_data_wr(0xb6,0x00,0x00);	// 16bit Non burst mode with Sync pulses
                }
                if (Mode.CompareTo("burst") == 0)
                {
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb1, VSA, HSA);    //VICR1=> VSA,HSA
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb2, (byte)(VBP + VSA), (byte)(HBP + HSA));    //VICR2=> VBP,HBP (BP+SA)
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb3, VFP, HFP);    //VICR3=> VFP,HFP
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb4, HD_H, HD_L);  //VICR4=> HACT HDISP
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb5, VD_H, VD_L);  //VICR5=> VACT VDISP  
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb6, 0x00, 0x1b); // 0x1b , bit5 : 0: continue clock ,1: non continue clock
                }

                if (Mode.CompareTo("syncevent") == 0)
                {
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb1, VSA, HSA);    //VICR1=> VSA,HSA
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb2, (byte)(VBP + VSA), (byte)(HBP + HSA));    //VICR2=> VBP,HBP (BP+SA)
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb3, VFP, HFP);    //VICR3=> VFP,HFP
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb4, HD_H, HD_L);  //VICR4=> HACT HDISP
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb5, VD_H, VD_L);  //VICR5=> VACT VDISP     // -----------clk lane in HS,when no data send--------------
                    XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb6, 0x00, 0x07); //0x03,bit5 
                }

                return true;
            }
            else
            {
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb9, 0x00, 0x00, 0x00); //PLL disable
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb8, 0x00, 0x00, 0x00); //VC(Virtual ChannelID) Control Register
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xde, 0x00, 0x00, Lane); //DSI lane setting,0x00:1 data lane ,0x01:2 data lane 0x02:3 data lane ,0x03:4 data lane

                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb7, 0x00, 0x02, 0x50);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xba, 0x00, FR, (byte)HS);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbb, 0x00, 0x00, LpVal);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb9, 0x00, 0x00, 0x01);

                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xd6, 0x00, 0x00, 0x01);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xc9, 0x00, 0x1c, 0x07); // data1: HS-ZERO, data2: HS-PRE
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xca, 0x00, 0x28, 0x0a); // data1: CK-ZERO, data2: CK-PRE
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xcc, 0x00, 0x0f, 0x0f); // data1: CK-TRAIL, data2: HS-TRAIL
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xd8, 0x00, 0x20, 0x20); // data lane0/lane1 delay fine tune
                return true;
            }
        }

        public bool SetMipiVideo(int vLanes, int hPixels, byte framerate, byte vbp, byte vfp, byte hbp, byte hfp, byte vsa, byte hsa)
        {
            byte HT_H = 0, HT_L = 0, VT_H = 0, VT_L = 0;
            int Value = 0;
            uint Val = 0;

            Value = hPixels + hsa + hbp + hfp;

            HT_H = (byte)(Value >> 8);
            HT_L = (byte)(Value & 0xff);

            HD_H = (byte)(hPixels >> 8);
            HD_L = (byte)(hPixels & 0xff);

            Value = vLanes + vsa + vbp + vfp;
            VT_H = (byte)(Value >> 8);
            VT_L = (byte)(Value & 0xff);

            VD_H = (byte)(vLanes >> 8);
            VD_L = (byte)(vLanes & 0xff);

            VBP = (byte)(vbp & 0xff);
            VFP = (byte)(vfp & 0xff);
            HBP = (byte)(hbp & 0xff);
            HFP = (byte)(hfp & 0xff);
            VSA = (byte)(vsa & 0xff);
            HSA = (byte)(hsa & 0xff);

            if (modeselect == 0x03)
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb4, HT_H, HT_L, HT_H, HT_L);    //TH
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb6, HD_H, HD_L, HD_H, HD_L);    //TH
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb8, 0x00, HBP, 0x00, HBP);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xba, HSA, HSA);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb5, VT_H, VT_L, VT_H, VT_L);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb7, VD_H, VD_L, VD_H, VD_L);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb9, 0x00, VBP, 0x00, VBP);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbb, VSA, VSA);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xad, 0x00, 0x00, 0x00);//Normal Data
                                                                                       /*2828 Setting*/
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb1, VSA, HSA);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb2, VBP, HBP);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb3, VFP, HFP);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb4, VD_H, VD_L);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb5, HD_H, HD_L);

#if (DEBUG)
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xb4, ref Val, 2);
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xb5, ref Val, 2);
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xb6, ref Val, 2);
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xb7, ref Val, 2);
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xb8, ref Val, 2);
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xb9, ref Val, 2);
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xba, ref Val, 2);
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xbb, ref Val, 2);
#endif
                return true;
            }
            else
            {
                Hsize = vLanes; Wsize = hPixels;
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb4, HT_H, HT_L, HT_H, HT_L);    //TH
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb5, VT_H, VT_L, VT_H, VT_L);    // TV
                return true;
            }
        }

        public bool ImageShow(string Parameter, string FilePath)
        {
            XM_Img_Lib ImgLib = new XM_Img_Lib();
            if (!ImgLib.IsFileExist(FilePath)) return false;
            return ImageWrite(Parameter, ImgLib);
        }
        /// <summary>
        /// usb add
        /// </summary>
        /// <param name="Parameter"></param>
        /// <param name="FilePath"></param>
        /// <param name="RdStr"></param>
        /// <returns></returns>
        public bool ImageWrite(string Parameter, string FilePath, ref string RdStr)
        {
            if (XM_SDCard_Util.EnaSDCardGen)
            {
                string Path = System.IO.Path.ChangeExtension(FilePath, ".txt");
                Path = Path.Substring(Path.LastIndexOf('\\'));
                Path = Path.Replace("\\", "\\Image_");
                XM_SDCard_Util.ImageFileName = Setting.ExeSDCardDirPath + Path;
            }
            XM_Img_Lib ImgLib = new XM_Img_Lib();
            if (!ImgLib.IsFileExist(FilePath)) { RdStr = "File Not Exist"; return false; }

            return Commandmode(Parameter, ImgLib);
        }

        public bool ImageShow(string Parameter, string FilePath, ref string RdStr)
        {
            if (XM_SDCard_Util.EnaSDCardGen)
            {
                string Path = System.IO.Path.ChangeExtension(FilePath, ".txt");
                Path = Path.Substring(Path.LastIndexOf('\\'));
                Path = Path.Replace("\\", "\\Image_");
                XM_SDCard_Util.ImageFileName = Setting.ExeSDCardDirPath + Path;
            }

            XM_Img_Lib ImgLib = new XM_Img_Lib();
            if (!ImgLib.IsFileExist(FilePath)) { RdStr = "File Not Exist"; return false; }
            if (WolBankEn == 0)
            { return DevImageShow(ImgLib); }
            if (WolBankEn == 1)
            {
                if (modeselect == 0x03)
                {
                    return ImageWrite(Parameter, ImgLib);//vidio mode ddr
                }
                else
                {
                    return cmdImageWrite(Parameter, ImgLib);//COMMAND MODE DDR
                }
            }
            return ImageWrite(Parameter, ImgLib);
        }

        private bool Commandmode(string Parameter, XM_Img_Lib ImgLib)
        {
            bool ret = false;
            List<byte> lXferData = new List<byte>();
            if (!string.IsNullOrEmpty(Parameter)) ret = true;
            ImgLib.BmpToList(ref lXferData);
            XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbc, 0x00, (byte)((Hsize * Wsize * 3) >> 8 & 0xff), (byte)((Hsize * Wsize * 3) & 0xff));
            XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbd, 0x00, (byte)((Hsize * Wsize * 3) >> 24 & 0xff), (byte)((Hsize * Wsize * 3) >> 16 & 0xff));
            XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbe, 0x00, (byte)((Wsize * 3) >> 8 & 0xff), (byte)((Wsize * 3) & 0xff));
            XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb7, 0x00, 0x06, 0x59);
            IntPtr WriteDataPtr = Marshal.AllocHGlobal(lXferData.ToArray().Length);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8b, 0x2c);
            XM_Comm_Control.XM_Comm_Base.AddrWr(0x8e);//沈乐造的寄存器   传数据（0x8c的作用）
            XM_Comm_Control.XM_Comm_Base.CommDelay(5);
            Marshal.Copy(lXferData.ToArray(), 0, WriteDataPtr, lXferData.ToArray().Length); // xferBuf to WriteDataPtr
            ret = Epp2USB.UsbWriteScanner(WriteDataPtr, (uint)lXferData.ToArray().Length, 0);
            Marshal.FreeHGlobal(WriteDataPtr);
            XM_Comm_Control.XM_Comm_Base.CommDelay(5);
            lXferData.Clear();
            return ret;
        }

        public bool I2CWrite(byte[] I2CData)
        {
            return XM_Comm_Control.XM_Comm_Base.I2CWrite(I2CADDR, I2CData);
        }

        public bool I2cRead(byte i2c_W_Addr, byte ICAddr, byte Rdnum, ref string RdStr)
        {
            byte outPort = 0;
            byte i2c_R_Addr = (byte)(i2c_W_Addr + 1);
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xa0, ref outPort);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xa0, 0x20);//i2c output
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9c, 0x4b, 0x4b);//i2c 400k
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9d, 0x00, 0x00, Rdnum);//i2c read count
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02);//i2c Start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, i2c_W_Addr);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, ICAddr);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x01);//i2c stop

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02);//i2c Start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, i2c_R_Addr);
            XM_Comm_Control.XM_Comm_Base.AddrWr(0x83);
            for (int i = 0; i < Rdnum; i++) { RdStr += "0x" + Convert.ToString(XM_Comm_Control.XM_Comm_Base.DataDummyRd(), 16); }
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x01);//i2c stop
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xa0, outPort);
            return true;
        }

        public bool PMIC_2_Read(byte ChipReg, ref byte RdVal)
        {
            XM_Comm_Control.XM_Comm_Base = XM_Comm_Control.XM_Comm_Type[1];


            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9c, 0x4b, 0x4b);//i2c 400k
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9d, 0x00, 0x00, 2);//i2c read count
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbe, 0x03); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x22); //slave addr,wr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, ChipReg); // addr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x23); //i2c stop
            XM_Comm_Control.XM_Comm_Base.AddrWr(0x83);
            RdVal = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbe, 0x02); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00);//i2c stop
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x01);//i2c stop

            if (XM_SDCard_Util.EnaSDCardGen == true)
            {
                XM_Comm_Control.XM_Comm_Base = XM_Comm_Control.XM_Comm_Type[0];
            }

            return true;
        }

        public bool PMIC_0_Read(byte ChipReg, ref byte RdVal)
        {
            XM_Comm_Control.XM_Comm_Base = XM_Comm_Control.XM_Comm_Type[1];


            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9c, 0x4b, 0x4b);//i2c 400k
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9d, 0x00, 0x00, 2);//i2c read count
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbd, 0x03); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x22); //slave addr,wr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, ChipReg); // addr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x23); //i2c stop
            XM_Comm_Control.XM_Comm_Base.AddrWr(0x83);
            RdVal = XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbd, 0x02); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00);//i2c stop
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x01);//i2c stop

            if (XM_SDCard_Util.EnaSDCardGen == true)
            {
                XM_Comm_Control.XM_Comm_Base = XM_Comm_Control.XM_Comm_Type[0];
            }

            return true;

        }


        public bool PMIC_2_Read(byte ChipReg, ref string RdStr)
        {
            XM_Comm_Control.XM_Comm_Base = XM_Comm_Control.XM_Comm_Type[1];


            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9c, 0x4b, 0x4b);//i2c 400k
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9d, 0x00, 0x00, 2);//i2c read count
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbe, 0x03); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x22); //slave addr,wr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, ChipReg); // addr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x23); //i2c stop
            XM_Comm_Control.XM_Comm_Base.AddrWr(0x83);
            RdStr += String.Format("0x{0:X2}", XM_Comm_Control.XM_Comm_Base.DataDummyRd());
            XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbe, 0x02); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00);//i2c stop
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x01);//i2c stop

            if (XM_SDCard_Util.EnaSDCardGen == true)
            {
                XM_Comm_Control.XM_Comm_Base = XM_Comm_Control.XM_Comm_Type[0];
            }
            return true;
        }

        public bool PMIC_0_Read(byte ChipReg, ref string RdStr)
        {
            XM_Comm_Control.XM_Comm_Base = XM_Comm_Control.XM_Comm_Type[1];

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9c, 0x4b, 0x4b);//i2c 400k
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9d, 0x00, 0x00, 2);//i2c read count
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbd, 0x03); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x22); //slave addr,wr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, ChipReg); // addr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x23); //slave addr,Read
            XM_Comm_Control.XM_Comm_Base.AddrWr(0x83);
            RdStr += String.Format("0x{0:X2}", XM_Comm_Control.XM_Comm_Base.DataDummyRd());
            XM_Comm_Control.XM_Comm_Base.DataDummyRd();
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbd, 0x02); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x00);//i2c stop
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x01);//i2c stop    

            if (XM_SDCard_Util.EnaSDCardGen == true)
            {
                XM_Comm_Control.XM_Comm_Base = XM_Comm_Control.XM_Comm_Type[0];
            }

            return true;

        }

        public bool PMIC_0_Write(byte ChipReg, byte Data)
        {
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xa0, 0x20);//i2c output

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9c, 0x4b, 0x4b);//i2c 400k
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9d, 0x00, 0x00, 0x01);//i2c read count
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbd, 0x03); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x22); //slave addr,wr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, ChipReg); // addr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, Data); //data
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x01); //i2c stop
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbd, 0x02); //pmic access enable
            return true;
        }

        public bool PMIC_0_Write(byte ChipReg, byte Data, ref string RdStr)
        {
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xa0, 0x20);//i2c output

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9c, 0x4b, 0x4b);//i2c 400k
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9d, 0x00, 0x00, 0x01);//i2c read count
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbd, 0x03); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x22); //slave addr,wr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, ChipReg); // addr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, Data); //data
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x01); //i2c stop
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbd, 0x02); //pmic access enable
            return true;
        }

        public bool PMIC_2_Write(byte ChipReg, byte Data)
        {

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9c, 0x4b, 0x4b);//i2c 400k
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9d, 0x00, 0x00, 0x01);//i2c read count
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbe, 0x03); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x22); //slave addr,wr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, ChipReg); // addr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, Data); //data
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x01); //i2c stop
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbe, 0x02); //pmic access enable
            return true;
        }

        public bool PMIC_2_Write(byte ChipReg, byte Data, ref string RdStr)
        {

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9c, 0x4b, 0x4b);//i2c 400k
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9d, 0x00, 0x00, 0x01);//i2c read count
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbe, 0x03); //pmic access enable
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x02); //i2c start
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, 0x22); //slave addr,wr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, ChipReg); // addr
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, Data); //data
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9b, 0x01); //i2c stop
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbe, 0x02); //pmic access enable
            return true;
        }

        public bool ReadFromDDRToImage(string ImageSize, string ImageFile)
        {
            byte[] Img = new byte[6003000];
            XM_Comm_Control.XM_Comm_Base.CommBase_MassRead(0x85, 1, ref Img, 6003000);
            string ImgFileName = Setting.ExeImgDirPath + "\\" + ImageFile;
            int Width = 750, Height = 1334;
            Bitmap Image = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            for (int ycnt = 0; ycnt < Width; ycnt++)
            {
                for (int xcnt = 0; xcnt < Height; xcnt++)
                {
                    Color newColor = Color.FromArgb(255, 0, 0);
                    Image.SetPixel(ycnt, xcnt, newColor);
                }
            }

            Image.Save(ImgFileName, System.Drawing.Imaging.ImageFormat.Bmp);

            return true;
        }

        public bool UsbCmdWrite(byte[] xferData)
        {
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(xferData, xferData.Length);
            return true;
        }

        public bool UsbCmdWriteGpio(byte[] xferData)
        {
            XM_Comm_Control.XM_Comm_Base.CommBase_MassDataWrScan(xferData);
            return true;
        }

        public bool GpioCtrl(byte Direct, byte G_Hb, byte G_Lb)
        {
            if (!(Direct == 0x00 || Direct == 0x01 || Direct == 0x10 || Direct == 0x11)) Direct = 0x11;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfa, Direct);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, G_Hb);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, G_Lb);
            return true;
        }

        public bool GpioCtrl(byte Direct, byte G_Hb)
        {
            if (!(Direct == 0x00 || Direct == 0x01 || Direct == 0x10 || Direct == 0x11)) Direct = 0x11;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfa, Direct);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, G_Hb);
            // XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, G_Lb);
            return true;
        }

        public bool PMIC_0_Ctrl(double SetVSP, double SetVSN, bool Enable)
        {
            string Reg = null;
            byte VolVSN = 0, VolVSP = 0, Data = 0;
            byte En = (Enable) ? (byte)1 : (byte)0;

            //VSP
            PMIC_0_Read(0x0e, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSP = (byte)((SetVSP - 4) / 0.05);
            VolVSP = (byte)((Data & 0xC0) | VolVSP);
            PMIC_0_Write(0x0e, VolVSP);

            //VSN
            Reg = null;
            PMIC_0_Read(0x0f, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSN = (byte)((Math.Abs(SetVSN) - 4) / 0.05);
            VolVSN = (byte)((Data & 0xC0) | VolVSN);
            PMIC_0_Write(0x0f, VolVSN);

            //Enable 
            Reg = null;
            PMIC_0_Read(0x0C, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)((Data & 0xB7) | (En << 6) + (En << 3));
            PMIC_0_Write(0x0C, Data);
            return true;
        }

        public bool PMIC_2_Ctrl(float SetVSP, float SetVSN, bool Enable)
        {
            string Reg = null;
            byte VolVSN = 0, VolVSP = 0, Data = 0;
            byte En = (Enable) ? (byte)1 : (byte)0;

            //VSP
            PMIC_2_Read(0x0e, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSP = (byte)((SetVSP - 4) / 0.05);
            VolVSP = (byte)((Data & 0xC0) | VolVSP);
            PMIC_2_Write(0x0e, VolVSP);

            //VSN
            Reg = null;
            PMIC_2_Read(0x0f, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            VolVSN = (byte)((Math.Abs(VolVSN) - 4) / 0.05);
            VolVSN = (byte)((Data & 0xC0) | VolVSN);
            PMIC_2_Write(0x0f, VolVSN);

            //Enable 
            Reg = null;
            PMIC_2_Read(0x0C, ref Reg);
            if (string.IsNullOrEmpty(Reg)) return false;
            if (!new XM_Digital_Util().StrToNumber<byte>(Reg, ref Data)) return false;
            Data = (byte)((Data & 0xB7) | (En << 6) + (En << 3));
            PMIC_2_Write(0x0C, Data);
            return true;
        }

        public bool BackLight_0_Ctrl(bool Enable, bool Single)
        {
            byte Reg = 0;
            byte Data = (Enable) ? (byte)1 : (byte)0;
            Data = (Single) ? Data : (byte)(Data + 8);
            PMIC_0_Read(0x0A, ref Reg);
            Reg = (byte)((Reg & 0xf6) | Data);
            PMIC_0_Write(0x0A, Reg);
            return true;
        }

        public bool BackLight_2_Ctrl(bool Enable, bool Single)
        {
            byte Reg = 0;
            byte Data = (Enable) ? (byte)1 : (byte)0;
            Data = (Single) ? Data : (byte)(Data + 8);
            PMIC_2_Read(0x0A, ref Reg);
            Reg = (byte)((Reg & 0xf6) | Data);
            PMIC_2_Write(0x0A, Reg);
            return true;
        }

        /*
         * OutVol: External Control and Low Level 
        */
        public bool ResetCtrl(int SetLevel, bool Triger)
        {
            bool ret = (SetLevel == 1) ? XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x00) : XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x80);
            if (Triger)
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x00);
                Thread.Sleep(30);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x90);
                Thread.Sleep(15);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x00);
            }
            return true;
        }

        public bool ResetCtrl()
        {
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x00);
            Thread.Sleep(10);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x90);
            Thread.Sleep(5);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x00);
            return true;
        }

        public bool BridgeRead(byte addr, byte RdNum, ref string RdStr)
        {
            uint xferValue = 0; bool ret = false;
            if (modeselect == 0x03)
            {
                ret = XM_Comm_Control.XM_Comm_Base.Bridge_ReadReg(addr, RdNum, ref xferValue);
            }
            else
            {
                ret = XM_Comm_Control.XM_Comm_Base.Bridge_RdRegNoCs(addr, RdNum, ref xferValue);
            }
            RdStr = "0x" + Convert.ToString(xferValue, 16);
            return ret;
        }

        public bool BridgeWrite(byte Addr, byte Data, byte Data1)
        {
            if (modeselect == 0x03)
            {
                return XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(Addr, Data, Data1);
            }
            else
            {
                return XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(Addr, 0x00, Data, Data1);
            }
        }

        public bool BridgeWrite(byte Addr, byte Data)
        {
            if (modeselect == 0x03)
            {
                return XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(Addr, Data);
            }
            else
            {
                return XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(Addr, Data);
            }
        }

        private bool SetBoardTiming(byte BankEn, byte BankWrRd, byte Interface, byte RgbMode, byte DcmMul, byte DcmDiv)
        {
            uint Val = 0;
            // byte BankEn2 = (byte)((BankEn >> 4) & 0x01);
            byte BankEn0 = (byte)(BankEn & 0x03);
            // BankEn0 = (BankEn2 > 0 || BankEn0 > 0) ? (byte)1 : (byte)0;
            modeselect = BankEn0;
            if (modeselect == 0x03)
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x92, 0x20); //Default(CPU/SPI From EPP, RGB from SRAM) , In_Data_Source
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xa0, Interface);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xa1, RgbMode);

                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x95, 0xaa); //SPI Setting
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x96, 0xaa); //SPI Setting

                if (BankEn0 == 0)
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xf3, 0x10);
                else
                {
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xf3, 0x11); //PLL Reset
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xf3, 0x10);
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xf3, 0x11);
                }

                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb0, BankEn);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb2, BankWrRd);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb3, 0x11);

                //DCM Reset
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xf0, 0x11);

                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xf0, 0x10);

                if (DcmMul < 2) DcmMul = 2;
                if (DcmDiv < 1) DcmDiv = 1;
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xf1, DcmMul);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xf2, DcmDiv);

                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8a, 0x00);//Reload


#if (DEBUG)
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x92, ref Val, 1); //0x20
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x95, ref Val, 1); //0xaa
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x96, ref Val, 1); //0xaa

                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xb0, ref Val, 1); //WhiskyValue[0]
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xb2, ref Val, 1); //WhiskyValue[1]
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xb3, ref Val, 1); //0x11

                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xa0, ref Val, 1); //WhiskyValue[2]
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xa1, ref Val, 1); //WhiskyValue[3]

                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xf1, ref Val, 1); // WhiskyValue[4]
                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xf2, ref Val, 1); // WhiskyValue[5]
#endif
                return true;
            }
            else
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x92, 0x20); //Default(CPU/SPI From EPP, RGB from SRAM) , In_Data_Source
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xa0, Interface);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xa1, RgbMode);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xf3, 0x11); //PLL Reset
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xf3, 0x10);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xf3, 0x11);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb0, BankEn);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xb2, BankWrRd);
                return true;
            }
        }

        private bool ImageWrite(string Parameter, XM_Img_Lib ImgLib)
        {
            bool ret = true, bNormal = false;
            List<byte> lXferData = new List<byte>();
            if (!string.IsNullOrEmpty(Parameter)) bNormal = true;

            ImgLib.BmpToListWithDummyVideo(ref lXferData);
            if (bNormal) ret = XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbc, 0x00);
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x93, 0x03);
            XM_Comm_Control.XM_Comm_Base.CommDelay(5);

            ret = XM_Comm_Control.XM_Comm_Base.DDR_MassWrite(0x84, 1, lXferData.ToArray(), lXferData.Count);
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbc, 0x11);
            XM_Comm_Control.XM_Comm_Base.CommDelay(5);
            lXferData.Clear();
            XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb7, 0x02, 0x59);

            XM_SDCard_Util.EnaSDImageGen = true;
            return true;
        }
        private bool cmdImageWrite(string Parameter, XM_Img_Lib ImgLib)
        {
            bool ret = true, bNormal = false;
            List<byte> lXferData = new List<byte>();
            if (!string.IsNullOrEmpty(Parameter)) bNormal = true;

            ImgLib.BmpToListWithDummy(Wsize, ref lXferData);

            if (bNormal) ret = XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbc, 0x00);
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x93, 0x03);
            XM_Comm_Control.XM_Comm_Base.CommDelay(5);

            ret = XM_Comm_Control.XM_Comm_Base.DDR_MassWrite(0x84, 1, lXferData.ToArray(), lXferData.Count);

            XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbc, 0x00, (byte)((Hsize * Wsize * 3) >> 8 & 0xff), (byte)((Hsize * Wsize * 3) & 0xff));
            XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbd, 0x00, (byte)((Hsize * Wsize * 3) >> 24 & 0xff), (byte)((Hsize * Wsize * 3) >> 16 & 0xff));
            XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbe, 0x00, (byte)((Wsize * 3) >> 8 & 0xff), (byte)((Wsize * 3) & 0xff));
            XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb7, 0x00, 0x06, 0x59);

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8b, 0x2c);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xae, 0x01);//沈乐造的寄存器   ddr endable
            XM_Comm_Control.XM_Comm_Base.CommDelay(5);
            ret = XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbc, 0x00);
            XM_Comm_Control.XM_Comm_Base.CommDelay(5);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xbc, 0x11);
            lXferData.Clear();
            XM_SDCard_Util.EnaSDImageGen = true;
            XM_Comm_Control.XM_Comm_Base.CommDelay(1000);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xae, 0x00);
            return true;
        }
        private bool DevImageShow(XM_Img_Lib ImgLib)
        {
            byte[,] Pixels = null;
            if (BaseIfCtrl == null) return false;

            if (ImgLib.BmpAryWithCpu(ref Pixels))
            {
                if (DEVADDRMODE == 0) BaseIfCtrl.WrImgWithHorizontal(Pixels);
                if (DEVADDRMODE == 1) BaseIfCtrl.WrImgWithVertical(Pixels);
                if (DEVADDRMODE == 2) BaseIfCtrl.WrImgWithPage(Pixels);
            }
            XM_SDCard_Util.EnaSDImageGen = true;
            Pixels = null;
            return true;
        }

        public bool FpgaWrite(byte Addr, byte[] Data)
        {
            bool ret = true;
            switch (Data.Length)
            {
                case 1:
                    ret = XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(Addr, Data[0]);
                    break;
                case 2:
                    ret = XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(Addr, Data[0], Data[1]);
                    break;
                case 3:
                    ret = XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(Addr, Data[0], Data[1], Data[2]);
                    break;
                case 4:
                    ret = XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(Addr, Data[0], Data[1], Data[2], Data[3]);
                    break;
                default:
                    break;
            }
            return ret;
        }

        public bool FpgaRead(byte Addr, int RdNum, ref string RdStr)
        {
            uint Val = 0;
            bool Ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(Addr, ref Val, RdNum);
            RdStr = "0x" + Convert.ToString(Val, 16);
            return Ret;
        }
    }
}
