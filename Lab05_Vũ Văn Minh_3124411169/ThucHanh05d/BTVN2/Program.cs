using System;
using System.Windows.Forms;
namespace BTVN_Tuan6App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain()); // Chạy Form Main MDI
        }
    }
}
