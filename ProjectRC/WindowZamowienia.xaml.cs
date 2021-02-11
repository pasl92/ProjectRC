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

            try
            {
                decimal x = (decimal)System.Data.SqlTypes.SqlDecimal.Parse(rabatTextBox.Text);

                if (x >= 1)
                {
                    MessageBox.Show("Wprowadz wartość rabatu od 0.00 do 0.99", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                zamowienia newZamowienia = new zamowienia()
                {
                    id_klienta = int.Parse(id_klientaTextBox.Text),
                    id_produktu = int.Parse(id_produktuTextBox.Text),
                    rabat = x,
                    data_zakupu = data_zakupuDatePicker.SelectedDate
                };
                contextZamowienia.zamowienia.Add(newZamowienia);
                contextZamowienia.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Wprowadzono niepoprawne dane", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            }
}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            contextZamowienia.zamowienia.Load();
            custViewSource.Source = contextZamowienia.zamowienia.Local;
        }


    }
}
