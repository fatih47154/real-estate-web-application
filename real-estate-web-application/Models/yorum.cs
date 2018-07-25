namespace real_estate_web_application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("yorum")]
    public partial class yorum
    {
        [StringLength(10)]
        public string icerik { get; set; }

        public int yorumID { get; set; }

        public bool? onay { get; set; }

        public int? ilanID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? eklenmeTarihi { get; set; }

        public int? kullaniciID { get; set; }

        public virtual Ilan Ilan { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
