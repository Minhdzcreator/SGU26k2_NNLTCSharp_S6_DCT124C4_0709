using System;
using System.Windows.Forms;
namespace WinFormsApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmBaiTap1()); // Kh?i ch?y Form B�i 1
        }
    }
}
