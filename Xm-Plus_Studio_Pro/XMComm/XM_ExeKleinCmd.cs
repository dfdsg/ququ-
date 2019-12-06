using KClmtrBase.KClmtrWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace XM_Tek_Studio_Pro.XMComm
{
    class XM_ExeKleinCmd_Util : XM_ExeCmd
    {
        public KClmtrWrap kClmtr;
        enum CmdType { Read, Write, WrAndRd }
        private string Message = null;
        public bool ExcuteCmd(string XMCmd, byte XMType, int Delay, byte XmCategory, ref string RdStr)
        {
            bool ret = true;

            if (kClmtr == null) { RdStr = "kClmtr Err"; return false; }

            if (RunInfo.FoundLoopList.Count > 0) { RunInfo.XmCmdInfo.Excute = false; return false; }
            if (RunInfo.RunLoop == null && RunInfo.RunLoopList.Count > 0) { RunInfo.XmCmdInfo.Excute = false; return false; };

            string[] XmCmd = (string[])MergeXMCmds(XMCmd.Trim()).ToArray(typeof(string));
            string[] XmPlusData = ExchangeXmData(RunInfo.RunLoopList, XmCmd, RunInfo.XmCmdInfo, XmCategory);

            if (XM_Cmd_Lib.xmd[59] == XmCmd[0]) ret = XmKleinFlickerRead(XmPlusData, ref RdStr);
            if (XM_Cmd_Lib.xmd[60] == XmCmd[0]) ret = XmKleinBrightRead(XmPlusData, ref RdStr);


            return ret;
        }

        private void KClmtr_MeasureEvent(object sender, MeasureEventArgs e)
        {
            wMeasurement measure = e.Measurement;
            Message = string.Concat(measure.CIE1931_x.ToString(), ",");
            Message = string.Concat(Message,measure.CIE1931_y.ToString(), ",");
            Message = string.Concat(Message,measure.BigY.ToString(), ",");
        }

        private void KClmtr_FlickerEvent(object sender, FlickerEventArgs e)
        {
            wFlicker Measure = e.Flicker;
            int ErroCode = Measure.FlickerDB.v.Length;
            ErroCode = Measure.FlickerPercent.v.Length;
            ErroCode = Measure.PeakFrequencyDB.v.Length;
            ErroCode = Measure.PeakFrequencyPercent.v.Length;
            ErroCode = Measure.Nits.v.Length;
            ErroCode = Measure.Counts.v.Length;
            Message = string.Concat(Message, " , ", Measure.PeakFrequencyDB.v.GetValue(0, 0).ToString());
        }


        private bool XmKleinFlickerRead(string[] EquipCmd, ref string RdStr)
        {
            string Temp = null;
            Message = Temp;
            bool bFlicker = kClmtr.isFlickering;
            if (!bFlicker) { kClmtr.startFlicker(); Thread.Sleep(1500); }
            kClmtr.getFlicker(out wFlicker Measure);
            if(Measure.PeakFrequencyPercent.v.Length == 6)
            {
                Temp = Measure.PeakFrequencyPercent.v.GetValue(0, 0).ToString();
                Message = string.Concat(Message, Temp, ",");
                Temp = Measure.PeakFrequencyPercent.v.GetValue(0, 1).ToString();
                Message = string.Concat(Message, Temp, ",");
                Temp = Measure.PeakFrequencyPercent.v.GetValue(1, 0).ToString();
                Message = string.Concat(Message, Temp, ",");
                Temp = Measure.PeakFrequencyPercent.v.GetValue(1, 1).ToString();
                Message = string.Concat(Message, Temp, ",");
                Temp = Measure.PeakFrequencyPercent.v.GetValue(2, 0).ToString();
                Message = string.Concat(Message, Temp, ",");
                Temp = Measure.PeakFrequencyPercent.v.GetValue(2, 1).ToString();
                Message = string.Concat(Message, Temp);
            }

            if (EquipCmd.Length == 1 && EquipCmd[0].EndsWith("txt")) { SaveKleinMsgToFile( EquipCmd[0], Message); }
            RdStr = Message;
            return true;
        }



        private bool XmKleinBrightRead(string[] EquipCmd, ref string RdStr)
        {
            bool bBright = kClmtr.isMeasure;
            if (!bBright) { kClmtr.startMeasuring(); Thread.Sleep(1500); }
            kClmtr.getMeasreument(out wMeasurement Messure);
            Message = string.Concat(Messure.CIE1931_x.ToString(), ",");
            Message = string.Concat(Message, Messure.CIE1931_y.ToString(), ",");
            Message = string.Concat(Message, Messure.BigY.ToString());
            RdStr = Message;
            if (EquipCmd.Length == 1 && EquipCmd[0].EndsWith("txt")) { SaveKleinMsgToFile(EquipCmd[0], Message); }
            return true;
        }

        public bool Status()
        {
            return true;
        }

    }
}
