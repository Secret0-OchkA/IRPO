using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml;

namespace Lab7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table = new DataTable();
        public MainWindow()
        {
            InitializeComponent();

            table.Columns.Add("Key Code");
            table.Columns.Add("Key Value");
            table.Columns.Add("Key State");
            table.Columns.Add("Key Char");
            table.Columns.Add("System Key");
            table.Columns.Add("Key Down");
            table.Columns.Add("Key Up");

            KeyGrid.ItemsSource = table.DefaultView;
        }

        public void AddRow(object sender, KeyEventArgs e)
        {
            DataRow row = table.NewRow();
            row[0] = e.Key;
            row[1] = Convert.ToInt32(e.Key);
            row[2] = e.KeyStates;
            row[3] = e.Key.ToString();
            row[4] = e.SystemKey;
            row[5] = e.IsDown;
            row[6] = e.IsUp;

            table.Rows.Add(row);

            KeyGrid.ScrollIntoView(KeyGrid.Items.GetItemAt(KeyGrid.Items.Count - 1));
        }
    }
}
