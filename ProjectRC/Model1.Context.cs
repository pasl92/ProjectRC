namespace ProjectRC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    /// <summary>
    /// Logika RcDBEntities
    /// </summary>
    public partial class RcDBEntities : DbContext
    {
        /// <summary>
        /// Konstruktor RcDBEntities
        /// </summary>
        public RcDBEntities()
            : base("name=RcDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        /// <summary>
        /// Tabela dostawa
        /// </summary>
        public virtual DbSet<dostawa> dostawa { get; set; }
        /// <summary>
        /// Tabela klienci
        /// </summary>
        public virtual DbSet<klienci> klienci { get; set; }
        /// <summary>
        /// Tabela produkty
        /// </summary>
        public virtual DbSet<produkty> produkty { get; set; }
        /// <summary>
        /// Tabela zamowienia
        /// </summary>
        public virtual DbSet<zamowienia> zamowienia { get; set; }
    }
}
