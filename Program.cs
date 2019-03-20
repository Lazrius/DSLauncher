using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DSLauncherV2
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Handle;
            AppDomain.CurrentDomain.UnhandledException += Handle;
            Application.Run(new Primary());
        }

        private static void Handle(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionHandler.Throw(ExceptionCode.Unknown, e.Exception.Message + "\n" + e.Exception.InnerException, Form.ActiveForm);
        }

        private static void Handle(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionHandler.Throw(ExceptionCode.Unknown, ((Exception)e.ExceptionObject)?.Message + "\n" + ((Exception)e.ExceptionObject)?.InnerException, Form.ActiveForm);
        }
    }
}
