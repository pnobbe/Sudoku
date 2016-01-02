using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wrapper;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SudokuWrapper sudoku = new SudokuWrapper();
            this.MainGrid.ShowGridLines = true;

            for (int i = 0; i < 9; i++)
            {
                Label label = new Label();
                label.SetValue(Grid.RowProperty, i);
                label.SetValue(Grid.ColumnProperty, i);
                label.Content = i;
            }
        }
    }
}
