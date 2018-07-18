namespace real_estate_web_application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("arsaDetay")]
    public partial class arsaDetay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public arsaDetay()
        {
            Kategori = new HashSet<Kategori>();
        }

        [Key]
        public int detayID { get; set; }

        [StringLength(50)]
        public string imarDurumu { get; set; }

        public int? mKareFiyati { get; set; }

        [StringLength(50)]
        public string tapuDurumu { get; set; }

        public bool? krediyeUygun { get; set; }

        public int? adaNo { get; set; }

        public int? parselNo { get; set; }

        public int? paftaNo { get; set; }

        public bool? katKarsiligi { get; set; }

        public bool? elektrik { get; set; }

        public bool? su { get; set; }

        public bool? telefon { get; set; }

        public bool? dogalgaz { get; set; }

        public bool? kanalizasyon { get; set; }

        public bool? aritma { get; set; }

        public bool? anaYol { get; set; }

        public bool? denizeSifir { get; set; }

        public bool? denizeYakin { get; set; }

        public bool? topluTasima { get; set; }

        public bool? ifrazli { get; set; }

        public bool? parselli { get; set; }

        public bool? projeli { get; set; }

        public bool? koseParsel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kategori> Kategori { get; set; }
    }
}
