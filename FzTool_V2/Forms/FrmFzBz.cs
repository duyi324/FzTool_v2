using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
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
    public partial class FrmBz : UserControl
    {

        private string _strNoData = "右键设置属性";
        private string _fieldName, _fieldValue;
        private string _layerName;

        private IMxDocument mDocument = null;
        private IMap mMap = null;

        public FrmBz(object hook)
        {
            InitializeComponent();
            this.Hook = hook;


            if (File.Exists(Config.PATH_BZ_CONFIG_FILE))
            {
                List<string> list = File.ReadAllLines(Config.PATH_BZ_CONFIG_FILE).ToList();
                if (list != null && list.Count > 0)
                {
                    string[] attrs = list[0].Split(',');
                    SetValue(attrs[0], attrs[1]);
                }
                else
                {
                    btnBz.Text = _strNoData;
                    btnBz.ForeColor = Color.Red;
                }
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
            private FrmBz m_windowUI;

            public AddinImpl()
            {
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new FrmBz(this.Hook);
                return m_windowUI.Handle;
            }

            protected override void Dispose(bool disposing)
            {
                if (m_windowUI != null)
                    m_windowUI.Dispose(disposing);

                base.Dispose(disposing);
            }

        }




        private void btnBz_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(MousePosition.X, MousePosition.Y);
            }
        }



        private void menuEdit_Click(object sender, EventArgs e)
        {
            FrmFzBzConfig frm = new FrmFzBzConfig();
            frm._actionSave = SetValue;
            frm.ShowDialog();
        }

        private void btnBz_Click(object sender, EventArgs e)
        {
            Init();

            try
            {
                if (Config._currentLayerName == null || Config._currentLayerName.Equals(""))
                {
                    DialogUtils.ShowDialogWarning("未选择图层，请在赋值界面选择图层");
                    return;
                }
                if (_fieldName == null || _fieldName == null)
                {
                    DialogUtils.ShowDialogWarning("未设置字段名和字段值");
                    return;
                }

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
                    Utils.setValue(mMap, Config._currentLayerName, _fieldName, _fieldValue);
                    //Utils.setValue(mMap, _currentLayerName, _fieldNameDlbm, vals[0], true, 400);
                    mDocument.ActiveView.Refresh();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void SetValue(string name, string value)
        {
            btnBz.Text = name + "->" + value;
            btnBz.ForeColor = Color.DarkGreen;
            _fieldName = name;
            _fieldValue = value;
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
