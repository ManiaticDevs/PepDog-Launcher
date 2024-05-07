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

        public static void SetupURIValues(Form form) {
            string[] holder = Variables.SharedArgs.Replace("pepdog://", "").Split('/');
            Variables.command = holder[0];
            try {
                Variables.id = int.Parse(holder[1]);
            } catch(FormatException e) {
                MessageBox.Show("Failed to process URL as ID was not a number!", "PepDog - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.Close();
            }
            
        }
    }
}
