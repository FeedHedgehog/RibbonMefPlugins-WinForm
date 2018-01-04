using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January.Contract
{

    public interface IRibbonPagePlugin
    {
        IEnumerable<IRibbonGroupPlugin> rbGroups { get; }
        string ID { get; }
        string Text { get; }
        string ToolTip { get; }
        int Order { get; }
    }
}
