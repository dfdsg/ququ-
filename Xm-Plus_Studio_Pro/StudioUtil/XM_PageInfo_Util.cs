using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XM_Tek_Studio_Pro.StudioUtil
{
    public class XmCmdList
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }

        public XmCmdList(int Index, string Name, string FileName)
        {
            this.Index = Index;
            this.Name = Name;
            this.FileName = FileName;
        }
    }

    class XM_PageInfo_Util
    {
        private const int MaxItem = 20;

        private int FindListIndex(List<XmCmdList> lCmdInfo)
        {
            int i = 0;
            for ( i = 0; i < MaxItem; i++)
            {
                if (lCmdInfo.Find(x => x.Index.Equals(i)) == null) break;
            }
            return i;
        }

        public int AddPagetoList(List<XmCmdList> lCmdInfo)
        {
            int index  = FindListIndex(lCmdInfo);
            lCmdInfo.Add(new XmCmdList(index, "Page" + index.ToString(), null));
            return index;
        }

        public int RemovePagetoList(List<XmCmdList> lCmdInfo,string Name)
        {
            int index = -1;
            XmCmdList CmdList = lCmdInfo.Find(x => x.Name.Equals(Name));
            if(CmdList!=null )
            { 
                index = lCmdInfo.IndexOf(CmdList);
                lCmdInfo.RemoveAt(index);
            }
            return index;
        }

        public bool UpdateFileToList(List<XmCmdList> lCmdInfo,string PageName, string FileName)
        {
            if (lCmdInfo.Exists(x => x.Name == PageName))
            {
                XmCmdList CmdList = lCmdInfo.Find(x => x.Name.Equals(PageName));
                int index = lCmdInfo.IndexOf(CmdList);
                CmdList.FileName = FileName;
                lCmdInfo.RemoveAt(index);
                lCmdInfo.Insert(index, CmdList);
            }
            return true;
        }
    }
}
