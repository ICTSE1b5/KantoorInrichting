﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Maps;

namespace KantoorInrichting.Views.Maps
{
    public partial class MapsScreen : UserControl
    {
        public MainFrame mainFrame;
        public MapsScreen(MainFrame mainFrame)
        {
            this.mainFrame = mainFrame;
            InitializeComponent();
            Space.result = Space.list;
            this.MapsGridView1.DataSource = Space.result;

        }

        private void MapsGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
              
                var hoi = MapsGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                MessageBox.Show(hoi);
                ShowSpaceScreen adsfasdf = new ShowSpaceScreen();
                adsfasdf.Show();
            } 
        }
    }
}
