using PepDog.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepDogURI.Forms {
    public partial class LoadingForm : Form {
        public LoadingForm() {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e) {

            if(Client.HasJava8()) {
                
            } else {
                MessageBox.Show("Java 8 was not found!", "PepDog Launcher Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
