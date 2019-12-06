using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

/* interface olny surport Attributes, Method, Event and  Index
   public interface Example
   {
       int 屬性 { get; }               // Attributes
       public void 方法();             // Method
       event MyEvent 事件；            // Event
       int this[int index] { get; set; } //Index sub
   }*/

namespace XM_Tek_Studio_Pro
{
    public interface IXM_Comm
    {
        byte ADDRWRMODE { get; set; }
        byte DATAWRMODE { get; set; }
        byte DATARDMODE { get; set; }
        byte ADDRWRMODE_2828 { get; set; }
        byte DATAWRMODE_2828 { get; set; }
        byte DATARDMODE_2828 { get; set; }
        byte REG_2828_RDMODE { get; set; }
        byte BrigeSel { get; set; }

        bool Dev_Open(ushort Vid, ushort Pid);
        bool Dev_Close(ushort Vid, ushort Pid);
        void Comm_RegWrite();
        void Comm_RegRead();
        void Comm_IO();

        bool AddrWr(byte Data);
        bool DataWr(byte Data);
        byte DataRd();

        byte DataDummyRd();

        bool Bridge_DataWr(byte Data);

        bool Bridge_DataWrNoCs(byte Data);

        bool Bridge_AddrWrNoCs(byte Data);

        bool Bridge_AddrWr(byte Data);

        /* 
         *  1.Write Data to Register 
         *  2.Switch Mode with 2828 Reg: 0xfa
         *  3.Switch FPGA Read Mode Reg:0x8d
         *  4.Read 
        */
        bool Bridge_ReadReg(byte xRegAddr, ref uint xRegVal, int Num);

        bool Bridge_ReadReg(byte xRegAddr, int Num, ref uint xRegVal);

        bool Bridge_RdRegNoCs(byte xRegAddr, ref uint xRegVal, int Num);

        bool Bridge_RdRegNoCs(byte xRegAddr, int Num, ref uint xRegVal);

        bool Bridge_WriteReg(byte Addr, byte Data);

        bool Bridge_WrRegNoCs(byte Addr, byte Data);

        bool Bridge_WrRegNoCs(byte Addr,byte empty, byte Data_H, byte Data_L);

        bool Bridge_WriteReg(byte Addr, byte Data_H, byte Data_L);

        bool CommBase_ReadReg(byte xRegBuf, ref byte xRegVal);

        bool CommBase_ReadReg(byte xRegBuf, ref ushort xRegVal);

        //xRegVal = (xRegVal << 8) + SL_DataRead();
        bool CommBase_ReadReg(byte xRegBuf, ref uint xRegVal, int Num);

        //word
        bool CommBase_ReadReg(byte xRegBuf, byte[] xRegVal, int Num);

        bool CommBase_MassRead(ref byte[] xferBuf, int xbufLen, bool Mass);

        bool CommBase_MassRead(uint wCmd, int wCmdLen, ref byte[] xferBuf, int xbufLen);

        bool CommBase_Read(ref uint xferBuf, int xbufLen);

        bool CommBase_Read(uint wCmd, int wCmdLen, ref uint xferBuf, int xbufLen);

        bool CommBase_WriteCmd(byte[] xferBuf, int xbufLen);

        bool CommBase_AddrWrite(byte[] wCmd);

        bool CommBase_MassDataWr(byte[] xferBuf);

        bool CommBase_MassDataWrScan(byte[] xferBuf);

        bool DDR_MassWrite(uint wCmd, int wCmdLen, byte[] xferBuf, int wDataLen);

        bool CommBase_Write(uint wCmd, int wCmdLen, uint wData, int wDataLen);

        //FPGA : Write Reg Value by Name
        bool CommBase_WriteReg(string RegName, uint Val);

        //FPGA :Write Reg Value by Name
        bool CommBase_WriteReg(string RegName, uint Val, int xbufLen);

        //FPGA :Write Value by Addr 
        bool CommBase_WriteReg(byte addr, uint Value, uint xbufLen);

        bool CommBase_WriteReg(byte addr, byte data);

        bool CommBase_WriteReg(byte addr, byte data, byte data1);

        bool CommBase_WriteReg(byte addr, byte data, byte data1, byte data2);

        bool CommBase_WriteReg(byte addr, byte data, byte data1, byte data2, byte data3);

        //byte ChipSel();

        bool BdgSel();

        bool UnBgeSel();

        bool CommDelay(double XmPlusData);

        bool I2CWrite(byte I2CAddr,byte[] xferBuf);
    }

    public class XM_Comm_Control
    {
        public static IXM_Comm XM_Comm_Base;
        public static List<IXM_Comm> XM_Comm_Type = new List<IXM_Comm>();
    }

    internal class GL600IOCtrl
    {
        public static bool GpioOE(int g1, int g2, int g3, int g4, int g5, int g6, int g7)
        {
            // Bit 0~6 are mapped to GPIO 1~7, "0"-> input, "1"-> output
            byte x = (byte)((g7 << 6) + (g6 << 5) + (g5 << 4) + (g4 << 3) + (g3 << 2) + (g2 << 1) + g1);
            return Epp2USB.GLGpioOE(x);
        }

        public static bool GpioWR(int g1, int g2, int g3, int g4, int g5, int g6, int g7)
        {
            // Bit 0~6 are mapped to GPIO 1~7, "0"-> input, "1"-> output
            byte x = (byte)((g7 << 6) + (g6 << 5) + (g5 << 4) + (g4 << 3) + (g3 << 2) + (g2 << 1) + g1);
            return Epp2USB.GLGpioWrite(x);
        }

        public static int GpioRD()
        {
            // Bit 0~6 are mapped to GPIO 1~7, "0"-> input, "1"-> output
            return Epp2USB.GLGpioRead();
        }
    }
 
    internal sealed partial class XMREGNAME
    {
        internal const string CS_RST_PINCTRL = "CS_RST_PINCTRL";
        internal const string DSX_RGBDSX = "DSX_RGBDSX";
        internal const string DDR3SEL = "DDR3SEL";
        internal const string SPI_RDDUMMYCLK = "SPI_RDDUMMYCLK";
        internal const string SPI_WRCLKH_L = "SPI_WRCLKH_L";
        internal const string SPI_RDCLKH_L = "SPI_RDCLKH_L";
        internal const string CS123SEL = "CS123SEL";
        internal const string I2C_STOP_START = "I2C_STOP_START";
        internal const string I2C_SCKH_L = "I2C_SCKH_L";
        internal const string I2C_RDBYTE_CNT = "I2C_RDBYTE_CNT";
        internal const string INTERFACEMODE = "INTERFACEMODE";
        internal const string RGBMODE_POLARITY = "RGBMODE_POLARITY";
        internal const string RGB_TH = "RGB_TH";
        internal const string RGB_TV = "RGB_TV";
        internal const string RGB_THDS = "RGB_THDS";
        internal const string RGB_TVDS = "RGB_TVDS";
        internal const string RGB_THBP = "RGB_THBP";
        internal const string RGB_TVBP = "RGB_TVBP";
        internal const string RGB_THPW = "RGB_THPW";
        internal const string RGB_TVPW = "RGB_TVPW";
        internal const string DDR3_1ADDR = "DDR3_1ADDR";
        internal const string DDR3_3ADDR = "DDR3_3ADDR";
        internal const string RGB_NORMALDATA = "RGB_NORMALDATA";
        internal const string SSD2828_BANKEN_MODESET = "SSD2828_BANKEN_MODESET";
        internal const string SSD2828_BANKCOLOR_SHUTDOWN = "SSD2828_BANKCOLOR_SHUTDOWN";
        internal const string REG_2828BX_WRRDEN = "REG_2828BX_WRRDEN";
        internal const string REG_2828BX_SPICSX = "REG_2828BX_SPICSX";
        internal const string RGB_TH_2828BX = "RGB_TH_2828BX";
        internal const string RGB_TV_2828BX = "RGB_TV_2828BX";
        internal const string RGB_THDS_2828BX = "RGB_THDS_2828BX";
        internal const string RGB_TVDS_2828BX = "RGB_TVDS_2828BX";
        internal const string RGB_THBP_2828BX = "RGB_THBP_2828BX";
        internal const string RGB_TVBP_2828BX = "RGB_TVBP_2828BX";
        internal const string RGB_THPW_2828BX = "RGB_THPW_2828BX";
        internal const string RGB_TVPW_2828BX = "RGB_TVPW_2828BX";
        internal const string RGB_RGBDSX_2828BX = "RGB_RGBDSX_2828BX";
        internal const string LCD_LED_POWER_SET = "LCD_LED_POWER_SET";
        internal const string DCM_EN_RST = "DCM_EN_RST";
        internal const string DCM_MULTIPLY = "DCM_MULTIPLY";
        internal const string DCM_DIVIDE = "DCM_DIVIDE";
        internal const string PLLEN_RST = "PLLEN_RST";
        internal const string GPIO_DIR = "GPIO_DIR";
        internal const string GPIOA_HB = "GPIOA_HB";
        internal const string GPIOA_LB = "GPIOA_LB";
        internal const string REG_GPIO = "REG_GPIO";
    }

    internal sealed partial class XMREGADDR
    {
        internal const byte ADDR_WR_MODE = 0x80;
        internal const byte DATA_WR_MODE = 0x81;
        internal const byte DATA_RD_MODE = 0x83;
        internal const byte DDR3_WR_MODE = 0x84;
        internal const byte DDR3_RD_MODE = 0x85;
        internal const byte DCM_REPROG_MODE = 0x8a;
        internal const byte ADDR_WR_MODE_2828 = 0x8b;
        internal const byte DATA_WR_MODE_2828 = 0x8c;
        internal const byte DATA_RD_MODE_2828 = 0x8d;

        internal const byte CS_RST_PINCTRL = 0x90;
        internal const byte DSX_RGBDSX = 0x92;
        internal const byte DDR3SEL = 0x93;
        internal const byte SPI_RDDUMMYCLK = 0x94;
        internal const byte SPI_WRCLKH_L = 0x95;

        internal const byte SPI_RDCLKH_L = 0x96;
        internal const byte CS123SEL = 0x98;
        internal const byte I2C_STOP_START = 0x9b;
        internal const byte I2C_SCKH_L = 0x9c;
        internal const byte I2C_RDBYTE_CNT = 0x9d;

        internal const byte INTERFACEMODE = 0xa0;
        internal const byte RGBMODE_POLARITY = 0xa1;
        internal const byte RGB_TH = 0xa2;
        internal const byte RGB_TV = 0xa3;
        internal const byte RGB_THDS = 0xa4;

        internal const byte RGB_TVDS = 0xa5;
        internal const byte RGB_THBP = 0xa6;
        internal const byte RGB_TVBP = 0xa7;
        internal const byte RGB_THPW = 0xa8;
        internal const byte RGB_TVPW = 0xa9;

        internal const byte DDR3_1ADDR = 0xab;
        internal const byte DDR3_3ADDR = 0xac;
        internal const byte RGB_NORMALDATA = 0xad;
        internal const byte SSD2828_BANKEN_MODESET = 0xb0;
        internal const byte SSD2828_BANKCOLOR_SHUTDOWN = 0xb1;

        internal const byte REG_2828BX_WRRDEN = 0xb2;
        internal const byte REG_2828BX_SPICSX = 0xb3;
        internal const byte RGB_TH_2828BX = 0xb4;
        internal const byte RGB_TV_2828BX = 0xb5;
        internal const byte RGB_THDS_2828BX = 0xb6;

        internal const byte RGB_TVDS_2828BX = 0xb7;
        internal const byte RGB_THBP_2828BX = 0xb8;
        internal const byte RGB_TVBP_2828BX = 0xb9;
        internal const byte RGB_THPW_2828BX = 0xba;
        internal const byte RGB_TVPW_2828BX = 0xbb;

        internal const byte RGB_RGBDSX_2828BX = 0xbc;
        internal const byte LCD_LED_POWER_SET = 0xbd;
        internal const byte DCM_EN_RST = 0xf0;
        internal const byte DCM_MULTIPLY = 0xf1;
        internal const byte DCM_DIVIDE = 0xf2;

        internal const byte PLLEN_RST = 0xf3;
        internal const byte GPIO_DIR = 0xfa;
        internal const byte GPIOA_HB = 0xfb;
        internal const byte GPIOA_LB = 0xfc;
        internal const byte REG_GPIO = 0xff;

    }

    /*
    * 1.FPGA Reg Table
    */
    internal sealed partial class RegFunc
    {
        //byte RegI2C = 0x80;
        //byte RegSPI = 0x81;
        //byte RegUsb = 0x82;
        //byte RegSATA = 0x83;
        //byte RegSSCI = 0x86;
        //byte RegFiber = 0x87;
    }

    /***********************************************************
    Error Code Define
    ***********************************************************/
    internal sealed partial class Chip
    {
        internal const byte ERROR_RESULT_OK = 0;
        internal const byte ERROR_RESULT_FAIL = 1;
        internal const byte ERROR_BUFLEN_ERR = 2;
        internal const byte ERROR_READREG_FAIL = 3;
        internal const byte ERROR_WRITEREG_FAIL = 4;
        internal const byte ERROR_LOOKUPREG_FAL = 5;
        internal const byte ERROR_DISADDRWR = 6;
        internal const byte ERROR_DISDATAWR = 7;
        internal const byte ERROR_SPI_WR_FAIL = 8;
        internal const byte ERROR_SPI_RD_FAIL = 8;
        /*
        internal const byte ERROR_IVALIDTOKEN = 8;
        internal const byte ERROR_ADDRWR_NOPARAM = 9;
        internal const byte ERROR_DATAWR_NOPARAM = 10;
        internal const byte ERROR_STOREFORMAT_ERR = 11;
        internal const byte ERROR_CMPIMG_NOPARAM = 12;
        internal const byte ERROR_CMPIMG_FILEEXIST = 13;
        */
    }

    public static class Epp2USB
    {
        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool FindScanner(ushort vid, ushort pid);

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool GeneCloseHandle();

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool GLGpioOE(byte x);

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool GLGpioWrite(byte y);

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern int GLGpioRead();

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool GLWriteEPPDataPort(byte x);

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool GLWriteEPPAddressPort(byte x);

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern byte GLReadEPPDataPort();

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbReadScanner(IntPtr buffer, uint len, byte EppCtl);

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbReadScanner(ref byte[] buffer, uint len, byte EppCtl);

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteScanner(IntPtr buffer, uint len, byte Eppctl);

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteScanner(ref byte[] buffer, int len, byte Eppctl);

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteCommand(IntPtr buffer, int len);

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool SetFastEPP();

        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteAD02(byte a1, byte d1);
        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteAD04(byte a1, byte d1, byte a2, byte d2);
        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteAD06(byte a1, byte d1, byte a2, byte d2, byte a3, byte d3);
        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteAD08(byte a1, byte d1, byte a2, byte d2, byte a3, byte d3, byte a4, byte d4);
        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteAD10(byte a1, byte d1, byte a2, byte d2, byte a3, byte d3, byte a4, byte d4, byte a5, byte d5);
        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteAD12(byte a1, byte d1, byte a2, byte d2, byte a3, byte d3, byte a4, byte d4, byte a5, byte d5
                                              , byte a6, byte d6);
        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteAD14(byte a1, byte d1, byte a2, byte d2, byte a3, byte d3, byte a4, byte d4, byte a5, byte d5
                                              , byte a6, byte d6, byte a7, byte d7);
        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteAD16(byte a1, byte d1, byte a2, byte d2, byte a3, byte d3, byte a4, byte d4, byte a5, byte d5
                                              , byte a6, byte d6, byte a7, byte d7, byte a8, byte d8);
        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteAD18(byte a1, byte d1, byte a2, byte d2, byte a3, byte d3, byte a4, byte d4, byte a5, byte d5
                                              , byte a6, byte d6, byte a7, byte d7, byte a8, byte d8, byte a9, byte d9);
        [DllImport("EPP2USB_DLL_V12.dll")]
        public static extern bool UsbWriteAD20(byte a1, byte d1, byte a2, byte d2, byte a3, byte d3, byte a4, byte d4, byte a5, byte d5
                                              , byte a6, byte d6, byte a7, byte d7, byte a8, byte d8, byte a9, byte d9, byte a10, byte d10);
    }
}
