﻿using System.Windows;
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
            MainGrid.ShowGridLines = true;
        }
    }
}
