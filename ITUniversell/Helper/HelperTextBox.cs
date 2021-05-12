using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ITUniversell.Helper
{
    public class HelperTextBox : TextBox
    {

        public HelperTextBox(bool isReadOnly)
        {
            IsReadOnly = isReadOnly;
            if (IsReadOnly) IsEnabled = false;
            TextWrapping = System.Windows.TextWrapping.Wrap;
            AcceptsReturn = true;
         
            Width = 230;
            Height = 35;
            
            
            /*
             if(IsReadOnly == true) {
                IsEnabled = false;
            }
            */
        }
    }
}
