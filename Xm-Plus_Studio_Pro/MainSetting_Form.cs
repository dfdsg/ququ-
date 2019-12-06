using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XM_Tek_Studio_Pro
{
    public partial class MainSetting_Form : Form
    {
        public MainSetting_Form()
        {
            InitializeComponent();

            Main_PicBox.Image = global::XM_Tek_Studio_Pro.Properties.Resources.XmMain;
            Main_PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
