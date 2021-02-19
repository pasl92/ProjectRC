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
using System.Data.Entity.Infrastructure;

namespace ProjectRC
{
    /// <summary>
    /// Logika WindowProdukty.xaml
    /// </summary>
    public partial class WindowProdukty : Window
    {
        RcDBEntities contextProdukty = new RcDBEntities();
        CollectionViewSource custViewSource;
        CollectionViewSource ordViewSource;

        /// <summary>
        /// Konstruktor WindowProdukty
        /// </summary>
        public WindowProdukty()
        {
            InitializeComponent();
            custViewSource = ((CollectionViewSource)(FindResource("produktyViewSource")));
            ordViewSource = ((CollectionViewSource)(FindResource("produktyViewSource")));
            DataContext = this;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contextProdukty.produkty.Load();
            custViewSource.Source = contextProdukty.produkty.Local;
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
                    koszt_zakup = (decimal)System.Data.SqlTypes.SqlDecimal.Parse(koszt_zakupTextBox.Text),
                    cena = (decimal)System.Data.SqlTypes.SqlDecimal.Parse(cenaTextBox.Text)

                };

                if (newProdukt.koszt_zakup < 0 || newProdukt.cena < 0) throw new ArgumentOutOfRangeException();
                contextProdukty.produkty.Add(newProdukt);
                contextProdukty.SaveChanges();
        }
            catch (FormatException)
            {
                MessageBox.Show("Wprowadzono niepoprawne dane", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Wprowadzono ujemną wartość", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
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
            catch (DbUpdateException)
            {
                MessageBox.Show("Zaznacz element do usunięcia", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            contextProdukty.produkty.Load();
            custViewSource.Source = contextProdukty.produkty.Local;
        }
    }
}
