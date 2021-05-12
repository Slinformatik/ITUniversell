using ITUniversell.Helper;
using System.Windows.Controls;
using System.Windows;
using System;

namespace ITUniversell
{
    public class Subnetting
    {
        static Grid myGrid;
        static HelperTextBox htb_Subnetzmaske;
        static HelperTextBox htb_NetzID;
        static HelperTextBox htb_Host;
        static HelperTextBox htb_Präfix;
        static HelperTextBox htb_Sprungweite;
        static HelperTextBox htb_Broadcast;
        static HelperTextBox htb_IPAdress;
        static HelperButton btn_submit;
        public static Grid CreateSubnetter()
        {
            
            myGrid = GridHelper.CreateGrid(6, 6);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("IP Subnetting"), 2, 0, 0);

            GridHelper.AddToGrid(myGrid, new HeaderLabel("IP Adresse", 0), 1, 1, 0);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("Subnetzmaske", 0), 3, 2, 0);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("Netz ID", 0), 4, 3, 0);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("Anzahl Host", 0), 5, 4, 0);

            GridHelper.AddToGrid(myGrid, new HeaderLabel("Präfix", 0), 1, 1, 3);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("Sprungweite", 0), 3, 2, 3);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("Broadcast", 0), 4, 3, 3);

            htb_IPAdress = new HelperTextBox(false);
            btn_submit = new HelperButton("Berechnen");
            btn_submit.Click += btn_submit_Click;
            //htb_IPAdress.Text = "192.168.0.0";

            htb_Subnetzmaske = new HelperTextBox(true);
            htb_NetzID = new HelperTextBox(true);
            htb_Host = new HelperTextBox(true);
            htb_Präfix = new HelperTextBox(false);
            htb_Präfix.MaxLength = 2;
            htb_Sprungweite = new HelperTextBox(true);
            htb_Broadcast = new HelperTextBox(true);

            GridHelper.AddToGrid(myGrid, htb_IPAdress, 1, 1, 1);
            GridHelper.AddToGrid(myGrid, htb_Subnetzmaske, 1, 2, 1);
            GridHelper.AddToGrid(myGrid, htb_NetzID, 1, 3, 1);
            GridHelper.AddToGrid(myGrid, htb_Host, 1, 4, 1);

            GridHelper.AddToGrid(myGrid, htb_Präfix, 1, 1, 4);
            GridHelper.AddToGrid(myGrid, htb_Sprungweite, 1, 2, 4);
            GridHelper.AddToGrid(myGrid, htb_Broadcast, 1, 3, 4);

            GridHelper.AddToGrid(myGrid, btn_submit, 2, 5, 4);
            
            return myGrid;
        }
        private static void btn_submit_Click(object sender, EventArgs e)
        {
            htb_NetzID.Text = "";
            htb_Sprungweite.Text = "";
            htb_Broadcast.Text = "";
            htb_Subnetzmaske.Text = "";
            int praefix = 0;
            int oktette = 0;
            int sprungweite = 0;
            string[] temp = htb_IPAdress.Text.Split('.');
            int[] ip = new int[temp.Length];
            if(temp.Length == 4)
            {
                for(int i = 0; i< temp.Length; i++)
                {
                    try
                    {
                        int.Parse(temp[i]);
                        if (int.Parse(temp[i]) >= 0 && int.Parse(temp[i]) <= 255)
                            ip[i] = int.Parse(temp[i]);
                        else MessageBox.Show("Fehler im IPBlock. Bitte nur Zahlen zwischen 0 und 255 eingeben");                        
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Fehler im IP-Block. Bitte nur Ziffern eingeben");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Fehler im IP-Block. Unbekannter Fehler");
                    }
                }
                try
                {
                    int.Parse(htb_Präfix.Text);
                    if (int.Parse(htb_Präfix.Text) >= 0 && int.Parse(htb_Präfix.Text) <= 30)
                        praefix = int.Parse(htb_Präfix.Text);
                    else MessageBox.Show("Fehler im Präfix. zahl ist zu groß");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Fehler im Präfix. Bitte nur Zahlen zwischen 0 und 30 angeben und kein /");
                }
                catch (Exception) 
                { 
                    MessageBox.Show("Fehler im Präfix. Unbekannter Fehler");
                }
            }
            else
            {
                MessageBox.Show("Bitte IP aus 4 Oktetten angeben");
            }

            sprungweite = (int) Math.Pow(2, 8- praefix % 8);

            htb_Sprungweite.Text = sprungweite.ToString();
            htb_Host.Text = ((int)Math.Pow(2, 32 - praefix) - 2).ToString();
            SubnetCalculate(praefix,oktette,ip,sprungweite);
            
        }
        static void SubnetCalculate(int praefix, int oktette,int[] ip, int sprungweite)
        {
            oktette = GeneratePraefix(praefix);
            
            for (int i = 0; i < ip.Length; i++)
            {
                if (oktette < i)
                {
                    htb_NetzID.Text += "0.";
                    htb_Broadcast.Text += "255.";
                    htb_Subnetzmaske.Text += "0.";
                }
                else if (oktette > i)
                {
                    htb_NetzID.Text += ip[i].ToString() + ".";
                    htb_Broadcast.Text += ip[i] + ".";
                    htb_Subnetzmaske.Text += "255.";
                }
                else
                {
                    htb_NetzID.Text += (ip[i] - ip[i] % sprungweite).ToString() + ".";
                    htb_Broadcast.Text += (ip[i] - ip[i] % sprungweite + sprungweite - 1).ToString() + ".";
                    htb_Subnetzmaske.Text += (256 - sprungweite).ToString() + ".";
                }
                if (i == 3)
                {
                    RemoveLastChar(htb_NetzID);
                    RemoveLastChar(htb_Broadcast);
                    RemoveLastChar(htb_Subnetzmaske);
                }
            }
        }
        static int GeneratePraefix(int praefix)
        {
            int oktette = 0;
            if (praefix < 8) oktette = 0;
            else if (praefix < 16) oktette = 1;
            else if (praefix < 24) oktette = 2;
            else oktette = 3;
            return oktette;
        }
        static void RemoveLastChar(TextBox tb)
        {
            tb.Text = tb.Text.Remove(tb.Text.Length - 1, 1);
        }
    }
}
