using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProjectRC
{
    /// <summary>
    /// Logika WindowDostawca.xaml
    /// </summary>
    public partial class WindowDostawca : Window
    {
        RcDBEntities contextDostawca = new RcDBEntities();
        CollectionViewSource custViewSource;
        CollectionViewSource ordViewSource;

        /// <summary>
        /// Konstruktor WindowDostawca
        /// </summary>
        public WindowDostawca()
        {
            InitializeComponent();
            custViewSource = ((CollectionViewSource)(FindResource("dostawaViewSource")));
            ordViewSource = ((CollectionViewSource)(FindResource("dostawaViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contextDostawca.dostawa.Load();
            custViewSource.Source = contextDostawca.dostawa.Local;

        }

        private void dostawaDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dostawa newDostawca = new dostawa()
                {

                    cena = (decimal)System.Data.SqlTypes.SqlDecimal.Parse(cenaTextBox.Text),
                    nazwa = nazwaTextBox.Text

                };

                if (newDostawca.cena < 0) throw new ArgumentOutOfRangeException();
                contextDostawca.dostawa.Add(newDostawca);
                contextDostawca.SaveChanges();
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
            contextDostawca.dostawa.Load();
            custViewSource.Source = contextDostawca.dostawa.Local;
        }

        private void dostawaDataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {

                var cur = custViewSource.View.CurrentItem as dostawa;

                var cust = (from c in contextDostawca.dostawa
                            where c.id_dostawa == cur.id_dostawa
                            select c).FirstOrDefault();

                contextDostawca.dostawa.Remove(cust);

                contextDostawca.SaveChanges();
                custViewSource.View.Refresh();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Zaznacz element do usunięcia", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

        }

        private void cenaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
