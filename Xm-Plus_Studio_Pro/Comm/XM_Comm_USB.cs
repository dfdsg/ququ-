using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    /// <summary>
    ///  Purpose: For GL660 High Speed protocol, it must redefine the protocol and let the user easy to use.
    ///  DLL: EPP2USB_DLL_V10.dll
    /// </summary>
    /// 
    //Switch 2808 Register

    public class XM_Comm_USB_Control : IXM_Comm
    {
        public byte[] Parameter = { 0x80, 0x81, 0x83, 0x8b, 0x8c, 0x8d, 0xfa, 0x00 };
        public byte ADDRWRMODE { get { return Parameter[0]; } set { this.Parameter[0] = value; } }
        public byte DATAWRMODE { get { return Parameter[1]; } set { this.Parameter[1] = value; } }
        public byte DATARDMODE { get { return Parameter[2]; } set { this.Parameter[2] = value; } }
        public byte ADDRWRMODE_2828 { get { return Parameter[3]; } set { this.Parameter[3] = value; } }
        public byte DATAWRMODE_2828 { get { return Parameter[4]; } set { this.Parameter[4] = value; } }
        public byte DATARDMODE_2828 { get { return Parameter[5]; } set { this.Parameter[5] = value; } }
        public byte REG_2828_RDMODE { get { return Parameter[6]; } set { this.Parameter[6] = value; } }
        public byte BrigeSel { get { return Parameter[7]; } set { this.Parameter[7] = value; } }

        public void SetInterfaceParm(int index) { }
        public void Comm_RegWrite() { Console.WriteLine("XM_Mipi Write Reg "); }
        public void Comm_RegRead() { Console.WriteLine("XM_Mipi Read Reg "); }
        public void Comm_IO() { Console.WriteLine("XM_Mipi Comm_IO"); }
        public bool Dev_Open(ushort Vid, ushort Pid) { return true; }
        public bool Dev_Close(ushort Vid, ushort Pid) { return true; }

        private const uint IOCTL_GPIO_WRITE = 0x8B;
        private const uint IOCTL_EPP_ADDR = 0x83;
        private const byte RWSCANNER_EPPCTL_8BIT = 0x00;
        private const byte RWSCANNER_EPPCTL_16BIT = 0x82;

        public bool AddrWr(byte Data){return Epp2USB.GLWriteEPPAddressPort(Data);}
        public bool DataWr(byte Data){return Epp2USB.GLWriteEPPDataPort(Data);}
        public byte DataRd(){return Epp2USB.GLReadEPPDataPort();}

        public byte DataDummyRd()
        {
            byte value = DataRd();      
            return DataRd();
        }

        public bool Bridge_DataWr(byte Data)
        {
            bool ret = BdgSel();
            ret = AddrWr(DATAWRMODE_2828);
            ret = DataWr(Data);
            ret = UnBgeSel();
            return ret;
        }

        public bool Bridge_DataWrNoCs(byte Data)
        {
            return AddrWr(DATAWRMODE_2828) && DataWr(Data);
        }

        public bool Bridge_AddrWrNoCs(byte Data)
        {
            return AddrWr(ADDRWRMODE_2828) && DataWr(Data);
        }

        public bool Bridge_AddrWr(byte Data)
        {
            bool ret  = BdgSel();
            ret = AddrWr(ADDRWRMODE_2828);
            ret = DataWr(Data);
            ret = UnBgeSel();
            return ret;
        }

        /* 
         *  1.Write Data to Register 
         *  2.Switch Mode with 2828 Reg: 0xfa
         *  3.Switch FPGA Read Mode Reg:0x8d
         *  4.Read 
        */
        public bool Bridge_ReadReg(byte xRegAddr, ref uint xRegVal, int Num)
        {
            //bool ret = BdgSel(false);
            bool ret = BdgSel();
            if (Num < 1 || Num > 4) return false;
            if (!Bridge_AddrWrNoCs(xRegAddr)) return false;
            if (!Bridge_AddrWrNoCs(REG_2828_RDMODE)) return false;
            if (!AddrWr(DATARDMODE_2828)) return false;
            for (int i = 0; i < Num; i++)  xRegVal +=  (uint)DataDummyRd() << (8*i);
            ret = UnBgeSel();
            return ret;
        }

        public bool Bridge_ReadReg(byte xRegAddr, int Num, ref uint xRegVal)
        {
            xRegVal = 0;
            //bool ret = BdgSel(false);
            bool ret = BdgSel();
            if (Num < 1 || Num > 4) return false;
            if (!Bridge_AddrWrNoCs(xRegAddr)) return false;
            if (!Bridge_AddrWrNoCs(REG_2828_RDMODE)) return false;
            if (!AddrWr(DATARDMODE_2828)) return false;
            for (int i = 0; i < Num; i++) xRegVal += (uint)DataDummyRd() << (8 * i);
            ret = UnBgeSel();
            return ret;
        }

        public bool Bridge_RdRegNoCs(byte xRegAddr, ref uint xRegVal, int Num)
        {
            xRegVal = 0;
            if (Num < 1 || Num > 4) return false;
            if (!Bridge_AddrWrNoCs(xRegAddr) ) return false;
            if (!Bridge_AddrWrNoCs(REG_2828_RDMODE)) return false;
            if (!AddrWr(DATARDMODE_2828)) return false;
            for (int i = 0; i < Num; i++) xRegVal += (uint)DataDummyRd() << (8 * i);
            return true;
        }

        public bool Bridge_RdRegNoCs(byte xRegAddr, int Num,ref uint xRegVal)
        {
            //xRegVal = 0;
            //if (Num < 1 || Num > 4) return false;
            //if (!Bridge_AddrWrNoCs(xRegAddr)) return false;
            //if (!Bridge_AddrWrNoCs(REG_2828_RDMODE)) return false;
            //if (!AddrWr(DATARDMODE_2828)) return false;
            //for (int i = 0; i < Num; i++) xRegVal += (uint)DataDummyRd() << (8 * i);
            //return true;
            xRegVal = 0;
            if (Num < 1 || Num > 4) return false;
            if (!Bridge_AddrWrNoCs(xRegAddr)) return false;
            if (!AddrWr(0x8d)) return false;
            DataRd();
            for (int i = 0; i < Num + 1; i++) xRegVal += ((uint)DataRd()) << (8 * (Num - i));
            return true;
        }

        public bool Bridge_WriteReg(byte Addr, byte Data)
        {
            byte[] WrData = new byte[4];
            bool ret = BdgSel();
            WrData[0] = ADDRWRMODE_2828;
            WrData[1] = Addr;
            WrData[2] = DATAWRMODE_2828;
            WrData[3] = Data;
            ret = CommBase_WriteCmd(WrData, WrData.Length);
            UnBgeSel();
            return ret;
        }

        public bool Bridge_WrRegNoCs(byte Addr, byte Data)
        {
            byte[] WrData = new byte[4];
            WrData[0] = ADDRWRMODE_2828;
            WrData[1] = Addr;
            WrData[2] = DATAWRMODE_2828;
            WrData[3] = Data;
            return CommBase_WriteCmd(WrData, WrData.Length);
        }

        public bool Bridge_WrRegNoCs(byte Addr, byte empty ,byte Data_H, byte Data_L)
        {
            bool ret = CommBase_WriteReg(0x8b, Addr);
           // ret = CommBase_WriteReg(0x8c, Data_L, Data_H);
            ret = CommBase_WriteReg(0x8c,empty, Data_H,Data_L );
            return ret;
        }

        public bool Bridge_WriteReg(byte Addr, byte Data_H, byte Data_L)
        {
            bool ret = BdgSel();
            ret = CommBase_WriteReg(0x8b, Addr);
            ret = CommBase_WriteReg(0x8c, Data_L, Data_H);
            ret = UnBgeSel();
            return ret;
        }

        public bool CommBase_ReadReg(byte xRegBuf, ref byte xRegVal)
        {
            xRegVal = 0;
            bool ret = AddrWr(xRegBuf);
            xRegVal = DataRd();
            return ret;
        }

        public bool CommBase_ReadReg(byte xRegBuf, ref ushort xRegVal)
        {
            xRegVal = 0;
            bool ret = AddrWr(xRegBuf);
            xRegVal = DataRd();
            return ret;
        }

        //xRegVal = (xRegVal << 8) + SL_DataRead();
        public bool CommBase_ReadReg(byte xRegBuf, ref uint xRegVal, int Num)
        {
            xRegVal = 0;
            if (Num < 1 || Num > 4) return false;
            bool ret = AddrWr(xRegBuf);
           
            for (int i = 0; i < Num; i++)
                xRegVal = (xRegVal << 8) + DataRd();

            return ret;
        }

        //word
        public bool CommBase_ReadReg(byte xRegBuf, byte[] xRegVal, int Num)
        {
            if (Num < 1) return false;
            bool ret = AddrWr(xRegBuf);
            for (int i = 0; i < Num; i++)
                xRegVal[i] = DataRd();

            return ret;
        }

        public bool CommBase_MassRead(ref byte[] xferBuf, int xbufLen, bool Mass)
        {
            bool ret = true;
            if (!AddrWr(DATARDMODE)) return false;
            if (Mass)
            {
                IntPtr ReadBackDatapPtr = Marshal.AllocHGlobal(xbufLen);
                ret = Epp2USB.UsbReadScanner(ReadBackDatapPtr, (uint)xbufLen, RWSCANNER_EPPCTL_8BIT);
                Marshal.Copy(ReadBackDatapPtr, xferBuf, 0, xbufLen); //ReadBackDatapPtr to xferBuf
                Marshal.FreeHGlobal(ReadBackDatapPtr);
            }
            else
            {
                for (int i = 0; i < xbufLen; i++)
                    xferBuf[i] = DataRd();
            }
            return ret;
        }

        public bool CommBase_MassRead(uint wCmd, int wCmdLen, ref byte[] xferBuf, int xbufLen)
        {
            if (xferBuf.Length < xbufLen) return false;
            if (wCmdLen < 1 || wCmdLen > 4) return false;
            if (!AddrWr(ADDRWRMODE)) return false;
            for (int i = wCmdLen; i > 0; i--)
                if (!DataWr((byte)((wCmd >> (8 * (wCmdLen - 1))) & 0xff))) return false;

            if (!AddrWr(DATARDMODE)) return false;
            IntPtr ReadBackDatapPtr = Marshal.AllocHGlobal(xbufLen);
            bool ret = Epp2USB.UsbReadScanner(ReadBackDatapPtr, (uint)xbufLen, RWSCANNER_EPPCTL_8BIT);
            Marshal.Copy(ReadBackDatapPtr, xferBuf, 0, xbufLen); //ReadBackDatapPtr to xferBuf
            Marshal.FreeHGlobal(ReadBackDatapPtr);
            return ret ;
        }

        public bool CommBase_Read(ref uint xferBuf, int xbufLen)
        {
            if (xbufLen > 5) return false;
            if (!AddrWr(DATARDMODE)) return false;

            for (int i = 0; i < xbufLen; i++)
                xferBuf = (xferBuf << 8) + DataRd();

            return true;
        }

        public bool CommBase_Read(uint wCmd, int wCmdLen, ref uint xferBuf, int xbufLen)
        {
            xferBuf = 0;
            if (wCmdLen < 1 || wCmdLen > 4) return false;
            if (!AddrWr(ADDRWRMODE)) return false;
            for (int i = wCmdLen; i > 0; i--)
                if (!DataWr((byte)((wCmd >> (8 * (wCmdLen - 1))) & 0xff))) return false;

            if (!AddrWr(DATARDMODE)) return false;

            for (int i = 0; i < xbufLen; i++)
                xferBuf = (xferBuf << 8) + DataRd();

            return true;
        }
     
        public bool CommBase_WriteCmd(byte[] xferBuf, int xbufLen)
        {

            if (xferBuf.Length < xbufLen || xbufLen > 64) return false;
            if (xbufLen % 2 == 1) return false;
            IntPtr WriteDataPtr = Marshal.AllocHGlobal(xbufLen);
            Marshal.Copy(xferBuf, 0, WriteDataPtr, xbufLen); // xferBuf to WriteDataPtr
            bool ret = Epp2USB.UsbWriteCommand(WriteDataPtr, xbufLen);
            Marshal.FreeHGlobal(WriteDataPtr);
            return ret;
        }

        public bool CommBase_MassDataWrScan(byte[] xferBuf)
        {
            bool Ret = true;
            int xferLen = xferBuf.Length -1;
            if (!AddrWr(xferBuf[0])) return false;
            IntPtr WriteDataPtr = Marshal.AllocHGlobal(xferLen);
            Marshal.Copy(xferBuf, 1, WriteDataPtr, xferLen); // xferBuf to WriteDataPtr
            Ret = Epp2USB.UsbWriteScanner(WriteDataPtr, (uint)xferLen, RWSCANNER_EPPCTL_8BIT);
            Marshal.FreeHGlobal(WriteDataPtr);
            return Ret;
        }

        public bool CommBase_AddrWrite(byte[] wCmd)
        {
          if (!AddrWr(ADDRWRMODE)) return false;
          foreach (byte Val in wCmd)
              if (!DataWr(Val)) return false;

          return true;
        }

        public bool CommBase_MassDataWr(byte[] xferBuf)
        {
            bool Ret = true;
            int xferLen = xferBuf.Length;
            if (!AddrWr(DATAWRMODE)) return false;
            IntPtr WriteDataPtr = Marshal.AllocHGlobal(xferLen);
            Marshal.Copy(xferBuf, 0, WriteDataPtr, xferLen); // xferBuf to WriteDataPtr
            Ret = Epp2USB.UsbWriteScanner(WriteDataPtr, (uint)xferLen, RWSCANNER_EPPCTL_8BIT);
            Marshal.FreeHGlobal(WriteDataPtr);
            return Ret;
        }

        public bool CommBase_MassDataWrGpio(byte[] xferBuf)
        {
            bool Ret = true;
            int xferLen = xferBuf.Length;
            if (!AddrWr(DATAWRMODE)) return false;
            IntPtr WriteDataPtr = Marshal.AllocHGlobal(xferLen);
            Marshal.Copy(xferBuf, 0, WriteDataPtr, xferLen); // xferBuf to WriteDataPtr
            Ret = Epp2USB.UsbWriteScanner(WriteDataPtr, (uint)xferLen, RWSCANNER_EPPCTL_16BIT);
            Marshal.FreeHGlobal(WriteDataPtr);
            return Ret;
        }

        public bool DDR_MassWrite(uint wCmd, int wCmdLen, byte[] xferBuf, int wDataLen)
        {
            bool ret = true;
            if (wDataLen > xferBuf.Length) return false;
            if (wCmdLen < 1 || wCmdLen > 4) return false;
            IntPtr WriteDataPtr = Marshal.AllocHGlobal(wDataLen);

            for (int i = wCmdLen; i > 0; i--)
                if (!AddrWr((byte)((wCmd >> (8 * (wCmdLen - 1))) & 0xff))) return false;

            Marshal.Copy(xferBuf, 0, WriteDataPtr, wDataLen); // xferBuf to WriteDataPtr
            ret = Epp2USB.UsbWriteScanner(WriteDataPtr, (uint)wDataLen, RWSCANNER_EPPCTL_8BIT);
            Marshal.FreeHGlobal(WriteDataPtr);
            return ret;
        }

        public bool CommBase_Write(uint wCmd, int wCmdLen, uint wData, int wDataLen)
        {
            bool ret = true;
            if (!AddrWr(ADDRWRMODE)) return false;
            if (wCmdLen < 0 || wCmdLen > 4) return false;

            for (int i = wCmdLen; i > 0; i--)
                ret = DataWr((byte)((wCmd >> (8 * (wCmdLen - 1))) & 0xff));

            if (!ret) return false;
            if (wDataLen > 4 || wDataLen < 0) return false;

            if (!AddrWr(DATAWRMODE)) return false;

            for (int i = wDataLen; i > 0; i--)
                ret = DataWr((byte)((wData >> (8 * (wDataLen - 1))) & 0xff));

            return ret;
        }

        //FPGA : Write Reg Value by Name
        public bool CommBase_WriteReg(string RegName, uint Val)
        {
            XM_Param_Util PramUtil = new XM_Param_Util();
            if (XM_Param_Util.ListRegInfo == null) return false;
            return CommBase_WriteReg(RegName, Val, PramUtil.GetWriteNum(RegName));
        }

        //FPGA :Write Reg Value by Name
        public bool CommBase_WriteReg(string RegName, uint Val, int xbufLen)
        {
            uint RegVal = 0;
   
            XM_Param_Util PramUtil = new XM_Param_Util();
            if (XM_Param_Util.ListRegInfo == null) return false;
            byte RegAddr = PramUtil.GetAddrByName(RegName);
            if (CommBase_ReadReg(RegAddr, ref RegVal, xbufLen))
            {
                uint RegData = PramUtil.AutoLoopUpGetData(RegName, RegVal, Val);
                if (CommBase_WriteReg(RegAddr, RegData, (uint)xbufLen)) return true;
            }
            return false;
        }

        //FPGA :Write Value by Addr 
        public bool CommBase_WriteReg(byte addr, uint Value, uint xbufLen)
        {
            byte[] data = new byte[4];
            bool ret = true;
            if (xbufLen < 1) return false;
            for (int i = 0; i < 4; i++)
            {
                data[i] = (byte)(Value & 0xff);
                Value = Value >> 8;
            }

            switch (xbufLen)
            {
                case 1:
                    ret = CommBase_WriteReg(addr, data[0]);
                    break;
                case 2:
                    ret = CommBase_WriteReg(addr, data[1], data[0]);
                    break;
                case 3:
                    ret = CommBase_WriteReg(addr, data[2], data[1], data[0]);
                    break;
                case 4:
                    ret = CommBase_WriteReg(addr, data[3], data[2], data[1], data[0]);
                    break;
            }

            return ret;
        }

        public bool CommBase_WriteReg(byte addr, byte data)  
        {
            return AddrWr(addr) && DataWr(data);
        }
              
        public bool CommBase_WriteReg(byte addr, byte data, byte data1)
        {
            return AddrWr(addr) && DataWr(data) && DataWr(data1);
        }

        public bool CommBase_WriteReg(byte addr, byte data, byte data1, byte data2)
        {
            return AddrWr(addr) && DataWr(data) && DataWr(data1) && DataWr(data2);
        }

        public bool CommBase_WriteReg(byte addr, byte data, byte data1, byte data2, byte data3)
        {
            return AddrWr(addr) && DataWr(data) && DataWr(data1) && DataWr(data2) && DataWr(data3); 
        }

        //public byte ChipSel()
        //{
        //    return (byte)(~BrigeSel & 0x11);
        //}

        public bool BdgSel()
        {
            //byte Data = BrigeSel, Val = 0;
            //if(!WrEn) Data = (BrigeSel == 0x11) ? (byte)0x10 : (byte)BrigeSel;
            //Val = (byte)(~Data & 0x11);
            return CommBase_WriteReg(0xb2, 0x01) && CommBase_WriteReg(0xb3,0x10);
        }

        public bool UnBgeSel()
        {
            return AddrWr(0xb3) && DataWr(0x11);
        }

        public bool CommDelay(double XmPlusData)
        {
            Thread.Sleep((int)XmPlusData);
            return true;
        }

        public bool I2CWrite(byte I2CAddr,byte[] xferBuf)
        {
            byte[] I2CVal = new byte[2];
            I2CVal[0] = I2CVal[1] = 0x80;

            I2CVal[0] = 0x9b; I2CVal[1] = 0x00;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(I2CVal, I2CVal.Length);//i2c Start

            I2CVal[0] = 0x9b; I2CVal[1] = 0x02;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(I2CVal, I2CVal.Length);//i2c Start

            I2CVal[0] = 0x80; I2CVal[1] = I2CAddr;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(I2CVal, I2CVal.Length);//Slave Address

            foreach (byte Data in xferBuf)
            {
                I2CVal[1] = Data;
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(I2CVal,I2CVal.Length);
            }

            I2CVal[0] = 0x9b; I2CVal[1] = 0x00;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(I2CVal, I2CVal.Length);//i2c Start

            I2CVal[0] = 0x9b; I2CVal[1] = 0x01;
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteCmd(I2CVal, I2CVal.Length);//i2c Start
            return true;
        }
    }
}
