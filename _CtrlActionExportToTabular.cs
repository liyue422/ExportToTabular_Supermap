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
