using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambdaBlox.Installer {
    public partial class InstallerWindow : Form {
        public InstallerWindow() {
            InitializeComponent();
        }

        private void InstallerWindow_Load(object sender, EventArgs e) {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!hasAdministrativeRight) {
                RunElevated(Application.ExecutablePath);
                this.Close();
                Application.Exit();
            }
        }

        private bool RunElevated(string fileName) {
            //MessageBox.Show("Run: " + fileName);
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.Verb = "runas";
            processInfo.FileName = fileName;
            try {
                Process.Start(processInfo);
                return true;
            } catch (Win32Exception) {
                // Do nothing. User probably canceled the UAC window
            }
            return false;
        }
        private void InstallButton_Click(object sender, EventArgs e) {
           this.Hide();
           (new InstallingWindow()).Show();
        }
    }
}
