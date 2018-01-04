using DevExpress.LookAndFeel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace January.App
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.Skins.SkinManager.EnableFormSkinsIfNotVista();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(FrmRibbonStart.MainRibbonForm).Assembly);
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(FrmNavigateStart.MainNavigateForm).Assembly);
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Dark Style");

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            RunApplication();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            
        }

        private static void RunApplication()
        {
            try
            {
                const string startFrmStr = "Ribbon";
                if (startFrmStr.Contains("Ribbon"))
                {
                    Application.Run(new FrmRibbonStart.MainRibbonForm());
                }
                else
                {
                    Application.Run(new FrmNavigateStart.MainNavigateForm());
                }
            }
            catch (Exception ex)
            {
                string spitstr = "\r\n<------------程序启动异常---------------->\r\n";
                string exceptionStr = string.Format("{0}{1}{2}{3}{4}", ex.Message, spitstr, ex.StackTrace, spitstr, ex.Source);
            }
        }
    }
}
