using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ITUniversell.Helper
{
    class HelperButton : Button
    {
        public HelperButton(string content)
        {
            Content = content;
            Width = 130;
            Height = 35;
        }
        public HelperButton(string content, int m_top)
        {
            Content = content;
            Width = 130;
            Height = 35;
            Margin = new System.Windows.Thickness(0, m_top, 0, 0);
        }
    }
}
