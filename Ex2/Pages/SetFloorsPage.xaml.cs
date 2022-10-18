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

namespace Ex2.Pages
{
    /// <summary>
    /// Логика взаимодействия для SetFloorsPage.xaml
    /// </summary>
    public partial class SetFloorsPage : Page
    {
        public SetFloorsPage()
        {
            InitializeComponent();
        }

        int floorCount = 1;

        private void IncFloor_Click(object sender, RoutedEventArgs e)
        {
            if(floorCount < 100)
                floorCount++;
            Floors.Text = floorCount.ToString();
        }

        private void DecFloor_Click(object sender, RoutedEventArgs e)
        {
            if(floorCount > 1)
                floorCount--;
            Floors.Text = floorCount.ToString();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ElevatorPage(floorCount));
        }
    }
}
