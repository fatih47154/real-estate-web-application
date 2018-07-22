namespace real_estate_web_application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ilan")]
    public partial class Ilan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ilan()
        {
            konutDetay = new HashSet<konutDetay>();
            Resim = new HashSet<Resim>();
            yorum = new HashSet<yorum>();
        }

        public int ilanID { get; set; }

        [StringLength(100)]
        public string baslik { get; set; }

        public double? fiyat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? tarih { get; set; }

        public int? metrekare { get; set; }

        [StringLength(500)]
        public string aciklama { get; set; }

        public bool? vitrin { get; set; }

        [StringLength(10)]
        public string durum { get; set; }

        public int? kullaniciID { get; set; }

        public int? kategoriID { get; set; }

        public long? IL_ID { get; set; }

        public long ILCE_ID { get; set; }

        public long? SEMT_ID { get; set; }

        public long? MAH_ID { get; set; }

        public virtual il il { get; set; }

        public virtual ilce ilce { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }

        public virtual mahalle_koy mahalle_koy { get; set; }

        public virtual semt semt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<konutDetay> konutDetay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resim> Resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yorum> yorum { get; set; }
    }
}
