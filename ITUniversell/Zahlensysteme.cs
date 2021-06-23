using ITUniversell.Helper;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace ITUniversell
{
    class Zahlensysteme
    {
        public static HelperTextBox htb_dezimal;
        public static HelperTextBox htb_binaer;
        public static HelperTextBox htb_hexa;

        public static Grid CreateZahlensysteme()
        {
            Grid mygrid = GridHelper.CreateGrid(5, 3);
            GridHelper.AddToGrid(mygrid, new HelperBackButton());
            GridHelper.AddToGrid(mygrid, new HeaderLabel("Zahlensysteme"), 2, 0, 0);
            GridHelper.AddToGrid(mygrid, new HeaderLabel("Dezimal", 0) { HorizontalAlignment = System.Windows.HorizontalAlignment.Center }, 1, 1, 1);
            htb_dezimal = new HelperTextBox(false);
            htb_dezimal.PreviewTextInput += Htb_PreviewTextInput;
            htb_dezimal.TextChanged += Htb_TextChanged;
            htb_dezimal.Width = 100;
            htb_dezimal.Tag = "d";
            GridHelper.AddToGrid(mygrid, htb_dezimal, 1, 1, 1);
            GridHelper.AddToGrid(mygrid, new HeaderLabel("Binär", 0) { HorizontalAlignment = System.Windows.HorizontalAlignment.Center }, 1, 1, 2);
            htb_binaer = new HelperTextBox(false);
            htb_binaer.Width = 100;
            htb_binaer.PreviewTextInput += Htb_PreviewTextInput;
            htb_binaer.TextChanged += Htb_TextChanged;
            htb_binaer.Tag = "b";
            GridHelper.AddToGrid(mygrid, htb_binaer, 1, 1, 2);
            GridHelper.AddToGrid(mygrid, new HeaderLabel("Hexadezimal", 0) { HorizontalAlignment = System.Windows.HorizontalAlignment.Center }, 1, 1, 3);
            htb_hexa = new HelperTextBox(false);
            htb_hexa.Width = 100;
            htb_hexa.PreviewTextInput += Htb_PreviewTextInput;
            htb_hexa.TextChanged += Htb_TextChanged;
            htb_hexa.Tag = "h";
            
            GridHelper.AddToGrid(mygrid, htb_hexa, 1, 1, 3);            
            return mygrid;
        }

        private static void Htb_TextChanged(object sender, TextChangedEventArgs e) => CalculateNumberSystem((sender as TextBox).Text, (sender as TextBox).Tag.ToString());
        private static void Htb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            
            if ((sender as TextBox).Tag.ToString() == "d")
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }            
        
            if ((sender as TextBox).Tag.ToString() == "b")
            {
                Regex regex = new Regex("[^0-1]+");
                e.Handled = regex.IsMatch(e.Text);
            }

            if ((sender as TextBox).Tag.ToString() == "h")
            {
                Regex regex = new Regex("[^0-9a-f]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            TBReadOnly();
            
        }

    
    private static void TBReadOnly()
    {
            
        //    if (htb_binaer.Text == "")
        //{
        //    htb_binaer.IsReadOnly = true;
        //    htb_binaer.IsEnabled = false;
        //}
        //if (htb_dezimal.Text == "")
        //{
        //    htb_dezimal.IsReadOnly = true;
        //    htb_dezimal.IsEnabled = false;
        //}
        //if (htb_hexa.Text == "")
        //{
        //    htb_hexa.IsReadOnly = true;
        //    htb_hexa.IsEnabled = false;
        //}

        //if (htb_binaer.Text == "" && htb_dezimal.Text == "" && htb_hexa.Text == "")
        //{
        //    htb_binaer.IsReadOnly = false;
        //    htb_dezimal.IsReadOnly = false;
        //    htb_hexa.IsReadOnly = false;
        //    htb_binaer.IsEnabled = true;
        //    htb_dezimal.IsEnabled = true;
        //    htb_hexa.IsEnabled = true;
        //}
    }

        private static void CalculateNumberSystem(string number, string tag)
        {
            
            if(tag == "d")
            {

            }
            else if(tag == "b")
            {
                htb_dezimal.Text = BinaryToDecimal(number);
            }
            else if(tag == "h")
            {

            }


        }

        private static string BinaryToDecimal(string number)
        {
            number = Methods.Reverse(number);
            int temp = 0;
            for(int i = 0; i< number.Length; i++)
            {
                if (number[i] == '1')
                    temp += (int)Math.Pow(2, i);
            }
            return temp.ToString();
        }
    }    
}