using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FzTool_V2
{
    public class BtnFzTool : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public BtnFzTool()
        {

          //  Config.ArcMapDocument = ArcMap.Document;

        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            // ArcMap.Application.CurrentTool = null;

            Utils.ShowDockAbleWindow(ThisAddIn.IDs.FrmFz);
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
          //  Config.ArcMapDocument = ArcMap.Document;
        }
    }

}
