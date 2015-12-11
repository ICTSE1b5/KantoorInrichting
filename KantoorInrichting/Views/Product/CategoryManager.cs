﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Controllers.Product;

namespace KantoorInrichting.Views.Product
{
    public partial class CategoryManager : Form
    {
        public CategoryManagerController controller;
        public string tempcat;
        public string tempsubcat;
        public KantoorInrichtingDataSet tempdata;

        public CategoryManager(CategoryManagerController controller)
        {
            this.controller = controller;
            InitializeComponent();

            this.categoryTableAdapter.Fill(this.kantoorInrichtingDataSet.category);
            var categoryList = kantoorInrichtingDataSet.category;
            
            controller.fillcombobox(CategoryModel.CategoryList, categoryComboBox);

            controller.fillSubcombobox(CategoryModel.SubcategoryList, subcategoryComboBox, categoryComboBox);
            //categoryComboBox.SelectedItem = null;
            //subcategoryComboBox.SelectedItem = ;
            
        }
        //uses the given data to create a new category
        private void newCategoryButton_Click(object sender, EventArgs e)
        {
            NewCategory newcat = new NewCategory(this);
            newcat.Show(this);
                controller.fillcombobox(CategoryModel.CategoryList, categoryComboBox);
                controller.fillSubcombobox(CategoryModel.SubcategoryList, subcategoryComboBox, categoryComboBox);
        }


        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.fillSubcombobox(CategoryModel.SubcategoryList, subcategoryComboBox, categoryComboBox);

            string selectedCategory = categoryComboBox.SelectedItem.ToString();

            // check how much products have this category
            int amount = controller.checkAmountOfProducts(selectedCategory);
            int amountSubs = controller.checkAmountOfSubs(selectedCategory);
            textBox1.Text = amount.ToString();
            textBox2.Text = amountSubs.ToString();


        }

        private void subcategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = subcategoryComboBox.SelectedItem.ToString();
            int amount = controller.checkAmountOfProducts(selectedCategory);
            textBox1.Text = amount.ToString();
            textBox2.Text = "niet mogelijk";
        }

        //saves the created categories
        private void saveButton_Click(object sender, EventArgs e)
        {
            tempcat = categoryComboBox.SelectedItem.ToString();
            tempsubcat = subcategoryComboBox.SelectedItem.ToString();
            this.Close();
        }

        //closes the screen
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void categoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.kantoorInrichtingDataSet);

        }

        private void CategoryManager_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kantoorInrichtingDataSet.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.kantoorInrichtingDataSet.category);

        }
    }
}
