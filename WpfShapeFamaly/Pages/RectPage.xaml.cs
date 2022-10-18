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
using Rect = ShapeFamaly.Rect;

namespace WpfShapeFamaly.Pages
{
    /// <summary>
    /// Логика взаимодействия для RectPage.xaml
    /// </summary>
    public partial class RectPage : Page
    {
        public RectPage()
        {
            InitializeComponent();
        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(TextBox_A.Text);
            double b = Convert.ToDouble(TextBox_B.Text);
            Shape shape = new Rect(a,b);
            TextBlock_Out.Text = shape.ToString();
        }
    }
}
