﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Controllers;
using KantoorInrichting.Controllers.Grid;
using KantoorInrichting.Controllers.Placement;
using KantoorInrichting.Controllers.Product;
using KantoorInrichting.Models.Grid;
using KantoorInrichting.Views.Grid;
using KantoorInrichting.Views.Placement;
using KantoorInrichting.Views.Product;

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

        public MainScreen()
        {
            InitializeComponent();
        }

        private void VooraadButton_Click(object sender, EventArgs e)
        {
            hoofdscherm.inventoryScreen1.Visible = true;
            hoofdscherm.inventoryScreen1.Enabled = true;
            this.Visible = false;
            hoofdscherm.inventoryScreen1.BringToFront();
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
//            GridController gc = new GridController(hoofdscherm.gridFieldView, new GridFieldModel(10, 10, 0.5f));
//            // hoofdscherm overwrites my GridFieldView size, so I have to set the screen size like this
//            hoofdscherm.Width = 800;
//            hoofdscherm.Height = 670;
//            hoofdscherm.gridFieldView.SetListView(ProductFactory.GetPossibilities());
//            Application.DoEvents();
//            hoofdscherm.Active = hoofdscherm.gridFieldView;
//            hoofdscherm.gridFieldView.Visible = true;
//            hoofdscherm.gridFieldView.Enabled = true;
//            this.Visible = false;
//            hoofdscherm.gridFieldView.BringToFront();

            Console.WriteLine("Open room selection and get data from there! -- MainScreen.cs Line 58");
            hoofdscherm.productGrid = new ProductGrid();
            IController controller = new ProductGridController(hoofdscherm.productGrid, 10, 10, 0.5f);
            hoofdscherm.AddPanelToMainscreen(hoofdscherm.productGrid);
            hoofdscherm.Size = ProductGrid.PanelSize;
            hoofdscherm.productGrid.Visible = true;
            hoofdscherm.productGrid.Enabled = true;
            this.Visible = false;
            hoofdscherm.productGrid.BringToFront();
        }

        private void assortmentButton_Click(object sender, EventArgs e)
        {
            hoofdscherm.assortmentScreen.Visible = true;
            hoofdscherm.assortmentScreen.Enabled = true;
            this.Visible = false;
            hoofdscherm.assortmentScreen.BringToFront();
        }

        private void ProductAddingButton_Click(object sender, EventArgs e)
        {

            hoofdscherm.spaceChoice.Visible = true;
            hoofdscherm.spaceChoice.Enabled = true;
            this.Visible = false;
            hoofdscherm.spaceChoice.BringToFront();
        }

        private void CategoryManager_Click(object sender, EventArgs e)
        {
            hoofdscherm.categoryManagerController = new CategoryManagerController();
            hoofdscherm.categoryManager = new CategoryManager(hoofdscherm.categoryManagerController);
        }

        private void MapsButton_Click(object sender, EventArgs e)
        {
            hoofdscherm.MapsScreen.Visible = true;
            hoofdscherm.MapsScreen.Enabled = true;
            this.Visible = false;
            hoofdscherm.MapsScreen.BringToFront();
        }
    }
}
