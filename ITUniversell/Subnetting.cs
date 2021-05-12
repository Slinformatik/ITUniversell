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

        //Methode zum erstellen von Grids
        public static Grid CreateSubnetter()
        {
            //Generiere Grid 6x6
            myGrid = GridHelper.CreateGrid(6, 6);
            //Füge einem Grid hinzu (Welches Grid?, Welches Element? Breite an Columns, Welche Reihe, Welche Column)
            GridHelper.AddToGrid(myGrid, new HeaderLabel("IP Subnetting"), 2, 0, 0);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("IP Adresse", 0), 1, 1, 0);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("Subnetzmaske", 0), 3, 2, 0);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("Netz ID", 0), 4, 3, 0);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("Anzahl Host", 0), 5, 4, 0);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("Präfix", 0), 1, 1, 3);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("Sprungweite", 0), 3, 2, 3);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("Broadcast", 0), 4, 3, 3);

            //Definiere TextBox mit (ReadOnly)
            htb_IPAdress = new HelperTextBox(false);
            //Definiere Button mit (Content)
            btn_submit = new HelperButton("Berechnen");
            //Verweise Button auf Event für Klick
            btn_submit.Click += btn_submit_Click;


            htb_Subnetzmaske = new HelperTextBox(true);
            htb_NetzID = new HelperTextBox(true);
            htb_Host = new HelperTextBox(true);
            htb_Präfix = new HelperTextBox(false);            
            htb_Sprungweite = new HelperTextBox(true);
            htb_Broadcast = new HelperTextBox(true);

            //Mehrere Zeilen in Textbox
            htb_Präfix.MaxLength = 2;

            
            GridHelper.AddToGrid(myGrid, htb_IPAdress, 1, 1, 1);
            GridHelper.AddToGrid(myGrid, htb_Subnetzmaske, 1, 2, 1);
            GridHelper.AddToGrid(myGrid, htb_NetzID, 1, 3, 1);
            GridHelper.AddToGrid(myGrid, htb_Host, 1, 4, 1);

            GridHelper.AddToGrid(myGrid, htb_Präfix, 1, 1, 4);
            GridHelper.AddToGrid(myGrid, htb_Sprungweite, 1, 2, 4);
            GridHelper.AddToGrid(myGrid, htb_Broadcast, 1, 3, 4);

            GridHelper.AddToGrid(myGrid, btn_submit, 2, 5, 4);
            //Gebe mein bisher erstelltes Grid aus
            return myGrid;
        }
        //Aufruf bei Klick auf Button btn_Submit
        private static void btn_submit_Click(object sender, EventArgs e)
        {
            //Setze alle Texte von Textboxen auf leeren String
            htb_NetzID.Text = "";
            htb_Sprungweite.Text = "";
            htb_Broadcast.Text = "";
            htb_Subnetzmaske.Text = "";
            //Variablen Erstellung
            int praefix = 0;
            int oktette = 0;
            int sprungweite = 0;

            //Nehme Text aus Textbox und trenne an jedem Punkt
            //192.168.0.0 => [0] 192, [1] 168, [2] 0, [3] 0
            
            string[] temp = htb_IPAdress.Text.Split('.');
            //Erstelle ein intArray welches alle Werte von temp als int beinhalten soll
            int[] ip = new int[temp.Length];
            //Sollte temp 4 Indexe haben (Spricht für eine IP            
            if(temp.Length == 4)
            {
                //Wiederhole 4 mal
                for(int i = 0; i< temp.Length; i++)
                {
                    //Versuche
                    try
                    {
                        //temp[i] in int umzuwandeln
                        int.Parse(temp[i]);
                        //Wenn es geklappt hat prüfe ob Wert zwischen 0 und 255 liegt
                        if (int.Parse(temp[i]) >= 0 && int.Parse(temp[i]) <= 255)
                            //Speicher das Ergebnis in intArray mit Position i
                            ip[i] = int.Parse(temp[i]);
                        //Wenn nicht. Hat User falsche Zahl eingegeben 
                        else //und er hält diese Messagebox
                            MessageBox.Show("Fehler im IPBlock. Bitte nur Zahlen zwischen 0 und 255 eingeben");                        
                    }
                    //Hat der Versuch oben nicht geklappt
                    //Fange Format Fehler ab
                    catch (FormatException)
                    {
                        //Gebe aus: User hat Fehler gemacht
                        MessageBox.Show("Fehler im IP-Block. Bitte nur Ziffern eingeben");
                    }
                    //Allgemeiner Fehler (ähnlich wie else)
                    catch (Exception)
                    {
                        //Gebe unbekannter Fehler aus
                        MessageBox.Show("Fehler im IP-Block. Unbekannter Fehler");
                    }
                }
                //Nach der Schleife (int Array ist befüllt)
                //Versuche (Siehe ip)
                try
                {
                    //Textbox möglich in int umzuwandeln?
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
            //User hat nicht 4 Oktette angebene bzw 3 Punkte
            else
            {
                MessageBox.Show("Bitte IP aus 4 Oktetten angeben");
            }
            // (wandelDasErgebnisInInt) Math.Pow(2^8-präfix %8) BSP /27 => 2^3 => 2^ 8 - (27%8=>3)
            //Math.Pow returnt einen Double daher (int) cast
            sprungweite = (int) Math.Pow(2, 8- praefix % 8);
           
            htb_Sprungweite.Text = sprungweite.ToString();
            //Rechnung für Anzahl Host pro Subnetz
            htb_Host.Text = ((int)Math.Pow(2, 32 - praefix) - 2).ToString();
            //Rufe SubnetCalculate auf 
            SubnetCalculate(praefix,oktette,ip,sprungweite);
            
        }
        //Methode zum Errechnen diverser Subnettingwerte
        static void SubnetCalculate(int praefix, int oktette,int[] ip, int sprungweite)
        {
            //Speicher in oktette Ergebnis von GeneratePraefix(praefix)
            oktette = DetectOktette(praefix);
            
            //Wiederhole 4 mal (Indexe in int Array)
            for (int i = 0; i < ip.Length; i++)
            {
                //Wenn oktette kleiner als i
                //192.168.180.0 => wir subnetten im 3 Oktette BEISPIEL Präfix =>18
                if (oktette < i)
                {
                    //Oktette ist nach dem "gesubnetteten" 
                    //NetzId an 4.Stelle = 0., Broadcast an 4. Stelle = 255., Subnetzmaske an 4.Stelle = 0
                    htb_NetzID.Text += "0.";
                    htb_Broadcast.Text += "255.";
                    htb_Subnetzmaske.Text += "0.";
                }
                else if (oktette > i)
                {
                    //Oktette ist vor dem "gesubnetteten"
                    //NetzId an 1&2.Stelle = InhaltTb., Broadcast an 1&2.Stelle = InhaltTb., Subnetzmaske an 1&2 = 255
                    htb_NetzID.Text += ip[i].ToString() + ".";
                    htb_Broadcast.Text += ip[i] + ".";
                    htb_Subnetzmaske.Text += "255.";
                }
                else
                {
                    //Wir sind "im gesubnetteten"
                    //192.168.3.0 => wir subnetten im 3 Oktette BEISPIEL
                    //Ändere alle an 3 Stelle
                        //NetzId += 180-180%64 => 128
                    htb_NetzID.Text += (ip[i] - ip[i] % sprungweite).ToString() + ".";
                        //Broadcast += 180-180%64+64-1 => 0
                    htb_Broadcast.Text += (ip[i] - ip[i] % sprungweite + sprungweite - 1).ToString() + ".";
                        //256 - 64 => 192
                    htb_Subnetzmaske.Text += (256 - sprungweite).ToString() + ".";
                }
                //192.168.191.255.
                if (i == 3)
                {
                    RemoveLastChar(htb_NetzID);
                    RemoveLastChar(htb_Broadcast);
                    RemoveLastChar(htb_Subnetzmaske);
                }
            }
        }
        //Ermittle Oktette
        static int DetectOktette(int praefix)
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
