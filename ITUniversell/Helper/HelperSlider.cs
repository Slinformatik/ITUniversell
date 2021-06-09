using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ITUniversell.Helper
{
    class HelperSlider : Slider
    {
        public HelperSlider(int min, int max, int value)
        {
            VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Minimum = min;
            Maximum = max;
            Value = value;
            Width = 100;
        }
    }
}
