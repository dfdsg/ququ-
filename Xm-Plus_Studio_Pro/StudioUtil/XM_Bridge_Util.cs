using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace XM_Tek_Studio_Pro.StudioUtil
{
    public class XMBridgeInfo
    {
        public XMBridgeInfo(string DeviceInfo, string description)
        {
            this.DevInfo = DeviceInfo;
            this.Description = description;
        }
        public string DevInfo { get; private set; }
        public string Description { get; private set; }
    }

    class XM_Dev_Util
    {
        private  List<USBDevInfo> UsbDevs = new List<USBDevInfo>();
        private const string DEV_3R = "3R";
        private const string DEV_SC = "SC";
        private const string DEV_XM = "Xm";
        private const string USBVID = "VID_";
        private const string USBPID = "PID_";
        private string Vid = null, Pid = null;
        public int  GetUSBDevs()
        {
            ManagementObjectCollection collection;
            UsbDevs.Clear();
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity "))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                UsbDevs.Add(new USBDevInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            return UsbDevs.Count;
        }

        public List<XMDevInfo> FindXMDev(string UserDevice)
        {
            List<XMDevInfo> XMDevs = new List<XMDevInfo>();

            foreach (USBDevInfo DevInfo in UsbDevs)
            {
                if (DevInfo.Description != null &&
                    (DevInfo.Description.Contains(DEV_3R) ||
                     DevInfo.Description.Contains(DEV_SC) ||
                     DevInfo.Description.Contains(DEV_XM) ||
                     DevInfo.Description.Contains(UserDevice)))
                {
                    XMDevs.Add(new XMDevInfo(DevInfo.Description, DevInfo.DevID));
                }
            }
            return XMDevs;
        }

        public List<XMDevInfo> FindXMDev()
        {
            List<XMDevInfo> XMDevs = new List<XMDevInfo>();

            foreach (USBDevInfo DevInfo in UsbDevs)
            {
                if (DevInfo.Description != null &&
                    (DevInfo.Description.Contains(DEV_3R) ||
                    DevInfo.Description.Contains(DEV_SC)  ||
                    DevInfo.Description.Contains(DEV_XM)))
                {
                    XMDevs.Add(new XMDevInfo(DevInfo.Description, DevInfo.DevID));
                }
            }         
            return XMDevs;
        }

        public bool DevCmp(XMBridgeInfo[] PastDevs , XMBridgeInfo[] NowDevs)
        {
            if (PastDevs.Length != NowDevs.Length) return false;
            for(int i = 0;i< PastDevs.Length;i++)
            {
                if (PastDevs[i].Description != NowDevs[i].Description) return false;
                if (PastDevs[i].DevInfo != NowDevs[i].DevInfo) return false;
            }
            return true;
        }


        public bool GetDevItem(string devStr)
        {
            int VidAddr = devStr.IndexOf(USBVID, 0);
            int PidAddr = devStr.IndexOf(USBPID, 0);
            if(VidAddr > 0 && PidAddr >0)
            {
                this.Vid = devStr.Substring(VidAddr+4, 4);
                this.Pid = devStr.Substring(PidAddr+4, 4);
                return true;
            }
            return false;
        }

        public int GetVid() { return ushort.Parse(this.Vid,System.Globalization.NumberStyles.HexNumber);  }
        public int GetPid() { return ushort.Parse(this.Pid, System.Globalization.NumberStyles.HexNumber); }
        public string GetStrVid() { return this.Vid; }
        public string GetStrPid() { return this.Pid; }
        public string GetRootDevInfo(string devInfo) { return devInfo.Substring(10, devInfo.Length - 10); }

        public class XMDevInfo
        {
            public XMDevInfo(string DevID, string Description)
            {
                this.DevID = DevID;
                this.Description = Description;
            }
            public string DevID { get; private set; }
            public string Description { get; private set; }
        }

        private class USBDevInfo
        {
            public USBDevInfo(string DevID, string PnpDevID, string description)
            {
                this.DevID = DevID;
                this.PnpDevID = PnpDevID;
                this.Description = description;
            }
            public string DevID { get; private set; }
            public string PnpDevID { get; private set; }
            public string Description { get; private set; }
        }
    }
}
