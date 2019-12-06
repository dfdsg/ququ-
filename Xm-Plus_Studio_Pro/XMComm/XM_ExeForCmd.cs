using System;
using System.Collections.Generic;
using System.Text;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public class LoopLib
    {
        public int StartLine { get; set; }
        public int EndLine { get; set; }
        public int LoopStart { get; set; }
        public int LoopEnd { get; set; }
        public int LoopStep { get; set; }
        public string Formula { get; set; }
        public int Index { get; set; }
        public LoopLib(int StartLine, int EndLine, int SNum, int ENum, int Step, string Type)
        {
            this.StartLine = StartLine;
            this.EndLine = EndLine;
            this.LoopStart = SNum;
            this.LoopEnd = ENum;
            this.LoopStep = Step;
            this.Formula = Type;
            this.Index = 0;
        }
    }
   
    class XM_ExeForCmd_Util : XM_ExeCmd
    {
        public  int num = 0;
        private char[] DelimiterChars = { ' ', ',', '\t' };
        enum CmdType { Read, Write, WrAndRd }
        private LoopLib XmFor;
        public bool  bEndLoop = false;
        public bool ExcuteCmd(string Cmd, byte XmCmdType)
        {
            string[] Parameter = Cmd.Split(DelimiterChars);
            if (XmCmdType == (byte)CmdType.Write)
            {
                MergeCommand(RunInfo.XmCmdInfo, Parameter[0], Parameter);
                if (XM_Cmd_Lib.xmd[44] == Parameter[0]) ExeLoopCmd(RunInfo.RealExeLine, Parameter, RunInfo.FoundLoopList, RunInfo.RunLoop);
                if (XM_Cmd_Lib.xmd[45] == Parameter[0]) ExeEndLoop(RunInfo.RealExeLine, RunInfo.FoundLoopList); bEndLoop = true;
            }
            return true;
        }
        private string ExeLoopCmd(int RunLine, string[] Parameter, List<LoopLib> FoundList, LoopLib RunLoop)
        {
            int Initial = 0, Condition = 0, Iterator = 0;
            StudioUtil.XM_Digital_Util HexUtil = new XM_Digital_Util();
            bool bInitial = HexUtil.StrToNumber<int>(Parameter[1], ref Initial); ;
            bool bCondition = HexUtil.StrToNumber<int>(Parameter[2], ref Condition); 
            bool bIterator = HexUtil.StrToNumber<int>(Parameter[3], ref Iterator);
           
            if (bInitial && bCondition && bIterator)
            {
                XmFor = new LoopLib(RunLine, 0, Initial, Condition, Iterator, Parameter[4]);
                FoundList.Add(XmFor);
                RunLoop = null;
            }
            return null;
        }

        private string ExeEndLoop(int EndLine, List<LoopLib> FoundList)
        {
            if (FoundList.Count > 0)
            {
                for(int Count = FoundList.Count - 1; Count >= 0; Count--)
                {
                    if (FoundList[Count].EndLine == 0)
                    {
                        FoundList[Count].EndLine = EndLine;
                        break;
                    }
                }
            }
            bEndLoop = true;
            return null;
        }
    }
}
