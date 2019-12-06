using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XM_Tek_Studio_Pro.StudioUtil
{
    /*
     * Found out Interface Setting within Script
     */
    class XM_IFSpt_Util
    {
        //private char Split = ' ';
        private string[] Script = null;
        public XM_IFSpt_Util() { }
        public XM_IFSpt_Util(string[] Spt) { this.Script = Spt; }

        public string ReplaceStr(string Message)
        {
            char[] Str = Message.ToCharArray();
            int length = Str.Length;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (Str[i] == '\\')
                {
                    switch (Str[i + 1])
                    {
                        case 't':
                            Message = Message.Remove(i - count, 2);
                            Message = Message.Insert(i - count, "\t");
                            count++;
                            break;
                        case 's':
                            Message = Message.Remove(i - count, 2);
                            Message = Message.Insert(i - count, " ");
                            count++;
                            break;
                        case 'n':
                            Message = Message.Remove(i - count, 2);
                            Message = Message.Insert(i - count, "\n");
                            count++;
                            break;
                    }
                }
            }
            return Message;
        }

        
        public string AppendSplit(string SplitStr)
        {
            string Splict = "\r\n";
            if (string.Compare(SplitStr.ToLower().Trim(), "t") ==0 ) Splict = "\t";
            if (string.Compare(SplitStr.ToLower().Trim(), "n") == 0) Splict = "\r\n";
            if (string.Compare(SplitStr.ToLower().Trim(), "s") == 0) Splict = " ";
            return Splict;

        }

        public bool CmdRegWithSpt(string ParaCmd, int Num,ref byte Reg)
        {
            XM_Digital_Util XmConvert = new XM_Digital_Util();
            string CmdPram = SearchCmdNode(ParaCmd,Num);
            if (!string.IsNullOrEmpty(CmdPram) && XmConvert.StrToNumber<byte>(CmdPram.Trim(), ref Reg))
                return true;
            else
                return false;
            
        }

        private string SearchCmdNode(string Cmd,int Num)
        {
            //Linq
            var EnumQuery =
                from Name in Script
                let Node = Name.Split(' ')
                where Node[0] == Cmd
                select Name.Split(' ')[Num];

            if(EnumQuery.Count() == 1 )
                return EnumQuery.ToList()[0];
            else
                return null;
        }

    }
}
