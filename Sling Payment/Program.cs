using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paypal_Recurring_Payment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Count() > 0)
            {
                Application.Run(new configForm(Int32.Parse(args[0]), args[1], args[2]));
            }
            else
            {
                Application.Run(new configForm(0, ""));
            }
        }
    }
}
