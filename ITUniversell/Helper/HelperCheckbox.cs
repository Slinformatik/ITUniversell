using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ITUniversell.Helper
{
    class HelperCheckbox : CheckBox
    {
        public HelperCheckbox(string content, bool isChecked)
        {
            Content = content;
            IsChecked = isChecked;
            VerticalAlignment = System.Windows.VerticalAlignment.Center;
            HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Margin = new System.Windows.Thickness(0, 0, 0, 0);
        }
    }
}
