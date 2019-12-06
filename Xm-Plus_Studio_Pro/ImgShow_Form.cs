using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public partial class ImgShow_Form : Form
    {

        public ImgShow_Form(string FileName)
        {
            InitializeComponent();
            if (new XM_IO_Util().IsFileExist(FileName))
                pic_show.Load(FileName);
            else
                lbl_msg.Text = "File Not Exist";

        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
