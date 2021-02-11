namespace ProjectRC
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Klasa obiektu produkty
    /// </summary>
    public partial class produkty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public produkty()
        {
            this.zamowienia = new ObservableCollection<zamowienia>();
        }

        /// <summary>
        /// Property id_produktu
        /// </summary>
        public int id_produktu { get; set; }

        /// <summary>
        /// Property cena
        /// </summary>
        public Nullable<decimal> cena { get; set; }

        /// <summary>
        /// Property koszt_zakupu
        /// </summary>
        public Nullable<decimal> koszt_zakup { get; set; }

        /// <summary>
        /// Property nazwa
        /// </summary>
        public string nazwa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<zamowienia> zamowienia { get; set; }
    }
}
