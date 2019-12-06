namespace XM_Tek_Studio_Pro
{
    partial class Help_Form
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help_Form));
            this.gbx_connection = new System.Windows.Forms.GroupBox();
            this.ts_help = new System.Windows.Forms.ToolStrip();
            this.tslb_msg = new System.Windows.Forms.ToolStripLabel();
            this.dgv_help = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbx_connection.SuspendLayout();
            this.ts_help.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbx_connection
            // 
            this.gbx_connection.Controls.Add(this.ts_help);
            this.gbx_connection.Controls.Add(this.dgv_help);
            this.gbx_connection.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_connection.Location = new System.Drawing.Point(12, 10);
            this.gbx_connection.Name = "gbx_connection";
            this.gbx_connection.Size = new System.Drawing.Size(780, 394);
            this.gbx_connection.TabIndex = 0;
            this.gbx_connection.TabStop = false;
            this.gbx_connection.Text = "Help";
            // 
            // ts_help
            // 
            this.ts_help.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ts_help.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslb_msg});
            this.ts_help.Location = new System.Drawing.Point(3, 23);
            this.ts_help.Name = "ts_help";
            this.ts_help.Size = new System.Drawing.Size(774, 25);
            this.ts_help.TabIndex = 1;
            this.ts_help.Text = "toolStrip1";
            // 
            // tslb_msg
            // 
            this.tslb_msg.Name = "tslb_msg";
            this.tslb_msg.Size = new System.Drawing.Size(41, 22);
            this.tslb_msg.Text = "Help?";
            // 
            // dgv_help
            // 
            this.dgv_help.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_help.Location = new System.Drawing.Point(3, 23);
            this.dgv_help.Name = "dgv_help";
            this.dgv_help.RowTemplate.Height = 27;
            this.dgv_help.Size = new System.Drawing.Size(774, 368);
            this.dgv_help.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(798, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(33, 368);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Visible = false;
            // 
            // Help_Form
            // 
            this.ClientSize = new System.Drawing.Size(835, 416);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbx_connection);
            this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Help_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Form_Load);
            this.gbx_connection.ResumeLayout(false);
            this.gbx_connection.PerformLayout();
            this.ts_help.ResumeLayout(false);
            this.ts_help.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_connection;
        private System.Windows.Forms.DataGridView dgv_help;
        private System.Windows.Forms.ToolStrip ts_help;
        private System.Windows.Forms.ToolStripLabel tslb_msg;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}