using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using System.Drawing;
using January.Contract;

namespace January.CommonToolsPlugin
{
    [Export(typeof(IPlugin))]
    public class iNewBtn : IPlugin
    {
        public Bitmap Icon
        {
            get
            {
                return Properties.Resources.b3d_open;
            }
        }

        public string ID
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }

        public string Name
        {
            get
            {
                return this.ToString();
            }
        }

        public string Text
        {
            get
            {
                return "新建";
            }
        }

        public string ToolTip
        {
            get
            {
                return "新建一个文件";
            }
        }

        public string Do()
        {
            XtraMessageBox.Show("新建的动作", "系统提示：");
            return string.Empty;
        }

        public RibbonItemStyles RbItemStyles { get { return RibbonItemStyles.Large; } }

        public int Order
        {
            get
            {
                return 1;
            }
        }

        public bool IsBeginGroup
        {
            get
            {
                return false;
            }
        }
    }
}
