using QuadraticSolverLib;
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

namespace Lab16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSolve_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(TextBoxA.Text, out var a))
                MessageBox.Show("A not number");
            if (!double.TryParse(TextBoxB.Text, out var b))
                MessageBox.Show("B not number");
            if (!double.TryParse(TextBoxC.Text, out var c))
                MessageBox.Show("C not number");

            QuadraticSolver.Solve(a, b, c, out double x1, out double x2);

            Solve1.Text = double.IsNaN(x1) ? "not solve" : x1.ToString();
            Solve2.Text = double.IsNaN(x2) ? "not solve" : x2.ToString();
        }
    }
}
