namespace XM_Tek_Studio_Pro
{
    partial class ScriptSetting_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptSetting_Form));
            this.cms_elecscmd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Tsmi_CmdSend = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsmi_CmdCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsmi_CmdPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsmi_CmdSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsmi_CmdClear = new System.Windows.Forms.ToolStripMenuItem();
            this.SDCardGen = new System.Windows.Forms.ToolStripMenuItem();
            this.IfSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_elecsmsg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_MsgCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_MsgSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_MsgClear = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_CommSet = new System.Windows.Forms.Panel();
            this.gbx_instrument = new System.Windows.Forms.GroupBox();
            this.btn_Scan = new System.Windows.Forms.Button();
            this.trv_instru = new System.Windows.Forms.TreeView();
            this.gbx_CommSetting = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_CommClose = new System.Windows.Forms.Button();
            this.Btn_CommOpen = new System.Windows.Forms.Button();
            this.Btn_LoadSpt = new System.Windows.Forms.Button();
            this.Btn_CommSend = new System.Windows.Forms.Button();
            this.Btn_AddPage = new System.Windows.Forms.Button();
            this.Btn_DelTabs = new System.Windows.Forms.Button();
            this.Btn_CloseAll = new System.Windows.Forms.Button();
            this.btn_CtrlCenter = new System.Windows.Forms.Button();
            this.pnl_CmdPage = new System.Windows.Forms.Panel();
            this.Tctl_Pages = new System.Windows.Forms.TabControl();
            this.gbx_elecsmsg = new System.Windows.Forms.GroupBox();
            this.rtf_ElecsMsg = new System.Windows.Forms.RichTextBox();
            this.cms_elecscmd.SuspendLayout();
            this.cms_elecsmsg.SuspendLayout();
            this.pnl_CommSet.SuspendLayout();
            this.gbx_instrument.SuspendLayout();
            this.gbx_CommSetting.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.pnl_CmdPage.SuspendLayout();
            this.gbx_elecsmsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms_elecscmd
            // 
            this.cms_elecscmd.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_elecscmd.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_elecscmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsmi_CmdSend,
            this.Tsmi_CmdCopy,
            this.Tsmi_CmdPaste,
            this.Tsmi_CmdSaveAs,
            this.Tsmi_CmdClear,
            this.SDCardGen,
            this.IfSetToolStripMenuItem,
            this.CommentToolStripMenuItem,
            this.UnCommentToolStripMenuItem});
            this.cms_elecscmd.Name = "cms_elecscmd";
            this.cms_elecscmd.Size = new System.Drawing.Size(155, 274);
            // 
            // Tsmi_CmdSend
            // 
            this.Tsmi_CmdSend.Image = global::XM_Tek_Studio_Pro.Properties.Resources.CommPlay;
            this.Tsmi_CmdSend.Name = "Tsmi_CmdSend";
            this.Tsmi_CmdSend.Size = new System.Drawing.Size(154, 30);
            this.Tsmi_CmdSend.Text = "Send";
            this.Tsmi_CmdSend.Click += new System.EventHandler(this.Tsmi_CmdSend_Click);
            // 
            // Tsmi_CmdCopy
            // 
            this.Tsmi_CmdCopy.Image = global::XM_Tek_Studio_Pro.Properties.Resources.copy;
            this.Tsmi_CmdCopy.Name = "Tsmi_CmdCopy";
            this.Tsmi_CmdCopy.Size = new System.Drawing.Size(154, 30);
            this.Tsmi_CmdCopy.Text = "Copy";
            this.Tsmi_CmdCopy.Click += new System.EventHandler(this.Tsmi_CmdCopy_Click);
            // 
            // Tsmi_CmdPaste
            // 
            this.Tsmi_CmdPaste.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Right_Arrow_48x48;
            this.Tsmi_CmdPaste.Name = "Tsmi_CmdPaste";
            this.Tsmi_CmdPaste.Size = new System.Drawing.Size(154, 30);
            this.Tsmi_CmdPaste.Text = "Paste";
            this.Tsmi_CmdPaste.Click += new System.EventHandler(this.Tsmi_CmdPaste_Click);
            // 
            // Tsmi_CmdSaveAs
            // 
            this.Tsmi_CmdSaveAs.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Save_48x48;
            this.Tsmi_CmdSaveAs.Name = "Tsmi_CmdSaveAs";
            this.Tsmi_CmdSaveAs.Size = new System.Drawing.Size(154, 30);
            this.Tsmi_CmdSaveAs.Text = "Save As";
            this.Tsmi_CmdSaveAs.Click += new System.EventHandler(this.Tsmi_CmdSaveAs_Click);
            // 
            // Tsmi_CmdClear
            // 
            this.Tsmi_CmdClear.Image = global::XM_Tek_Studio_Pro.Properties.Resources.exit_64x64;
            this.Tsmi_CmdClear.ImageTransparentColor = System.Drawing.Color.White;
            this.Tsmi_CmdClear.Name = "Tsmi_CmdClear";
            this.Tsmi_CmdClear.Size = new System.Drawing.Size(154, 30);
            this.Tsmi_CmdClear.Text = "Clear";
            this.Tsmi_CmdClear.Click += new System.EventHandler(this.Tsmi_CmdClear_Click);
            // 
            // SDCardGen
            // 
            this.SDCardGen.Image = global::XM_Tek_Studio_Pro.Properties.Resources.SDCardtoBin;
            this.SDCardGen.Name = "SDCardGen";
            this.SDCardGen.Size = new System.Drawing.Size(154, 30);
            this.SDCardGen.Text = "SDCardGen";
            this.SDCardGen.Click += new System.EventHandler(this.SDCardGen_Click);
            // 
            // IfSetToolStripMenuItem
            // 
            this.IfSetToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.IfSet;
            this.IfSetToolStripMenuItem.Name = "IfSetToolStripMenuItem";
            this.IfSetToolStripMenuItem.Size = new System.Drawing.Size(154, 30);
            this.IfSetToolStripMenuItem.Text = "Interface";
            this.IfSetToolStripMenuItem.Click += new System.EventHandler(this.IfSetToolStripMenuItem_Click);
            // 
            // CommentToolStripMenuItem
            // 
            this.CommentToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Comment;
            this.CommentToolStripMenuItem.Name = "CommentToolStripMenuItem";
            this.CommentToolStripMenuItem.Size = new System.Drawing.Size(154, 30);
            this.CommentToolStripMenuItem.Text = "Comment";
            this.CommentToolStripMenuItem.Click += new System.EventHandler(this.CommentToolStripMenuItem_Click);
            // 
            // UnCommentToolStripMenuItem
            // 
            this.UnCommentToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.UnComment;
            this.UnCommentToolStripMenuItem.Name = "UnCommentToolStripMenuItem";
            this.UnCommentToolStripMenuItem.Size = new System.Drawing.Size(154, 30);
            this.UnCommentToolStripMenuItem.Text = "Uncomment";
            this.UnCommentToolStripMenuItem.Click += new System.EventHandler(this.UnCommentToolStripMenuItem_Click);
            // 
            // cms_elecsmsg
            // 
            this.cms_elecsmsg.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_elecsmsg.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_elecsmsg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_MsgCopy,
            this.tsmi_MsgSaveAs,
            this.tsmi_MsgClear});
            this.cms_elecsmsg.Name = "cms_elecsmsg";
            this.cms_elecsmsg.Size = new System.Drawing.Size(185, 104);
            // 
            // tsmi_MsgCopy
            // 
            this.tsmi_MsgCopy.Image = global::XM_Tek_Studio_Pro.Properties.Resources.copy;
            this.tsmi_MsgCopy.Name = "tsmi_MsgCopy";
            this.tsmi_MsgCopy.Size = new System.Drawing.Size(184, 26);
            this.tsmi_MsgCopy.Text = "Copy";
            this.tsmi_MsgCopy.Click += new System.EventHandler(this.Tsmi_MsgCopy_Click);
            // 
            // tsmi_MsgSaveAs
            // 
            this.tsmi_MsgSaveAs.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Save_48x48;
            this.tsmi_MsgSaveAs.Name = "tsmi_MsgSaveAs";
            this.tsmi_MsgSaveAs.Size = new System.Drawing.Size(184, 26);
            this.tsmi_MsgSaveAs.Text = "Save As";
            this.tsmi_MsgSaveAs.Click += new System.EventHandler(this.Tsmi_MsgSaveAs_Click);
            // 
            // tsmi_MsgClear
            // 
            this.tsmi_MsgClear.Image = global::XM_Tek_Studio_Pro.Properties.Resources.exit_64x64;
            this.tsmi_MsgClear.Name = "tsmi_MsgClear";
            this.tsmi_MsgClear.Size = new System.Drawing.Size(184, 26);
            this.tsmi_MsgClear.Text = "Clear";
            this.tsmi_MsgClear.Click += new System.EventHandler(this.Tsmi_MsgClear_Click);
            // 
            // pnl_CommSet
            // 
            this.pnl_CommSet.Controls.Add(this.gbx_instrument);
            this.pnl_CommSet.Controls.Add(this.gbx_CommSetting);
            this.pnl_CommSet.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_CommSet.Location = new System.Drawing.Point(492, 0);
            this.pnl_CommSet.Name = "pnl_CommSet";
            this.pnl_CommSet.Size = new System.Drawing.Size(290, 553);
            this.pnl_CommSet.TabIndex = 2;
            // 
            // gbx_instrument
            // 
            this.gbx_instrument.Controls.Add(this.btn_Scan);
            this.gbx_instrument.Controls.Add(this.trv_instru);
            this.gbx_instrument.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbx_instrument.Location = new System.Drawing.Point(0, 403);
            this.gbx_instrument.Name = "gbx_instrument";
            this.gbx_instrument.Size = new System.Drawing.Size(290, 150);
            this.gbx_instrument.TabIndex = 2;
            this.gbx_instrument.TabStop = false;
            this.gbx_instrument.Text = "Instrument";
            // 
            // btn_Scan
            // 
            this.btn_Scan.Location = new System.Drawing.Point(228, 113);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.Size = new System.Drawing.Size(56, 31);
            this.btn_Scan.TabIndex = 1;
            this.btn_Scan.Text = "Scan";
            this.btn_Scan.UseVisualStyleBackColor = true;
            this.btn_Scan.Click += new System.EventHandler(this.Btn_Scan_Click);
            // 
            // trv_instru
            // 
            this.trv_instru.AllowDrop = true;
            this.trv_instru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv_instru.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trv_instru.LabelEdit = true;
            this.trv_instru.Location = new System.Drawing.Point(3, 23);
            this.trv_instru.Name = "trv_instru";
            this.trv_instru.ShowNodeToolTips = true;
            this.trv_instru.Size = new System.Drawing.Size(284, 124);
            this.trv_instru.TabIndex = 0;
            this.trv_instru.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Trv_instru_NodeMouseClick);
            // 
            // gbx_CommSetting
            // 
            this.gbx_CommSetting.Controls.Add(this.tableLayoutPanel3);
            this.gbx_CommSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbx_CommSetting.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_CommSetting.Location = new System.Drawing.Point(0, 0);
            this.gbx_CommSetting.Name = "gbx_CommSetting";
            this.gbx_CommSetting.Size = new System.Drawing.Size(290, 162);
            this.gbx_CommSetting.TabIndex = 1;
            this.gbx_CommSetting.TabStop = false;
            this.gbx_CommSetting.Text = "Functional Area";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.btn_CommClose, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.Btn_CommOpen, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.Btn_LoadSpt, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Btn_CommSend, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Btn_AddPage, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Btn_DelTabs, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.Btn_CloseAll, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_CtrlCenter, 3, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(284, 139);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btn_CommClose
            // 
            this.btn_CommClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CommClose.Image = global::XM_Tek_Studio_Pro.Properties.Resources.CommClose;
            this.btn_CommClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CommClose.Location = new System.Drawing.Point(216, 3);
            this.btn_CommClose.Name = "btn_CommClose";
            this.btn_CommClose.Size = new System.Drawing.Size(65, 63);
            this.btn_CommClose.TabIndex = 3;
            this.btn_CommClose.Text = "Test";
            this.btn_CommClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_CommClose.UseVisualStyleBackColor = true;
            this.btn_CommClose.Click += new System.EventHandler(this.Btn_CommClose_Click);
            // 
            // Btn_CommOpen
            // 
            this.Btn_CommOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CommOpen.Image = global::XM_Tek_Studio_Pro.Properties.Resources.CommOpen;
            this.Btn_CommOpen.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_CommOpen.Location = new System.Drawing.Point(145, 3);
            this.Btn_CommOpen.Name = "Btn_CommOpen";
            this.Btn_CommOpen.Size = new System.Drawing.Size(65, 63);
            this.Btn_CommOpen.TabIndex = 2;
            this.Btn_CommOpen.Text = "Test";
            this.Btn_CommOpen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_CommOpen.UseVisualStyleBackColor = true;
            this.Btn_CommOpen.Click += new System.EventHandler(this.Btn_CommOpen_Click);
            // 
            // Btn_LoadSpt
            // 
            this.Btn_LoadSpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_LoadSpt.Image = global::XM_Tek_Studio_Pro.Properties.Resources.open_32;
            this.Btn_LoadSpt.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_LoadSpt.Location = new System.Drawing.Point(74, 3);
            this.Btn_LoadSpt.Name = "Btn_LoadSpt";
            this.Btn_LoadSpt.Size = new System.Drawing.Size(65, 63);
            this.Btn_LoadSpt.TabIndex = 1;
            this.Btn_LoadSpt.Text = "Load ";
            this.Btn_LoadSpt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_LoadSpt.UseVisualStyleBackColor = true;
            this.Btn_LoadSpt.Click += new System.EventHandler(this.Btn_LoadSpt_Click);
            // 
            // Btn_CommSend
            // 
            this.Btn_CommSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CommSend.Image = global::XM_Tek_Studio_Pro.Properties.Resources.CommPlay;
            this.Btn_CommSend.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_CommSend.Location = new System.Drawing.Point(3, 3);
            this.Btn_CommSend.Name = "Btn_CommSend";
            this.Btn_CommSend.Size = new System.Drawing.Size(65, 63);
            this.Btn_CommSend.TabIndex = 0;
            this.Btn_CommSend.Text = "Send";
            this.Btn_CommSend.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_CommSend.UseVisualStyleBackColor = true;
            this.Btn_CommSend.Click += new System.EventHandler(this.Btn_CommSend_Click);
            // 
            // Btn_AddPage
            // 
            this.Btn_AddPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_AddPage.Image = global::XM_Tek_Studio_Pro.Properties.Resources.newtab;
            this.Btn_AddPage.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_AddPage.Location = new System.Drawing.Point(3, 72);
            this.Btn_AddPage.Name = "Btn_AddPage";
            this.Btn_AddPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_AddPage.Size = new System.Drawing.Size(65, 64);
            this.Btn_AddPage.TabIndex = 4;
            this.Btn_AddPage.Text = "Sheet+";
            this.Btn_AddPage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_AddPage.UseVisualStyleBackColor = true;
            this.Btn_AddPage.Click += new System.EventHandler(this.Btn_AddPage_Click);
            // 
            // Btn_DelTabs
            // 
            this.Btn_DelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_DelTabs.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_DelTabs.Image = global::XM_Tek_Studio_Pro.Properties.Resources.del;
            this.Btn_DelTabs.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_DelTabs.Location = new System.Drawing.Point(74, 72);
            this.Btn_DelTabs.Name = "Btn_DelTabs";
            this.Btn_DelTabs.Size = new System.Drawing.Size(65, 64);
            this.Btn_DelTabs.TabIndex = 5;
            this.Btn_DelTabs.Text = "-Sheet";
            this.Btn_DelTabs.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_DelTabs.UseVisualStyleBackColor = true;
            this.Btn_DelTabs.Click += new System.EventHandler(this.Btn_DelTabs_Click);
            // 
            // Btn_CloseAll
            // 
            this.Btn_CloseAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CloseAll.Image = global::XM_Tek_Studio_Pro.Properties.Resources.closeall;
            this.Btn_CloseAll.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_CloseAll.Location = new System.Drawing.Point(145, 72);
            this.Btn_CloseAll.Name = "Btn_CloseAll";
            this.Btn_CloseAll.Size = new System.Drawing.Size(65, 64);
            this.Btn_CloseAll.TabIndex = 6;
            this.Btn_CloseAll.Text = "CloseAll";
            this.Btn_CloseAll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_CloseAll.UseVisualStyleBackColor = true;
            this.Btn_CloseAll.Click += new System.EventHandler(this.Btn_CloseAll_Click);
            // 
            // btn_CtrlCenter
            // 
            this.btn_CtrlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CtrlCenter.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CtrlCenter.Image = global::XM_Tek_Studio_Pro.Properties.Resources.centerl;
            this.btn_CtrlCenter.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CtrlCenter.Location = new System.Drawing.Point(216, 72);
            this.btn_CtrlCenter.Name = "btn_CtrlCenter";
            this.btn_CtrlCenter.Size = new System.Drawing.Size(65, 64);
            this.btn_CtrlCenter.TabIndex = 7;
            this.btn_CtrlCenter.Text = "Center";
            this.btn_CtrlCenter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_CtrlCenter.UseVisualStyleBackColor = true;
            this.btn_CtrlCenter.Click += new System.EventHandler(this.Btn_CtrlCenter_Click);
            // 
            // pnl_CmdPage
            // 
            this.pnl_CmdPage.Controls.Add(this.Tctl_Pages);
            this.pnl_CmdPage.Controls.Add(this.gbx_elecsmsg);
            this.pnl_CmdPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_CmdPage.Location = new System.Drawing.Point(0, 0);
            this.pnl_CmdPage.Name = "pnl_CmdPage";
            this.pnl_CmdPage.Size = new System.Drawing.Size(492, 553);
            this.pnl_CmdPage.TabIndex = 4;
            // 
            // Tctl_Pages
            // 
            this.Tctl_Pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tctl_Pages.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.Tctl_Pages.Location = new System.Drawing.Point(0, 0);
            this.Tctl_Pages.Name = "Tctl_Pages";
            this.Tctl_Pages.SelectedIndex = 0;
            this.Tctl_Pages.Size = new System.Drawing.Size(492, 403);
            this.Tctl_Pages.TabIndex = 2;
            this.Tctl_Pages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Tctl_Pages_DrawItem);
            this.Tctl_Pages.SelectedIndexChanged += new System.EventHandler(this.Tctl_Pages_SelectedIndexChanged);
            this.Tctl_Pages.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tctl_Pages_MouseClick);
            // 
            // gbx_elecsmsg
            // 
            this.gbx_elecsmsg.Controls.Add(this.rtf_ElecsMsg);
            this.gbx_elecsmsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbx_elecsmsg.Location = new System.Drawing.Point(0, 403);
            this.gbx_elecsmsg.Name = "gbx_elecsmsg";
            this.gbx_elecsmsg.Size = new System.Drawing.Size(492, 150);
            this.gbx_elecsmsg.TabIndex = 1;
            this.gbx_elecsmsg.TabStop = false;
            this.gbx_elecsmsg.Text = "Message";
            // 
            // rtf_ElecsMsg
            // 
            this.rtf_ElecsMsg.ContextMenuStrip = this.cms_elecsmsg;
            this.rtf_ElecsMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtf_ElecsMsg.Location = new System.Drawing.Point(3, 23);
            this.rtf_ElecsMsg.Name = "rtf_ElecsMsg";
            this.rtf_ElecsMsg.Size = new System.Drawing.Size(486, 124);
            this.rtf_ElecsMsg.TabIndex = 0;
            this.rtf_ElecsMsg.Text = "";
            // 
            // ScriptSetting_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.pnl_CmdPage);
            this.Controls.Add(this.pnl_CommSet);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ScriptSetting_Form";
            this.Text = "Verification Page";
            this.Load += new System.EventHandler(this.ScriptSetting_Form_Load);
            this.cms_elecscmd.ResumeLayout(false);
            this.cms_elecsmsg.ResumeLayout(false);
            this.pnl_CommSet.ResumeLayout(false);
            this.gbx_instrument.ResumeLayout(false);
            this.gbx_CommSetting.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.pnl_CmdPage.ResumeLayout(false);
            this.gbx_elecsmsg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cms_elecscmd;
        private System.Windows.Forms.ToolStripMenuItem Tsmi_CmdClear;
        private System.Windows.Forms.ToolStripMenuItem Tsmi_CmdSaveAs;
        private System.Windows.Forms.ContextMenuStrip cms_elecsmsg;
        private System.Windows.Forms.ToolStripMenuItem tsmi_MsgClear;
        private System.Windows.Forms.ToolStripMenuItem tsmi_MsgSaveAs;
        private System.Windows.Forms.ToolStripMenuItem Tsmi_CmdPaste;
        private System.Windows.Forms.ToolStripMenuItem Tsmi_CmdCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_MsgCopy;
        private System.Windows.Forms.ToolStripMenuItem Tsmi_CmdSend;
        private System.Windows.Forms.Panel pnl_CommSet;
        private System.Windows.Forms.GroupBox gbx_instrument;
        private System.Windows.Forms.Button btn_Scan;
        private System.Windows.Forms.TreeView trv_instru;
        private System.Windows.Forms.GroupBox gbx_CommSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_CommClose;
        private System.Windows.Forms.Button Btn_CommOpen;
        private System.Windows.Forms.Button Btn_LoadSpt;
        private System.Windows.Forms.Button Btn_CommSend;
        private System.Windows.Forms.Button Btn_AddPage;
        private System.Windows.Forms.Button Btn_DelTabs;
        private System.Windows.Forms.Button Btn_CloseAll;
        private System.Windows.Forms.Button btn_CtrlCenter;
        private System.Windows.Forms.Panel pnl_CmdPage;
        private System.Windows.Forms.TabControl Tctl_Pages;
        private System.Windows.Forms.GroupBox gbx_elecsmsg;
        private System.Windows.Forms.RichTextBox rtf_ElecsMsg;
        private System.Windows.Forms.ToolStripMenuItem SDCardGen;
        private System.Windows.Forms.ToolStripMenuItem IfSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CommentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnCommentToolStripMenuItem;
    }
}