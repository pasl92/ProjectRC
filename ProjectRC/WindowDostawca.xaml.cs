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
    /// Interaction logic for WindowDostawca.xaml
    /// </summary>
    public partial class WindowDostawca : Window
    {
        RcDBEntities contextDostawca = new RcDBEntities();
        CollectionViewSource custViewSource;
        CollectionViewSource ordViewSource;

        public WindowDostawca()
        {
            InitializeComponent();
            custViewSource = ((CollectionViewSource)(FindResource("dostawaViewSource")));
            ordViewSource = ((CollectionViewSource)(FindResource("dostawaViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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

                    cena = int.Parse(cenaTextBox.Text),
                    nazwa = nazwaTextBox.Text

                };

                contextDostawca.dostawa.Add(newDostawca);
                contextDostawca.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wprowadzono niepoprawne dane", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            catch (Exception ex)
            {
                MessageBox.Show("Zaznacz element do usunięcia", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void cenaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
