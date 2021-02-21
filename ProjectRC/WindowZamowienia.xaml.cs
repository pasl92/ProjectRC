using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProjectRC
{
    /// <summary>
    /// Logika WindowZamowienia.xaml
    /// </summary>
    public partial class WindowZamowienia : Window
    {
        RcDBEntities contextZamowienia = new RcDBEntities();
        CollectionViewSource custViewSource;
        CollectionViewSource ordViewSource;


        /// <summary>
        /// Konstruktor WindowZamowienia
        /// </summary>
        public WindowZamowienia()
        {
            InitializeComponent();
            custViewSource = ((CollectionViewSource)(FindResource("zamowieniaViewSource")));
            ordViewSource = ((CollectionViewSource)(FindResource("zamowieniaViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contextZamowienia.zamowienia.Load();
            custViewSource.Source = contextZamowienia.zamowienia.Local;
        }

        private void zamowieniaDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            zamowienia newZamowienia = new zamowienia();

            try
            {
                decimal x = (decimal)System.Data.SqlTypes.SqlDecimal.Parse(rabatTextBox.Text);

                if (x >= 1)
                {
                    MessageBox.Show("Wprowadz wartość rabatu od 0.00 do 0.99", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                IQueryable<klienci> recordsKlienci = contextZamowienia.klienci;
                var countIdKlienta = recordsKlienci.Count();

                newZamowienia.id_klienta = int.Parse(id_klientaTextBox.Text);
                if (countIdKlienta < newZamowienia.id_klienta)
                {
                    MessageBox.Show($"Maksymalny indeks klienta wynosi {countIdKlienta}\nSprawdz id klienta w tabeli klienci", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                IQueryable<klienci> recordsProdukty = contextZamowienia.klienci;
                var countIdProdukty = recordsProdukty.Count();

                newZamowienia.id_produktu = int.Parse(id_produktuTextBox.Text);
                if (countIdProdukty < newZamowienia.id_produktu)
                {
                    MessageBox.Show($"Maksymalny indeks produktu wynosi {countIdProdukty}\nSprawdz id produktu w tabeli produkty", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                newZamowienia.rabat = x;
                newZamowienia.data_zakupu = data_zakupuDatePicker.SelectedDate;

            }
            catch (Exception)
            {
                MessageBox.Show("Wprowadzono niepoprawne dane", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                contextZamowienia.zamowienia.Add(newZamowienia);
                contextZamowienia.SaveChanges();

            }
            catch (Exception)
            {
                MessageBox.Show("Wprowadzono niepoprawidłowe id klienta lub produktu", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                var cur = custViewSource.View.CurrentItem as zamowienia;

                var cust = (from c in contextZamowienia.zamowienia
                            where c.id_zamowienia == cur.id_zamowienia
                            select c).FirstOrDefault();

                contextZamowienia.zamowienia.Remove(cust);

                contextZamowienia.SaveChanges();
                custViewSource.View.Refresh();
            }

            catch (Exception)
            {
                MessageBox.Show("Zaznacz element do usunięcia", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            contextZamowienia.zamowienia.Load();
            custViewSource.Source = contextZamowienia.zamowienia.Local;
        }


    }
}
