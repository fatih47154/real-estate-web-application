namespace real_estate_web_application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ilce")]
    public partial class ilce
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ilce()
        {
            Ilan = new HashSet<Ilan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ILCE_ID { get; set; }

        public long? IL_ID { get; set; }

        [StringLength(255)]
        public string ILCE_ADI_BUYUK { get; set; }

        [StringLength(255)]
        public string ILCE_ADI { get; set; }

        [StringLength(255)]
        public string ILCE_ADI_KUCUK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilan> Ilan { get; set; }
    }
}
