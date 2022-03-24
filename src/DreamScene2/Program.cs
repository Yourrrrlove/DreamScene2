using System;
using System.IO;
using System.Windows.Forms;

namespace DreamScene2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string filePath = Helper.GetPathForAppFolder("lock");
                File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            }
            catch
            {
                MessageBox.Show("当前已经有一个实例在运行。", Constant.ProjectName);
                return;
            }

#if NET5_0_OR_GREATER
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length != 0 && args[0] == Constant.Cmd)
            {
                MainForm mainForm = new MainForm();
                mainForm.Opacity = 0;
                mainForm.Show();

                mainForm.Hide();
                mainForm.Opacity = 1;

                Application.Run();
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}
