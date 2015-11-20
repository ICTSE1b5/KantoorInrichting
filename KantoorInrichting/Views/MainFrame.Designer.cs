﻿namespace KantoorInrichting
{
    partial class MainFrame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inrichterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigatieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terugNaarHoofdschermToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigatieToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.afsluitenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.terugNaarHoofdschermToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryScreen1 = new KantoorInrichting.Views.Inventory.InventoryScreen(this);
            this.mainScreen1 = new KantoorInrichting.Views.MainScreen(this);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inrichterToolStripMenuItem,
            this.navigatieToolStripMenuItem,
            this.bestandToolStripMenuItem,
            this.navigatieToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 28);
            this.menuStrip1.TabIndex = 2;
            // 
            // inrichterToolStripMenuItem
            // 
            this.inrichterToolStripMenuItem.Name = "inrichterToolStripMenuItem";
            this.inrichterToolStripMenuItem.Size = new System.Drawing.Size(12, 24);
            // 
            // navigatieToolStripMenuItem
            // 
            this.navigatieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afsluitenToolStripMenuItem,
            this.terugNaarHoofdschermToolStripMenuItem});
            this.navigatieToolStripMenuItem.Name = "navigatieToolStripMenuItem";
            this.navigatieToolStripMenuItem.Size = new System.Drawing.Size(12, 24);
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
            // 
            // terugNaarHoofdschermToolStripMenuItem
            // 
            this.terugNaarHoofdschermToolStripMenuItem.Name = "terugNaarHoofdschermToolStripMenuItem";
            this.terugNaarHoofdschermToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.bestandToolStripMenuItem.Text = "Bestand";
            // 
            // navigatieToolStripMenuItem1
            // 
            this.navigatieToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afsluitenToolStripMenuItem1,
            this.terugNaarHoofdschermToolStripMenuItem1});
            this.navigatieToolStripMenuItem1.Name = "navigatieToolStripMenuItem1";
            this.navigatieToolStripMenuItem1.Size = new System.Drawing.Size(85, 24);
            this.navigatieToolStripMenuItem1.Text = "Navigatie";
            // 
            // afsluitenToolStripMenuItem1
            // 
            this.afsluitenToolStripMenuItem1.Name = "afsluitenToolStripMenuItem1";
            this.afsluitenToolStripMenuItem1.Size = new System.Drawing.Size(245, 26);
            this.afsluitenToolStripMenuItem1.Text = "Afsluiten";
            // 
            // terugNaarHoofdschermToolStripMenuItem1
            // 
            this.terugNaarHoofdschermToolStripMenuItem1.Name = "terugNaarHoofdschermToolStripMenuItem1";
            this.terugNaarHoofdschermToolStripMenuItem1.Size = new System.Drawing.Size(245, 26);
            this.terugNaarHoofdschermToolStripMenuItem1.Text = "Terug naar hoofdscherm";
            // 
            // inventoryScreen1
            // 
            this.inventoryScreen1.AutoSize = true;
            this.inventoryScreen1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inventoryScreen1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.inventoryScreen1.Enabled = false;
            this.inventoryScreen1.Location = new System.Drawing.Point(0, 28);
            this.inventoryScreen1.MinimumSize = new System.Drawing.Size(100, 100);
            this.inventoryScreen1.Name = "inventoryScreen1";
            this.inventoryScreen1.Size = new System.Drawing.Size(464, 164);
            this.inventoryScreen1.TabIndex = 1;
            this.inventoryScreen1.Visible = false;
            // 
            // mainScreen1
            // 
            this.mainScreen1.AutoSize = true;
            this.mainScreen1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainScreen1.Location = new System.Drawing.Point(0, 28);
            this.mainScreen1.Name = "mainScreen1";
            this.mainScreen1.Size = new System.Drawing.Size(742, 113);
            this.mainScreen1.TabIndex = 0;
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(742, 409);
            this.Controls.Add(this.inventoryScreen1);
            this.Controls.Add(this.mainScreen1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrame";
            this.Text = "MainFrame";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Views.MainScreen mainScreen1;
        public Views.Inventory.InventoryScreen inventoryScreen1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inrichterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigatieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afsluitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terugNaarHoofdschermToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigatieToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem afsluitenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem terugNaarHoofdschermToolStripMenuItem1;
    }
}