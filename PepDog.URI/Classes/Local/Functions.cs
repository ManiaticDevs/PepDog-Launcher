using PepDog.Core;
using PepDogURI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepDogURI.Local {
    class Functions {
        public static void RegisterURI(Form form) {
            if(SecurityFuncs.IsElevated) {
                try {
                    URIRegister uri = new URIRegister("pepdog", "url.pepdog");
                    uri.Register();

                    MessageBox.Show("URI successfully installed and registered!", "PepDog - Install URI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex) {
                    MessageBox.Show("Failed to register. (Error: " + ex.Message + ")", "PepDog - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    form.Close();
                }
            } else {
                MessageBox.Show("Failed to register. (Error: Did not run as Administrator)", "PepDog - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.Close();
            }

        }

        public static void SetupURIValues() {
            string ExtractedArg = Variables.SharedArgs.Replace("pepdog://", "").Replace("pepdog", "").Replace(":", "").Replace("/", "").Replace("?", "");
        }
    }
}
