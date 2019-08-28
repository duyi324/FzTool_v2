using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ESRI.ArcGIS.ArcMapUI;
namespace FzTool_V2
{
    static class Config
    {

        public static IMxDocument ArcMapDocument;

        public static string PATH_CONFIG_FILE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "fzconfig.ini");
        public static string PATH_BZ_CONFIG_FILE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "fzconfigbz.ini");

        public static LANGUAGES LANGUAGE = LANGUAGES.ID;

        /// <summary>
        /// 非地类数据有几行，当前为 3
        /// 1.每行多少按钮
        /// 2.语言
        /// 3.编码和名称字段名
        /// </summary>
        public static int RowsCountExceptData = 3;


        /// <summary>
        /// 要操作的图层名称
        /// </summary>
        public static string _currentLayerName;
    }
}
