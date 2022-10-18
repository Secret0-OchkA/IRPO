using Lab5.CoffeLib;
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

namespace Lab5
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
        CoffeeMaker coffeeMaker = new CoffeeMaker();
        int money;

        private void CheckBox_Sugar_Change(object sender, RoutedEventArgs e)
        {
            if(CheckBox_Sugar.IsChecked == true)
                Image_Sugar.Visibility = Visibility.Visible;
            else
                Image_Sugar.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Milk_Change(object sender, RoutedEventArgs e)
        {
            if (CheckBox_Milk.IsChecked == true)
                Image_Milk.Visibility = Visibility.Visible;
            else
                Image_Milk.Visibility = Visibility.Collapsed;

        }



        private void Button_ConfirmMoney_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(TextBox_MoneyInput.Text, out money);
            TextBlock_InputMoney.Text = money.ToString();
        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            RadioButton_CoffeeType_Checked(null, new RoutedEventArgs());

            if (CheckBox_Milk.IsChecked == true) coffeeMaker.AddMilk();
            if (CheckBox_Sugar.IsChecked == true) coffeeMaker.AddSugar();

            Coffee coffee = coffeeMaker.Build();
            int cost = coffee.GetPrice();

            TextBlock_Cost.Text = cost.ToString();

            if(money >= cost) TextBlock_Change.Text = (money - cost).ToString();
        }



        private void RadioButton_CoffeeType_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioButton_Amerikano.IsChecked == true) coffeeMaker.BaseCoffee(new Americano());
            else if (RadioButton_Capuchino.IsChecked == true) coffeeMaker.BaseCoffee(new Cappuccino());
            else if (RadioButton_Ecspresso.IsChecked == true) coffeeMaker.BaseCoffee(new Espresso());
            else if (RadioButton_Cacao.IsChecked == true) coffeeMaker.BaseCoffee(new Cocoa());

            if (Image_Coffe != null)
                Image_Coffe.Source = coffeeMaker.GetImage();
        }
    }
}
