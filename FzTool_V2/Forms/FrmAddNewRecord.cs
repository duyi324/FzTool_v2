using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FzTool_V2
{
    public partial class FrmAddNewRecord : Form
    {
        public Action<string, string> _actionAddNewRow;


        public FrmAddNewRecord()
        {
            InitializeComponent();

            tbDlbm.KeyPress += TbDlbm_KeyPress;
        }

        private void TbDlbm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = false;
            //}
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string dlbm = tbDlbm.Text = tbDlbm.Text.Trim();
            string dlmc = tbDlmc.Text = tbDlmc.Text.Trim();
            if (dlbm.Contains(' '))
            {
                DialogUtils.ShowDialogWarning("地类编码包含空格");
                return;
            }
            if (dlmc.Contains(' '))
            {
                DialogUtils.ShowDialogWarning("地类名称包含空格");
                return;
            }
            _actionAddNewRow.Invoke(dlbm, dlmc);

            // _actionAddNewRow(dlbm, dlmc);
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
