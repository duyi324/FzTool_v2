namespace FzTool_V2
{
    partial class FrmFz
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuEditConfigFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChooseLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.rootPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuLayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSingleField = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.rootPanel.SuspendLayout();
            this.contextMenuLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditConfigFile,
            this.menuRefresh,
            this.menuChooseLayer,
            this.menuSingleField});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(570, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuEditConfigFile
            // 
            this.menuEditConfigFile.Name = "menuEditConfigFile";
            this.menuEditConfigFile.Size = new System.Drawing.Size(92, 21);
            this.menuEditConfigFile.Text = "编辑配置文件";
            this.menuEditConfigFile.Click += new System.EventHandler(this.menuEditConfigFile_Click);
            // 
            // menuRefresh
            // 
            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Size = new System.Drawing.Size(44, 21);
            this.menuRefresh.Text = "刷新";
            this.menuRefresh.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // menuChooseLayer
            // 
            this.menuChooseLayer.ForeColor = System.Drawing.Color.Red;
            this.menuChooseLayer.Name = "menuChooseLayer";
            this.menuChooseLayer.Size = new System.Drawing.Size(134, 21);
            this.menuChooseLayer.Text = "当前图层：<未选择>";
            this.menuChooseLayer.Click += new System.EventHandler(this.menuChooseLayer_Click);
            // 
            // rootPanel
            // 
            this.rootPanel.Controls.Add(this.label1);
            this.rootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootPanel.Location = new System.Drawing.Point(0, 25);
            this.rootPanel.Name = "rootPanel";
            this.rootPanel.Size = new System.Drawing.Size(570, 469);
            this.rootPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 469);
            this.label1.TabIndex = 0;
            this.label1.Text = "请点击菜单栏的编辑配置文件以配置地类列表，如果已经配置过，请点击刷新按钮";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuLayer
            // 
            this.contextMenuLayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuLayer.Name = "contextMenuLayer";
            this.contextMenuLayer.Size = new System.Drawing.Size(98, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(97, 22);
            this.toolStripMenuItem2.Text = "123";
            // 
            // menuSingleField
            // 
            this.menuSingleField.Name = "menuSingleField";
            this.menuSingleField.Size = new System.Drawing.Size(80, 21);
            this.menuSingleField.Text = "单字段赋值";
            this.menuSingleField.Click += new System.EventHandler(this.menuSingleField_Click);
            // 
            // FrmFz
            // 
            this.Controls.Add(this.rootPanel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmFz";
            this.Size = new System.Drawing.Size(570, 494);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.rootPanel.ResumeLayout(false);
            this.contextMenuLayer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEditConfigFile;
        private System.Windows.Forms.Panel rootPanel;
        private System.Windows.Forms.ToolStripMenuItem menuRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuChooseLayer;
        private System.Windows.Forms.ContextMenuStrip contextMenuLayer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem menuSingleField;

    }
}
