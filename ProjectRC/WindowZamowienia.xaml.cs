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
    /// Interaction logic for WindowZamowienia.xaml
    /// </summary>
    public partial class WindowZamowienia : Window
    {
        RcDBEntities contextZamowienia = new RcDBEntities();
        CollectionViewSource custViewSource;
        CollectionViewSource ordViewSource;

        public WindowZamowienia()
        {
            InitializeComponent();
            custViewSource = ((CollectionViewSource)(FindResource("zamowieniaViewSource")));
            ordViewSource = ((CollectionViewSource)(FindResource("zamowieniaViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //System.Windows.Data.CollectionViewSource zamowieniaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("zamowieniaViewSource")));
            //// Load data by setting the CollectionViewSource.Source property:
            //// zamowieniaViewSource.Source = [generic data source]
            ///
            contextZamowienia.zamowienia.Load();

            // After the data is loaded, call the DbSet<T>.Local property    
            // to use the DbSet<T> as a binding source.   
            custViewSource.Source = contextZamowienia.zamowienia.Local;
        }
    }
}
