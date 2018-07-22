namespace real_estate_web_application.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class emlakDB : DbContext
    {
        public emlakDB()
            : base("name=emlakDB")
        {
        }

        public virtual DbSet<Ilan> Ilan { get; set; }
        public virtual DbSet<il> il { get; set; }
        public virtual DbSet<ilce> ilce { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<konutDetay> konutDetay { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<mahalle_koy> mahalle_koy { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<semt> semt { get; set; }
        public virtual DbSet<SiteOzellikleri> SiteOzellikleri { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<yorum> yorum { get; set; }
        public virtual DbSet<arsaDetay> arsaDetay { get; set; }
        public virtual DbSet<isyeriDetay> isyeriDetay { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ilan>()
                .Property(e => e.durum)
                .IsFixedLength();

            modelBuilder.Entity<ilce>()
                .HasMany(e => e.Ilan)
                .WithRequired(e => e.ilce)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<konutDetay>()
                .Property(e => e.katSayisi)
                .IsFixedLength();

            modelBuilder.Entity<SiteOzellikleri>()
                .Property(e => e.ad)
                .IsUnicode(false);

            modelBuilder.Entity<SiteOzellikleri>()
                .HasMany(e => e.Kullanicilar)
                .WithOptional(e => e.SiteOzellikleri)
                .HasForeignKey(e => e.resimID);

            modelBuilder.Entity<yorum>()
                .Property(e => e.icerik)
                .IsFixedLength();
        }
    }
}
