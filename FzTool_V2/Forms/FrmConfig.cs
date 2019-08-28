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
    public partial class FrmConfig : Form
    {
        public Action _actionSave;
        /// <summary>
        /// 选中行的索引
        /// </summary>
        private int indexSelected = -1;


        public FrmConfig()
        {
            InitializeComponent();

            tbButtonCountPerRow.KeyPress += TbButtonCountPerRow_KeyPress;

        }


        private void TbButtonCountPerRow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        /// <summary>
        /// 添加新行数据
        /// </summary>
        /// <param name="dlbm">地类编码的值</param>
        /// <param name="dlmc">地类名称的值</param>
        private void AddNewRow(string dlbm, string dlmc)
        {
            dataGridView.Rows.Add(dlbm, dlmc);
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.Rows.Count - 1;
        }


        /// <summary>
        /// 保存按钮
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 1)
            {
                DialogUtils.ShowDialogWarning("未添加任何数据");
                return;
            }
            string count = tbButtonCountPerRow.Text.Trim();
            if (count.Equals(""))
            {
                DialogUtils.ShowDialogWarning("未填写每行按钮数");
                return;
            }
            int countInt = -1;
            if (!int.TryParse(count, out countInt))
            {
                DialogUtils.ShowDialogWarning("每行按钮数量填写格式有误");
                return;
            }

            string fieldDlbm = tbDlbmFieldName.Text = tbDlbmFieldName.Text.Replace(" ", "");
            string fieldDlmc = tbDlmcFieldName.Text = tbDlmcFieldName.Text.Replace(" ", "");
            //if (fieldDlbm.Equals("") || fieldDlmc.Equals(""))
            //{
            //    DialogUtils.ShowDialogWarning("字段名称不允许为空");
            //    return;
            //}

            Save(countInt);
            _actionSave.Invoke();
            Close();
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="column"></param>
        private void Save(int column)
        {
            if (File.Exists(Config.PATH_CONFIG_FILE))
            {
                File.Delete(Config.PATH_CONFIG_FILE);
            }
            int dataCount = dataGridView.Rows.Count - 1;
            string rl = column.ToString();

            List<string> data = new List<string>();
            // 每行按钮个数
            data.Add(rl);
            // 语言
            data.Add(Config.LANGUAGE.ToString());
            // 字段名：编码,名称
            data.Add(tbDlbmFieldName.Text + "," + tbDlmcFieldName.Text);


            for (int i = 0; i < dataCount; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(dataGridView.Rows[i].Cells[0].Value);
                sb.Append(",");
                sb.Append(dataGridView.Rows[i].Cells[1].Value);
                data.Add(sb.ToString());
            }
            try
            {
                File.WriteAllLines(Config.PATH_CONFIG_FILE, data.ToArray());
                DialogUtils.ShowDialogInfo("配置文件保存成功");
            }
            catch (Exception e)
            {
                DialogUtils.ShowDialogError("配置文件保存失败，请检查是否被占用，文件路径：" + Config.PATH_CONFIG_FILE);
            }
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmAddNewRecord frm = new FrmAddNewRecord();
            frm._actionAddNewRow += AddNewRow;
            frm.ShowDialog();
        }


        private void BtnTest_Click(object sender, EventArgs e)
        {
            //dataGridView
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            // Convert.ToInt64(ts.TotalSeconds).ToString();


            Random random = new Random(Convert.ToInt32(ts.TotalSeconds));
            int intvalue = random.Next();

            AddNewRow("第哈哈", intvalue.ToString());
        }


        /// <summary>
        /// 表格右键菜单
        /// </summary>
        private void DataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 如果选中的不是第一行和最后一行，则显示右键菜单
                if (e.RowIndex >= 0 && e.RowIndex != dataGridView.Rows.Count - 1)
                {
                    if (e.RowIndex == 0)
                    {
                        menuMoveUp.Visible = false;
                        menuMoveDown.Visible = true;
                    }
                    else if (e.RowIndex == dataGridView.Rows.Count - 2)
                    {
                        menuMoveUp.Visible = true;
                        menuMoveDown.Visible = false;
                    }
                    else
                    {
                        menuMoveUp.Visible = true;
                        menuMoveDown.Visible = true;
                    }

                    dataGridView.ClearSelection();
                    dataGridView.Rows[e.RowIndex].Selected = true;
                    //dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenu.Show(MousePosition.X, MousePosition.Y);
                    indexSelected = e.RowIndex;
                }
            }
        }

        /// <summary>
        /// 右键菜单：删除
        /// </summary>
        private void MenuDelete_Click(object sender, EventArgs e)
        {

            dataGridView.Rows.RemoveAt(indexSelected);
            RefreshDataViewIndex();
        }

        /// <summary>
        /// 刷新表格
        /// </summary>
        private void RefreshDataViewIndex()
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        /// <summary>
        ///  右键菜单：上移当前行
        /// </summary> 
        private void MenuMoveUp_Click(object sender, EventArgs e)
        {
            ExchangeRowValue(indexSelected, indexSelected - 1);
            dataGridView.ClearSelection();
            dataGridView.Rows[indexSelected - 1].Selected = true;
        }

        /// <summary>
        ///  右键菜单：下移当前行
        /// </summary> 
        private void MenuMoveDown_Click(object sender, EventArgs e)
        {
            ExchangeRowValue(indexSelected, indexSelected + 1);
            dataGridView.ClearSelection();
            dataGridView.Rows[indexSelected + 1].Selected = true;
        }

        /// <summary>
        /// 交换行的值
        /// </summary>
        /// <param name="currentRowIndex">当前行的索引</param>
        /// <param name="destRowIndex">待交换值的行索引</param>
        private void ExchangeRowValue(int currentRowIndex, int destRowIndex)
        {
            var lastValue1 = dataGridView.Rows[destRowIndex].Cells[0].Value;
            var lastValue2 = dataGridView.Rows[destRowIndex].Cells[1].Value;

            dataGridView.Rows[destRowIndex].Cells[0].Value = dataGridView.Rows[currentRowIndex].Cells[0].Value;
            dataGridView.Rows[destRowIndex].Cells[1].Value = dataGridView.Rows[currentRowIndex].Cells[1].Value;

            dataGridView.Rows[currentRowIndex].Cells[0].Value = lastValue1;
            dataGridView.Rows[currentRowIndex].Cells[1].Value = lastValue2;

            dataGridView.ClearSelection();
            dataGridView.Rows[destRowIndex].Selected = true;
        }


        /// <summary>
        /// 窗口载入事件
        /// </summary>
        private void FrmConfig_Load(object sender, EventArgs e)
        {
            // 读取配置文件
            if (File.Exists(Config.PATH_CONFIG_FILE))
            {
                try
                {
                    var data = File.ReadAllLines(Config.PATH_CONFIG_FILE).ToList();
                    if (data != null && data.Count > 0)
                    {
                        // 第一行为主界面每行多少个按钮
                        tbButtonCountPerRow.Text = data[0];
                        // 第二行为语言选项
                        if (data[1].Equals(LANGUAGES.ID.ToString()))
                        {
                            rbId.Checked = true;
                        }
                        else if (data[1].Equals(LANGUAGES.NAME.ToString()))
                        {
                            rbName.Checked = true;
                        }
                        else if (data[1].Equals(LANGUAGES.ID_NAME.ToString()))
                        {
                            rbIdName.Checked = true;
                        }
                        else if (data[1].Equals(LANGUAGES.NAME_ID.ToString()))
                        {
                            rbNameId.Checked = true;
                        }
                        // 第三行为字段名
                        string[] fieldNames = data[2].Split(',');
                        tbDlbmFieldName.Text = fieldNames[0];
                        tbDlmcFieldName.Text = fieldNames[1];

                        // 后面的数据添加到表格
                        for (int i = Config.RowsCountExceptData; i < data.Count; i++)
                        {
                            string[] tmpData = data[i].Split(',');
                            AddNewRow(tmpData[0], tmpData[1]);
                        }
                    }
                }
                catch (Exception)
                {
                    DialogUtils.ShowDialogError("配置文件读取失败");
                }
            }
        }

        private void rbId_CheckedChanged(object sender, EventArgs e)
        {
            Config.LANGUAGE = LANGUAGES.ID;
        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            Config.LANGUAGE = LANGUAGES.NAME;
        }

        private void rbIdName_CheckedChanged(object sender, EventArgs e)
        {
            Config.LANGUAGE = LANGUAGES.ID_NAME;
        }

        private void rbNameId_CheckedChanged(object sender, EventArgs e)
        {
            Config.LANGUAGE = LANGUAGES.NAME_ID;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
        }
    }
}
