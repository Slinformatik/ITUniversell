using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ITUniversell.Helper
{
    class HelperBackButton : Button
    {
        public HelperBackButton()
        {
            Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/ITUniversell;component/Resources/arrow-point-to-right.png")));
            Height = 20;
            Width = 20;
            Click += HPB_Click;
        }
        public  void HPB_Click(object sender, EventArgs e)
        {
            MainWindow.main.Content = MainWindow.mainGrid;
        }
    }
}
