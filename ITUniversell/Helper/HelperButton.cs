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
    }
}
