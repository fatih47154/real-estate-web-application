namespace real_estate_web_application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("semt")]
    public partial class semt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public semt()
        {
            Ilan = new HashSet<Ilan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SEMT_ID { get; set; }

        public long? IL_ID { get; set; }

        public long? ILCE_ID { get; set; }

        [StringLength(255)]
        public string SEMT_ADI_BUYUK { get; set; }

        [StringLength(255)]
        public string SEMT_ADI { get; set; }

        [StringLength(255)]
        public string SEMT_ADI_KUCUK { get; set; }

        [StringLength(10)]
        public string POSTA_KODU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilan> Ilan { get; set; }
    }
}
