using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FzTool_V2
{
    public partial class FrmFzBzConfig : Form
    {
        public Action<string, string> _actionSave;

        public FrmFzBzConfig()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fieldName = tbFieldName.Text = tbFieldName.Text.Trim();
            string fieldValue = tbFieldName.Text = tbFieldValue.Text.Trim();

            try
            {
                File.WriteAllText(Config.PATH_BZ_CONFIG_FILE, fieldName + "," + fieldValue);
                _actionSave.Invoke(fieldName, fieldValue);
                Close();
            }
            catch (Exception)
            {
                DialogUtils.ShowDialogWarning("配置文件保存失败，请关闭可能占用的应用程序后重试");
            }
        }
    }
}
