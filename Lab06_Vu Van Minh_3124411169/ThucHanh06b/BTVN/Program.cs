using System;
using System.Windows.Forms;

namespace ThucHanh06b_BTVN
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }
    }
}