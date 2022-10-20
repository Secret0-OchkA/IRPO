using System;
using System.Collections.Generic;
using System.IO;
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

namespace _9c
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ButtonCopy.CommandBindings.Add(new CommandBinding(ApplicationCommands.Cut, Copy));
            ButtonPast.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, Past));
            ButtonCut.CommandBindings.Add(new CommandBinding(ApplicationCommands.Cut, Cut));
        }

        public void Copy(object sender, ExecutedRoutedEventArgs e) => RichTextBoxEdit.Copy();
        public void Past(object sender, ExecutedRoutedEventArgs e) => RichTextBoxEdit.Paste();
        public void Cut(object sender, ExecutedRoutedEventArgs e) => RichTextBoxEdit.Cut();
    }
}
