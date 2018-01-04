using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January.Contract
{
    public interface IPlugin
    {
        string ID { get; }
        string Name { get; }
        string Text { get; }
        string ToolTip { get; }
        Bitmap Icon { get; }
        RibbonItemStyles RbItemStyles { get; }
        int Order { get; }
        bool IsBeginGroup { get; }
        string Do();
    }
}
