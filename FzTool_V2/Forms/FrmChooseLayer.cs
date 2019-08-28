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
    public partial class FrmChooseLayer : Form
    {
        public Action<string> _actionSetLayer;
        public Func<List<string>> _funcGetLayers;
        private string _noLayerData = "<没有任何矢量图层>";

        public FrmChooseLayer()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshLayers();
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!cbLayerList.Text.Equals(_noLayerData))
            {
                _actionSetLayer.Invoke(cbLayerList.Text);
            }
            Close();
        }

        private void FrmChooseLayer_Load(object sender, EventArgs e)
        {
            RefreshLayers();
        }

        /// <summary>
        /// 刷新图层
        /// </summary>
        private void RefreshLayers()
        {
            List<string> layers = _funcGetLayers.Invoke();
            cbLayerList.Items.Clear();
            if (layers.Count > 0)
            {
                cbLayerList.Items.AddRange(layers.ToArray());

            }
            else
            {
                cbLayerList.Items.Add(_noLayerData);
            }
            cbLayerList.SelectedIndex = 0;
        }
    }
}
