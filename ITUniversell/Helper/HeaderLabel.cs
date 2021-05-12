using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ITUniversell.Helper
{
    public class HeaderLabel : Label
    {
        public HeaderLabel(string content)
        {
            Content = content;          
            FontSize = 30;
        }
        public HeaderLabel(string content, int x)
        {
            Content = content;           
            FontSize = 13;
        }
    }
}
