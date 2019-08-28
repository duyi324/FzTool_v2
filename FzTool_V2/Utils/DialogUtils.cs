using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FzTool_V2
{
  public  class DialogUtils
    {

        public static DialogResult ShowDialogWarning(string msg)
        {
            return MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowDialogError(string msg)
        {
            return MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowDialogInfo(string msg)
        {
            return MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowDialogQuestion(string msg)
        {
            return MessageBox.Show(msg, "确定？", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

    }
}
