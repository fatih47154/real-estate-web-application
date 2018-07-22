namespace real_estate_web_application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("isyeriDetay")]
    public partial class isyeriDetay
    {
        [Key]
        public int detayID { get; set; }

        [StringLength(50)]
        public string turu { get; set; }

        public int? bolumOda { get; set; }

        public int? aidat { get; set; }

        [StringLength(50)]
        public string isitma { get; set; }

        [StringLength(50)]
        public string binaYasi { get; set; }

        public bool? krediyeUygun { get; set; }

        public bool? atolye { get; set; }

        public bool? bufe { get; set; }

        public bool? cafeBar { get; set; }

        public bool? eczaneMedikal { get; set; }

        public bool? otoYikama { get; set; }

        public bool? kuafor { get; set; }

        public bool? market { get; set; }

        public bool? otomotiv { get; set; }

        public bool? oyunCafe { get; set; }

        public bool? pastane { get; set; }

        public bool? restoran { get; set; }

        public bool? tamirhane { get; set; }

        public bool? cayOcagi { get; set; }

        public bool? imalathane { get; set; }

        public bool? guvenlikKamerasi { get; set; }

        public bool? jenerator { get; set; }

        public bool? suDeposu { get; set; }

        public bool? yanginAlarm { get; set; }

        public bool? hirsizAlarm { get; set; }

        public bool? hidrofor { get; set; }

        public bool? mutfak { get; set; }

        public bool? wc { get; set; }

        [StringLength(50)]
        public string cephe { get; set; }

        public bool? elektrik { get; set; }

        public bool? su { get; set; }

        public bool? telefon { get; set; }

        public bool? dogalgaz { get; set; }

        public bool? kanalizasyon { get; set; }

        public bool? aritma { get; set; }
    }
}
