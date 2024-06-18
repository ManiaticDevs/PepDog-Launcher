using LambdaBloxURI.Forms;
using LambdaBloxURI.Local;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambdaBloxURI
{
    internal sealed class PepDogURI
    {
        /** <summary>
        * The main entry point for the application.
        * </summary> */
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
            {
                Application.Run(new InstallForm());
            }
            else
            {
                foreach (string s in args)
                {
                    Variables.SharedArgs = s;
                }

                Application.Run(new LoadingForm());
            }
        }
    }
}
