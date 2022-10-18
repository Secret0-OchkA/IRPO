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
using DeckLibrary;

namespace WpfDeck
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateDeck();
        }

        Deck deck = new Deck();

        private void btnShuffle_Click(object sender, RoutedEventArgs e)
        {
            deck.Shuffle();
            UpdateDeck();
        }

        private void btnNewDeck_Click(object sender, RoutedEventArgs e)
        {
            deck = new Deck();
            UpdateDeck();
        }

        private void UpdateDeck()
        {
            for(int i = 0; i < 52; i++)
            {
                TextBlock textBlock = DeckGrid.Children[i] as TextBlock;
                textBlock.Text = deck[i].ToString();
            }
        }
    }
}
