﻿using PepDogURI.Local;
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
    public partial class InstallForm : Form {
        public InstallForm() {
            InitializeComponent();
        }

        private void InstallForm_Load(object sender, EventArgs e) {
            CenterToScreen();
        }

        private void InstallButton_Click(object sender, EventArgs e) {
            Functions.RegisterURI(this);
            Close();
        }
    }
}
