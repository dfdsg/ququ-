using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Management; // need to add System.Management to your project references.
using System.Collections;

namespace XM_Tek_Studio_Pro
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
     
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Splash());
            Application.Run(new Main_Form());
        }
    }

    //--------------------------------------------------------------------
    public static class Parm
    {
        public static bool Usb_bConn = false;
        public static XMUsbDevInfo XMUsbDev = null;
        public static uint[] flashbuf = new uint[256];
    }

    public class XMUsbDevInfo
    {
        public XMUsbDevInfo(string DevID, ushort DevVID, ushort DevPID)
        {
            this.DevID = DevID;
            this.DevVID = DevVID;
            this.DevPID = DevPID;
        }
        public string DevID { get; private set; }
        public ushort DevVID { get; private set; }
        public ushort DevPID { get; private set; }
    }

    internal sealed partial class XMPLUSPARS
    {
        internal const string SECTION1 = "DEVICE";
        internal const string COLORDEV = "COLORDEV";
        internal const string SECTION2 = "COMM";
        internal const string SECTION3  = "COLOR";
        internal const string COMPORT = "Comport";
        internal const string BAUDRATE = "Baudrate";
        internal const string DATABIT = "Databit";
        internal const string PARITY = "Parity";
        internal const string STOPBIT = "Stopbit";

    }


  



   
}
