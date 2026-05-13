using System;
using System.Windows.Forms;
using CLIESC_ConUni_DotNet_GR6.ec.edu.monster.vista;

namespace CLIESC_ConUni_DotNet_GR6
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginVista());
        }
    }
}
