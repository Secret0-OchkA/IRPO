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

namespace _9a
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((rbTextBox.IsChecked ?? false) && sender is TextBox)
                e.Handled = true;
            if ((rbGrid.IsChecked ?? false) && sender is Grid)
                e.Handled = true;
            if ((rbWindow.IsChecked ?? false) && sender is Window)
                e.Handled = true;

            MessageBox.Show(sender.ToString());
        }
    }
}
