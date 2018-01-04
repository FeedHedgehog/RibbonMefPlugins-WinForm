using January.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January.CommonToolsPlugin
{
    [Export(typeof(IRibbonPagePlugin))]
    public class CommmonPagePlugin : IRibbonPagePlugin
    {
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

        [ImportMany]
        public IEnumerable<IRibbonGroupPlugin> _rbGroups;
        public IEnumerable<IRibbonGroupPlugin> rbGroups
        {
            get
            {
                return _rbGroups;
            }
        }

        public string Text
        {
            get
            {
                return "主页";
            }
        }

        public string ToolTip
        {
            get
            {
                return "主页";
            }
        }
    }
}
