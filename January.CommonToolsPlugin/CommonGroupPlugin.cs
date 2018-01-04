using January.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January.CommonToolsPlugin
{
    [Export(typeof(IRibbonGroupPlugin))]
    public class CommonGroupPlugin : IRibbonGroupPlugin
    {

        [ImportMany]
        public IEnumerable<IPlugin> _barItems;
        public IEnumerable<IPlugin> BarItems
        {
            get
            {
                return _barItems;
            }
        }

        public string ID
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }

        public string Text
        {
            get
            {
                return "文件";
            }
        }

        public string ToolTip
        {
            get
            {
                return "文件";
            }
        }
    }
}
