using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SuperMap.Desktop;

namespace SuperMap.Desktop.ExportToTabular
{
    public class _Plugin : Plugin
    {
        public _Plugin(PluginInfo pluginInfo)
            : base(pluginInfo)
        {

        }

        public override Boolean Initialize()
        {
            return true;
        }

        public override Boolean ExitInstance()
        {
            return true;
        }
    }

    class _CtrlAction : CtrlAction
    {
        override public void Run()
        {
            MessageBox.Show("_CtrlAction.Run");
        }
    }
}
