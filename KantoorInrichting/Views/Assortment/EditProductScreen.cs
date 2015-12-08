﻿using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Controllers;

namespace KantoorInrichting.Views.Assortment
{
    public partial class EditProductScreen : Form
    {
        private DatabaseController dbc;
        private readonly string currentImagePath;
        private readonly ProductModel product;
        private int amount;
        private string brand;
        private int category_id;
        private string description;
        private int height;
        private bool isNewImage;
        private int length;
        private string name;
        private Image newImage;
        private string newImageFileName;
        private string newImagePath;
        private string newImageSource = "";
        private string type;
        private int width;

        public EditProductScreen(ProductModel product)
        {
            InitializeComponent();
            this.product = product;
            dbc = DatabaseController.Instance;
            currentImagePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) +
                               @"\Resources\" + product.imageFileName;
            isNewImage = false;
            FillComboBox();
            FillTextBoxes();
        }

        //Fills the textboxes with the values from the corresponding product object
        public void FillTextBoxes()
        {
            nameTextBox.Text = product.name;
            typeTextBox.Text = product.type;
            brandTextBox.Text = product.brand;
            heightTextBox.Text = product.height.ToString();
            widthTextBox.Text = product.width.ToString();
            lengthTextBox.Text = product.length.ToString();
            amountTextBox.Text = product.amount.ToString();
            descriptionTextBox.Text = product.description;
            pictureBox.Image = product.image;
        }

        //Fills the category combobox with categories from the database and selects the category
        public void FillComboBox()
        {
            var categoryList = dbc.DataSet.category;

            foreach (var category in categoryList)
            {
                categoryComboBox.Items.Add(category.name);
                if (category.category_id == product.category_id)
                {
                    categoryComboBox.SelectedIndex = category.category_id;
                    //Minus 1 to match the category number from the database -->
                    //this might be needing changes later
                }
            }
        }

        //This method checks if the user inputs is correct. When everything is correct it will return True
        private bool ValitdateUserInput()
        {
            //There are 9 checks the validation has to pass, every check it passes there is -1, 
            //when this number reaches 0 it is equal to passing the checks.
            var validationPassed = 9;

            if (!Regex.IsMatch(nameTextBox.Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                errorNameLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorNameLabel.Text = "";
                name = nameTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(typeTextBox.Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                errorTypeLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorTypeLabel.Text = "";
                type = typeTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(brandTextBox.Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                errorBrandLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorBrandLabel.Text = "";
                brand = brandTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(heightTextBox.Text, @"^[0-9]+$"))
            {
                errorHeightLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorHeightLabel.Text = "";
                height = int.Parse(heightTextBox.Text);
                validationPassed--;
            }
            if (!Regex.IsMatch(widthTextBox.Text, @"^[0-9]+$"))
            {
                errorWidthLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorWidthLabel.Text = "";
                width = int.Parse(widthTextBox.Text);
                validationPassed--;
            }
            if (!Regex.IsMatch(lengthTextBox.Text, @"^[0-9]+$"))
            {
                errorLengthLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorLengthLabel.Text = "";
                length = int.Parse(lengthTextBox.Text);
                validationPassed--;
            }
            if (!Regex.IsMatch(amountTextBox.Text, @"^[0-9]+$"))
            {
                errorAmountLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorAmountLabel.Text = "";
                amount = int.Parse(amountTextBox.Text);
                validationPassed--;
            }
            if (categoryComboBox.SelectedIndex < 0)
            {
                errorCategoryLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorCategoryLabel.Text = "";
                category_id = categoryComboBox.SelectedIndex + 1;
                //Plus 1 to match the category number from the database, this might be needing change later, if changed -> also change in EditProductScreen FillComboBox()
                validationPassed--;
            }
            if (!Regex.IsMatch(descriptionTextBox.Text, @"^[a-zA-Z0-9\s\p{P}\d]+$"))
            {
                errorDescriptionLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorDescriptionLabel.Text = "";
                description = descriptionTextBox.Text;
                validationPassed--;
            }
            if (validationPassed == 0)
            {
                return true;
            }
            return false;
        }

        //Update the existing ProductModel
        private void UpdateProductModel()
        {
            product.name = name;
            product.brand = brand;
            product.type = type;
            product.category_id = category_id;
            product.height = height;
            product.width = width;
            product.length = length;
            product.description = description;
            product.amount = amount;
            if (isNewImage)
            {
                product.imageFileName = newImageFileName;
                product.image = newImage;
            }
        }

        //Update the prodcut in the database
        private void UpdateProductInDatabase()
        {
            //Fill the TableAdapter with data from the dataset
            try
            {
                //Search the tabel Product for a certain ProductID
                var productRow = dbc.DataSet.product.FindByproduct_id(product.product_id);
                //Assign a new value to the Column Quantity
                productRow.name = product.name;
                productRow.brand = product.brand;
                productRow.type = product.type;
                productRow.category_id = product.category_id;
                productRow.height = product.height;
                productRow.width = product.width;
                productRow.length = product.length;
                productRow.amount = product.amount;
                productRow.image = product.imageFileName;
                productRow.description = product.description;

                //Update the database with the new Data
                dbc.ProductTableAdapter.Update(dbc.DataSet.product);
                if (isNewImage)
                {
                    RemoveImage(currentImagePath);
                }
                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                if (isNewImage)
                {
                    RemoveImage(newImagePath);
                }
                MessageBox.Show("Update failed" + ex);
            }
        }

        //Select an image from a folder and show the image in the form
        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            //Open new filedialog to select an image
            var ofd = new OpenFileDialog();
            //Only files with these extensions will be visible in the filedialog
            ofd.Filter =
                "All Image Formats| *.jpg; *.png; *.bmp; *.gif; *.ico; *.txt | JPG Image | *.jpg | BMP image | *.bmp " +
                "| PNG image | *.png | GIF Image | *.gif | Icon | *.ico";
            //Set the initialdirectory when opening the file dialog
            ofd.InitialDirectory = @"C:\";
            ofd.Title = "Selecteer een afbeelding";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Get the filename of the selected file
                newImageFileName = ofd.SafeFileName;
                //Get the path and the file selected file
                newImageSource = ofd.FileName;
                newImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(ofd.FileName)));
                //Resize the picture so it will be shown correctly in the picturebox
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //Load the picture
                pictureBox.Image = newImage;
                isNewImage = true;
            }
        }

        //Copy the selected image to the resources folder
        private bool CopySelectedImage()
        {
            if (isNewImage)
            {
                newImagePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) +
                               @"\Resources\" + newImageFileName;
                try
                {
                    File.Copy(newImageSource, newImagePath);
                    return true;
                }
                catch (IOException ex)
                {
                    string v = ex.Data.ToString();
                    MessageBox.Show("Er bestaat al een bestand met deze naam");
                    return false;
                }
            }
            return true;
        }

        //Remove image from folder
        private void RemoveImage(string imagePath)
        {
            GC.Collect();
            File.Delete(imagePath);
        }

        //Add new product button
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ValitdateUserInput())
            {
                if (CopySelectedImage())
                {
                    UpdateProductModel();
                    UpdateProductInDatabase();
                    Close();
                }
            }
        }

        //Closes this form
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}