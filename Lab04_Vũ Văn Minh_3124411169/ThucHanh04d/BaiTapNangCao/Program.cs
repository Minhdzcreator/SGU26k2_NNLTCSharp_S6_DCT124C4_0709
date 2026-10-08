using System;
using System.Windows.Forms;
namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Ch?y form Cafe Sinh Vi�n
            Application.Run(new frmCafeSinhVien());
        }
    }
}
