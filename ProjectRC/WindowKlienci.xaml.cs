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
    /// Logika WindowKlienci.xaml
    /// </summary>
    public partial class WindowKlienci : Window
    {
        RcDBEntities contextKlienci = new RcDBEntities();
        CollectionViewSource custViewSource;
        CollectionViewSource ordViewSource;

        /// <summary>
        /// Konstruktor WindowKlienci
        /// </summary>
        public WindowKlienci()
        {
            InitializeComponent();
            custViewSource = ((CollectionViewSource)(FindResource("klienciViewSource")));
            ordViewSource = ((CollectionViewSource)(FindResource("klienciViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contextKlienci.klienci.Load();
            custViewSource.Source = contextKlienci.klienci.Local;
        }

        private void klienciDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                klienci newKlient = new klienci()
                {

                    imie = imieTextBox.Text,
                    nazwisko = nazwiskoTextBox.Text,
                    nr_tel = int.Parse(nr_telTextBox.Text)

                };

                contextKlienci.klienci.Add(newKlient);
                contextKlienci.SaveChanges();
            }
            catch (FormatException)
            {
                MessageBox.Show("Wprowadzono niepoprawne dane", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var cur = custViewSource.View.CurrentItem as klienci;

                var cust = (from c in contextKlienci.klienci
                            where c.id_klienci == cur.id_klienci
                            select c).FirstOrDefault();

                contextKlienci.klienci.Remove(cust);

                contextKlienci.SaveChanges();
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
            contextKlienci.klienci.Load();
            custViewSource.Source = contextKlienci.klienci.Local;
        }
    }
}
