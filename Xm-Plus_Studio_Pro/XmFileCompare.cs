using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public partial class XmFileCompare : Form
    {
        private string OriFileA = null, CmpFileB = null;
        private ArrayList OriSpt = null, CmpSpt = null;
        private string[] Original = null, Compare = null;
        XM_IO_Util XmUtil = new XM_IO_Util();
        public static int lengthOrig = 0, lengthComp = 0;


        public XmFileCompare()
        {
            InitializeComponent();
        }

        private ArrayList LoadFile(string FilePath, bool IgSpace)
        {
            string Temp = null;
            string[] Script = null;
            ArrayList CmpStr = new ArrayList();
            if (XmUtil.IsFileExist(FilePath)) Script = XmUtil.ReadFile(FilePath);
            foreach (string Str in Script)
            {
                Temp = (IgSpace) ? Str.Trim() : Str;
                if (!string.IsNullOrEmpty(Temp)) CmpStr.Add(Str);
            }
            return CmpStr;
        }

        /// <summary>
        /// 得到 原数据和要比较数据的数组
        /// </summary>
        /// <param name="Original"></param>
        /// <param name="Compare"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        private ArrayList GetArrayList(string[] file)
        {
            ArrayList list = new ArrayList();
            char[] DelimiterChars = { ' ', ',', ':', '\t', '\n' };
            for (int i = 0; i < file.Length; i++)
            {
                string[] Data = file[i].Split(DelimiterChars);
                foreach (string item in Data)
                {
                    if (!string.IsNullOrEmpty(item.Trim())) list.Add(item);
                }
            }           
            return list;
        }
        private bool CompareTxt(string[] Original, string[] Compare, ref string Message)
        {
            bool ret = true;
            int Val_1 = 0, Val_2 = 0;
            ArrayList OriginalList = new ArrayList();
            ArrayList CompareList = new ArrayList();
            XM_Digital_Util DigUtil = new XM_Digital_Util();

            if (Original.Length > Compare.Length) { Message = "File Line Size Err, Original File > Comppare File\r\n"; return false; }
            if (lengthOrig > lengthComp) { Message = "File LineNum Size Err, Original File > Comppare File\r\n"; return false; }
            //Prepare the information to be compared

            OriginalList = GetArrayList(Original);
            CompareList = GetArrayList(Compare);

            for (int i = 0; i < OriginalList.Count; i++)
            {
                if (!DigUtil.StrToNumber<int>((string)OriginalList[i].ToString().Trim(), ref Val_1)) { Message += string.Concat("Line: ", (i / lengthOrig).ToString(), " ","Num: ", (i % lengthOrig).ToString(), " ,Data Err\r\n"); return false; }
                if (!DigUtil.StrToNumber<int>((string)CompareList[i].ToString().Trim(), ref Val_2)) { Message += string.Concat("Line: ", (i/ lengthOrig).ToString()," ", "Num: ", (i % lengthOrig).ToString(), " ,Data Err\r\n"); return false; }
                if (Val_1 != Val_2)
                {
                    Message += string.Concat("Line: ", (i / lengthOrig).ToString(), " ","Num: ", (i % lengthOrig).ToString(), " ,Compare Err\r\n");
                    ret = false;
                }
            }
            CompareList.Clear();
            OriginalList.Clear();
            return ret;
        }
        private void BtnLoadFileA_Click(object sender, EventArgs e)
        {
            OpenFileDialog OriginalFile = new OpenFileDialog
            {
                Filter = "*.txt|*.*",
                FileName = "default.txt",
                InitialDirectory = Setting.ExeLogDirPath,
            };

            if (OriginalFile.ShowDialog() == DialogResult.OK)
            {

                OriFileA = OriginalFile.FileName;
                TxtBoxFileA.Text = Path.GetFileName(OriFileA);
                OriSpt = LoadFile(OriFileA,true);
                if(OriSpt!=null) TxtBoxState.Text = OriSpt.Count.ToString();
                if (TxtBoxFileA.Text.Contains(".txt")) lengthOrig = XM_IO_Util.LengthA;
                if (TxtBoxFileA.Text.Contains(".csv")) lengthOrig = XM_IO_Util.LengthA / 2;
            }
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            string Message = null;
            int Line = 0;
            XM_Digital_Util DigUtil = new XM_Digital_Util();
            if (OriSpt == null || CmpSpt == null) return;
            if (!DigUtil.StrToNumber<int>(TxtBoxState.Text, ref Line)) return;
            if (Line > OriSpt.Count) lbl_Msg.Text = "Please Note Condition Status";
            Line = (Line > OriSpt.Count) ? OriSpt.Count : Line;

            Original = new string[Line];
            Compare = new string[CmpSpt.Count];
            OriSpt.CopyTo(0, Original, 0,Line);
            CmpSpt.CopyTo(0,Compare,0, CmpSpt.Count);

            if (CompareTxt(Original, Compare, ref Message))
            {
                RtfMsg.Clear();
                Color black = Color.Black;
                RtfMsg.SelectionColor = black;
                RtfMsg.AppendText("Result Pass, Compare Successfully!");
            }
            else
            {
                RtfMsg.Clear();
                Color red = Color.Red;
                RtfMsg.SelectionColor = red;
                RtfMsg.AppendText(string.Concat("Result Error!\r\n", Message));
            }
        }

        private void BtnLoadFileB_Click(object sender, EventArgs e)
        {
            OpenFileDialog CompareFile = new OpenFileDialog
            {
                Filter = "*.txt|*.*",
                FileName = "default.txt",
                InitialDirectory = Setting.ExeLogDirPath,
            };

            if (CompareFile.ShowDialog() == DialogResult.OK)
            {
                CmpFileB = CompareFile.FileName;
                TxtBoxFileB.Text = Path.GetFileName(CmpFileB);
                string [] Script = XmUtil.ReadFile(CmpFileB);
                CmpSpt = LoadFile(CmpFileB,false);
                if (TxtBoxFileA.Text.Contains(".txt")) lengthComp = XM_IO_Util.LengthB;
                if (TxtBoxFileA.Text.Contains(".csv")) lengthComp = XM_IO_Util.LengthB / 2;
            }
        }

        private void BtnClr_Click(object sender, EventArgs e)
        {
            TxtBoxFileA.Text = " ";
            TxtBoxFileB.Text = " ";
            TxtBoxState.Text = " ";
        }
    }
}
