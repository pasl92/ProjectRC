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

namespace ProjectRC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowKlienci winKlienci = new WindowKlienci();
            winKlienci.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowProdukty winProdukty = new WindowProdukty();
            winProdukty.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WindowDostawca winDostawa = new WindowDostawca();
            winDostawa.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            WindowZamowienia winZamowienia = new WindowZamowienia();
            winZamowienia.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
