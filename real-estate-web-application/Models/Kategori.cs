namespace real_estate_web_application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kategori")]
    public partial class Kategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kategori()
        {
            Ilan = new HashSet<Ilan>();
        }

        public int kategoriID { get; set; }

        [StringLength(50)]
        public string kategoriAdi { get; set; }

        public int? detayID { get; set; }

        public virtual arsaDetay arsaDetay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilan> Ilan { get; set; }

        public virtual isyeriDetay isyeriDetay { get; set; }

        public virtual konutDetay konutDetay { get; set; }
    }
}
