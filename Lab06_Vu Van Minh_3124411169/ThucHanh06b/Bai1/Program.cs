using System;
using System.Windows.Forms;

namespace ThucHanh06b_Bai1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmSinhVien_Combo());
        }
    }
}