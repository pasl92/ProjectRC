//------------------------------------------------------------------------------
namespace ProjectRC
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Klasa obiektu zamowienia
    /// </summary>
    public partial class zamowienia
    {
        /// <summary>
        /// Property id_zamowienia
        /// </summary>
        public int id_zamowienia { get; set; }

        /// <summary>
        /// Property id_produktu
        /// </summary>
        public Nullable<int> id_produktu { get; set; }

        /// <summary>
        /// Property id_klienta
        /// </summary>
        public Nullable<int> id_klienta { get; set; }

        /// <summary>
        /// Property rabat
        /// </summary>
        public Nullable<decimal> rabat { get; set; }

        /// <summary>
        /// Property data_zakupu
        /// </summary>
        public Nullable<System.DateTime> data_zakupu { get; set; }

        /// <summary>
        /// Virtual property klienci from klienci object
        /// </summary>
        public virtual klienci klienci { get; set; }

        /// <summary>
        /// summary>
        /// Virtual property produkty from produkty object
        /// </summary>
        public virtual produkty produkty { get; set; }
    }
}
