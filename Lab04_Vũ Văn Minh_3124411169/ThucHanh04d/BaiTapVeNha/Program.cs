using System;
using System.Windows.Forms;
namespace WinFormsApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Ch?y Form dang k� Kh�ch s?n Thanh Thanh
            Application.Run(new frmDangkyKS());
        }
    }
}
