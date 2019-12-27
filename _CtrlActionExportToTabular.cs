using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using SuperMap.Desktop ;
using SuperMap.Data;
using SuperMap.Mapping;


namespace SuperMap.Desktop.ExportToTabular
{
    class _CtrlActionExportToTabular:CtrlAction 
    {  
        public _CtrlActionExportToTabular(IBaseItem caller)
            :base (caller)
        {
        
        }
       
        //当当前地图窗口中不存在任何图层时，定位到按钮不可用

        //public override bool Enable()
        //{
        //    Boolean enable = false;
        //    try
        //    {
        //        //获取当前活动的地图窗口

        //        IFormMap mapwindow = FormClass as IFormMap;
        //        if (mapwindow.MapControl.Map.Layers.Count > 0)
        //        {
        //            enable = true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        SuperMap.Desktop.Application.ActiveApplication.Output.Output(ex.StackTrace);

        //    }
        //    return enable;
        //}
        //触发定位到按钮，执行弹出定位到的窗口
        public override void Run()
        {
            try
            {
                _frmExportToTabular frmExportToTabular = new _frmExportToTabular();
                frmExportToTabular.Show();
            }
            catch (System.Exception ex)
            {
                SuperMap.Desktop.Application.ActiveApplication.Output.Output(ex.StackTrace);
            }
        }

        public override Boolean Enable()
        {
            Boolean enable = false;
            try
            {
                //首先获取当前窗体的工作空间对象

                Workspace Wkspace = Application.ActiveApplication.Workspace;
                Datasources objDss = Wkspace.Datasources;
                int DsCount = objDss.Count;

                if (DsCount == 0)
                {
                    enable = false;
                }
                else
                {
                    enable = true;
                }

            }
            catch
            {

            }
            return enable;
        }

    }
}
