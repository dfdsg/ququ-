using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace XM_Tek_Studio_Pro
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }


        private void About_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            txtBox_version.Text  = fileVersionInfo.ProductVersion;
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


