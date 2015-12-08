﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views.Inventory
{
    public partial class InventoryEdit : Form
    {
        private Models.Product.ProductModel P;

        //makes sure the productnaam and amount are filled in correctly in the screen
        public InventoryEdit(Models.Product.ProductModel p)
        {
            InitializeComponent();
            P = p;

            ProductNaam.Text = "productnaam: " + P.name;
            ProductAantal.Value = P.amount;
            
        }
        //sets the amount from the product to the given value
        private void button1_Click(object sender, EventArgs e)
        {
            P.amount = Convert.ToInt32(ProductAantal.Value);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}