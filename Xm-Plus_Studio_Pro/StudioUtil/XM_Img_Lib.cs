using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace XM_Tek_Studio_Pro.StudioUtil
{

    public class ResultInfo
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public int Heigth { get; set; }
        public int Width { get; set; }
    }

    /***********************************************************
    Error Code Define
    ***********************************************************/
    internal sealed partial class SystemInfo
    {
        internal const byte ERROR_RESULT_OK = 0;
        internal const byte ERROR_IVALIDTOKEN = 1;
        internal const byte ERROR_ADDRWR_NOPARAM = 2;
        internal const byte ERROR_DATAWR_NOPARAM = 3;
        internal const byte ERROR_STOREFORMAT_ERR = 4;
        internal const byte ERROR_CMP_NOPARAM = 5;
        internal const byte ERROR_CMP_FILENOTEXIST = 6;
        internal const byte ERROR_CMP_MATCH = 7;
        internal const byte ERROR_CMP_ERROR = 8;
    }

    class XM_Img_Lib
    {
        private string ImgPath = null;
        private Bitmap ResultBmp = null;
        private char[] SplitLineChars = { '\n', '\t' };
        private char[] LineChars = { '\t', ',', '(', ')' };
        private const string FILENOTEXIST = "File not Exist\n";
        private const string BMPCMPMATCH = "BMP COMPARE MATCH";
        private int bWidth = 0, bHeight = 0;
        public XM_Img_Lib()
        {
            ImgPath = null;
        }
        public XM_Img_Lib(string _path)
        {
            ImgPath = _path;
        }

        public int GetWidth() { return this.bWidth; }
        public int GetHeight() { return this.bHeight; }

        public void SetImagePath(string bmpPath)
        {
            this.ImgPath = bmpPath;
        }

        public Bitmap OriginalBmp()
        {
            Bitmap bmp = new Bitmap(ImgPath);
            return bmp;
        }

        public bool IsFileExist(string ImagePath)
        {
            bool ret = false;
            XM_IO_Util imgUtil = new XM_IO_Util();
            string fullPath = Setting.ExeImgDirPath + "\\" +ImagePath;
            if (imgUtil.IsFileExist(ImagePath)) { this.ImgPath = ImagePath; ret = true; }
            if (imgUtil.IsFileExist(fullPath)) { this.ImgPath = fullPath; ret = true; }        
            return ret;
        }

        private byte MaxRGB(byte R, byte G, byte B)
        {
            byte Max = 0;
            if (R >= G)
                Max = R;
            else
                Max = G;

            if (Max < B)
                Max = B;

            return Max;

        }

        public bool BmpAryWithCpu(ref byte[,] Pixels)
        {
            int Temp = 0;
            List<byte> XferData = new List<byte>();
            if (!BmpToList(ref XferData)) return false;
           
            Pixels = new byte[this.bWidth, this.bHeight];

            for (int h = 0; h < this.bHeight; h++)
            {
                for (int w = 0; w < this.bWidth; w++)
                {
                    Temp = (h * 128 + w) * 3;
                    Pixels[w, h] = MaxRGB(XferData[Temp], XferData[Temp+1], XferData[Temp+2]);
                }
            }
            return true ;
        }

        public List<byte> ArrayWithBmp( int Mode)
        {
            //int Temp = 0;
            List<byte> XferData = new List<byte>();
            ArrayList ImageList = new ArrayList();
            if (!BmpToList(ref XferData)) return null;

            


            //byte[,] Pixels = new byte[this.bWidth, this.bHeight];
            //for (int h = 0; h < this.bHeight; h++)
            //{
            //    for (int w = 0; w < this.bWidth; w++)
            //    {
            //        Temp = (h * 128 + w) * 3;
            //        Pixels[w, h] = MaxRGB(XferData[Temp], XferData[Temp + 1], XferData[Temp + 2])>127 ? (byte)255: (byte)0;
            //    }
            //}

            //switch (Mode)
            //{
            //    case 0:
            //        ImageList = PageWithBmp( Pixels);
            //        break;
            //    case 1:
            //        ImageList = HorizontalWithBmp(Pixels);
            //        break;
            //    case 2:
            //        ImageList = VerticalWithBmp(Pixels);
            //        break;
            //    default:
            //        ImageList = PageWithBmp(Pixels);
            //        break;
            //}

            return XferData;
        }

        private ArrayList PageWithBmp(byte[,] Pixels)
        {
            int Data = 0;
            ArrayList ImgList = new ArrayList();
            for (int h = 0; h < this.bHeight; h+=8)
            {
                for (int w = 0; w < this.bWidth; w++)
                {
                    for (int x = 0; x < 8; x++)
                        Data = (byte)(Data + ((Pixels[w, h + x] & 0x80) >> (7 - x)));
                    ImgList.Add(Data.ToString());
                    Data = 0;
                }
            }
            return ImgList;
        }

        private ArrayList VerticalWithBmp(byte[,] Pixels)
        {
            int Data = 0;
            ArrayList ImgList = new ArrayList();
 
            for (int w = 0; w < this.bWidth; w++)
            {
                for (int h = 0; h < this.bHeight; h+=8)
                {
                    for (int x = 0; x < 8; x++)
                        Data = (byte)(Data + ((Pixels[w, h + x] & 0x80) >> (7 - x)));
                    ImgList.Add(Data.ToString());
                    Data = 0;
                }
            }
            return ImgList;

        }

        private ArrayList HorizontalWithBmp(byte[,] Pixels)
        {
            int Data = 0;
            ArrayList ImgList = new ArrayList();
            for (int h = 0; h < this.bHeight; h += 8)
            {
                for (int w = 0; w < this.bWidth; w++)
                {
                    for (int x = 0; x < 8; x++)
                        Data = (byte)(Data + ((Pixels[w, h + x] & 0x80) >> (7 - x)));
                    ImgList.Add(Data.ToString());
                    Data = 0;
                }
            }
            return ImgList;
        }


        //video mode
        public bool BmpToListWithDummyVideo(ref List<byte> XferData)
        {
            Bitmap bmp = new Bitmap(ImgPath);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Color PixelColor;
            int Count = 0;
            int TotalCount = bmp.Height * bmp.Width * 3;
            TotalCount = TotalCount + (16 - TotalCount % 16);
            TotalCount = TotalCount + TotalCount / 16;
            List<byte> lXferImage = new List<byte>();
            byte[] Image = new byte[TotalCount];

            for (int h = 0; h < bmp.Height; h++)
            {
                for (int w = 0; w < bmp.Width; w++)
                {
                    PixelColor = bmp.GetPixel(w, h);
                    lXferImage.Add(PixelColor.R);
                    lXferImage.Add(PixelColor.G);
                    lXferImage.Add(PixelColor.B);
                }
            }

            for (int i = 0; i < lXferImage.Count; i++)
            {
                Image[Count] = lXferImage[i];
                Count++;
                if (i % 16 == 15) { Image[Count] = 0; Count++; }
            }

            XferData = new List<byte>(Image);
            return true;
        }
        //video mode
        public bool BmpToListVideo(ref List<byte> XferData)
        {
            Bitmap bmp = new Bitmap(ImgPath);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Color PixelColor;

            this.bHeight = bmp.Height;
            this.bWidth = bmp.Width;
            //bgr
            for (int h = 0; h < bmp.Height; h++)
            {
                for (int w = 0; w < bmp.Width; w++)
                {
                    PixelColor = bmp.GetPixel(w, h);
                    XferData.Add(PixelColor.R);
                    XferData.Add(PixelColor.G);
                    XferData.Add(PixelColor.B);
                }
            }

            return true;
        }

        //command mode
        public bool BmpToListWithDummy(int wsize,ref List<byte> XferData)
        {
            Bitmap bmp = new Bitmap(ImgPath);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Color PixelColor;
            int Count = 0;
            int TotalCount = bmp.Height * bmp.Width * 3 ;
            TotalCount = TotalCount+ (16 - TotalCount % 16);
            TotalCount = TotalCount + TotalCount / 16;
            List<byte> lXferImage = new List<byte>();
            List<byte> CSVimage = new List<byte>();
            byte[] Image = new byte[TotalCount];

            for (int h = 0; h < bmp.Height; h++)
            {
                for (int w = 0; w < bmp.Width; w++)
                {
                    PixelColor = bmp.GetPixel(w, h);
                    lXferImage.Add(PixelColor.B);
                    lXferImage.Add(PixelColor.G);
                    lXferImage.Add(PixelColor.R);
                    CSVimage.Add(PixelColor.R);
                    CSVimage.Add(PixelColor.G);
                    CSVimage.Add(PixelColor.B);
                }
            }
           
            for (int i = 0; i < lXferImage.Count; i++)
            {
                Image[Count] = lXferImage[i];
                Count++;
                if (i % 16 == 15) { Image[Count] = 0; Count++; }
            }

            XferData = new List<byte>(Image);

            
            //存为csv档
           
            string name = ImgPath.Remove(0, ImgPath.LastIndexOf("\\") + 1);
            string SaveFile_Path = string.Concat(Setting.ExeLogDirPath, "\\", name + ".csv");
            FileStream fs = new FileStream(SaveFile_Path, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("Big5")))
            {
                for (int i = 0; i < CSVimage.Count; i++)
                {
                    if (i % (bmp.Width * 3) == 0 && i!=0)
                    {
                        sw.Write('\n');
                    }
                    sw.Write(CSVimage[i]+",");
                }
                sw.Close();
                fs.Close();
            }
            return true;
        }
        //command mode
        public bool BmpToList(ref List<byte> XferData)
        {
            Bitmap bmp = new Bitmap(ImgPath);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Color PixelColor;

            this.bHeight = bmp.Height;
            this.bWidth = bmp.Width;
            //bgr
            for (int h = 0; h < bmp.Height; h++)
            {
                for (int w = 0; w < bmp.Width; w++)
                {
                    PixelColor = bmp.GetPixel(w, h);
                    XferData.Add(PixelColor.B);
                    XferData.Add(PixelColor.G);
                    XferData.Add(PixelColor.R);
                }
            }

            return true;
        }

        public Bitmap GetResultBmp()
        {
            return  ResultBmp ?? null;
        }

        public int CompareGrpah(string CmpGraphFile, ref string SysMsg, ref List<string> lCmpInfo)
        {
            int ret = SystemInfo.ERROR_RESULT_OK;
            string AddrTmp = null;
            XM_IO_Util FileVerfiy = new XM_IO_Util();
            if (!FileVerfiy.IsFileExist(ImgPath)) return SystemInfo.ERROR_CMP_FILENOTEXIST;
            if (!FileVerfiy.IsFileExist(CmpGraphFile)) return SystemInfo.ERROR_CMP_FILENOTEXIST;
            Bitmap DefaultBmp = new Bitmap(ImgPath);
            Bitmap CmpBmp = new Bitmap(CmpGraphFile);
            Rectangle DefaultRect = new Rectangle(0, 0, DefaultBmp.Width, DefaultBmp.Height);
            Rectangle CmpRect = new Rectangle(0, 0, CmpBmp.Width, CmpBmp.Height);

            System.Drawing.Imaging.BitmapData DefaultBmpData =
                DefaultBmp.LockBits(DefaultRect, System.Drawing.Imaging.ImageLockMode.ReadWrite, DefaultBmp.PixelFormat);

            System.Drawing.Imaging.BitmapData CmpBmpData =
                CmpBmp.LockBits(CmpRect, System.Drawing.Imaging.ImageLockMode.ReadWrite, CmpBmp.PixelFormat);

            // Get the address of the first line.
            IntPtr DefualtPtr = DefaultBmpData.Scan0;
            IntPtr CmpPtr = CmpBmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int DefaultBytes = Math.Abs(DefaultBmpData.Stride) * DefaultBmp.Height;
            int CmpBytes = Math.Abs(CmpBmpData.Stride) * CmpBmpData.Height;
            int ResultBytes = Math.Abs(DefaultBmpData.Stride) * DefaultBmpData.Height;

            byte[] DrgbValues = new byte[DefaultBytes];
            byte[] CrgbValues = new byte[CmpBytes];
            byte[] RrgbValues = new byte[ResultBytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(DefualtPtr, DrgbValues, 0, DefaultBytes);
            System.Runtime.InteropServices.Marshal.Copy(CmpPtr, CrgbValues, 0, CmpBytes);

            // Set every third value to 255. A 24bpp bitmap will look red.  
            for (int Counter = 0; Counter < DrgbValues.Length; Counter += 3)
            {
                if (DrgbValues[Counter] == CrgbValues[Counter] && DrgbValues[Counter + 1] == CrgbValues[Counter + 1]
                    && DrgbValues[Counter + 2] == CrgbValues[Counter + 2])
                        RrgbValues[Counter] = RrgbValues[Counter + 1] = RrgbValues[Counter + 2] = 255;
                else
                {
                    RrgbValues[Counter + 2] = 255;
                    RrgbValues[Counter + 1] = RrgbValues[Counter] = 0;
                    AddrTmp = CountLocation(DefaultBmp.Width, DefaultBmp.Height, Counter);
                    ShowCmpMsg(ref lCmpInfo, AddrTmp, DrgbValues[Counter + 2], DrgbValues[Counter + 1], DrgbValues[Counter],
                         CrgbValues[Counter + 2], CrgbValues[Counter + 1], CrgbValues[Counter]);
                    ret = SystemInfo.ERROR_CMP_ERROR;
                }
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(DrgbValues, 0, DefualtPtr, DefaultBytes);
            System.Runtime.InteropServices.Marshal.Copy(CrgbValues, 0, CmpPtr, CmpBytes);

            // Unlock the bits.
            DefaultBmp.UnlockBits(DefaultBmpData);
            CmpBmp.UnlockBits(CmpBmpData);

            ResultBmp = CreateBmp(RrgbValues, DefaultBmp.Width, DefaultBmp.Height);

            return ret;
        }

        private void ShowCmpMsg(ref List<string> lCmpInfo, string Location, int Dr, int Dg, int Db, int Cr, int Cg, int Cb)
        {
            string Str = Location + LineChars[0] + LineChars[1];
            Str += LineChars[0] + "(" + string.Format("{0,3}", Dr) + LineChars[1] + string.Format("{0,3}", Dg) + LineChars[1] + string.Format("{0,3}", Db) + LineChars[3] + LineChars[0] + LineChars[1];
            Str += LineChars[0] + "(" + string.Format("{0,3}", Cr) + LineChars[1] + string.Format("{0,3}", Cg) + LineChars[1] + string.Format("{0,3}", Cb) + LineChars[3] + LineChars[0];
            lCmpInfo.Add(Str);
        }

        private string CountLocation(int Width, int Height, int Addr)
        {
            int Location = Addr / 3;
            int X = Location % Width;
            int Y = Location / Width;
            return "[" + string.Format("{0,3}", X) + "," + string.Format("{0,3}", Y) + "]";
        }

        public Bitmap ConvertGrayBmp()
        {
            Bitmap bmp = new Bitmap(ImgPath);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            int r = 0, g = 0, b = 0;
            byte color = 0;
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Set every third value to 255. A 24bpp bitmap will look red.  
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {
                r = rgbValues[counter];
                g = rgbValues[counter + 1];
                b = rgbValues[counter + 2];
                color = (byte)(0.299 * r + 0.587 * g + 0.114 * b);
                rgbValues[counter] = rgbValues[counter + 1] = rgbValues[counter + 2] = color;
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            return bmp;
        }

        public byte[] ArrageData(ResultInfo FileInfo, byte[] rdData)
        {
            int MaxVal = FileInfo.Heigth * FileInfo.Width * 3;
            byte Tmp = 0;
            byte[] bgrColor = new byte[MaxVal];
            for (int i = 0; i < MaxVal; i++)
                bgrColor[i] = rdData[(2 * i) + 1];

            //RGB->BGR
            for (int counter = 0; counter < MaxVal; counter += 3)
            {
                Tmp = bgrColor[counter];
                bgrColor[counter] = bgrColor[counter + 2];    //Blue
                bgrColor[counter + 2] = Tmp; //Red
            }
            return bgrColor;
        }


        public Bitmap CreateBmp(byte[] bgrData, int Width, int Height)
        {
            Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Set every third value to 255. A 24bpp bitmap will look red.  
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {
                rgbValues[counter] = bgrData[counter];
                rgbValues[counter + 1] = bgrData[counter + 1];
                rgbValues[counter + 2] = bgrData[counter + 2];
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            return bmp;
        }

        public bool WriteImgToTxt(string FilePath, byte[] Pixel)
        {
            XM_Digital_Util imgUtil = new XM_Digital_Util();
            string TxtPath = Path.ChangeExtension(FilePath, "txt");
            imgUtil.WriteByteToTxt(TxtPath, Pixel, true);
            return true;
        }

        public bool SaveTxtResult(string FilePath,ref  List<string> lCmpInfo, bool delFile)
        {
            XM_IO_Util imgUtil = new XM_IO_Util();
            string Addr = string.Format("{0,8}", "Addr");
            Addr += "\t,\t";
            Addr += string.Format("{0,12}", "(R,G,B)");
            Addr += "\t,\t";
            Addr += string.Format("{0,12}", "(CR,CG,CB)");
            string TxtPath = Path.ChangeExtension(FilePath, "txt");
            if (lCmpInfo.Count == 0) lCmpInfo.Add(BMPCMPMATCH);
            if (delFile) imgUtil.FileDelete(TxtPath);           
            lCmpInfo.Insert(0, Addr);
            FileStream fs = new FileStream(TxtPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            foreach (string item in lCmpInfo)
                sw.WriteLine(item);
            sw.Close();
            lCmpInfo.Clear();
            return true;
        }


        /*TreeNode Thread*/
        public bool AddTreeNode(List<TreeNode> ImgSubNode, XmImage Node)
        {
            TreeNode SubNodes = new TreeNode{ Text = Node.UpperDir };
            bool bMatch = false;
            int MatchNum = 0;
            for(int i =0;i<ImgSubNode.Count;i++)
            {
                if(string.Compare(ImgSubNode[i].Text, Node.UpperDir) == 0)
                {
                    bMatch = true;
                    MatchNum = i;
                    break;
                }
            }

            if (!bMatch) { ImgSubNode.Add(SubNodes); MatchNum = ImgSubNode.Count - 1; }

            ImgSubNode[MatchNum].Nodes.Add(Node.ImageName);

            return true;
        }

    }
}
