﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserClient
{
    public partial class SetupSeverData : Form
    {
        public SetupSeverData()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
        }
    }
}
