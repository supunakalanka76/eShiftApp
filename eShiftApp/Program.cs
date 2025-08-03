using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShiftApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Forms.LoginForm());
            //Application.Run(new Forms.AdminDashboardForm());
            //Application.Run(new Forms.RegisterForm());
            //Application.Run(new Forms.TransportForm());
        }
    }
}
