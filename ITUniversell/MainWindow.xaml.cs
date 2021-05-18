using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITUniversell.Helper;

namespace ITUniversell
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Statisch  (Veränderungen in anderen Klassen werden auch hier übernommen)
        public static Grid mainGrid;
        public static MainWindow main;

        int m_top = 20;
        public MainWindow()
        {
            InitializeComponent();
            //statisches Objekt main referenziert auf das Hauptfenster
            main = this;

            mainGrid = GridHelper.CreateGrid(3, 7);
            main.Content = mainGrid;

            HelperButton btn_Subnetting = new HelperButton("Subnetting");
            btn_Subnetting.Click += btn_Subnetting_Click;
            GridHelper.AddToGrid(mainGrid, btn_Subnetting, 1, 0, 1);

            HelperButton btn_IT_Mathe = new HelperButton("IT Mathe", m_top);
            btn_IT_Mathe.Click += btn_IT_Mathe_Click;
            GridHelper.AddToGrid(mainGrid, btn_IT_Mathe, 1, 1, 1);
        }

        private void btn_Subnetting_Click(object sender, EventArgs e)
        {
            main.Content = Subnetting.CreateSubnetter();

        }
        private void btn_IT_Mathe_Click(object sender, EventArgs e)
        {
            main.Content = IT_Mathe.CreateIT_Mathe();
        }
    }
}
