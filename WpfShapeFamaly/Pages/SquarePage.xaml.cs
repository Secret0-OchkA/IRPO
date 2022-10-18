using ShapeFamaly;
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

namespace WpfShapeFamaly.Pages
{
    /// <summary>
    /// Логика взаимодействия для SquarePage.xaml
    /// </summary>
    public partial class SquarePage : Page
    {
        public SquarePage()
        {
            InitializeComponent();
        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(TextBox_SquareSize.Text);
            Shape shape = new Square(a);
            TextBlock_Out.Text = shape.ToString();
        }
    }
}
