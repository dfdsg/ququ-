using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace XM_Tek_Studio_Pro.StudioUtil
{
    public class Setting
    {
        public static string ExePath = null;
        public static string ExeImgDirPath = null;
        public static string ExeLogDirPath = null;
        public static string ExeSptDirPath = null;
        public static string ExeDriverPath = null;
        public static string ExeScopeDirPath = null;
        public static string ExeWolConfigPath = null;
        public static string ExeSysIniPath = null;
        public static string ExeSDCardDirPath = null;
        public static string DataSourcePath = null;
        //Debug Process
        public static bool TxCmd = true;
        public static int T_EveryCmd = 35;
        public static bool CmdMsg = true; 
    }

    public class XmImage
    {
        public string FullPath = null;
        public string UpperDir = null;
        public string ImageName = null;

        public XmImage(string FullPath,string UpperDirPath,string ImageName)
        {
            this.FullPath = FullPath;
            this.UpperDir = UpperDirPath;
            this.ImageName = ImageName;
        }
    }

    class XM_IO_Util
    {
        private const byte ASCII_0 = 0x30;
        private const byte ASCII_9 = 0x39;
        private const byte ASCII_x = 0x78;
        private const byte ASCII_a = 0x61;
        private const byte ASCII_f = 0x66;
        private char[] DelimiterDot = { '.' };
        private string[] ImgExtName = { ".bmp", ".jpg",".png"};
        private string[] TxtExtName = { ".csv", ".txt", };
        private char[] DelimiterChars = { ' ', ',', ':', '\t','\n'};     
        private char[] SplitExtName = { '.' };
        private string FullFilePath = null;
        private List<string> DirNode = null;
        public static int LengthA = 0;
        public static int LengthB= 0;


        public XM_IO_Util(){}
        public XM_IO_Util(string IOPath) { this.FullFilePath = IOPath; }

        public bool OutputDll(string DllFileName, string Resource)
        {
            if (File.Exists(DllFileName)) return true;
            Assembly aObj = Assembly.GetExecutingAssembly();
            Stream sStream = aObj.GetManifestResourceStream(Resource);

            if (sStream != null)
            {
                byte[] bySave = new byte[sStream.Length];
                sStream.Read(bySave, 0, bySave.Length);
                FileStream fsObj = new FileStream(DllFileName, FileMode.CreateNew);
                fsObj.Write(bySave, 0, bySave.Length);
                fsObj.Close();
                sStream.Close();
            }
            else
                 return false;
            return true;
        }

        public bool OutputTxt(string FileName, string InnerTxt)
        {
            FileInfo file = new FileInfo(FileName);
            StreamWriter sw = file.CreateText();
            sw.Write(InnerTxt);
            sw.Close();
            return true;
        }

        public bool OutputTxt(string FileName, ArrayList InnerTxt)
        {
            FileInfo file = new FileInfo(FileName);

            using (StreamWriter sw = file.CreateText())
            {
                foreach (string Msg in InnerTxt) sw.WriteLine(Msg);
                sw.Close();
            }
               
            return true;
        }

        public bool OutputCSV(string FileName, string InnerTxt)
        {
            FileStream fs = new FileStream(FileName, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("Big5")))
            {
                sw.Write(InnerTxt);
                sw.Close();
            }
            fs.Close();
            return true;
        }

        public bool OutputCSV(string FileName, ArrayList InnerTxt)
        {
            FileStream fs = new FileStream(FileName, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("Big5")))
            {
                foreach (string Msg in InnerTxt) sw.WriteLine(Msg);
                sw.Close();
            }
            fs.Close();
            return true;
        }

        public bool AppendTxt(string FileName, ArrayList InnerTxt)
        {
            FileInfo file = new FileInfo(FileName);

            using (StreamWriter sw = file.AppendText())
            {
                foreach (string Msg in InnerTxt) sw.WriteLine(Msg);
                sw.Close();
            }

            return true;
        }

        public bool CompareExtName(string FileName, string ExtName)
        {
            return string.Compare(GetExtName(FileName), ExtName) == 0 ? true : false;
        }

        public string GetPureFileName(string FilePath)
        {
            string Temp = Path.GetFileName(FilePath);
            string[] Words = Temp.Split(SplitExtName);
            if (Words.Length < 1) return null;
            return Words[0];
        }

        public string GetExtName(string FilePath)
        {
            return GetExtensionName(FilePath);

        }

        public bool IsMatchExtName(string DirPath)
        {
            string extName = GetExtName(DirPath).ToLower();
            for(int i =0;i< TxtExtName.Length; i++)
            {
                if (extName == TxtExtName[i])
                    return true;
            }
            for (int i = 0; i < ImgExtName.Length; i++)
            {
                if (extName == ImgExtName[i])
                    return true;
            }
            return false;
        }

        public string SetSptFileName(string SptNamePath)
        {
            string rootName = Path.GetDirectoryName(SptNamePath);
            string ExtensionName = GetExtName(SptNamePath).ToLower();
            string BaseName = null;

            foreach (string extName in ImgExtName)
            {
                if (extName == ExtensionName)
                {
                    BaseName = Setting.ExeImgDirPath;
                    break;
                }
            }

            foreach (string extName in TxtExtName)
            {
                if (extName == ExtensionName)
                {
                    BaseName = Setting.ExeDriverPath;
                    break;
                }
            }

            if (String.IsNullOrEmpty(rootName))
                return Path.Combine(BaseName, SptNamePath);
            else
                return SptNamePath;
        }

        public void CreateDir(string DirPath)
        {
            if (!System.IO.Directory.Exists(DirPath))
                System.IO.Directory.CreateDirectory(DirPath);
        }

        public bool CopyFileToDir(string FileName,string DesDir)
        {
            if (IsFileExist(FileName))
                System.IO.File.Copy(FileName, Path.Combine(DesDir, Path.GetFileName(FileName)), true);
            else
                return false;
            return true;
        }

        public bool IsDirPath(string DirPath) {return System.IO.Directory.Exists(DirPath);}
        public string GetFullFilePath(){return this.FullFilePath;}
        public bool IsFileExist(string FilePath) { return System.IO.File.Exists(FilePath); }
        public void FileDelete(string FilePath) { System.IO.File.Delete(FilePath); }

        public bool FileExist(string FileName)
        { 
            string fullPath =  Setting.ExeSptDirPath + "\\" + FileName;
            if (IsFileExist(fullPath)) { this.FullFilePath = fullPath; return true; }
            if (IsFileExist(FileName)) { this.FullFilePath = FileName; return true; }
            return false;
        }

        public bool FileExist(string FileName, ref string CompletePath)
        {
            string fullPath = Setting.ExeSptDirPath + "\\" + FileName;
            if (IsFileExist(FileName)) { CompletePath = FileName; return true; }
            if (IsFileExist(fullPath)) { CompletePath = fullPath; return true; }      
            return false;
        }
      
        public string[] ReadFile(string FileName)
        {
            
            string innerTxt = null;
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(FileName))
                {

                    if (LengthA == 0)
                    {
                        LengthA = sr.ReadLine().Length;
                    }
                    else LengthB = sr.ReadLine(). Length;
                    // Read the stream to a string, and write the string to the console.
                    innerTxt = sr.ReadToEnd();
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }

            return innerTxt.Split('\n');
        }


        public bool CmpXmImgs(XmImage[] XmNewImg, XmImage[] XmOldImg)
        {
            if (XmNewImg.Length != XmOldImg.Length) return false;
            for(int i =0;i< XmNewImg.Length;i++)
            {
                if (string.Compare(XmNewImg[i].ImageName, XmOldImg[i].ImageName) !=0)
                    return false;
            }
            return true;
        }

        /*
         * Get Image File Name from Special Directory for XmPlus Rules
         * Only for one hierarchy and don't support the Recursive Directory
         */
        public XmImage[] GetDirAndImages()
        {
            List<string> DirList = new List<string>();
            List<XmImage> XmImageList = new List<XmImage>();
            DirNode  = new List<string>();
            string[] Exts = { "*.jpg", "*.png", "*.bmp" };
            string FullPath = null, UpperDirPath = null, FileName =null;
            foreach (string pattern in Exts)
            {
                DirList.AddRange( System.IO.Directory.GetFiles(FullFilePath, pattern, SearchOption.AllDirectories));
            }

            foreach (string XmImg in DirList)
            {
                System.IO.FileInfo fi = null;
                try
                {
                    fi = new System.IO.FileInfo(XmImg);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                FullPath = XmImg;
                UpperDirPath = AddDirName(fi.Directory.Name.ToString());
                FileName = fi.Name ;
                XmImageList.Add(new XmImage(XmImg,UpperDirPath,FileName));
            }

            return XmImageList.ToArray();
        }

        

        public string[] GetDirNode(bool Order , string Node)
        {
            int Addr = 0;
            if(DirNode != null)
            {
                if (Order)
                {
                    for (int i = 0; i < DirNode.Count; i++)
                    {
                        if(string.Compare(DirNode[i], Node) == 0)
                        {
                            Addr = i;
                            break;
                        }
                    }

                    if (Addr > 0) { DirNode.RemoveAt(Addr); DirNode.Insert(0, Node); }
                }
                return DirNode.ToArray();
            }
            else
                return null;
        }

        public XmImage[] GetImgFiles(string Node, XmImage[] XmImage)
        {
            List<XmImage> lImgInfo = new List<XmImage>();
            foreach (XmImage Image in XmImage)
            {
                if (string.Compare(Node, Image.UpperDir) == 0) lImgInfo.Add(Image);
            }

            return lImgInfo.ToArray();
        }

        public bool WriteByteToTxt(string FilePath, List<byte> Pixels, int Width, int WrNum, bool delFile)
        {
            string Msg = null, TxtFilePath = FilePath;
            int Temp = 0;
            if (delFile) new XM_IO_Util().FileDelete(TxtFilePath);
            FileStream fs = new FileStream(TxtFilePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            WrNum = (WrNum == 0) ? Width : WrNum;

            for (int i = 0; i < Pixels.Count; i=i+3)
            {
                if (i != 0 && i % (WrNum*3) == 0)
                {
                    Msg = string.Concat(Msg, "\r\n");
                    sw.Write(Msg);
                    Msg = null;
                }
                if (int.TryParse(Pixels[i].ToString(), out Temp))
                    Msg = string.Concat(Msg, "0x", Temp.ToString("X2"));
                Msg = string.Concat(Msg, "\t");
            }
            Msg = string.Concat(Msg, "\r\n");
            sw.Write(Msg);
            sw.Close();
            return true;
        }

        public bool WriteByteToTxt(string FilePath, byte[,] Pixels, bool delFile)
        {
            string Msg = null, TxtFilePath = FilePath;
            int Width = Pixels.GetLength(0);
            int Height = Pixels.GetLength(1);
            if (delFile) new XM_IO_Util().FileDelete(TxtFilePath);
            FileStream fs = new FileStream(TxtFilePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);

            for (int h = 0; h < Height; h++)
            {
                for(int w =0;w< Width;w++)
                {
                    Msg += "0x" + Pixels[w,h].ToString("X2")+ "\t";
                }
                sw.WriteLine(Msg);
                Msg = null;
            }
            sw.Close();
            return true;
        }

        public bool WriteByteToTxt(string FilePath, ArrayList Pixels, int Width, int WrNum, bool delFile)
        {
            string Msg = null, TxtFilePath = FilePath;
            int  Temp = 0;
            if (delFile) new XM_IO_Util().FileDelete(TxtFilePath);
            FileStream fs = new FileStream(TxtFilePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            WrNum = (WrNum == 0) ? Width : WrNum;

            for (int i = 0; i < Pixels.Count; i++)
            {
                if (i != 0 && i % WrNum == 0)
                {
                    Msg = string.Concat(Msg, "\r\n");
                    sw.Write(Msg);
                    Msg = null;
                }
                if(int.TryParse(Pixels[i].ToString(),out Temp))
                    Msg = string.Concat(Msg, "0x", Temp.ToString("X2"));
                Msg = string.Concat(Msg, "\t");
            }
            Msg = string.Concat(Msg, "\r\n");
            sw.Write(Msg);
            sw.Close();
            return true;
        }


        public bool WriteByteToTxt(string FilePath, byte[,] Pixels,int WrNum, bool delFile)
        {
            string Msg = null, TxtFilePath = FilePath;
            int Width = Pixels.GetLength(0), Height = Pixels.GetLength(1),Sum =0;
            if (delFile) new XM_IO_Util().FileDelete(TxtFilePath);
            FileStream fs = new FileStream(TxtFilePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            WrNum = (WrNum == 0) ? Width : WrNum;
            for (int h = 0; h < Height; h++)
            {
                for (int w = 0; w < Width; w++)
                {
                    Sum = h * Width + w;
                    if (Sum != 0 && Sum % WrNum == 0)
                    {
                        Msg = string.Concat(Msg, "\r\n");
                        sw.Write(Msg);
                        Msg = null;
                    } 
                    Msg = string.Concat(Msg,"0x", Pixels[w, h].ToString("X2"));
                    Msg = string.Concat(Msg, "\t");           
                }            
            }
            Msg = string.Concat(Msg, "\r\n");
            sw.Write(Msg);
            sw.Close();
            return true;
        }

        private string AddDirName(string DirName)
        {
            bool IsMatch = false;
            
            if (DirNode == null) return DirName;

            foreach (string Name in DirNode)
            {
                if (string.Compare(Name, DirName) == 0) { IsMatch = true; break; }
            }

            if (!IsMatch) DirNode.Add(DirName);
            return DirName;
        }

        private string GetExtensionName(string FilePath) { return Path.GetExtension(FilePath); }
    }
}

