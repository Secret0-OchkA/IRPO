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

namespace _8c
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

        private void Numpud_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button btn)
                TextBlockNum.Text += btn.Content.ToString();
        }

        List<KeyValuePair<string, double>> ops = new List<KeyValuePair<string, double>>();
        private void Calculate()
        {
            double result = ops[0].Value;
            for(int i = 1; i < ops.Count; i++)
            switch (ops[i - 1].Key)
            {
                case "+": result += ops[i].Value; break;
                case "-": result -= ops[i].Value; break;
                case "*": result *= ops[i].Value; break;
                case "/": result /= ops[i].Value; break;
            }
            TextBlockNum.Text = result.ToString();
        }

        private void ToolBar_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                double.TryParse(TextBlockNum.Text, out double newNum);
                switch (btn.Content.ToString())
                {
                    case "+": case "-": case "*": case "/":
                        ops.Add(new KeyValuePair<string, double>(btn.Content.ToString(), newNum));
                        TextBlockNum.Text = "";
                        break;
                    case "=":  
                        ops.Add(new KeyValuePair<string, double>(btn.Content.ToString(), newNum));
                        Calculate();
                        ops.Clear();
                        break;
                    case "C": TextBlockNum.Text = ""; ops.Clear(); break;
                }

            }
        }
    }
}
