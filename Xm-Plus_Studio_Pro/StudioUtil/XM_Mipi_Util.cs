#define DEBUG
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace XM_Tek_Studio_Pro.StudioUtil
{
    class XM_Comm_Mipi 
    {
        public void MipiBridgeSelect(byte SelVal)
        {
            XM_Comm_Control.XM_Comm_Base.BrigeSel = SelVal;
        }

        public bool ImageFill(byte R, byte G, byte B)
        {
            XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb7, 0x02, 0x59);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x92, 0x20);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xad, R, G, B);
            return true;
        }

        public bool MipiWrite(byte[] Data)
        {
            byte[] WolValue = Data;
            int DataNum = WolValue.Length - 1;
            byte HD = 0, M_HD = 0, M_LD = 0, LD = 0, ConfRegH = 0, ConfRegL = 0;

            //General Packet
            if (WolValue[0] == 0x29) { ConfRegH = 0x06; ConfRegL = 0x10; }
            if (WolValue[0] == 0x03 || WolValue[0] == 0x13 || WolValue[0] == 0x23) { ConfRegH = 0x02; ConfRegL = 0x10; }
            //DCS
            if (WolValue[0] == 0x39) { ConfRegH = 0x06; ConfRegL = 0x50; }
            if (WolValue[0] == 0x05 || WolValue[0] == 0x15) { ConfRegH = 0x02; ConfRegL = 0x50; }

            LD = (byte)(DataNum & 0xff);
            M_LD = (byte)((DataNum >> 8) & 0xff);
            M_HD = (byte)((DataNum >> 16) & 0xff);
            HD = (byte)((DataNum >> 24) & 0xff);

            if (XM_ExeWol_Util.modeselect == 0x03)
            {
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb7, ConfRegH, ConfRegL);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xbd, HD, M_HD);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xbc, M_LD, LD);

                XM_Comm_Control.XM_Comm_Base.BdgSel();
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8b, 0xbf);

                //XM_Comm_Control.XM_Comm_Base.AddrWr(0x8c);
                //for (int i = 1; i < WolValue.Length; i++)
                //    XM_Comm_Control.XM_Comm_Base.DataWr(WolValue[i]);

                for (int i = 1; i < WolValue.Length; i++)
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, WolValue[i]);
                XM_Comm_Control.XM_Comm_Base.UnBgeSel();

                return true;
            }
            else
            {
               XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb7, 0x00, ConfRegH, ConfRegL);
               XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbd, 0x00, HD, M_HD);
               XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbc, 0x00, M_LD, LD);
               XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8b, 0xbf);

                    switch (DataNum % 3)
                    {
                        case 0:
                            for (int i = 1; i < DataNum; i += 3)
                            {
                                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, WolValue[i + 2], WolValue[i + 1], WolValue[i]);
                            }
                            break;
                        case 1:
                            for (int i = 1; i < DataNum - 1; i += 3)
                            {
                                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, WolValue[i + 2], WolValue[i + 1], WolValue[i]);
                            }
                            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, 0x00, 0x00, WolValue[DataNum]);
                            break;
                        case 2:
                            for (int i = 1; i < DataNum - 2; i += 3)
                            {
                                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, WolValue[i + 2], WolValue[i + 1], WolValue[i]);
                            }
                            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, 0x00, WolValue[DataNum], WolValue[DataNum - 1]);
                            break;
                    }
                    return true;
                }
        }

        public bool MipiHSWrite(byte[] Data)
        {
            byte[] WolValue = Data;
            int DataNum = WolValue.Length - 1;
            byte HD = 0, M_HD = 0, M_LD = 0, LD = 0, ConfRegH = 0, ConfRegL = 0;

            //General Packet
            if (WolValue[0] == 0x29) { ConfRegH = 0x06; ConfRegL = 0x19; }
            if (WolValue[0] == 0x03 || WolValue[0] == 0x13 || WolValue[0] == 0x23) { ConfRegH = 0x02; ConfRegL = 0x19; }
            //DCS
            if (WolValue[0] == 0x39) { ConfRegH = 0x06; ConfRegL = 0x50; }
            if (WolValue[0] == 0x05 || WolValue[0] == 0x15) { ConfRegH = 0x02; ConfRegL = 0x59; }

            LD = (byte)(DataNum & 0xff);
            M_LD = (byte)((DataNum >> 8) & 0xff);
            M_HD = (byte)((DataNum >> 16) & 0xff);
            HD = (byte)((DataNum >> 24) & 0xff);
            if (XM_ExeWol_Util.modeselect == 0x03)
            {
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xb7, ConfRegH, ConfRegL);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xbd, HD, M_HD);
                XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xbc, M_LD, LD);

                XM_Comm_Control.XM_Comm_Base.BdgSel();
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8b, 0xbf);
                for (int i = 1; i < WolValue.Length; i++)
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, WolValue[i]);
                XM_Comm_Control.XM_Comm_Base.UnBgeSel();
                return true;
            }
            else
            {
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xb7, 0x00, ConfRegH, ConfRegL);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbd, 0x00, HD, M_HD);
                XM_Comm_Control.XM_Comm_Base.Bridge_WrRegNoCs(0xbc, 0x00, M_LD, LD);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8b, 0xbf);

                switch (DataNum % 3)
                {
                    case 0:
                        for (int i = 1; i < DataNum; i += 3)
                        {
                            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, WolValue[i + 2], WolValue[i + 1], WolValue[i]);
                        }
                        break;
                    case 1:
                        for (int i = 1; i < DataNum - 1; i += 3)
                        {
                            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, WolValue[i + 2], WolValue[i + 1], WolValue[i]);
                        }
                        XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, 0x00, 0x00, WolValue[DataNum]);
                        break;
                    case 2:
                        for (int i = 1; i < DataNum - 2; i += 3)
                        {
                            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, WolValue[i + 2], WolValue[i + 1], WolValue[i]);
                        }
                        XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x8c, 0x00, WolValue[DataNum], WolValue[DataNum - 1]);
                        break;
                }
                return true;
            }
        }
    }
}
