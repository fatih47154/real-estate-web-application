namespace real_estate_web_application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mesaj")]
    public partial class Mesaj
    {
        public int? gelenID { get; set; }

        public int? gidenID { get; set; }

        [StringLength(10)]
        public string icerik { get; set; }

        public int mesajID { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }

        public virtual Kullanicilar Kullanicilar1 { get; set; }
    }
}
