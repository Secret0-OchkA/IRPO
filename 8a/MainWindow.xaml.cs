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

namespace _8a
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var ffArray = Fonts.SystemFontFamilies;
            foreach (var ff in ffArray)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.FontFamily = ff;
                item.Content = ff;

                cbFontFamily.Items.Add(item);
            }
        }

        private void BtnBold_Click(object sender, RoutedEventArgs e)
        {
            var selection = richTextBox.Selection;
            if (!selection.IsEmpty)
            {
                if (selection.GetPropertyValue(TextElement.FontWeightProperty).ToString() == "Bold")
                    selection.ApplyPropertyValue(TextElement.FontWeightProperty, "Normal");
                else
                    selection.ApplyPropertyValue(TextElement.FontWeightProperty, "Bold");
            }
        }

        private void SliderFontSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var selection = richTextBox?.Selection;
            if (selection != null && !selection.IsEmpty)
                selection.ApplyPropertyValue(TextElement.FontSizeProperty, sliderFontSize.Value);
        }

        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selection = richTextBox.Selection;
            if (!selection.IsEmpty)
            {
                if (selection.GetPropertyValue(TextElement.FontFamilyProperty) == DependencyProperty.UnsetValue)
                    return;
                cbFontFamily.SelectedValue = selection.GetPropertyValue(TextElement.FontFamilyProperty);
            }
        }

        private void CbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = richTextBox.Selection;
            if (!selection.IsEmpty && cbFontFamily.SelectedValue != null)
            {
                Console.WriteLine(cbFontFamily.SelectedValue);
                selection.ApplyPropertyValue(TextElement.FontFamilyProperty, cbFontFamily.SelectedValue.ToString());
            }
        }

        private void BtnItalic_Click(object sender, RoutedEventArgs e)
        {
            var selection = richTextBox.Selection;
            if (!selection.IsEmpty)
            {
                if (selection.GetPropertyValue(TextElement.FontStyleProperty).ToString() == "Italic")
                {
                    selection.ApplyPropertyValue(TextElement.FontStyleProperty, "Normal");
                }
                else
                {
                    selection.ApplyPropertyValue(TextElement.FontStyleProperty, "Italic");
                }
            }
        }
    }
}