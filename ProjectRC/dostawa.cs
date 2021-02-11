namespace ProjectRC
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Klasa obiektu dostawa
    /// </summary>
    public partial class dostawa
    {
        /// <summary>
        /// Property id_dostawa
        /// </summary>
        public int id_dostawa { get; set; }

        /// <summary>
        /// Property nazwa
        /// </summary>
        public string nazwa { get; set; }

        /// <summary>
        /// Property cena
        /// </summary>
        public Nullable<decimal> cena { get; set; }
    }
}
