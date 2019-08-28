namespace FzTool_V2
{
    partial class FrmBz
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
            this.btnBz = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBz
            // 
            this.btnBz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBz.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBz.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBz.ForeColor = System.Drawing.Color.Red;
            this.btnBz.Location = new System.Drawing.Point(0, 0);
            this.btnBz.Name = "btnBz";
            this.btnBz.Size = new System.Drawing.Size(300, 300);
            this.btnBz.TabIndex = 0;
            this.btnBz.Text = "右键设置属性";
            this.btnBz.UseVisualStyleBackColor = true;
            this.btnBz.Click += new System.EventHandler(this.btnBz_Click);
            this.btnBz.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBz_MouseUp);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(100, 22);
            this.menuEdit.Text = "编辑";
            this.menuEdit.Click += new System.EventHandler(this.menuEdit_Click);
            // 
            // FrmBz
            // 
            this.Controls.Add(this.btnBz);
            this.Name = "FrmBz";
            this.Size = new System.Drawing.Size(300, 300);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBz;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;

    }
}
