using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XM_Tek_Studio_Pro.StudioUtil
{
    interface ISetI2CCtrl
    {
        bool SetI2CSlaveAddr(byte i2cAddr);
    }

    class XM_I2C_Util : XMBaseIfCtrl, ISetI2CCtrl
    {
        private byte I2CSlaveAddr = 0x78;

        private bool I2CmdWrite(byte Command)
        {
            byte[] I2CVal = new byte[] { Command };
            return I2CCmdWrite(I2CVal);
        }

        private bool I2CmdWrite(byte Address, byte Command)
        {
            byte[] I2CVal = new byte[] { Address, Command };
            return I2CCmdWrite(I2CVal);
        }

        private bool I2CmdWrite(byte Address, byte Cmd1,byte Cmd2)
        {
            byte[] I2CVal = new byte[] { Address, Cmd1 , Cmd2 };
            return I2CCmdWrite(I2CVal);
        }

        private bool I2CDataWrite(byte Command)
        {
            byte[] I2CVal = new byte[] { Command };
            return I2CDataWrite(I2CVal);
        }

        private bool I2CCmdWrite(byte[] XferData)
        {
            byte[] XmBlockData = new byte[XferData.Length + 1];
            Array.Clear(XmBlockData, 0, XmBlockData.Length);
            Array.Copy(XferData, 0, XmBlockData, 1, XferData.Length);
            return XM_Comm_Control.XM_Comm_Base.I2CWrite(I2CSlaveAddr, XmBlockData);
        }

        public  bool I2CDataWrite(byte[] XferData)
        {
            byte[] XmBlockData = Enumerable.Repeat((byte)0x40, (XferData.Length + 1)).ToArray();
            Array.Copy(XferData, 0, XmBlockData, 1, XferData.Length);
            return XM_Comm_Control.XM_Comm_Base.I2CWrite(I2CSlaveAddr, XmBlockData);
        }

        bool ISetI2CCtrl.SetI2CSlaveAddr(byte I2CAddr)
        {
            I2CSlaveAddr = I2CAddr;
            return true;
        }

        public override bool WrImgWithHorizontal(byte[,] Pixels)
        {
            int Col = 0;
            byte Data = 0;

        
            I2CmdWrite(0x20, 0x00); //Device Address Mode

            I2CmdWrite(0x21,0x00,0x7f);
            I2CmdWrite(0x22,0x00,0x07);

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
                    I2CDataWrite(Data);
                }
            }
            return true;
        }

        public override bool WrImgWithVertical(byte[,] Pixels)
        {

            byte Seg = 0;

            I2CmdWrite(0x20, 0x01);  //Device Address Mode

            I2CmdWrite(0x21, 0x00, 0x7f);
            I2CmdWrite(0x22, 0x00, 0x07);

            for (int w = 0; w < Pixels.GetLength(0); w++)
            {
                for (int h = 0; h < (Pixels.GetLength(1) / 8); h++)
                {
                    Seg = 0;
                    for (int s = 0; s < 8; s++) Seg = (byte)(Seg + ((Pixels[w, h * 8 + s] & 0x80) >> (7 - s)));
                    I2CDataWrite(Seg);
                }
            }

            return true;
        }


        public override bool WrImgWithPage(byte[,] Pixels)
        {
            int Width = 0, Height = 0, PageNum = 0;
            byte Seg = 0;

            I2CmdWrite(0x20, 0x02);    //Device Address Mode

            Width = Pixels.GetLength(0);
            Height = Pixels.GetLength(1);
            PageNum = Height / 8;

            for (int h = 0; h < PageNum; h++)
            {
                I2CmdWrite(0x00);
                I2CmdWrite(0x10);
                I2CmdWrite( (byte) (0xb0 | (h & 0x07)));
                for (int w = 0; w < Width; w++)
                {
                    Seg = 0;
                    for (int s = 0; s < 8; s++) Seg = (byte)(Seg + ((Pixels[w, h * 8 + s] & 0x80) >> (7 - s)));
                    I2CDataWrite(Seg);
                }
            }
            return true;
        }
    }
}
