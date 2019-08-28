using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Framework;

namespace FzTool_V2
{
    public static class Utils
    {
        //public static ESRI.ArcGIS.Desktop.AddIns.ComboBox getComboBox(string IDs)
        //{
        //    return AddIn.FromID<ESRI.ArcGIS.Desktop.AddIns.ComboBox>(ThisAddIn.IDs.ComboBox_LayerItem);
        //}


        /// <summary>
        /// 得到指定地图中的所有矢量图层
        /// </summary>
        /// <param name="map">地图</param>
        /// <returns></returns>
        public static IEnumLayer getFeatureLayers(IMap map)
        {
            UID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";//FeatureLayer            
            IEnumLayer layers = map.get_Layers(uid, true);
            return layers;
        }

        /// <summary>
        /// 根据名称在地图上查找对应矢量图层
        /// </summary>
        /// <param name="map">地图</param>
        /// <param name="layerName">图层名称</param>
        /// <returns>查找到的矢量图层</returns>
        public static IFeatureLayer getFeatureLayerByName(IMap map, string layerName)
        {
            IEnumLayer layers = getFeatureLayers(map);
            layers.Reset();
            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                {
                    return layer as IFeatureLayer;
                }
            }
            return null;
        }

        /// <summary>
        /// 得到指定图层上的选中的features
        /// </summary>
        /// <param name="map">地图</param>
        /// <param name="layerName">图层名</param>
        /// <returns>包含选中要素的IFeatureCursor</returns>
        public static IFeatureCursor getSelectFeatures(IMap map, string layerName)
        {
            IFeatureLayer featureLayer = getFeatureLayerByName(map, layerName);
            //得到选中的feature
            IFeatureClass inputFeatureClass = featureLayer.FeatureClass;
            IDataset inputDataset = (IDataset)inputFeatureClass;
            IDatasetName inputDatasetName = (IDatasetName)inputDataset.FullName;
            IFeatureSelection featureSelection = (IFeatureSelection)featureLayer;
            ISelectionSet selectionSet = featureSelection.SelectionSet;

            ICursor cursor;
            selectionSet.Search(null, false, out cursor);
            IFeatureCursor featureCursor = (IFeatureCursor)cursor;

            return featureCursor;
        }

        /// <summary>
        /// 得到指定图层中的所有feature
        /// </summary>
        /// <param name="map">地图文档</param>
        /// <param name="layerName">图层名</param>
        /// <returns>包含所有要素的IFeatureCursor</returns>
        public static IFeatureCursor getAllFeatures(IMap map, string layerName)
        {
            IFeatureLayer pFeatureLayer = getFeatureLayerByName(map, layerName);

            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
            return pFeatureCursor;
        }


        /// <summary>
        /// 设置属性表中的字段值
        /// </summary>
        /// <param name="map">IMap对象</param>
        /// <param name="layerName">图层名称</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="checkArea">是否检查小面积</param>
        /// <param name="area">小面积阈值，如果<b>checkArea</b>设置为false，则此值无效</param>
        public static void setValue(IMap map, string layerName, string fieldName, object value, bool checkArea = false, double area = 0)
        {
            IFeatureCursor pCursor = Utils.getSelectFeatures(map, layerName);
            IFeature pFeature = pCursor.NextFeature();
            if (pFeature == null)
            {
                return;
            }
            int pIndex = -1;
            try
            {
                //找字段
                pIndex = pFeature.Fields.FindFieldByAliasName(fieldName);
            }
            catch (Exception)
            {
                ShowDialogError("字段\"" + fieldName + "\"不存在！");
                return;
            }
            if (pIndex >= 0)
            {
                while (pFeature != null)
                {
                    if (checkArea)
                    {
                        IArea pArea = pFeature.Shape as IArea;
                        if (pArea.Area >= area)
                        {
                            //设置属性表中的值
                            pFeature.Value[pIndex] = value;
                            pFeature.Store();
                        }
                        else
                        {
                            ShowDialogWarning("当前图斑面积为：" + pArea.Area + "m²，小于临界面积：" + area + "m²。");
                        }
                    }
                    else
                    {
                        //设置属性表中的值
                        pFeature.Value[pIndex] = value;
                        pFeature.Store();
                    }
                    pFeature = pCursor.NextFeature();
                }
            }
        }

        /// <summary>
        /// 设置属性表中的字段值
        /// </summary>
        /// <param name="map">IMap对象</param>
        /// <param name="layerName">图层名称</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="checkArea">是否检查小面积</param>
        /// <param name="area">小面积阈值，如果<b>checkArea</b>设置为false，则此值无效</param>
        public static void setValue(IMap map, string layerName, string fieldName1, object value1, string fieldName2, object value2, double area = -1)
        {
            IFeatureCursor pCursor = Utils.getSelectFeatures(map, layerName);
            IFeature pFeature = pCursor.NextFeature();
            if (pFeature == null)
            {
                return;
            }
            int pIndex1 = -1, pIndex2 = -1;
            try
            {
                //找字段
                pIndex1 = pFeature.Fields.FindFieldByAliasName(fieldName1);
                pIndex2 = pFeature.Fields.FindFieldByAliasName(fieldName2);
                //MessageBox.Show(pIndex1 + "---" + pIndex2);
            }
            catch (Exception)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("字段[");
                if (pIndex1 == -1)
                {
                    sb.Append(fieldName1);
                    sb.Append("]");
                    if (pIndex2 == -1)
                    {
                        sb.Append("及[");
                        sb.Append(fieldName2);
                        sb.Append("]");
                    }
                }
                else if (pIndex2 == -1)
                {
                    sb.Append(fieldName2);
                    sb.Append("]");
                }
                sb.Append("未找到");
                MessageBox.Show(sb.ToString());
            }
            if (pIndex1 >= 0 && pIndex2 >= 0)
            {
                while (pFeature != null)
                {
                    IArea pArea = pFeature.Shape as IArea;
                    if (area == -1 || pArea.Area >= area)
                    {
                        //设置属性表中的值
                        pFeature.Value[pIndex1] = value1;
                        pFeature.Value[pIndex2] = value2;
                        pFeature.Store();
                    }
                    else
                    {
                        ShowDialogWarning("当前图斑面积为：" + pArea.Area + "m²，小于临界面积：" + area + "m²。");
                    }
                    pFeature = pCursor.NextFeature();
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("字段[");
                if (pIndex1 == -1)
                {
                    sb.Append(fieldName1);
                    sb.Append("]");
                    if (pIndex2 == -1)
                    {
                        sb.Append("及[");
                        sb.Append(fieldName2);
                        sb.Append("]");
                    }
                }
                else if (pIndex2 == -1)
                {
                    sb.Append(fieldName2);
                    sb.Append("]");
                }
                sb.Append("未找到");
                MessageBox.Show(sb.ToString());
            }
        }

        /// <summary>
        /// 向属性表中添加字段
        /// </summary>
        /// <param name="map">地图文档</param>
        /// <param name="layerName">图层名字</param>
        /// <param name="fieldName">字段名字</param>
        /// <param name="esriFieldType">字段类型</param>
        public static void addField(IMap map, string layerName, string fieldName, esriFieldType esriFieldType)
        {


            //achieve layer in the map
            IFeatureLayer pFeatureLayer = getFeatureLayerByName(map, layerName) as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            ITable pTable = pFeatureClass as ITable;        //use ITable or IClass  

            if (pTable.Fields.FindField(fieldName) >= 0)
            {
                if (DialogResult.Yes ==
                    MessageBox.Show("指定的字段名 \"" + fieldName + "\" 无效，因为它与现有字段重名。是否自动将该字段重命名为" +
                    " \"" + fieldName + "1\" ?", "无效字段", MessageBoxButtons.YesNo))
                {
                    fieldName += "1";
                }
                else
                {
                    return;
                }
            }
            //new a field and add to layer in the map  
            //new a field: "name_cit", type:string 
            IField pField = new FieldClass();
            IFieldEdit pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Name_2 = fieldName;
            pFieldEdit.Type_2 = esriFieldType;

            pTable.AddField(pFieldEdit);

            // 设置字段值
            //set values of every feature's field-"name_cit" in the first layer  
            //for (int i = 0; i < pFeatureClass.FeatureCount(null); i++)
            //{
            //    IFeature pFeature = pFeatureClass.GetFeature(i);
            //    pFeature.set_Value(pFeature.Fields.FindField("name_city"), "city_name");
            //    pFeature.Store();
            //}
        }

        /// <summary>
        /// 从属性表中删除字段
        /// </summary>
        /// <param name="map">地图文档</param>
        /// <param name="layerName">图层名</param>
        /// <param name="fieldName">字段名</param>
        public static bool deleteField(IMap map, string layerName, string fieldName)
        {
            try
            {
                IFeatureLayer pFeatureLayer = getFeatureLayerByName(map, layerName);
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                ITable pTable = pFeatureClass as ITable;

                // 根据字段名找到字段对象
                IFields pFields = pFeatureClass.Fields as IFields;
                int pFieldIndex = pFields.FindField(fieldName);

                //MessageBox.Show(
                //    "fieldName::" + fieldName
                //    + "\npFieldIndex::" + pFieldIndex

                //    );

                IField pField = pFields.Field[pFieldIndex];
                pTable.DeleteField(pField);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 根据图层属性表中某个字段的索引获取其字段名
        /// </summary>
        /// <param name="map">地图文档</param>
        /// <param name="layerName">图层名</param>
        /// <param name="index">字段索引</param>
        /// <returns>返回字段名</returns>
        public static string getFieldName(IMap map, string layerName, int index)
        {
            IFeatureLayer pFeatureLayer = getFeatureLayerByName(map, layerName);
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            ITable pTable = pFeatureClass as ITable;
            if (index <= pTable.Fields.FieldCount)
            {
                MessageBox.Show("索引超出范围", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return pTable.Fields.Field[index].Name;
        }

        /// <summary>
        /// 根据图层属性表中某个字段的字段名获取其索引号
        /// </summary>
        /// <param name="map">地图文档</param>
        /// <param name="layerName">图层名</param>
        /// <param name="fieldName">字段名</param>
        /// <returns>返回字段的索引，如果未找到返回-1</returns>
        public static int getFieldIndex(IMap map, string layerName, string fieldName)
        {
            IFeatureLayer pFeatureLayer = getFeatureLayerByName(map, layerName) as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            ITable pTable = pFeatureClass as ITable;
            if (pTable.FindField(fieldName) > 0)
            {
                return pTable.FindField(fieldName);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取字段值
        /// </summary>
        /// <param name="map"></param>
        /// <param name="layerName"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static object getFieldValue(IMap map, string layerName, string fieldName)
        {
            IFeatureCursor pCursor = getSelectFeatures(map, layerName);
            IFeature pFeature = pCursor.NextFeature();
            if (pFeature == null)
            {
                return null;
            }
            int index = getFieldIndex(map, layerName, fieldName);
            return pFeature.Value[index];
        }


        internal static void ShowDialogWarning(string msg)
        {
            MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        internal static void ShowDialogError(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static void ShowDialogInfo(string msg)
        {
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        internal static void ShowDialogQuestion(string msg)
        {
            MessageBox.Show(msg, "确定？", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// 根据ID显示指定的DockWindow
        /// </summary>
        /// <param name="uid_value">UID.Value，一般为“ThisAddIn.IDs.xxxx”格式，其中“xxxx”为DockableWindow的ID</param>
        internal static void ShowDockAbleWindow(string uid_value)
        {
            if (DateTime.Now > new DateTime(2019, 8, 31))
            {
                ShowDialogInfo("插件已过期");
                return;
            }

            IDockableWindowManager pDocWinMgr = ArcMap.DockableWindowManager;
            UID uid = new UIDClass()
            {
                Value = uid_value
            };
            IDockableWindow pWindow = pDocWinMgr.GetDockableWindow(uid);


            if (!pWindow.IsVisible())
            {
                pWindow.Dock(esriDockFlags.esriDockShow);
            }
            else
            {
                pWindow.Dock(esriDockFlags.esriDockUnPinned);
            }

        }
    }
}
