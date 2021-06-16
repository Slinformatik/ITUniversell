using ITUniversell.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ITUniversell
{
    class Zahlensysteme
    {
        public static HelperTextBox htb_dezimal;
        public static HelperTextBox htb_binaer;
        public static HelperTextBox htb_hexa;
        public static HelperButton hbtn_submit;
        public static Grid CreateZahlensysteme()
        {
            Grid mygrid = GridHelper.CreateGrid(5, 3);
            GridHelper.AddToGrid(mygrid, new HeaderLabel("Zahlensysteme"),2,0,0);
            GridHelper.AddToGrid(mygrid, new HeaderLabel("Dezimal", 0) { HorizontalAlignment = System.Windows.HorizontalAlignment.Center }, 1, 1, 1);
            htb_dezimal = new HelperTextBox(false);
            htb_dezimal.Width = 100;
            GridHelper.AddToGrid(mygrid, htb_dezimal, 1, 1, 1);
            GridHelper.AddToGrid(mygrid, new HeaderLabel("Binär", 0) { HorizontalAlignment = System.Windows.HorizontalAlignment.Center }, 1, 1, 2);
            htb_binaer = new HelperTextBox(false);
            htb_binaer.Width = 100;
            GridHelper.AddToGrid(mygrid, htb_binaer, 1, 1, 2);
            GridHelper.AddToGrid(mygrid, new HeaderLabel("Hexadezimal", 0) { HorizontalAlignment = System.Windows.HorizontalAlignment.Center }, 1, 1, 3);
            htb_hexa = new HelperTextBox(false);
            htb_hexa.Width = 100;

            GridHelper.AddToGrid(mygrid, htb_hexa, 1, 1, 3);
            hbtn_submit = new HelperButton("Umrechnen");
            
            GridHelper.AddToGrid(mygrid,hbtn_submit,3,2,1);


         


            return mygrid;
        }     
    }
}
