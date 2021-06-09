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
            GridHelper.AddToGrid(myGrid, new HelperBackButton());
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
            decimal sizeDownload = decimal.Parse(htb_datasize.Text);
            decimal speedDownload = decimal.Parse(htb_dataspeed.Text);
            double indexSize = hcb_datasize.SelectedIndex;
            double indexSpeed = hcb_dataspeed.SelectedIndex;
            decimal speedInBit;
            decimal sizeInBit;
            if (indexSpeed == 0)
                speedInBit = speedDownload;
            else
                speedInBit = speedDownload *(decimal)Math.Pow(1000, indexSpeed);
            sizeInBit = sizeDownload * (decimal) Math.Pow(1024, indexSize-1) * 8;
            decimal seconds = Math.Ceiling(sizeInBit / speedInBit);
            htb_h.Text = seconds/3600<1?"0": Math.Ceiling(seconds / 3600).ToString();
            seconds = seconds % 3600;
            htb_min.Text = seconds / 60 <1?"0":Math.Ceiling(seconds / 60).ToString();
            htb_s.Text = Math.Ceiling(seconds % 60).ToString();


            //decimal seconds = Convert.Todecimal32(Math.Ceiling(decimal.Parse(htb_datasize.Text)*Math.Pow(1024,hcb_datasize.SelectedIndex-1)*8/
            //    (decimal.Parse(htb_dataspeed.Text) * Math.Pow(1000, hcb_dataspeed.SelectedIndex))));
            
            
        }
    }
}
