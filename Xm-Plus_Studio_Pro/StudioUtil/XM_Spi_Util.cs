using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XM_Tek_Studio_Pro.StudioUtil
{

    class XM_Spi_Util: XMBaseIfCtrl
    {
        public override bool WrImgWithHorizontal(byte[,] Pixels)
        {
            int Col = 0;
            byte Data = 0;

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x90, 0x02);        //CS Low

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x20);        //Device Address Mode
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x00);

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x21);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x00);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x7f);

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x22);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x00);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x07);

            int Width = Pixels.GetLength(0);
            int Height = Pixels.GetLength(1);
            Col = Height / 8;

            for (int h = 0; h < Col; h++)
            {
                for (int w = 0; w < Width; w++)
                {
                    Data = 0;
                    for (int x = 0; x < 8; x++)
                        Data = (byte)(Data + ((Pixels[w, h * 8 + x] & 0x80) >> (7 - x)));
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, Data);
                }
            }


            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x90, 0x03);        //CS High
            return true;
        }

        public override bool WrImgWithVertical(byte[,] Pixels)
        {

            byte Seg = 0;

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x90, 0x02);        //CS Low

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x20);       //Device Address Mode
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x01);

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x21);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x00);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x7f);

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x22);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x00);
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x07);

            for (int w = 0; w < Pixels.GetLength(0); w++)
            {
                for (int h = 0; h < (Pixels.GetLength(1) / 8); h++)
                {
                    Seg = 0;
                    for (int s = 0; s < 8; s++) Seg = (byte)(Seg + ((Pixels[w, h * 8 + s] & 0x80) >> (7 - s)));
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, Seg);
                }
            }

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x90, 0x03);        //CS High
            return true;
        }


        public override bool WrImgWithPage(byte[,] Pixels)
        {
            int Width = 0, Height = 0, PageNum = 0;
            byte Seg = 0;

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x90, 0x02);        //CS Low

            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x20);        //Device Address Mode
            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x02);

            Width = Pixels.GetLength(0);
            Height = Pixels.GetLength(1);
            PageNum = Height / 8;

            for (int h = 0; h < PageNum; h++)
            {
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x00);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, 0x10);
                XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x80, (byte)(0xb0 | (h & 0x07)));
                for (int w = 0; w < Width; w++)
                {
                    Seg = 0;
                    for (int s = 0; s < 8; s++) Seg = (byte)(Seg + ((Pixels[w, h * 8 + s] & 0x80) >> (7 - s)));
                    XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x81, Seg);
                }
            }


            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x90, 0x03);        //CS Low

            return true;
        }
    }
}
