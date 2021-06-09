using ITUniversell.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ITUniversell
{
    class PasswordGenerate
    {
        public static Grid myGrid;
        static HelperRichTextBox hrtb_password;
        static HelperButton hbtn_Submit;
        static HelperCheckbox hcb_IsNumeric;
        static HelperCheckbox hcb_IsSpecialChar;
        static HelperSlider hsl_Length;
        static HeaderLabel label = new HeaderLabel("12", 0);


        public static Grid CreatePassword()
        {
            myGrid = GridHelper.CreateGrid(5, 6);
            hbtn_Submit = new HelperButton("Generiere");
            hbtn_Submit.Click += hbtn_Submit_Click;
            hrtb_password = new HelperRichTextBox();
            hcb_IsNumeric = new HelperCheckbox("Zahlen",true);
            hcb_IsSpecialChar = new HelperCheckbox("Sonderzeichen", true);
            hsl_Length = new HelperSlider(8, 40, 12);
            hsl_Length.ValueChanged += hsl_Length_ValueChanged;

            GridHelper.AddToGrid(myGrid, new HeaderLabel("Passwortgenerator"), 3, 0, 0);
            GridHelper.AddToGrid(myGrid, hrtb_password,2,1,0);
            GridHelper.AddToGrid(myGrid, hbtn_Submit, 1, 1, 2);
            GridHelper.AddToGrid(myGrid, hcb_IsNumeric, 1, 3, 0);
            GridHelper.AddToGrid(myGrid, hcb_IsSpecialChar, 1, 3, 1);
            GridHelper.AddToGrid(myGrid, hsl_Length, 2, 3, 2);
            GridHelper.AddToGrid(myGrid, label, 2, 3, 3);
            GridHelper.AddToGrid(myGrid, new HelperBackButton());
            return myGrid;
        }

        public static void hbtn_Submit_Click(object sender, EventArgs e)
        {
            List<string> password = new List<string>();
            List<string> shuffeldPassword = new List<string>();
            int lengthOfPasswort = Convert.ToInt32(hsl_Length.Value);
            int lastFor = lengthOfPasswort; //Damit die Länge des Passwortes bekannt bleibt
            int twentyPercent = lengthOfPasswort / 5;
            hrtb_password.Document.Blocks.Clear();

            if (hcb_IsNumeric.IsChecked == true)
            {
                for (int i = 0; i < twentyPercent; i++)
                    password.Add(Convert.ToChar(MainWindow.rnd.Next(48, 58)).ToString());
                lengthOfPasswort -= twentyPercent;
            }
                

            if(hcb_IsSpecialChar.IsChecked == true)
            {
                    for (int i = 0; i < twentyPercent; i++)
                        password.Add(Convert.ToChar(MainWindow.rnd.Next(33, 48)).ToString());
                    lengthOfPasswort -= twentyPercent;

                
            }
            for (int i = 0; i < lengthOfPasswort; i++)
                if (MainWindow.rnd.Next(0, 2) == 0)
                    password.Add(Convert.ToChar(MainWindow.rnd.Next(65, 91)).ToString());
                else
                    password.Add(Convert.ToChar(MainWindow.rnd.Next(97, 123)).ToString());
            for (int i = 0; i< lastFor; i++)
            {
                int temp = MainWindow.rnd.Next(0, password.Count);
                shuffeldPassword.Add(password[temp]);
                password.RemoveAt(temp);
            }
            foreach (string s in shuffeldPassword)
            {
                int ascii = Convert.ToChar(s);
                if(ascii >=48 && ascii <= 57)
                    AppendText(hrtb_password, s, "Red");
                else
                    AppendText(hrtb_password, s, "Black");
            }
            //Clipboard.SetText(htb_password.Text);

        }
        public static void AppendText(RichTextBox box, string text, string color)
        {
            BrushConverter bc = new BrushConverter();
            TextRange tr = new TextRange(box.Document.ContentEnd, box.Document.ContentEnd);
            tr.Text = text;
            try
            {
                tr.ApplyPropertyValue(TextElement.ForegroundProperty,
                    bc.ConvertFromString(color));
            }
            catch (FormatException) { }
        }
        public static void hsl_Length_ValueChanged(object sender, EventArgs e)
        {
            label.Content = Convert.ToInt32(hsl_Length.Value).ToString();
        }
    }
}
