﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views
{
    public partial class MainScreen : UserControl
    {
        public MainFrame hoofdscherm;
        public MainScreen(MainFrame hoofdscherm)
        {
            this.hoofdscherm = hoofdscherm;
            InitializeComponent();
        }

        private void VooraadButton_Click(object sender, EventArgs e)
        {
            hoofdscherm.inventoryScreen1.Visible = true;
            hoofdscherm.inventoryScreen1.Enabled = true;
            this.Visible = false;
            hoofdscherm.inventoryScreen1.BringToFront();
        }
    }
}