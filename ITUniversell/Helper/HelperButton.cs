using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ITUniversell.Helper
{
    class HelperButton : Button
    {
        public HelperButton(string content)
        {
            Content = content;
            Width = 130;
            Height = 35;
            Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
        }
        public HelperButton(string content, int m_top)
        {
            Content = content;
            Width = 130;
            Height = 35;
            Margin = new System.Windows.Thickness(0, m_top, 0, 0);
            Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
        }
    }
}
