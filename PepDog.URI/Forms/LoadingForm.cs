﻿using LambdaBlox.Core;
using LambdaBloxURI.Local;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambdaBloxURI.Forms {
    public partial class LoadingForm : Form {
        public LoadingForm() {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e) {
            Functions.SetupURIValues(this);
            MessageBox.Show(Variables.command + " " + Variables.name);
        }
    }
}
