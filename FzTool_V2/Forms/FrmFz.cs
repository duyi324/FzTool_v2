using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.ArcMapUI;

namespace FzTool_V2
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// </summary>
    public partial class FrmFz : UserControl
    {
        IMxDocument mDocument = null;
        IMap mMap = null;

        private List<string> dataList = new List<string>();
        private int columns = 5;

        private string _fieldNameDlbm = "";
        private string _fieldNameDlmc = "";

        public FrmFz(object hook)
        {
            InitializeComponent();
            this.Hook = hook;

            //mDocument = ArcMap.Document;  // Config.ArcMapDocument;
            //mMap = mDocument.FocusMap;

            //if (mDocument == null)
            //{
            //    DialogUtils.ShowDialogWarning("文档对象获取失败，请重启ArcGIS后重试");
            //}

            //if (mMap == null)
            //{
            //    DialogUtils.ShowDialogWarning("地图对象获取失败，请重启ArcGIS后重试");
            //}

            if (File.Exists(Config.PATH_CONFIG_FILE))
            {
                RefreshLayout();
            }
        }

        /// <summary>
        /// Host object of the dockable window
        /// </summary>
        private object Hook
        {
            get;
            set;
        }

        /// <summary>
        /// Implementation class of the dockable window add-in. It is responsible for 
        /// creating and disposing the user interface class of the dockable window.
        /// </summary>
        public class AddinImpl : ESRI.ArcGIS.Desktop.AddIns.DockableWindow
        {
            private FrmFz m_windowUI;

            public AddinImpl()
            {
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new FrmFz(this.Hook);
                return m_windowUI.Handle;
            }

            protected override void Dispose(bool disposing)
            {
                if (m_windowUI != null)
                    m_windowUI.Dispose(disposing);

                base.Dispose(disposing);
            }

        }

        /// <summary>
        /// 编辑配置文件
        /// </summary>
        private void menuEditConfigFile_Click(object sender, EventArgs e)
        {
            Init();
            FrmConfig frmConfig = new FrmConfig();
            frmConfig._actionSave = RefreshLayout;
            frmConfig.ShowDialog();
        }

        /// <summary>
        /// 菜单：刷新
        /// </summary>
        private void menuRefresh_Click(object sender, EventArgs e)
        {
            Init();
            if (File.Exists(Config.PATH_CONFIG_FILE))
            {
                RefreshLayout();
            }
            else
            {
                DialogResult result = DialogUtils.ShowDialogQuestion("未发现配置文件，是否立即配置？");
                if (result == DialogResult.Yes)
                {
                    FrmConfig frmConfig = new FrmConfig();
                    frmConfig._actionSave = RefreshLayout;
                    frmConfig.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 刷新布局
        /// </summary>
        private void RefreshLayout()
        {
            dataList.Clear();
            try
            {
                dataList = File.ReadAllLines(Config.PATH_CONFIG_FILE).ToList();
                if (dataList.Count > 0)
                {
                    // 获取每行多少按钮
                    string colStr = dataList[0];

                    if (!int.TryParse(colStr, out columns))
                    {
                        columns = 5;
                    }
                    // 设置语言
                    if (dataList[1].Equals(LANGUAGES.ID.ToString()))
                    {
                        Config.LANGUAGE = LANGUAGES.ID;
                    }
                    else if (dataList[1].Equals(LANGUAGES.NAME.ToString()))
                    {
                        Config.LANGUAGE = LANGUAGES.NAME;
                    }
                    else if (dataList[1].Equals(LANGUAGES.ID_NAME.ToString()))
                    {
                        Config.LANGUAGE = LANGUAGES.ID_NAME;
                    }
                    else if (dataList[1].Equals(LANGUAGES.NAME_ID.ToString()))
                    {
                        Config.LANGUAGE = LANGUAGES.NAME_ID;
                    }
                    // 字段名称
                    string[] fieldNames = dataList[2].Split(',');
                    _fieldNameDlbm = fieldNames[0];
                    _fieldNameDlmc = fieldNames[1];


                    // 将前面的非数据条目移除
                    for (int i = 0; i < Config.RowsCountExceptData; i++)
                    {
                        dataList.RemoveAt(0);
                    }

                    // 添加表格控件
                    rootPanel.Controls.Clear();
                    TableLayoutPanel tableLayout = new TableLayoutPanel();
                    tableLayout.Dock = DockStyle.Fill;
                    rootPanel.Controls.Add(tableLayout);
                    // 添加列
                    for (int i = 0; i < columns; i++)
                    {
                        tableLayout.ColumnCount++;
                        tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, tableLayout.Width * columns / 10.0f));    //利用百分比计算，0.2f表示占用本行长度的20%
                    }
                    // 计算需要多少行
                    int rows = (dataList.Count) / columns;
                    if ((dataList.Count) % columns > 0)
                    {
                        rows++;
                    }
                    // 添加行
                    for (int i = 0; i < rows; i++)
                    {
                        tableLayout.RowCount++;
                        tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, tableLayout.Height * rows / 10.0f));
                    }
                    // 遍历添加按钮
                    for (int rowIndex = 0; rowIndex < rows; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < columns; colIndex++)
                        {
                            var index = rowIndex * columns + colIndex;
                            if (index < dataList.Count)
                            {
                                Button button = new Button();
                                button.FlatStyle = FlatStyle.System;
                                button.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                //button.Text = dataList[rowIndex * columns + colIndex ]; //map.Keys.ToArray()[rowIndex * columns + colIndex];
                                string tmpData = dataList[rowIndex * columns + colIndex];
                                button.Tag = tmpData;
                                button.Text = GetButtonText(tmpData);
                                button.Dock = DockStyle.Fill;
                                button.Click += new EventHandler(ButtonClickEvent);
                                tableLayout.Controls.Add(button, colIndex, rowIndex);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                DialogUtils.ShowDialogError("配置文件读取失败");
            }

        }

        /// <summary>
        /// 根据数据转换得到地类数据
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string GetButtonText(string val)
        {
            // 数据格式：0101,旱地
            var valArray = val.Split(',');
            string result = valArray[0];
            switch (Config.LANGUAGE)
            {
                case LANGUAGES.ID:
                default:
                    result = valArray[0];
                    break;
                case LANGUAGES.NAME:
                    result = valArray[1];
                    break;
                case LANGUAGES.ID_NAME:
                    result = valArray[0] + "\r\n" + valArray[1];
                    break;
                case LANGUAGES.NAME_ID:
                    result = valArray[1] + "\r\n" + valArray[0];
                    break;
            }
            return result;
        }

        private void SetLayer(string layerName)
        {
            Config._currentLayerName = layerName;
            menuChooseLayer.Text = "当前图层：" + Config._currentLayerName;
            menuChooseLayer.ForeColor = Color.DarkGreen;
        }


        /// <summary>
        /// 选择图层
        /// </summary>
        private void menuChooseLayer_Click(object sender, EventArgs e)
        {
            Init();
            FrmChooseLayer frm = new FrmChooseLayer();
            frm._funcGetLayers = RefreshLayers;
            frm._actionSetLayer = SetLayer;
            frm.ShowDialog();
        }



        /// <summary>
        /// 刷新图层列表
        /// </summary>
        /// <returns></returns>
        private List<string> RefreshLayers()
        {
            List<string> list = new List<string>();
            IEnumLayer layers = Utils.getFeatureLayers(mMap);
            if (layers == null || layers.Next() == null)
            {
                return list;
            }
            ILayer layer = null;
            layers.Reset();  //将游标归位
            //遍历获取到的矢量图层，并添加到下拉列表中
            while ((layer = layers.Next()) != null)
            {
                // ToolStripMenuItem menuItem = new ToolStripMenuItem(layer.Name);  
                list.Add(layer.Name);
            }
            return list;
        }



        /// <summary>
        /// 选择图层下拉菜单
        /// </summary>
        private void menuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                Config._currentLayerName = (sender as ToolStripMenuItem).Text;
            }
            menuChooseLayer.Text = "当前图层：" + Config._currentLayerName;
            menuChooseLayer.ForeColor = Color.DarkGreen;
        }


        /// <summary>
        /// 动态添加的赋值按钮点击事件，对选中要素赋值
        /// </summary>
        private void ButtonClickEvent(object sender, EventArgs e)
        {
            //Button btn = sender as Button;
            //string[] vals = btn.Tag.ToString().Split(',');
            //Utils.ShowDialogWarning("地类编码：" + vals[0] + "\r\n地类名称：" + vals[1]);


            if (sender is Button)
            {
                if (string.IsNullOrEmpty(Config._currentLayerName))
                {
                    Utils.ShowDialogWarning("未选择图层");
                    return;
                }


                Button btn = sender as Button;

                // MessageBox.Show((sender as Button).Text);
                IEnumLayer layers = Utils.getFeatureLayers(mMap);
                if (layers == null || layers.Next() == null)
                {
                    Utils.ShowDialogWarning("没有矢量图层");
                    return;
                }
                if (Config._currentLayerName == null || Config._currentLayerName.Equals(""))
                {
                    Utils.ShowDialogWarning("请先选择图层");
                    return;
                }
                if (mDocument != null)
                {
                    Button button = (Button)sender;
                    string[] vals = btn.Tag.ToString().Split(',');

                    Utils.setValue(mMap, Config._currentLayerName, _fieldNameDlbm, vals[0]);
                    Utils.setValue(mMap, Config._currentLayerName, _fieldNameDlmc, vals[1]);
                    //Utils.setValue(mMap, _currentLayerName, _fieldNameDlbm, vals[0], true, 400);
                    mDocument.ActiveView.Refresh();
                }
            }
        }

        private void menuSingleField_Click(object sender, EventArgs e)
        {
            Init();
            Utils.ShowDockAbleWindow(ThisAddIn.IDs.FrmBz);
        }




        private void Init()
        {
            if (mDocument == null)
            {
                mDocument = ArcMap.Document;
            }
            if (mMap == null)
            {
                mMap = mDocument.FocusMap;
            }
        }


    }
}
