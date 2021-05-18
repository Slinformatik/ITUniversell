using ITUniversell.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ITUniversell
{
    class IT_Mathe
    {
        static Grid myGrid;
        public static Grid CreateIT_Mathe()
        {
            myGrid = GridHelper.CreateGrid(12,7);
            GridHelper.AddToGrid(myGrid, new HeaderLabel("IT Mathe"), 2, 0, 0);

            return myGrid;
        }
    }
}
