using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    /*
       class XmPlusCmd
        {
             string Cmd : 
                XmPlus Command
             byte Type :  
                R/W/WR/Found/Save: 0/1/2/3/4
             byte Category :
                0:  No Parameter
                1:  Examine Parameter as String
                2:  Examine Parameter as Numeric
                3:  Examine Parameter as Numeric and Parameter Num Equal
				4.  Examine Parameter as String and Parameter Num Equal
                5:  Examine the last One Item (String,DSI)
				6:  Examine the last One Item (String,For) and compare value
				7.  Examine the last one Item as txt file
				8:  Examine Parameter as Float and the last one is negative
                9.  Examine Parameter as Reg(Numeric) and Parameter Num Equal
                10. Examine Parameter as Reg and the last one Item as txt file
                11. Examine Parameter as Reg, and the last one Item as txt file
                Appendix: Parameters are bigger then zero (all of above)
             int  MaxParm : 
                R/W Paramenter Number  Range: 0~65535
             int MaxValue :  
                0~65535
             byte Class:
                0:  Comm Command
				1:  System Command
                2:  Instrument Command
                3.  XmPlus Command
                4.  For Command
                5.  CA-210 Command
                6.  KLEIN Command
            byte Reg:
                Register Address
            ArrayList Item :
                Special Compare Item
            Delay:
                Delay Time for Next Command Operation
        }
    
        public class ScriptInfo
        {
            public string Command { get; set; } 
                Original Command
            public byte Result { get; set; }
                0: No Error
                1: Warning
                2: Comment
                3: Command Error
				4: Parameter Error
                5: Space
                6: ErrFor
            public string Message { get; set; }
                Errro Report
            public in Line{ get; set; }
                Rows Num
            public Index{ get; set; }
                Index among Array
               
        }
     */
    public class ScriptInfo
    {
        public string Cmd { get; set; }
        public string CleanCmd { get; set; }
        public int Index { get; set; }
        public byte Result { get; set; }
        public string Msg { get; set; }
        public int Line { get; set; }
    }

    public class XmPlusCmd
    {
        public string Cmd { get; set; }
        public byte Type { get; set; }
        public int MaxParm { get; set; }
        public int MaxValue { get; set; }
        public byte Category { get; set; }
        public byte Class { get; set; }
        public byte Reg { get; set; }
        public int Delay { get; set; }
        public int Least { get; set; }
        public ArrayList Item { get; set; }
    }



    public class XmCmdInfo
    {
        public string XmCmd { get; set; }
        public bool Excute { get; set; }
    }

    public class XmResult
    {
        public string XmPlusCmd { get; set; }
        public int Line { get; set; }
        public int End { get; set; }
        public bool Result { get; set; }

        public XmResult(string XmPlusCmd, int Line, int End, bool Result)
        {
            this.XmPlusCmd = XmPlusCmd;
            this.Line = Line;
            this.End = End;
            this.Result = Result;
        }
    }

    //SendCommmand : Deal With SendCommand
    class XM_Cmd_Lib
    {
        private char[] DelimiterChars = { ' ', '\t' };
        private int ElecsOpt = -1;

        private string SplitLine = "\r\n", SendCmd = null;
        private string Comment = "#";
        private readonly string READMSG = Properties.Resources.MSG_SPT_READ;
        private readonly string ERRMSG = Properties.Resources.MSG_SPT_ERR;
        private readonly string WARNMSG = Properties.Resources.MSG_SPT_WARN;
        private readonly string PASSMSG = Properties.Resources.MSG_SPT_PASS;
        private readonly string COMMENTMSG = Properties.Resources.MSG_SPT_COMMENT;
        private readonly string SPACETMSG = Properties.Resources.MSG_SPT_SPACE;
        private readonly string ERRFORMSG = Properties.Resources.MSG_SPT_FORERR;
        private readonly string ERRLACKFOR = Properties.Resources.MSG_SPT_LACKFOR;
        private readonly string ERRLACKENDFOR = Properties.Resources.MSG_SPT_LACKENDFOR;

        public static XmPlusCmd[] DictionXm = new XmPlusCmd[1];
        public enum MSG : byte { PASS, WARN, COMMENT, ERRCMD, ERRPARM, SPACE, ERRFOR };
        public static Dictionary<int, XmPlusCmd[]> valuePairs = new Dictionary<int, XmPlusCmd[]>();
        public static List<string> xmd = new List<string>();

        public XM_Cmd_Lib()
        {
            Help_Form help_Form = new Help_Form();
            string strDir = Directory.GetCurrentDirectory();
            string fileName = strDir + @"\Command List.csv";
            string filename = fileName.Remove(0, fileName.LastIndexOf("\\") + 1);
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName.Remove(fileName.LastIndexOf("\\") + 1) + ";Extended Properties=\"text;HDR=Yes;FMT=Delimited\";";
            OleDbConnection conn = new OleDbConnection(strCon);
            conn.Open();
            string sql = "select * from [" + filename + "]";
            OleDbDataAdapter myCommand = new OleDbDataAdapter(sql, strCon);
            DataSet ds = new DataSet();
            myCommand.Fill(ds, "Command List$");
            help_Form.dataGridView1.DataMember = "Command List$";
            help_Form.dataGridView1.DataSource = ds;
            conn.Close();
            for (int i = 0; i < 1; i++)
            {
                DictionXm[i] = new XmPlusCmd
                {
                    Item = new ArrayList()
                };
            }
            for (int i = 0; i < help_Form.dataGridView1.RowCount - 1; i++)
            {
                XmPlusCmd[] XmPlusCmds = new XmPlusCmd[1];
                for (int k = 0; k < 1; k++)
                {
                    XmPlusCmds[k] = new XmPlusCmd
                    {
                        Item = new ArrayList()
                    };
                }
                XmPlusCmds[0].Cmd = Convert.ToString(help_Form.dataGridView1.Rows[i].Cells[0].Value);
                XmPlusCmds[0].Class = Convert.ToByte(help_Form.dataGridView1.Rows[i].Cells[1].Value);
                XmPlusCmds[0].Type = Convert.ToByte(help_Form.dataGridView1.Rows[i].Cells[2].Value);
                XmPlusCmds[0].Category = Convert.ToByte(help_Form.dataGridView1.Rows[i].Cells[3].Value);
                XmPlusCmds[0].MaxValue = Convert.ToInt32(help_Form.dataGridView1.Rows[i].Cells[4].Value);//maxvalue
                XmPlusCmds[0].MaxParm = Convert.ToInt32(help_Form.dataGridView1.Rows[i].Cells[5].Value);//maxparm
                if (!(help_Form.dataGridView1.Rows[i].Cells[6].Value.ToString().Length == 0))
                { XmPlusCmds[0].Reg = byte.Parse(help_Form.dataGridView1.Rows[i].Cells[6].Value.ToString(), System.Globalization.NumberStyles.HexNumber); }
                if (!(help_Form.dataGridView1.Rows[i].Cells[7].Value.ToString().Length == 0))
                { XmPlusCmds[0].Delay = Convert.ToInt32(help_Form.dataGridView1.Rows[i].Cells[7].Value); }
                if (!(help_Form.dataGridView1.Rows[i].Cells[8].Value.ToString().Length == 0))
                { XmPlusCmds[0].Least = Convert.ToInt32(help_Form.dataGridView1.Rows[i].Cells[8].Value); }
                if ((help_Form.dataGridView1.Rows[i].Cells[9].Value.ToString().Length != 0) &
                   (help_Form.dataGridView1.Rows[i].Cells[10].Value.ToString().Length != 0) &
                   (help_Form.dataGridView1.Rows[i].Cells[11].Value.ToString().Length != 0))
                {
                    XmPlusCmds[0].Item.Add(help_Form.dataGridView1.Rows[i].Cells[9].Value.ToString());
                    XmPlusCmds[0].Item.Add(help_Form.dataGridView1.Rows[i].Cells[10].Value.ToString());
                    XmPlusCmds[0].Item.Add(help_Form.dataGridView1.Rows[i].Cells[11].Value.ToString());
                }
                if ((help_Form.dataGridView1.Rows[i].Cells[9].Value.ToString().Length != 0) &
                   (help_Form.dataGridView1.Rows[i].Cells[10].Value.ToString().Length != 0) &
                   help_Form.dataGridView1.Rows[i].Cells[11].Value.ToString().Length == 0)
                {
                    XmPlusCmds[0].Item.Add(help_Form.dataGridView1.Rows[i].Cells[9].Value.ToString());
                    XmPlusCmds[0].Item.Add(help_Form.dataGridView1.Rows[i].Cells[10].Value.ToString());
                }
                // valuePairs.Add((string)help_Form.dataGridView1.Rows[i].Cells[0].Value, XmPlusCmds);
                valuePairs.Add(i, XmPlusCmds);
            }
            for (int m = 0; m < valuePairs.Count; m++)
            {
                var cmds = valuePairs.ElementAt(m);
                xmd.Add(cmds.Value[0].Cmd);
            }
        }
        /*  1.Exam and Verify the Command Format*/
        public string ExamScript(string[] Commands, List<ScriptInfo> ScriptInfo)
        {
            string ErrResult = null, CleanCmd = null;
            int ErrCode = 0;
            for (int i = 0; i < Commands.Length; i++)
            {
                ScriptInfo Info = new ScriptInfo
                {
                    Cmd = Commands[i].Trim(),
                    Line = i
                };

                if (!ExamCmd(Commands[i].Trim(), ref CleanCmd, ref ErrCode))
                {
                    //  Info.Index = ElecsOpt;
                    Info.CleanCmd = CleanCmd;
                    if (ErrCode == (byte)MSG.ERRCMD)
                    {
                        Info.Msg = this.ErrResult(CleanCmd, i + 1);
                        ErrResult += Info.Msg;
                        Info.Result = (byte)MSG.ERRCMD;
                    }
                    else if (ErrCode == (byte)MSG.ERRPARM)
                    {
                        Info.Msg = this.ErrResult(CleanCmd, i + 1);
                        ErrResult += Info.Msg;
                        Info.Result = (byte)MSG.ERRPARM;
                    }
                    else if (ErrCode == (byte)MSG.WARN) //Warning
                    {
                        Info.Msg = this.WarnResult(CleanCmd, i + 1);
                        ErrResult += Info.Msg;
                        Info.Result = (byte)MSG.WARN;
                    }
                    else if (ErrCode == (byte)MSG.COMMENT)//Comment
                    {
                        Info.Msg = this.CommentResult(CleanCmd, i + 1);
                        Info.Result = (byte)MSG.COMMENT;
                    }
                    else
                    {
                        Info.Msg = this.SpaceResult(CleanCmd, i + 1);
                        Info.Result = (byte)MSG.SPACE;
                    }
                }
                else
                {
                    Info.Msg = this.PassResult(Commands[i].Trim(), i + 1);
                    Info.CleanCmd = CleanCmd;
                    Info.Msg = CleanCmd;
                    Info.Index = ElecsOpt;
                    Info.Result = (byte)MSG.PASS;
                }
                ScriptInfo.Add(Info);
                CleanCmd = null;
            }
            return ErrResult;
        }

        private bool PariedLoop(List<XmResult> XmPlusInfo, int Line)
        {
            int i = 0, Count = XmPlusInfo.Count - 1;
            for (i = Count; i >= 0; i--)
            {
                //if(string.Compare(XmPlusInfo[i].XmPlusCmd, XM_FOR)==0 && XmPlusInfo[i].Result==false)
                if (string.Compare(XmPlusInfo[i].XmPlusCmd, "for") == 0 && XmPlusInfo[i].Result == false)
                {
                    XmPlusInfo[i].Result = true;
                    XmPlusInfo[i].End = Line;
                    break;
                }
            }
            if (i < 0)
            {
                //  XmResult XmInfo = new XmResult(XM_ENDFOR, Line, 0, false);
                XmResult XmInfo = new XmResult("endfor", Line, 0, false);
                XmPlusInfo.Add(XmInfo);
            }
            return true;
        }

        public string VerifyForScript(List<ScriptInfo> ScriptInfo)
        {
            string ErrResult = null;
            string XmCmd = null;
            List<XmResult> XmPlusInfo = new List<XmResult>();

            //Found the for and endfor
            for (int i = 0; i < ScriptInfo.Count; i++)
            {
                if (ScriptInfo[i].Result > 1) continue;
                XmCmd = ScriptInfo[i].CleanCmd.Split(DelimiterChars)[0];
                if (XmCmd.CompareTo("for") == 0)
                {
                    XmResult XmInfo = new XmResult("for", ScriptInfo[i].Line, 0, false);
                    XmPlusInfo.Add(XmInfo);
                }
                if (XmCmd.CompareTo("endfor") == 0) PariedLoop(XmPlusInfo, i);
            }

            //Mark the Wrong Code
            for (int i = 0; i < XmPlusInfo.Count; i++)
            {
                if (string.Compare(XmPlusInfo[i].XmPlusCmd, "for") == 0 && XmPlusInfo[i].Result == false)
                {
                    int End = (i + 1 < XmPlusInfo.Count) ? XmPlusInfo[i + 1].Line : ScriptInfo.Count;

                    for (int j = XmPlusInfo[i].Line; j < End; j++)
                        if (ScriptInfo[j].Result < 2) ScriptInfo[j].Result = (byte)MSG.ERRFOR;

                    ErrResult += ForErrResut(ERRLACKENDFOR, XmPlusInfo[i].Line + 1);
                }
                if (string.Compare(XmPlusInfo[i].XmPlusCmd, "endfor") == 0)
                {
                    int Start = i - 1 >= 0 ? XmPlusInfo[i - 1].End + 1 : 0;
                    for (int j = Start; j <= XmPlusInfo[i].Line; j++)
                        if (ScriptInfo[j].Result < 2) ScriptInfo[j].Result = (byte)MSG.ERRFOR;

                    ErrResult += ForErrResut(ERRLACKFOR, XmPlusInfo[i].Line + 1);
                }
            }

            XmPlusInfo.Clear();
            return ErrResult;
        }

        public byte ExamCmd(ScriptInfo ScriptCmd)
        {
            if (ScriptCmd.Result == 0 || ScriptCmd.Result == 1)
            {
                SendCmd = ScriptCmd.CleanCmd;
                ElecsOpt = ScriptCmd.Index;
                getpara();

            }
            return ScriptCmd.Result;
        }

        public bool ExamCmd(string Cmd, ref string CleanCmd, ref int ErrCode)
        {
            bool ret = true;
            if (CleanComment(Cmd, ref CleanCmd))
            {
                if (!VerifyToken(CleanCmd)) { ErrCode = (byte)MSG.ERRCMD; return false; }  //Verify Main Token
                if (!VerifyParameter(CleanCmd)) { ErrCode = (byte)MSG.ERRPARM; return false; }   //Verify Parameter
                if (!VerifyWarning(CleanCmd)) { ErrCode = (byte)MSG.WARN; ; return false; }
            }
            else
            {
                if (string.IsNullOrEmpty(CleanCmd)) { ErrCode = (byte)MSG.SPACE; }
                if (Cmd.Trim().IndexOf(Comment) == 0) { ErrCode = (byte)MSG.COMMENT; }
                ret = false;
            }
            return ret;
        }

        public string GetCommAddr()
        {

            string CommAddr = null;
            if (DictionXm[0].Class == 1)//class
            {
                string[] Cmds = this.SendCmd.Split(DelimiterChars);
                if (Cmds.Length == 2) CommAddr = Cmds[1].Trim();
            }
            return CommAddr;
        }

        public string GetInstruAddr()
        {

            string DeviceAddr = null;
            if (DictionXm[0].Class == 1)//class
            {
                ArrayList Cmds = MergeElecsCmds(this.SendCmd);
                if (Cmds.Count > 1) DeviceAddr = Cmds[1].ToString();
            }
            return DeviceAddr;
        }

        /*
        0:  Comm Command
		1:  System Command
        2:  Instrument Command
        3.  XmPlus Command
        4.  For Command
        */
        public string GetXmCmd()
        {
            string[] Cmds = (string[])MergeElecsCmds(SendCmd.Trim()).ToArray(typeof(string));

            return this.SendCmd;
        }
        public void getpara()
        {
            valuePairs.TryGetValue(ElecsOpt, out DictionXm);

        }
        public byte GetCmdClass() { return DictionXm[0].Class; }
        public byte GetCmdType() { return DictionXm[0].Type; }
        public byte GetCmdCategory() { return DictionXm[0].Category; }
        public byte GetCmdReg() { return DictionXm[0].Reg; }
        public XmPlusCmd GetXmPlus() { return DictionXm[0]; }
        public string ReadInfo(int Line, string Result) { return READMSG + "[" + Line.ToString() + "]: " + Result.Trim() + SplitLine; }
        public string ReadInfo(XmResult Result) { return READMSG + "[" + Result.Line.ToString() + "]: " + Result.Result + SplitLine; }
        public string ErrResult(string Info, int Line) { return " (Line: " + Line.ToString() + " )  " + ERRMSG + " : " + " " + Info + SplitLine; }
        public string WarnResult(string Info, int Line) { return " (Line: " + Line.ToString() + " )  " + WARNMSG + " : " + " " + Info + SplitLine; }
        public string CommentResult(string Info, int Line) { return " (Line: " + Line.ToString() + " )  " + COMMENTMSG + " : " + " " + Info + SplitLine; }
        public string SpaceResult(string Info, int Line) { return " (Line: " + Line.ToString() + " )  " + SPACETMSG + " : " + " " + Info + SplitLine; }
        public string PassResult(string Info, int Line) { return " (Line: " + Line.ToString() + " )  " + PASSMSG + " : " + " " + Info + SplitLine; }
        public string ForErrResut(string Info, int Line) { return " (Line: " + Line.ToString() + " )  " + ERRFORMSG + " : " + " " + Info + SplitLine; }
        public string GetFullCmd() { return this.SendCmd; }
        private ArrayList MergeElecsCmds(string Command)
        {
            ArrayList eCmdList = new ArrayList();
            string[] SplitStr = Command.Split(DelimiterChars);

            foreach (string CmdStr in SplitStr)
            {
                if (!string.IsNullOrEmpty(CmdStr))
                    eCmdList.Add(CmdStr);
            }

            return eCmdList;
        }

        private bool CleanComment(string Cmd, ref string mCmd)
        {
            bool ret = true;
            if (string.IsNullOrEmpty(Cmd)) return false;
            int CommentAddr = Cmd.Trim().IndexOf(Comment);
            if (CommentAddr < 0) { mCmd = Cmd.Trim(); } // No Comment
            if (CommentAddr == 0) ret = false;
            if (CommentAddr > 0) mCmd = Cmd.Substring(0, CommentAddr).Trim();

            return ret;
        }

        private bool VerifyToken(string Command)
        {
            bool ret = false;
            string[] CmdToken = Command.Split(DelimiterChars);
            for (int i = 0; i < valuePairs.Count; i++)
            {
                var cmdpara = valuePairs.ElementAt(i);
                if (CmdToken[0] == cmdpara.Value[0].Cmd)
                {
                    ElecsOpt = i;
                    ret = true;
                    break;
                }
            }
            getpara();

            return ret;
        }

        public bool VerifyRepeatToken(string[] Command, ref int Image_num)
        {
            bool ret = true;
            Image_num = 0;
            for (int j = 0; j < Command.Length; j++)
            {
                string[] CmdToken = Command[j].Split(DelimiterChars);
                if ((CmdToken[0].CompareTo("mipi.read") == 0) || (CmdToken[0].CompareTo("mipi.read.hs") == 0))
                {
                    ElecsOpt = j;
                    ret = false;
                    getpara();
                    return ret;
                }
                if ((CmdToken[0].CompareTo("image.show") == 0))
                {
                    Image_num++;
                }
            }
            return ret;
        }

        /* warning If the value occurs error, Range: 0~255*/
        private bool VerifyWarning(string Command)
        {

            ArrayList eCmdList = MergeElecsCmds(Command);
            // XmPlusCmd DictionXm[0] = XmPlusCmds[ElecsOpt];
            XM_Digital_Util SlUtil = new XM_Digital_Util();
            int Value = 0;
            int Count = eCmdList.Count;

            if (DictionXm[0].Category == 0 || DictionXm[0].Category == 1 || DictionXm[0].Category == 5) return true;
            if (DictionXm[0].Category == 4) Count = Count - 1;

            if (!((DictionXm[0].Category == 7) || DictionXm[0].Category == 8))
            {
                for (int i = 1; i < Count; i++)
                {
                    if (SlUtil.StrToNumber<int>(eCmdList[i].ToString(), ref Value) && Value > 65536) return false;
                }
            }
            return true;
        }

        private bool VerifyParameter(string Command)
        {
            bool VerifyParm = true, bItemMatch = true;
            ArrayList xCmdList = MergeElecsCmds(Command);
            string[] XPlusCmd = new string[xCmdList.Count - 1];
            /// XmPlusCmd DictionXm[0] = XmPlusCmds[ElecsOpt];
            XM_Digital_Util Util = new XM_Digital_Util();
            XM_IO_Util ExtUtil = new XM_IO_Util();
            int Value = 0, OneVal = 0, SecVal = 0;
            float fValue = 0;
            switch (DictionXm[0].Category)
            {
                case 0:
                    if (xCmdList.Count > 1) VerifyParm = false;
                    break;
                case 1:
                    if (xCmdList.Count < 1 || xCmdList.Count > DictionXm[0].MaxParm) VerifyParm = false;
                    break;
                case 2:
                    if (xCmdList.Count < 1 || xCmdList.Count > DictionXm[0].MaxParm) VerifyParm = false;
                    Array.Copy(xCmdList.ToArray(), 1, XPlusCmd, 0, xCmdList.Count - 1);
                    foreach (string str in XPlusCmd) { if (!Util.ValidStrandRange(str, 0, DictionXm[0].MaxValue, ref Value)) { VerifyParm = false; break; } }
                    break;
                case 3:
                    if (xCmdList.Count != DictionXm[0].MaxParm) VerifyParm = false;
                    Array.Copy(xCmdList.ToArray(), 1, XPlusCmd, 0, xCmdList.Count - 1);
                    foreach (string str in XPlusCmd) { if (!Util.ValidStrandRange(str, 0, DictionXm[0].MaxValue, ref Value)) { VerifyParm = false; break; } }
                    break;
                case 4:
                    if (xCmdList.Count != DictionXm[0].MaxParm) VerifyParm = false;
                    break;
                case 5://Only for DSI Cmd
                    if (xCmdList.Count < 1 || xCmdList.Count > DictionXm[0].MaxParm) VerifyParm = false;
                    Array.Resize(ref XPlusCmd, xCmdList.Count - 2);
                    Array.Copy(xCmdList.ToArray(), 1, XPlusCmd, 0, xCmdList.Count - 2);
                    foreach (string Str in XPlusCmd) { if (!Util.ValidStrandRange(Str, 0, DictionXm[0].MaxValue, ref fValue)) { VerifyParm = false; break; } }
                    foreach (string Str in DictionXm[0].Item) { if (xCmdList[xCmdList.Count - 1].ToString().CompareTo(Str) == 0) { bItemMatch = false; break; } }
                    bItemMatch = !bItemMatch;
                    break;
                case 6: //Only for for Cmd
                    if (xCmdList.Count < 1 || xCmdList.Count > DictionXm[0].MaxParm) VerifyParm = false;
                    Array.Resize(ref XPlusCmd, xCmdList.Count - 2);
                    Array.Copy(xCmdList.ToArray(), 1, XPlusCmd, 0, xCmdList.Count - 2);
                    foreach (string Str in XPlusCmd) { if (!Util.ValidStrandRange(Str, 0, DictionXm[0].MaxValue, ref Value)) { VerifyParm = false; break; } }
                    foreach (string Str in DictionXm[0].Item) { if (xCmdList[xCmdList.Count - 1].ToString().CompareTo(Str) == 0) { bItemMatch = false; break; } }
                    if (!bItemMatch && VerifyParm)
                    {
                        Util.StrToNumber<int>(XPlusCmd[0], ref OneVal); Util.StrToNumber<int>(XPlusCmd[1], ref SecVal);
                        if (xCmdList[xCmdList.Count - 1].ToString().CompareTo("plus") == 0) if (OneVal >= SecVal) VerifyParm = false;
                        if (xCmdList[xCmdList.Count - 1].ToString().CompareTo("minus") == 0) if (OneVal <= SecVal) VerifyParm = false;
                    }
                    bItemMatch = !bItemMatch;
                    break;
                case 7: //Examine file format as Txt File
                    if (xCmdList.Count > DictionXm[0].MaxParm) VerifyParm = false;
                    if (xCmdList.Count > DictionXm[0].Least && !ExtUtil.IsMatchExtName(xCmdList[xCmdList.Count - 1].ToString())) VerifyParm = false;
                    break;
                case 8:
                    if (xCmdList.Count != DictionXm[0].MaxParm) VerifyParm = false;
                    if (Util.StrToNumber<float>(xCmdList[1].ToString(), ref fValue) && fValue < 0) VerifyParm = false;
                    if (Util.StrToNumber<float>(xCmdList[2].ToString(), ref fValue) && fValue > 0) VerifyParm = false;
                    if (xCmdList.Count > 3)
                        foreach (string Str in DictionXm[0].Item) { if (xCmdList[xCmdList.Count - 1].ToString().CompareTo(Str) == 0) { bItemMatch = false; break; } }
                    else
                        bItemMatch = false;

                    bItemMatch = !bItemMatch;
                    break;
                case 9://Only for for Reg
                    if (xCmdList.Count < 2 || xCmdList.Count > DictionXm[0].MaxParm) VerifyParm = false;
                    Array.Copy(xCmdList.ToArray(), 1, XPlusCmd, 0, xCmdList.Count - 1);
                    foreach (string Str in XPlusCmd)
                    {
                        if (Util.ValidStrandRange(Str, 0, DictionXm[0].MaxValue, ref Value)) continue;//Only for numeral
                        if (Str.Length < 3 || Str.Substring(0, 3).ToLower().CompareTo("reg") != 0) { VerifyParm = false; break; } //Only for Reg                    
                    }
                    break;
                case 10:
                    if (xCmdList.Count < 2 || xCmdList.Count > DictionXm[0].MaxParm) VerifyParm = false;
                    int Length = (xCmdList.Count == DictionXm[0].MaxParm) ? xCmdList.Count - 2 : xCmdList.Count - 1;
                    Array.Copy(xCmdList.ToArray(), 1, XPlusCmd, 0, Length);
                    Array.Resize(ref XPlusCmd, Length);
                    foreach (string Str in XPlusCmd)
                    {
                        if (Util.ValidStrandRange(Str, 0, DictionXm[0].MaxValue, ref Value)) continue;//Only for numeral
                        if (Str.Length < 3 || Str.Substring(0, 3).ToLower().CompareTo("reg") != 0) { VerifyParm = false; break; } //Only for Reg                    
                    }
                    if (xCmdList.Count == DictionXm[0].MaxParm && !ExtUtil.IsMatchExtName(xCmdList[xCmdList.Count - 1].ToString())) VerifyParm = false;
                    break;

                case 11:
                    if (xCmdList.Count < 2 || xCmdList.Count > DictionXm[0].MaxParm) VerifyParm = false;
                    Array.Copy(xCmdList.ToArray(), 1, XPlusCmd, 0, 3);
                    Array.Resize(ref XPlusCmd, 3);
                    foreach (string Str in XPlusCmd)
                    {
                        if (Util.ValidStrandRange(Str, 0, DictionXm[0].MaxValue, ref Value)) continue;//Only for numeral
                        if (Str.Length < 3 || Str.Substring(0, 3).ToLower().CompareTo("reg") != 0) { VerifyParm = false; break; } //Only for Reg                    
                    }
                    if (xCmdList.Count > 4 && !ExtUtil.IsMatchExtName(xCmdList[xCmdList.Count - 1].ToString())) VerifyParm = false;
                    break;
                case 12:
                    if (xCmdList.Count < 2 || xCmdList.Count > DictionXm[0].MaxParm) VerifyParm = false;
                    Length = (xCmdList.Count == DictionXm[0].MaxParm) ? xCmdList.Count - 2 : xCmdList.Count - 1;
                    Array.Copy(xCmdList.ToArray(), 1, XPlusCmd, 0, Length);
                    Array.Resize(ref XPlusCmd, Length);
                    foreach (string Str in XPlusCmd)
                    {

                        if (Util.ValidStrandRange(Str, 0, DictionXm[0].MaxValue, ref Value)) continue;//Only for numeral
                        if (Str.Substring(0, 1).ToLower().CompareTo(":") == 0) //Only for numeral
                        {
                            if (Util.ValidStrandRange(Str.Substring(1), 0, DictionXm[0].MaxValue, ref Value)) continue;//Only for numeral
                        }
                        if (Str.Length < 3 || Str.Substring(0, 3).ToLower().CompareTo("reg") != 0) { VerifyParm = false; break; } //Only for Reg                    
                    }
                    if (xCmdList.Count == DictionXm[0].MaxParm && !ExtUtil.IsMatchExtName(xCmdList[xCmdList.Count - 1].ToString())) VerifyParm = false;
                    break;
                default:
                    break;
            }

            return VerifyParm == true && bItemMatch == true;
        }

    }
}
