namespace real_estate_web_application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiteOzellikleri")]
    public partial class SiteOzellikleri
    {
        [Key]
        public int siteID { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(50)]
        public string cepTel { get; set; }

        [StringLength(50)]
        public string telefon { get; set; }

        public int? resimID { get; set; }

        [StringLength(500)]
        public string hakkimizda { get; set; }

        [StringLength(200)]
        public string misyon { get; set; }

        [StringLength(200)]
        public string adres { get; set; }

        public virtual Resim Resim { get; set; }
    }
}
