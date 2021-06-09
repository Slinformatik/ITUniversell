﻿using ITUniversell.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ITUniversell
{
    class PasswordGenerate
    {
        public static Grid myGrid;
        static HelperTextBox htb_password;
        static HelperButton hbtn_Submit;
        static HelperCheckbox hcb_IsNumeric;
        static HelperCheckbox hcb_IsSpecialChar;
        static HelperSlider hsl_Length;
        static HeaderLabel label = new HeaderLabel("12", 0);


        public static Grid CreatePassword()
        {
            myGrid = GridHelper.CreateGrid(5, 6);
            myGrid.ShowGridLines = true;
            hbtn_Submit = new HelperButton("Generiere");
            htb_password = new HelperTextBox(true);
            hcb_IsNumeric = new HelperCheckbox("Zahlen",true);
            hcb_IsSpecialChar = new HelperCheckbox("Sonderzeichen", true);
            hsl_Length = new HelperSlider(8, 40, 12);
            hsl_Length.ValueChanged += hsl_Length_ValueChanged;

            GridHelper.AddToGrid(myGrid, new HeaderLabel("Passwortgenerator"), 3, 0, 0);
            GridHelper.AddToGrid(myGrid, htb_password,2,1,0);
            GridHelper.AddToGrid(myGrid, hbtn_Submit, 1, 1, 2);
            GridHelper.AddToGrid(myGrid, hcb_IsNumeric, 1, 3, 0);
            GridHelper.AddToGrid(myGrid, hcb_IsSpecialChar, 1, 3, 1);
            GridHelper.AddToGrid(myGrid, hsl_Length, 2, 3, 2);
            GridHelper.AddToGrid(myGrid, label, 2, 3, 3);
            GridHelper.AddToGrid(myGrid, new HelperBackButton());
            return myGrid;
        }

        public static void hsl_Length_ValueChanged(object sender, EventArgs e)
        {
            label.Content = Convert.ToInt32(hsl_Length.Value).ToString();
        }
    }
}
