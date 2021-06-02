using ITUniversell.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ITUniversell
{
    class IT_Mathe
    {
        static Grid myGrid;
        static HelperTextBox htb_datasize;
        static HelperTextBox htb_dataspeed;
        static HelperButton btn_submit;
        static HelperComboBox hcb_datasize;
        static HelperComboBox hcb_dataspeed;
        static HelperTextBox htb_h;
        static HelperTextBox htb_min;
        static HelperTextBox htb_s;
        public static Grid CreateIT_Mathe()
        {
            myGrid = GridHelper.CreateGrid(5, 5);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("IT Mathe"), 2, 0, 0);

            //GridHelper.AddToGrid(myGrid, new HelperBack(), 1, 0, 5);

            btn_submit = new HelperButton("Berechne");
            GridHelper.AddToGrid(myGrid, btn_submit, 2, 5, 5);
            btn_submit.Click += btn_submit_Click;

            GridHelper.AddToGrid(myGrid, new HeaderLabel("Dateigröße:", 0), 1, 1, 0);
            htb_datasize = new HelperTextBox(false);
            GridHelper.AddToGrid(myGrid, htb_datasize, 1, 1, 1);

            GridHelper.AddToGrid(myGrid, new HeaderLabel("Geschwindigkeit:", 0), 1, 2, 0);
            htb_dataspeed = new HelperTextBox(false);
            GridHelper.AddToGrid(myGrid, htb_dataspeed, 1, 2, 1);

            GridHelper.AddToGrid(myGrid, new HeaderLabel("Stunden:", 1, "a"), 1, 1, 3);
            htb_h = new HelperTextBox(true);
            GridHelper.AddToGrid(myGrid, htb_h, 1, 1, 3);

            GridHelper.AddToGrid(myGrid, new HeaderLabel("Minuten:", 1, "a"), 1, 2, 3);
            htb_min = new HelperTextBox(true);
            GridHelper.AddToGrid(myGrid, htb_min, 1, 2, 3);

            GridHelper.AddToGrid(myGrid, new HeaderLabel("Sekunden:", 1, "a"), 1, 3, 3);
            htb_s = new HelperTextBox(true);
            GridHelper.AddToGrid(myGrid, htb_s, 1, 3, 3);

            hcb_datasize = new HelperComboBox(new string[] { "Bit", "Byte (B)", "KibiByte (kiB)", "MebiByte (MiB)", "GibiByte (GiB)", "TibiByte (TiB)" }, 4);
            GridHelper.AddToGrid(myGrid, hcb_datasize, 1, 1, 2);

            hcb_dataspeed = new HelperComboBox(new string[] { "Bit/s", "KiloBit/s (KBit/s)", "MegaBit (MBit/s)", "GigaBit/s (GB/s)", "TeraBit (TB/s)" }, 3);
            GridHelper.AddToGrid(myGrid, hcb_dataspeed, 1, 2, 2);

            return myGrid;
        }
        public static void btn_submit_Click(object sender, EventArgs e)
        {

        }
    }
}
