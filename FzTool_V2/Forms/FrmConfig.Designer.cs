namespace FzTool_V2
{
    partial class FrmConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbButtonCountPerRow = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dlbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNameId = new System.Windows.Forms.RadioButton();
            this.rbIdName = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.rbId = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbDlmcFieldName = new System.Windows.Forms.TextBox();
            this.tbDlbmFieldName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(462, 124);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 33);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(38, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "每行按钮个数：";
            // 
            // tbButtonCountPerRow
            // 
            this.tbButtonCountPerRow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbButtonCountPerRow.Location = new System.Drawing.Point(151, 28);
            this.tbButtonCountPerRow.Name = "tbButtonCountPerRow";
            this.tbButtonCountPerRow.Size = new System.Drawing.Size(228, 26);
            this.tbButtonCountPerRow.TabIndex = 3;
            this.tbButtonCountPerRow.Text = "5";
            this.tbButtonCountPerRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dlbm,
            this.dlmc});
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(400, 284);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_CellMouseClick);
            // 
            // dlbm
            // 
            this.dlbm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dlbm.DefaultCellStyle = dataGridViewCellStyle5;
            this.dlbm.HeaderText = "地类编码";
            this.dlbm.MinimumWidth = 50;
            this.dlbm.Name = "dlbm";
            this.dlbm.ReadOnly = true;
            // 
            // dlmc
            // 
            this.dlmc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dlmc.DefaultCellStyle = dataGridViewCellStyle6;
            this.dlmc.HeaderText = "地类名称";
            this.dlmc.Name = "dlmc";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(462, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 33);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Tag = "";
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(463, 511);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(108, 33);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "测试功能";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDelete,
            this.menuMoveUp,
            this.menuMoveDown});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(137, 70);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(136, 22);
            this.menuDelete.Text = "删除当前行";
            this.menuDelete.Click += new System.EventHandler(this.MenuDelete_Click);
            // 
            // menuMoveUp
            // 
            this.menuMoveUp.Name = "menuMoveUp";
            this.menuMoveUp.Size = new System.Drawing.Size(136, 22);
            this.menuMoveUp.Text = "上移当前行";
            this.menuMoveUp.Click += new System.EventHandler(this.MenuMoveUp_Click);
            // 
            // menuMoveDown
            // 
            this.menuMoveDown.Name = "menuMoveDown";
            this.menuMoveDown.Size = new System.Drawing.Size(136, 22);
            this.menuMoveDown.Text = "下移当前行";
            this.menuMoveDown.Click += new System.EventHandler(this.MenuMoveDown_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNameId);
            this.groupBox1.Controls.Add(this.rbIdName);
            this.groupBox1.Controls.Add(this.rbName);
            this.groupBox1.Controls.Add(this.rbId);
            this.groupBox1.Location = new System.Drawing.Point(12, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 88);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "语言选项";
            // 
            // rbNameId
            // 
            this.rbNameId.AutoSize = true;
            this.rbNameId.Location = new System.Drawing.Point(189, 56);
            this.rbNameId.Name = "rbNameId";
            this.rbNameId.Size = new System.Drawing.Size(149, 16);
            this.rbNameId.TabIndex = 3;
            this.rbNameId.Text = "显示地类名称+地类编码";
            this.rbNameId.UseVisualStyleBackColor = true;
            this.rbNameId.CheckedChanged += new System.EventHandler(this.rbNameId_CheckedChanged);
            // 
            // rbIdName
            // 
            this.rbIdName.AutoSize = true;
            this.rbIdName.Location = new System.Drawing.Point(189, 27);
            this.rbIdName.Name = "rbIdName";
            this.rbIdName.Size = new System.Drawing.Size(149, 16);
            this.rbIdName.TabIndex = 2;
            this.rbIdName.Text = "显示地类编码+地类名称";
            this.rbIdName.UseVisualStyleBackColor = true;
            this.rbIdName.CheckedChanged += new System.EventHandler(this.rbIdName_CheckedChanged);
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Location = new System.Drawing.Point(38, 56);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(95, 16);
            this.rbName.TabIndex = 1;
            this.rbName.Text = "显示地类名称";
            this.rbName.UseVisualStyleBackColor = true;
            this.rbName.CheckedChanged += new System.EventHandler(this.rbName_CheckedChanged);
            // 
            // rbId
            // 
            this.rbId.AutoSize = true;
            this.rbId.Checked = true;
            this.rbId.Location = new System.Drawing.Point(38, 27);
            this.rbId.Name = "rbId";
            this.rbId.Size = new System.Drawing.Size(95, 16);
            this.rbId.TabIndex = 0;
            this.rbId.TabStop = true;
            this.rbId.Text = "显示地类编码";
            this.rbId.UseVisualStyleBackColor = true;
            this.rbId.CheckedChanged += new System.EventHandler(this.rbId_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbDlmcFieldName);
            this.groupBox2.Controls.Add(this.tbDlbmFieldName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbButtonCountPerRow);
            this.groupBox2.Location = new System.Drawing.Point(12, 396);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 160);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "其他设置";
            // 
            // tbDlmcFieldName
            // 
            this.tbDlmcFieldName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDlmcFieldName.Location = new System.Drawing.Point(151, 116);
            this.tbDlmcFieldName.Name = "tbDlmcFieldName";
            this.tbDlmcFieldName.Size = new System.Drawing.Size(228, 26);
            this.tbDlmcFieldName.TabIndex = 7;
            this.tbDlmcFieldName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDlbmFieldName
            // 
            this.tbDlbmFieldName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDlbmFieldName.Location = new System.Drawing.Point(151, 72);
            this.tbDlbmFieldName.Name = "tbDlbmFieldName";
            this.tbDlbmFieldName.Size = new System.Drawing.Size(228, 26);
            this.tbDlbmFieldName.TabIndex = 6;
            this.tbDlbmFieldName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(38, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "地类名称字段：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(38, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "地类编码字段：";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(463, 68);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 33);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 568);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑配置";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbButtonCountPerRow;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlmc;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem menuMoveDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbIdName;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.RadioButton rbId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbNameId;
        private System.Windows.Forms.TextBox tbDlmcFieldName;
        private System.Windows.Forms.TextBox tbDlbmFieldName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
    }
}