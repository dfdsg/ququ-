using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace XM_Tek_Studio_Pro.StudioUtil
{
    class XM_Sytem_API
    {
        public const int WM_SETREDRAW = 0x0B;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint RegisterWindowMessage(string lpString);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(IntPtr classname, string title); // extern method: FindWindow

        [DllImport("user32.dll")]
        public static extern void MoveWindow(IntPtr hwnd, int X, int Y,
            int nWidth, int nHeight, bool rePaint); // extern method: MoveWindow

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect
            (IntPtr hwnd, out Rectangle rect); // extern method: GetWindowRect

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        public static void  FindAndMoveMsgBox(string main_form, string parant_form, bool repaint)
        {
            Thread thr = new Thread(() => // create a new thread
            {

                IntPtr msgBox_main = IntPtr.Zero;
                // while there's no MessageBox, FindWindow returns IntPtr.Zero.
                while ((msgBox_main = XM_Sytem_API.FindWindow(IntPtr.Zero, main_form)) == IntPtr.Zero) ;

                Rectangle main = new Rectangle();
                XM_Sytem_API.GetWindowRect(msgBox_main, out main); // Gets the rectangle of the message box

                IntPtr msgBox_parant = IntPtr.Zero;
                // while there's no MessageBox, FindWindow returns IntPtr.Zero
                while ((msgBox_parant = XM_Sytem_API.FindWindow(IntPtr.Zero, parant_form)) == IntPtr.Zero) ;
                Rectangle parant = new Rectangle();
                XM_Sytem_API.GetWindowRect(msgBox_parant, out parant); // Gets the rectangle of the message box
                                                                       // after the while loop, msgBox is the handle of your MessageBox

                XM_Sytem_API.MoveWindow(msgBox_parant /* handle of the message box */,
                                         main.Location.X + (main.Width - main.Location.X) / 2 - (parant.Width - parant.X) / 2,
                                         main.Location.Y + (main.Height - main.Location.Y) / 2 - (parant.Height - parant.Y) / 2,
                                         parant.Width - parant.X /* width of originally message box */,
                                         parant.Height - parant.Y /* height of originally message box */,
                                         repaint /* if true, the message box repaints */);
            });
            thr.Start(); // starts the thread
        }
    }
}
