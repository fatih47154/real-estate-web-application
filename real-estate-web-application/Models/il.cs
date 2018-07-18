namespace real_estate_web_application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("il")]
    public partial class il
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public il()
        {
            Ilan = new HashSet<Ilan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IL_ID { get; set; }

        [StringLength(3)]
        public string PLAKA { get; set; }

        [StringLength(255)]
        public string IL_ADI_BUYUK { get; set; }

        [StringLength(255)]
        public string IL_ADI { get; set; }

        [StringLength(255)]
        public string IL_ADI_KUCUK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilan> Ilan { get; set; }
    }
}
