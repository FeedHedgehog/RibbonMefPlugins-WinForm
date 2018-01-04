using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;

namespace January.Contract
{
    public interface IRibbonGroupPlugin 
    {
        IEnumerable<IPlugin> BarItems { get; }
        string ID { get; }       
        string Text { get; }
        string ToolTip { get; }               
        int Order { get; }
    }
}
