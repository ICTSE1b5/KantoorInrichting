﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Views.CreateSpace;
using KantoorInrichting.Models.Space;

namespace KantoorInrichting.Controllers.CreateSpace
{
    class CreateSpaceController
    {
        private static CreateSpaceController instance;
        public static CreateSpaceController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CreateSpaceController();
                }
                return instance;
            }
        }

        public static Space space;
        DatabaseController dbc = DatabaseController.Instance;

        private CreateSpaceController()
        {
            //
        }

        //Activate when a new space is being made
        public void NewSpace()
        {
            SpaceInfoDialog spaceInfoDialog = new SpaceInfoDialog();
            spaceInfoDialog.ShowDialog();
            switch (spaceInfoDialog.DialogResult)
            {
                case DialogResult.Yes:
                    CreateNewSpace(spaceInfoDialog.SpaceInfo);
                    break;

                case DialogResult.OK:
                    CreateNewSpace(spaceInfoDialog.SpaceInfo);
                    space = null;
                    break;
                default:
                    space = null;
                    break;
            }
            //Dispose after use
            spaceInfoDialog.Dispose();
        }

        
        private void CreateNewSpace(Dictionary<string, string> dict)
        {
            //Multiplies Length and Width by 100 to convert Meters to Centimeters
            space = new Space(dict["Total"], dict["Floor"], dict["Building"], dict["Room"],
                (int)(Double.Parse(dict["Length"])*100), (int)(Double.Parse(dict["Width"])*100), false);
            
            SaveNewSpace(space);

            //TODO
            //Make a button to convert to final (set final to true)
            //And update it in the database

            //TODO
            //If room already exists, give an message
        }

        private void SaveNewSpace(Space space)
        {
            //TODO
            //Add Space to database
            DataRow anyRow = dbc.DataSet.space.NewRow();
            
            anyRow["space_number"] = space.Room;
            anyRow["floor"] = space.Floor;
            anyRow["building"] = space.Building;
            anyRow["roomnumber"] = space.Roomnumber;
            anyRow["final"] = space.Final;
            anyRow["length"] = space.Length;
            anyRow["width"] = space.Width;

            dbc.DataSet.space.Rows.Add(anyRow);
            dbc.SpaceTableAdapter.Update(dbc.DataSet.space);
        }

    }
}
