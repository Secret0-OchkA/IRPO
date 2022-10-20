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

namespace _7c
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

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point cord = e.GetPosition(this);
            polygon.Points.Add(cord);

            double width = 10, height = 10;
            TranslateTransform translate = new TranslateTransform(cord.X - width / 2, cord.Y - height / 2);
            Ellipse ellipse = new Ellipse() { Width = width, Height = height, Fill = new SolidColorBrush(Color.FromRgb(180, 80, 80)), RenderTransform = translate };

            canvas.Children.Add(ellipse);
        }
    }
}
