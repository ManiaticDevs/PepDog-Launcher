using LambdaBloxURI.Local;
using System;
using System.Windows.Forms;

namespace LambdaBloxURI.Forms {
    public partial class InstallForm : Form {
        public InstallForm() {
            InitializeComponent();
        }

        private void InstallForm_Load(object sender, EventArgs e) {
            CenterToScreen();
        }

        private void InstallButton_Click(object sender, EventArgs e) {
            Functions.RegisterURI(this);
        }
    }
}
