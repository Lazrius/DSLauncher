using System;
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
            Application.ThreadException += new ThreadExceptionEventHandler(Program.Handle);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.Handle);
            Application.Run(new Primary());
        }

        private static void Handle(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionHandler.Throw(ExceptionCode.Unknown, e.Exception.Message, (Primary)Form.ActiveForm);
        }

        private static void Handle(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionHandler.Throw(ExceptionCode.Unknown, ((Exception)e.ExceptionObject)?.Message, (Primary)Form.ActiveForm);
        }
    }
}
