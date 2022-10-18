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
using WpfShapeFamaly.Pages;

namespace WpfShapeFamaly
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Page rectPage = new RectPage();
        Page squarePage = new SquarePage();
        Page circlePage = new CirclePage();

        private void Button_ShowRect_Click(object sender, RoutedEventArgs e)
        {
            FrameShapePages.Navigate(rectPage);
        }

        private void Button_ShowSquare_Click(object sender, RoutedEventArgs e)
        {
            FrameShapePages.Navigate(squarePage);
        }

        private void Button_ShowCircle_Click(object sender, RoutedEventArgs e)
        {
            FrameShapePages.Navigate(circlePage);
        }
    }
}
