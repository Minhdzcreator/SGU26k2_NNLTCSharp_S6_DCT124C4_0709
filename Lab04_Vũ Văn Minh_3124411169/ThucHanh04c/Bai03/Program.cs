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
            Application.Run(new frmBai03()); // Ch?y Form B�i 3
        }
    }
}
