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
        StackPanel sp_Main;
        public MainWindow()
        {
            InitializeComponent();
            sp_Main = new StackPanel();
            this.Content = sp_Main;
            Button btn_Subnetting = new Button()
            {
                Height = 30,
                Width = 150,
                Content = "Subnetting"
            };
            btn_Subnetting.Click += btn_Subnetting_Click;
            sp_Main.Children.Add(btn_Subnetting);
            
          
        }

        private void btn_Subnetting_Click(object sender, EventArgs e)
        {
            Content = Subnetting.CreateSubnetter();
        }
    }
}
