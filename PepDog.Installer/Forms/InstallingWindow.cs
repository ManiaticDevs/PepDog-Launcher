using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambdaBlox.Installer {
    public partial class InstallingWindow : Form {
        public InstallingWindow() {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e) {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".lambdablox");
            string temp = System.IO.Path.Combine(path, "tmp");
            string clientfolder = System.IO.Path.Combine(path, "client");

            if (!System.IO.Directory.Exists(path)) {
                System.IO.Directory.CreateDirectory(path);
                progressBar1.Increment(20);
            }

            if (!System.IO.Directory.Exists(temp)) {
                System.IO.Directory.CreateDirectory(temp);
                progressBar1.Increment(20);
            } else {
                progressBar1.Increment(40);
            }

            using (var client = new WebClient()) {
                client.DownloadFile("http://afs.gurdit.com/download/L2008.zip", System.IO.Path.Combine(temp, "client.zip"));
            }

            progressBar1.Increment(20);

            if (!System.IO.Directory.Exists(clientfolder)) {
                System.IO.Directory.CreateDirectory(clientfolder);
                ZipFile.ExtractToDirectory(System.IO.Path.Combine(temp, "client.zip"), clientfolder);
            }

            progressBar1.Increment(20);
        }
    }
}
