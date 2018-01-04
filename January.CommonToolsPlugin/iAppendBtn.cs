using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using January.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January.CommonToolsPlugin
{
    [Export(typeof(IPlugin))]
    public class iAppendBtn : IPlugin
    {
        public Bitmap Icon
        {
            get
            {
                return Properties.Resources.b3d_add1;
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
                return "添加";
            }
        }

        public string ToolTip
        {
            get
            {
                return "添加一个文件";
            }
        }

        public string Do()
        {
            XtraMessageBox.Show("添加的动作", "系统提示：");
            return string.Empty;
        }

        public RibbonItemStyles RbItemStyles { get { return RibbonItemStyles.SmallWithText; } }      

        public int Order
        {
            get
            {
                return 2;
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
