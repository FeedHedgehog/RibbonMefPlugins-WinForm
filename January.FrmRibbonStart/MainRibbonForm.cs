using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using DevExpress.Utils;
using January.Contract;
using DevExpress.XtraBars.Ribbon;

namespace January.FrmRibbonStart
{
    public partial class MainRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private CompositionContainer _container;
        private bool _appMenuLoaded = false;
        public MainRibbonForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            //设置目录，让引擎能自动去发现新的扩展
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + "Plugins\\"));

            //创建一个容器，相当于是生产车间
            _container = new CompositionContainer(catalog);

            //调用车间的ComposeParts把各个部件组合到一起
            try
            {
                this._container.ComposeParts(this);//这里只需要传入当前应用程序实例就可以了，其它部分会自动发现并组装
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        [ImportMany]
        public IEnumerable<IRibbonPagePlugin> rbPages;

        protected override void OnLoad(EventArgs e)
        {
            foreach (IRibbonPagePlugin rbPage in rbPages.OrderBy(h => h.Order))
            {
                RibbonPage ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
                ribbonPage1.Name = string.Format("ribbonPage{0}", rbPage.Order);
                ribbonPage1.Text = rbPage.Text;                
                ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            ribbonPage1});
                foreach (IRibbonGroupPlugin group in rbPage.rbGroups.OrderBy(h => h.Order))
                {
                    RibbonPageGroup ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
                    ribbonPageGroup1.Text = group.Text;                    
                    ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            ribbonPageGroup1});
                    foreach (IPlugin item in group.BarItems.OrderBy(h => h.Order))
                    {
                        BarButtonItem barButtonItem1 = new BarButtonItem();
                        ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
           barButtonItem1});
                        barButtonItem1.Caption = item.Text;
                        barButtonItem1.Id = item.Order;
                        barButtonItem1.Name = string.Format("barBtn{0}", rbPage.Order);
                        if (item.RbItemStyles == RibbonItemStyles.Large)
                        {
                            barButtonItem1.LargeGlyph = item.Icon;
                        }
                        else
                        {
                            barButtonItem1.Glyph = item.Icon;
                        }

                        barButtonItem1.Hint = item.ToolTip;
                        barButtonItem1.RibbonStyle = item.RbItemStyles;
                        barButtonItem1.ItemClick += (s, arg) => { item.Do(); };
                        ribbonPageGroup1.ItemLinks.Add(barButtonItem1);
                        if (!_appMenuLoaded)
                        {
                            barButtonItem1.Glyph = item.Icon;
                            this.ribbon.QuickToolbarItemLinks.Add(barButtonItem1);
                            this.appMenu.ItemLinks.Add(barButtonItem1);
                        }
                    }
                    _appMenuLoaded = true;
                }
            }

            base.OnLoad(e);
        }
    }
}