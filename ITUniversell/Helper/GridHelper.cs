using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ITUniversell.Helper
{
    public class GridHelper
    {
        public static Grid CreateGrid(int column, int row)
        {
            
            Grid myGrid = new Grid();
            myGrid.Background = new SolidColorBrush(Color.FromRgb(220,220,220));

            for (int i = 0; i < column; i++)
                myGrid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < row; i++)
                myGrid.RowDefinitions.Add(new RowDefinition());

            return myGrid;
        }
        
        public static void AddToGrid(Grid grid, Control control, int columnSpan, int row,int column)
        {
            Grid.SetColumnSpan(control, columnSpan);
            Grid.SetRow(control, row);
            Grid.SetColumn(control, column);
            grid.Children.Add(control);

        }
    }
}
