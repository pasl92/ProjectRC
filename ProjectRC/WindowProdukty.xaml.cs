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
using System.Windows.Shapes;
using System.Data.Entity;

namespace ProjectRC
{
    /// <summary>
    /// Interaction logic for WindowProdukty.xaml
    /// </summary>
    public partial class WindowProdukty : Window
    {
        RcDBEntities contextProdukty = new RcDBEntities();
        CollectionViewSource custViewSource;
        CollectionViewSource ordViewSource;

        public WindowProdukty()
        {
            InitializeComponent();
            custViewSource = ((CollectionViewSource)(FindResource("produktyViewSource")));
            ordViewSource = ((CollectionViewSource)(FindResource("produktyViewSource")));
            DataContext = this;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        private void produktyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                produkty newProdukt = new produkty()
                {

                    nazwa = nazwaTextBox.Text,
                    koszt_zakup = int.Parse(koszt_zakupTextBox.Text),
                    cena = int.Parse(cenaTextBox.Text)

                };

                contextProdukty.produkty.Add(newProdukt);
                contextProdukty.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wprowadzono niepoprawne dane", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var cur = custViewSource.View.CurrentItem as produkty;

                var cust = (from c in contextProdukty.produkty
                            where c.id_produktu == cur.id_produktu
                            select c).FirstOrDefault();

                contextProdukty.produkty.Remove(cust);

                contextProdukty.SaveChanges();
                custViewSource.View.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Zaznacz element do usunięcia", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            contextProdukty.produkty.Load();
            custViewSource.Source = contextProdukty.produkty.Local;
        }
    }
}
