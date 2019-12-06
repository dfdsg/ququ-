using System;
using System.Collections.Generic;

namespace XM_Tek_Studio_Pro.StudioUtil
{
    public class XM_SDCard_Util
    {
        private const int WM_VSCROLL = 0x115;
        private const int WM_SETREDRAW = 0x0B;
        private const int SB_BOTTOM = 0x0007;

        IntPtr eventMask = IntPtr.Zero;

        /// <summary>
        /// Scrolls the vertical scroll bar of a multi-line text box to the bottom.
        /// </summary>
        /// <param name="tb">The text box to scroll</param>
        public static void ScrollToBottom(System.Windows.Forms.Control RichTextBox)
        {         
            XM_Sytem_API.SendMessage(RichTextBox.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
        }

        public static void SuspendDrawing(System.Windows.Forms.Control RichTextBox)
        {
            XM_Sytem_API.SendMessage(RichTextBox.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(System.Windows.Forms.Control RichTextBox)
        {
            XM_Sytem_API.SendMessage(RichTextBox.Handle, WM_SETREDRAW, true, 0);
            RichTextBox.Invalidate(true);
            RichTextBox.Update();
        }

        public void UsbWriteAD02(byte add, byte Data)
        {
            Epp2USB.UsbWriteAD02(add, Data);
        }

        public void UsbWriteAD04(byte add, byte Data, byte add1, byte Data1)
        {
            Epp2USB.UsbWriteAD04(add, Data, add1, Data1);
        }

        public void UsbWriteScanner(IntPtr ptr, uint len, byte eppct)
        {
            Epp2USB.UsbWriteScanner(ptr, (uint)len, eppct);
            // ptr = Marshal.AllocHGlobal((int)bs);
        }

        public void UsbReadScanner(IntPtr ptr, uint len, byte eppct)
        {
            Epp2USB.UsbReadScanner(ptr, (uint)len, eppct);
            // ptr = Marshal.AllocHGlobal((int)bs);
        }

        // uSD.Spi_cs_L.
        public int Spi_cs_L()
        { Epp2USB.UsbWriteAD02(0x90, 0x02); return 0; }

        // uSD.Spi_cs_H 
        public int Spi_cs_H()
        { Epp2USB.UsbWriteAD02(0x90, 0x03); return 0; }

        // Spi_cs_H_wd.
        public  int Spi_cs_H_wd()
        { Epp2USB.UsbWriteAD04(0x90, 0x03, 0x80, 0xff); return 0; }

        // Addr_Wr_Mode.
        public int Addr_Wr_Mode()
        { Epp2USB.GLWriteEPPAddressPort(XM_Comm_Control.XM_Comm_Base.ADDRWRMODE); return 0; }

        // Data_Wr_Mode.
        public int Data_Wr_Mode()
        { Epp2USB.GLWriteEPPAddressPort(XM_Comm_Control.XM_Comm_Base.DATAWRMODE); return 0; }

        // Data_Rd_Mode.
        public int Data_Rd_Mode()
        { Epp2USB.GLWriteEPPAddressPort(XM_Comm_Control.XM_Comm_Base.DATARDMODE); return 0; }

        // rd_8bit.
        public int Rd_8bit(ref int x)
        {
            Epp2USB.GLReadEPPDataPort();
            x = Epp2USB.GLReadEPPDataPort();
            return 0;
        }

        public string Reset_H()
        {
            Epp2USB.UsbWriteAD02(0x90, 0x10);
            string text;
            text = "0x90 0x10 0x00 0x00";
            return text;
        }

        public string Reset_L()
        {
            Epp2USB.UsbWriteAD02(0x90, 0x00);
            string text;
            text = "0x90 0x00 0x00 0x00";
            return text;
        }

        public byte MaxRGB(byte r, byte g, byte b)
        {
            byte max = 0;
            if (r >= g)
                max = r;
            else
                max = g;

            if (max < b)
                max = b;

            return max;
        }

        public int GroBoxResult_X = 0;
        public int GroBoxResult_Y = 0;
        public int TabControl_X = 0;
        public int TabControl_Y = 0;
        public int GroBoxResult_Width = 0;
        public int GroBoxResult_Height = 0;
        public int TabControl_Width = 0;
        public int TabControl_Height = 0;
        public int buttonSaveSDInfo_X = 0;
        public int buttonSaveSDInfo_Y = 0;
        public int buttonLoadSDInfo_X = 0;
        public int buttonLoadSDInfo_Y = 0;
        public int buttonSaveSDInfo_Width = 0;
        public int buttonSaveSDInfo_Height = 0;
        public int buttonLoadSDInfo_Width = 0;
        public int buttonLoadSDInfo_Height = 0;
        public int WindowsForm_Width = 0;
        public int WindowsForm_Height = 0;

        public static bool EnaSDCardGen = false;
        public static bool EnaSDImageGen= false;
        public static string ImageFileName = "";
        public static int ImageNum = 0;
        public  static List <byte> CmdToBin = new List <byte> ();

        public class DowSDCard_Items
        {
            public int Addr { get; set; }
            public int Block_Length { get; set; }
            public int ImageNum { get; set; }
            public string[] ItemFilePath = new string[128];//{ get; set; }
        }

        internal static uint ItemNum = 256;
        public DowSDCard_Items[] SDCard_Item = new DowSDCard_Items[ItemNum];

        public void InitalSDCard_Item()
        {
            for (int i = 0; i < ItemNum; i++)
            {
                SDCard_Item[i] = new DowSDCard_Items();
                SDCard_Item[i].Addr = 0;
                SDCard_Item[i].Block_Length = 1;
                SDCard_Item[i].ImageNum = -1;
            }
        }
    }
}
