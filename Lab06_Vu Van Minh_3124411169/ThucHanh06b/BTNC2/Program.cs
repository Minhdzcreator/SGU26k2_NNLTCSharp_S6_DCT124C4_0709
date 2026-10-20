using System;
using System.Windows.Forms;

namespace ThucHanh06b_BTNC2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmDanhSachDiem());
        }
    }
}