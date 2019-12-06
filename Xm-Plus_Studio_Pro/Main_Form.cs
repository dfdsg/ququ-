using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using XM_Tek_Studio_Pro.StudioUtil;
using XMToolDll;
using System.Drawing;

namespace XM_Tek_Studio_Pro
{

    public partial class Main_Form : Form
    {
        private USB_Flash_Program GL660 = null;
        private USB2EPP_ComEdit ComEdit = null;
        private List<XMBridgeInfo> PastDev = new List<XMBridgeInfo>();
        private ManualResetEvent ImgEvent = new ManualResetEvent(false);
        Form rootForm = null;
        InterfaceSetting_Form DisplayForm = null;
        ScriptSetting_Form WolForm = null;
        MainSetting_Form MainForm = null;
        ExpandFpga_Form FpgaParForm = null;
        Thread DevThread = null, ImgThread = null;
        public static Main_Form frmMain = null;
        const int WM_KEYDOWN = 256;
        const int WM_SYSKEYDOWN = 260;
        enum MSG : int { MSG_VAL = 1, MSG_PROG, MSG_SPTMODE, MSG_SPTNAME, MSG_XMDEV, MSG_COMM, MSG_XMIMG, MSG_XMCLRIMG, MSG_KONICA };
        private XmImage[] XmOldImg;

        private const string COLORDEV = "COLORDEV";
        private const string COMMDEV = "Comm";
        string FpgaVersion = null;
        uint Val = 0;
        public Main_Form()
        {
            InitializeComponent();
            InitialSetting();
            frmMain = this;
            DisplayForm = new InterfaceSetting_Form();
            WolForm = new ScriptSetting_Form();
            MainForm = new MainSetting_Form();
            FpgaParForm = new ExpandFpga_Form();
            DisplayForm.MdiParent = this;
            WolForm.MdiParent = this;
            MainForm.MdiParent = this;
            FpgaParForm.MdiParent = this;
            ShowSubMdi(MainForm);
            ScanDevThread();
            ScanGraphThread();

            XM_Comm_Control.XM_Comm_Type.Add(new XM_Comm_IO_Control());
            XM_Comm_Control.XM_Comm_Type.Add(new XM_Comm_USB_Control());
            XM_Comm_Control.XM_Comm_Base = XM_Comm_Control.XM_Comm_Type[1];
        }

        private void InitialSetting()
        {
            
            ContextMenuStrip menuStrip = new ContextMenuStrip();
            XM_IO_Util IOUtil = new XM_IO_Util();
            Setting.ExePath = Application.StartupPath;
           
            //Create Picture Floder
            Setting.ExeImgDirPath = Setting.ExePath + "\\Image";
            IOUtil.CreateDir(Setting.ExeImgDirPath);

            //Create Log Floder
            Setting.ExeLogDirPath = Setting.ExePath + "\\Log";
            IOUtil.CreateDir(Setting.ExeLogDirPath);

            //Create Script Floder
            Setting.ExeSptDirPath = Setting.ExePath + "\\Script";
            IOUtil.CreateDir(Setting.ExeSptDirPath);

            //Create System Floder
            Setting.ExeDriverPath = Setting.ExePath + "\\Driver";
            IOUtil.CreateDir(Setting.ExeDriverPath);

            //Create Scope Floder
            Setting.ExeScopeDirPath = Setting.ExePath + "\\Scope";
            IOUtil.CreateDir(Setting.ExeScopeDirPath);

            //Create Scope Floder
            Setting.ExeSDCardDirPath = Setting.ExePath + "\\SDCard";
            IOUtil.CreateDir(Setting.ExeSDCardDirPath);

           
            //Create System INI
            Setting.ExeSysIniPath = Setting.ExePath + "\\.xmplus.ini";

            //Create DataSource
            Setting.DataSourcePath = Setting.ExePath + "\\Command List.csv";

            

            //Copy Dll
            string EppDll = Application.StartupPath + "\\EPP2USB_DLL_V12.dll";
            IOUtil.OutputDll(EppDll, "XM_Tek_Studio_Pro.Resources.EPP2USB_DLL_V12.dll");

            //Copy FastColoredTextBox.dll
            string FastColorDll = Application.StartupPath + "\\XMColoredLib.dll";
            IOUtil.OutputDll(FastColorDll, "XM_Tek_Studio_Pro.Resources.XMColoredLib.dll");

            //Create Pattern Gen
            string ImageExe = Setting.ExeImgDirPath + "\\PAT_gen_V13.exe";
            IOUtil.OutputDll(ImageExe, "XM_Tek_Studio_Pro.Resources.PAT_gen_V13.exe");

            //Copy DataGridViewNumericUpDownElements
            string NumericUpDownDll = Application.StartupPath + "\\XMGridViewCtrl.dll";
            IOUtil.OutputDll(NumericUpDownDll, "XM_Tek_Studio_Pro.Resources.XMGridViewCtrl.dll");

            //Copy Kclmtr
            string KClmtrWrapperDll = Application.StartupPath + "\\KClmtrWrapper.dll";
            IOUtil.OutputDll(KClmtrWrapperDll, "XM_Tek_Studio_Pro.Resources.KClmtrWrapper.dll");

            //Copy ReleaseHistory
            string XMToolDll = Application.StartupPath + "\\XMToolDll.dll";
            IOUtil.OutputDll(XMToolDll, "XM_Tek_Studio_Pro.Resources.XMToolDll.dll");

            //Create Pattern Gen
            string XmToolPdf = Setting.ExeLogDirPath + "\\INRUSH_CURRENT_RIPPLE_RELAY_BOARD_UserGuide.pdf";
            IOUtil.OutputDll(XmToolPdf, "XM_Tek_Studio_Pro.Resources.INRUSH_CURRENT_RIPPLE_RELAY_BOARD_UserGuide");

            //Create Sample Script
            IOUtil.OutputTxt(Setting.ExeSptDirPath + "\\CPT47_iPhone6_initialcode_20180521.txt", Properties.Resources.CPT47_iPhone6_initialcode_20180521);
            IOUtil.OutputTxt(Setting.ExeSptDirPath + "\\Xm92180.ini", Properties.Resources.Xm92180);
            IOUtil.OutputTxt(Setting.ExeSptDirPath + "\\008_Command_mode_init_code.txt", Properties.Resources._008_Command_mode_init_code);

           

            //Create GL600 Driver
            IOUtil.OutputTxt(Setting.ExeDriverPath + "\\Xm_USB20_v11.inf", Properties.Resources.Xm_USB20_v11);

            //Create System INI
            if (!File.Exists(Setting.ExeSysIniPath)) IOUtil.OutputTxt(Setting.ExeSysIniPath, Properties.Resources.Default_Config_V01);
            if (!File.Exists(Setting.DataSourcePath)) IOUtil.OutputCSV(Setting.DataSourcePath, Properties.Resources.Command_List);

            TsBtn_CA210.Visible = false;
            TsBtn_RS232.Visible = false;

            TrvImages.ContextMenuStrip = menuStrip;
            menuStrip.Items.Add("Show");
            menuStrip.Items.Add("Open");
            menuStrip.Items.Add("Preview");
            menuStrip.Items.Add("Copy");
            menuStrip.ItemClicked += new ToolStripItemClickedEventHandler(Image_ItemClicked);          
        }

        private void EnScanGraphThread(bool bStop)
        {
            if (bStop)
            {
                XmOldImg = null;
                ImgEvent.Set();

            }
            else
                ImgEvent.Reset();
        }

        private void ScanGraphThread()
        {
            ImgThread = new Thread(ScanImgThread)
            {
                IsBackground = true
            };

            ImgThread.Start();
        }

        private void ScanDevThread()
        {
            DevThread = new Thread(UsbDevList)
            {
                IsBackground = true
            };
            DevThread.Start();
        }

        private void ScanImgThread()
        {
            XM_IO_Util XmUtil = new XM_IO_Util(Setting.ExeImgDirPath);
            XmImage[] XmNewImg = null;
            while (true)
            {
                ImgEvent.WaitOne();
                XmNewImg = XmUtil.GetDirAndImages();
                if (XmOldImg == null) { XmOldImg = XmNewImg; UpdateMsgTree(XmOldImg); }
                if (!XmUtil.CmpXmImgs(XmNewImg, XmOldImg))
                {
                    XmOldImg = XmNewImg;
                    UpdateMsgTree(XmOldImg);
                }
                Thread.Sleep(50);
            }
        }

        private void UsbDevList()
        {
            XM_Dev_Util DevUtil = new XM_Dev_Util();
            string Version = null, UsbDevList = null ;
            List<XMBridgeInfo> NowDev =  new List<XMBridgeInfo>();
            
            while (true)
            {
                NowDev.Clear();
                Version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();

                if (DevUtil.GetUSBDevs() > 0)
                {
                    List<XM_Dev_Util.XMDevInfo> UsbDev = DevUtil.FindXMDev();
                    foreach (XM_Dev_Util.XMDevInfo XmDev in UsbDev)
                        NowDev.Add(new XMBridgeInfo(XmDev.DevID, XmDev.Description));              
                }

                NowDev.Add(new XMBridgeInfo("Studio Version", Version));


                if (!DevUtil.DevCmp(PastDev.ToArray(), NowDev.ToArray()))
                {
                    Parm.Usb_bConn = false;
                    PastDev.Clear();
                    UsbDevList = null;

                    foreach (XMBridgeInfo info in NowDev)
                        UsbDevList += info.DevInfo + " , " + info.Description + " , ";
                 
                    InvokeUsbDevInfo(UsbDevList);
                    PastDev.AddRange(NowDev);
                }   
                Thread.Sleep(25);
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void ExitEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Epp2USB.GeneCloseHandle();
            this.Close();
        }

        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Epp2USB.GeneCloseHandle();
        }
        //--------------------------------------------------------------------------------------------------
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        //--------------------------------------------------------------------------------------------------
        private void USBFlashEditToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GL660 == null)
            {
                GL660 = new USB_Flash_Program();
            }
            if (GL660.IsDisposed == true)
            {
                GL660 = new USB_Flash_Program();
            }
            GL660.ShowDialog();
            GL660.Activate();
        }


        //--------------------------------------------------------------------------------------------------
        private void USBToEPPCommandEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ComEdit == null)
            {
                ComEdit = new USB2EPP_ComEdit();
            }
            if (ComEdit.IsDisposed == true)
            {
                ComEdit = new USB2EPP_ComEdit();
            }
            ComEdit.Show();
            ComEdit.Activate();
        }

        private void ToolStripBtn_Home_Click(object sender, EventArgs e)
        {
            ShowSubMdi(MainForm);
            SetUpScript(false);
        }

        private void TsBtn_RS232_Click(object sender, EventArgs e)
        {
            if (ScriptSetting_Form.frmScript.CommDev == null)
            {
                CommPort_Form CommPage = new CommPort_Form(XMPLUSPARS.SECTION2);
                if (CommPage.ShowDialog() == DialogResult.OK) ScriptSetting_Form.frmScript.InvokeCommDev(1, COMMDEV);
            }else
                ScriptSetting_Form.frmScript.InvokeCommDev(0, COMMDEV);
        }

        private void TsBtn_CA210_Click(object sender, EventArgs e)
        {
            ColorPort_Form ColorDevPage = new ColorPort_Form(XMPLUSPARS.SECTION3);
            if (ScriptSetting_Form.frmScript.ColorDev == null && ScriptSetting_Form.frmScript.kClmtr == null)
            { 
                if (ColorDevPage.ShowDialog() == DialogResult.OK)
                    ScriptSetting_Form.frmScript.InvokeColorDev(1, COLORDEV);
            }else
                ScriptSetting_Form.frmScript.InvokeColorDev(0, COLORDEV);
        }

        private void TsBtn_ScriptPage_Click(object sender, EventArgs e)
        {
            ShowSubMdi(WolForm);
            SetUpScript(true);
        }

        private void ToolStripBtn_DisplaySet_Click(object sender, EventArgs e)
        {
            ShowSubMdi(DisplayForm);
            SetUpScript(false);

        }

        private void ToolStripBtn_SetParFpag_Click(object sender, EventArgs e)
        {
            ShowSubMdi(FpgaParForm);
            SetUpScript(false);
        }

        private void ShowSubMdi(Form subForm)
        {
            rootForm = subForm;
            rootForm.WindowState = FormWindowState.Maximized;
            rootForm.ControlBox = false;
            rootForm.Show();
        }

        private void TreeView_SysInfo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            XM_Dev_Util XmDevUtil = new XM_Dev_Util();
            string strChildNode = null, strRootNode = null, strVidPid = null;

            if (e.Node.Parent == null) //Root
            {
                strVidPid = strRootNode = e.Node.ToString();
                strVidPid = strChildNode = e.Node.Nodes[0].ToString();
            }
            else                      //Child
            {
                strVidPid = strRootNode = e.Node.Parent.ToString();
                strVidPid = strChildNode = e.Node.ToString();
            }

            if (XmDevUtil.GetDevItem(strVidPid))
            {
                Parm.Usb_bConn = Epp2USB.FindScanner((ushort)XmDevUtil.GetVid(), (ushort)XmDevUtil.GetPid());
                if (Parm.Usb_bConn)
                {
                    txt_usb.Text = XmDevUtil.GetRootDevInfo(strRootNode);
                    txt_usb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                    Parm.XMUsbDev = new XMUsbDevInfo(strRootNode, (ushort)XmDevUtil.GetVid(), (ushort)XmDevUtil.GetPid());
 //add fpga version:                   
                    TreeNode fathernode;
                    TreeNode childnode;
                    bool Ret = XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x01, ref  Val, 1);
                    if (Val.ToString("X2") == "05" && Ret)
                    {
                        FpgaVersion = "05";
                        childnode = new TreeNode(FpgaVersion + "  " + "Vedio Mode");
                        fathernode = treeView_SysInfo.Nodes.Add("Fpga Version");
                        fathernode.Nodes.Add(childnode);
                    }
                    else
                    {
                        FpgaVersion = "06";
                        childnode = new TreeNode(FpgaVersion + "  " + "Command Mode");
                        fathernode = treeView_SysInfo.Nodes.Add("Fpga Version");
                        fathernode.Nodes.Add(childnode);
                    }
                }
                else
                {
                    txt_usb.Text = "USB Fail, Please re-Plug again          ";
                    txt_usb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                }
            }
        }

        private void SetUpScript(bool bSetup)
        {
            if(bSetup)
            {
                ShowXmImg(bSetup);
                TsBtn_CA210.Visible = bSetup;
                TsBtn_RS232.Visible = bSetup;
            }
            else
            {
                ClrXmImg(bSetup);
                TsBtn_CA210.Visible = bSetup;
                TsBtn_RS232.Visible = bSetup;
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.F1:
                        ShowSubMdi(MainForm);
                        SetUpScript(false);
                        break;
                    case Keys.F2:
                        ShowSubMdi(WolForm);
                        SetUpScript(true);
                        break;
                    case Keys.F3:
                        ShowSubMdi(DisplayForm);
                        SetUpScript(false);
                        break;
                    case Keys.F4:
                        ShowSubMdi(FpgaParForm);
                        SetUpScript(false);
                        break;
                    case Keys.F5:
                        Scope_Form scopeform = new Scope_Form();
                        scopeform.ShowDialog();
                        //SetUpScript(false);
                        break;
                    case (Keys.Control | Keys.Alt | Keys.R):
                        {
                            XMToolDll.ReleaseForm ReleaseForm = new XMToolDll.ReleaseForm();
                            ReleaseForm.ShowDialog();
                        }
                        break;
                }
            }
            return false;
        }



        private void Tsmi_DisplayScript_Click(object sender, EventArgs e)
        {
            ShowSubMdi(WolForm);
        }

        private void Tsmi_AutoSetFpga_Click(object sender, EventArgs e)
        {
            ShowSubMdi(DisplayForm);
        }

        private void Tsmi_ManualSetFpag_Click(object sender, EventArgs e)
        {
            ShowSubMdi(FpgaParForm);
        }

        public void InvokePrgbMax(int Val)
        {
            MyMarshalToForm((int)MSG.MSG_VAL, Val.ToString(), "");
        }

        public void InvokePrgbPos(int Pos)
        {
            MyMarshalToForm((int)MSG.MSG_PROG, Pos.ToString(), "");
        }

        public void InvokeSelInfo(string SelMode)
        {
            MyMarshalToForm((int)MSG.MSG_SPTMODE, SelMode, "");
        }

        public void InvokeSptName(string SptName)
        {
            MyMarshalToForm((int)MSG.MSG_SPTNAME, SptName, "");
        }

        public void ClrUsbCon()
        {
            PastDev.Clear();
        }

        public void InvokeUsbDevInfo(string DevMsg)
        {
            MyMarshalToForm((int)MSG.MSG_XMDEV, DevMsg, "");
        }

        public void InvokeComm(string Mode)
        {
            MyMarshalToForm((int)MSG.MSG_COMM, Mode, "");
        }

        public void InvokeColorDev(string Mode)
        {
            MyMarshalToForm((int)MSG.MSG_KONICA, Mode, "");
        }

        private delegate void MarshalToForm(int action, String textToAdd, object dt, int iRowRefresh = -1);


        ///  <summary>
        ///  Enables accessing a form's controls from another thread 
        ///  </summary>
        ///  
        ///  <param name="action"> a String that names the action to perform on the form </param>
        ///  <param name="textToDisplay"> text that the form displays or the code uses for 
        ///  another purpose. Actions that don't use text ignore this parameter.  </param>

        public void MyMarshalToForm(int Action, String textToDisplay, object dt, int iRowToRefresh = -1)
        {
            try
            {
                object[] args = { Action, textToDisplay, dt, iRowToRefresh };
                MarshalToForm MarshalToFormDelegate = null;

                //  The AccessForm routine contains the code that accesses the form.

                MarshalToFormDelegate = new MarshalToForm(AccessForm);

                //  Execute AccessForm, passing the parameters in args.

                base.BeginInvoke(MarshalToFormDelegate, args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AccessForm(int Action, String formText, object dt, int iRowRefresh )
        {
            switch (Action)
            {
                case (int)MSG.MSG_VAL:
                    prgb_rate.Maximum = int.Parse(formText);
                    break;
                case (int)MSG.MSG_PROG:
                    prgb_rate.Value = int.Parse(formText);
                    break;
                case (int)MSG.MSG_SPTMODE:
                    tsplbl_modemsg.Text = formText;
                    break;
                case (int)MSG.MSG_SPTNAME:
                    tsplbl_sptname.Text = formText;
                    break;
                case (int)MSG.MSG_XMDEV:
                    ShowXmDev(formText);
                    break;
                case (int)MSG.MSG_COMM:
                    SetUpXmComm(formText);
                    break;
                case (int)MSG.MSG_KONICA:
                    MeasureGarma(formText);
                    break;
                default:
                    break;
            }
        }

        delegate void UpdateMessageVoidDelegate(XmImage[] XmImg);

        private void UpdateMsgTree(XmImage[] XmImg)
        {
            if (this.TrvImages.InvokeRequired)
            {
                UpdateMessageVoidDelegate d = new UpdateMessageVoidDelegate(UpdateMsgTree);
                this.Invoke(d, new object[] { XmImg });
            }
            else
            {
                UpdateImgShow(XmImg);
            }
        }

        private void UpdateImgShow(XmImage[] XmImg)
        {
            TrvImages.Nodes.Clear();
            XM_Img_Lib ImgUtil = new XM_Img_Lib();
            List<TreeNode> ImgSubNode = new List<TreeNode>();

            foreach (XmImage Node in XmImg)
                ImgUtil.AddTreeNode(ImgSubNode, Node);
               
            foreach (TreeNode Node in ImgSubNode)
                TrvImages.Nodes.Add(Node);

            TrvImages.ExpandAll();
        }

        private void SetUpXmComm(string Mode)
        {
            switch (Mode)
            {
                case "Open":
                    TsBtn_RS232.Image = Properties.Resources.RS232_Open;
                    TsBtn_RS232.ToolTipText = string.Concat(Properties.Resources.OPEN_MSG, " ", Properties.Resources.SUCCESS_MSG); ;
                    break;
                case "Close":
                    TsBtn_RS232.Image = Properties.Resources.RS232_NO;
                    TsBtn_RS232.ToolTipText = Properties.Resources.CLOSE_MSG;
                    break;
                case "Initial":
                    TsBtn_RS232.Image = Properties.Resources.RS232;
                    TsBtn_RS232.ToolTipText = string.Concat(Properties.Resources.OPEN_MSG, " ", Properties.Resources.COMM_MSG); ;      
                    break;
                default:
                    TsBtn_RS232.Image = Properties.Resources.RS232;
                    break;
            }
        }

        private void MeasureGarma(string Mode)
        {
            switch (Mode)
            {
                case "Open":
                    TsBtn_CA210.Image = Properties.Resources.CA210_Open;
                    TsBtn_CA210.ToolTipText = string.Concat(Properties.Resources.OPEN_MSG, " " + Properties.Resources.SUCCESS_MSG); ;
                    break;
                case "Close":
                    TsBtn_CA210.Image = Properties.Resources.CA210_NO;
                    TsBtn_CA210.ToolTipText = Properties.Resources.CLOSE_MSG;
                    break;
                case "Initial":
                    TsBtn_CA210.Image = Properties.Resources.CA210;
                    TsBtn_CA210.ToolTipText = string.Concat(Properties.Resources.OPEN_MSG, " " + Properties.Resources.OPTICS_MSG);
                    break;
                default:
                    TsBtn_CA210.Image = Properties.Resources.CA210;
                    break;
            }
        }

        private void ShowDevToTree(List<XMBridgeInfo> XmDev)
        {
            foreach (XMBridgeInfo XmInfo in XmDev)
            {
                TreeNode rootnode = new TreeNode(XmInfo.DevInfo, 0, 1)
                {
                    ToolTipText = XmInfo.Description
                };
                rootnode.Nodes.Add("", XmInfo.Description, 0, 1);
                treeView_SysInfo.Nodes.Add(rootnode);
            }
        }

        private void OpenUsbBridge()
        {
            string Usb = treeView_SysInfo.Nodes[0].ToString();
            if(Usb.Contains("Xm") || Usb.Contains("3R") ||  Usb.Contains("SC"))
                treeView_SysInfo.SelectedNode = treeView_SysInfo.Nodes[0];
        }


        private void ShowXmDev(string Msg)
        {
            treeView_SysInfo.Nodes.Clear();
            txt_usb.Text = "";
            string[] MsgList = Msg.Split(',');
            string Description = null;
            uint Val = 0;
            Array.Resize(ref MsgList, MsgList.Length - 1);         
            List<XMBridgeInfo> XmDev = new List<XMBridgeInfo>();

            for (int i = 0; i < MsgList.Length; i += 2)
                XmDev.Add(new XMBridgeInfo(MsgList[i], MsgList[i+1]));

            ShowDevToTree(XmDev);

            OpenUsbBridge();
            //System Version
            XmDev.Clear();
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x00, ref Val, 3);
            Description = string.Concat("ID\\", Val.ToString("X2"));
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x01, ref Val, 1);
            Description = string.Concat(Description, "&Ver\\",Val.ToString("X2"));
            XmDev.Add(new XMBridgeInfo("Platform Version", Description));

            if (Parm.Usb_bConn) ShowDevToTree(XmDev);

        }

        private void ClrXmImg(bool Enable)
        {
            TrvImages.Nodes.Clear();
            EnScanGraphThread(Enable);
        }

        private void ShowXmImg(bool Enable)
        {
            EnScanGraphThread(Enable);

        }

        private bool GetTrvNodeImage(ref string FilePath)
        {
            string ImgName =null, ParentImg =null;  
            try
            {
               // ImgName = TrvImages.SelectedNode.Text.ToString();
               // ParentImg = TrvImages.SelectedNode.Parent.ToString();
                ImgName = TrvImages.SelectedNode?.Text.ToString();
               ParentImg = TrvImages.SelectedNode.Parent?.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Choose the Right Node");
                return false;
                throw;
            }

            if (string.IsNullOrEmpty(ParentImg)) { MessageBox.Show("Please Choose the Right Node"); return false; }
            string[] Node = ParentImg.Split(':');
            if (2 > Node.Length) return false;
            FilePath = string.Compare(Node[1].Trim(), "Image") == 0 ? string.Concat("Image", "\\", ImgName) : 
                string.Concat("Image", "\\",Node[1].Trim(), "\\", ImgName);

            return true;
        }

        void Image_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string ImgPath = null;

            switch (e.ClickedItem.Text)
            {
                case "Preview":
                    if (!GetTrvNodeImage(ref ImgPath)) return;
                    ImgShow_Form ImageShow = new ImgShow_Form(ImgPath);
                    ImageShow.ShowDialog();
                    break;
                case "Show":
                    if (!GetTrvNodeImage(ref ImgPath)) return;
                    ShowImage(ImgPath);
                    break;
                case "Copy":
                    if (!GetTrvNodeImage(ref ImgPath)) return;
                    Clipboard.SetDataObject(ImgPath);
                    break;
                case "Open":
                    string TmpDir = string.Concat(Setting.ExeImgDirPath, "\\", "Temp");
                    if (!OpenImage(ref ImgPath)) return;
                    XM_IO_Util FileUtil = new XM_IO_Util(ImgPath);
                    FileUtil.CreateDir(TmpDir);
                    FileUtil.CopyFileToDir(ImgPath, TmpDir);
                    TmpDir = Path.Combine(TmpDir, Path.GetFileName(ImgPath));
                    ScriptSetting_Form.frmScript.InvokeDownload(0, TmpDir);
                    tsplbl_fileinfo.Text = string.Concat(Path.GetFileName(ImgPath), " Show Finished");
                    break;
            }
        }

        private void ScriptCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help_Form helpform = new Help_Form();
            helpform.Show();
        }

        private void PatternGenV12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ImageExe = Setting.ExeImgDirPath + "\\PAT_gen_V13.exe";
            if (File.Exists(ImageExe)) Process.Start(ImageExe);
        }

        private void OscilloscopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scope_Form ScopeForm = new Scope_Form();
            ScopeForm.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void TemperatureChamberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instrument Frm = new Instrument();
            Frm.ShowDialog();
        }

        private void TemperatureChamberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Instrument TempChamper = new Instrument();
            TempChamper.ShowDialog();
        }

        private void SourceMeasureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Source_Measure SourceMeter = new Source_Measure();
            SourceMeter.ShowDialog();
        }

        private void PWMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PWM_Measure PwmMeter = new PWM_Measure();
            PwmMeter.ShowDialog();
        }

        private void Trv_Images_DoubleClick(object sender, EventArgs e)
        {
            string ImgPath = null;
            if (!GetTrvNodeImage(ref ImgPath)) return;
            ShowImage(ImgPath);
        }

        private void ShowImage(string ImgName)
        {
            if (new XM_IO_Util().IsFileExist(ImgName))
            {
                ScriptSetting_Form.frmScript.InvokeDownload(0, ImgName);
                tsplbl_fileinfo.Text = string.Concat(ImgName, " Show Finished");
            }
            else
                tsplbl_fileinfo.Text = string.Concat(ImgName, " Not Exist");

        }

        private void CommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string XmToolPath = Setting.ExeLogDirPath + "\\INRUSH_CURRENT_RIPPLE_RELAY_BOARD_UserGuide.pdf";
            ProcessStartInfo startInfo = new ProcessStartInfo(XmToolPath);
            Process.Start(startInfo);
        }

        private bool OpenImage(ref string ImageFile)
        {
           XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeImgDirPath);
           string FilePath = IniUtil.IniReadValue("System", "ImageDir");
           FilePath = (FilePath == "NULL") ? Setting.ExeImgDirPath : FilePath;

           OpenFileDialog ImaageFile = new OpenFileDialog
           {
                FileName = "Test.bmp",
                Filter = "Image Files|*.bmp|*.png|*.jpg",
                InitialDirectory = FilePath,
                DefaultExt = "*.bmp"
           };

           if (ImaageFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
           {
                IniUtil.IniWriteValue("System", "ImageDir", ImaageFile.FileName);
                ImageFile = ImaageFile.FileName;
            }
            else
                return false;

            return true;
        }



        private void GammaToolToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            XmGammaTool GammaTool = new XmGammaTool();
            GammaTool.ShowDialog();
        }

        private void SDCardControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SDCardControl SDCardControl = new SDCardControl();
            SDCardControl.ShowDialog();
        }

        private void ReleaseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            XMToolDll.ReleaseForm ReleaseForm = new XMToolDll.ReleaseForm();
            ReleaseForm.ShowDialog();
        }

        private void FileCompareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmFileCompare FileCmp = new XmFileCompare();
            FileCmp.Show();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }
        string imgname;int flag;
        private void TrvImages_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            imgname = e.Node.Text.ToString();
            if (!(imgname == "Image"))
            {
                toolTip1.Show(imgname, this, MousePosition.X - 300, MousePosition.Y - 180);
                flag = 1;
            }
        }
        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            if (!(imgname == "Image"))
            {
                string path = string.Concat(Setting.ExeImgDirPath, "\\", imgname);
                Bitmap bmp = new Bitmap(path);
                Rectangle imageRec = new Rectangle(e.Bounds.X, e.Bounds.Y, 135, 240);
                e.Graphics.DrawImage(bmp, imageRec);
            }

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(135,240);
        }

       

        private void TrvImages_MouseLeave(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                toolTip1.Active = false;
            }
            flag = 0;
            toolTip1.Active = true;
        }

        private void MIPILpSlewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MipiLp_SlewRate_Form MipiSlewRateTool = new MipiLp_SlewRate_Form();
            MipiSlewRateTool.ShowDialog();
        }
    }
}
