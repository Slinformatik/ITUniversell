using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ITUniversell.Helper
{
    class HelperComboBox : ComboBox
    {
        public HelperComboBox(string[] source, int startIndex)
        {
            ItemsSource = source;
            SelectedIndex = startIndex;
            Width = 125;
            Height = 30;

        }
        //HelperComboBox x = new HelperComboBox(new string[] {"Byte","KibiByte"...}, 1);
    }
}
