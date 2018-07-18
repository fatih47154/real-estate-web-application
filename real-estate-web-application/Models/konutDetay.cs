namespace real_estate_web_application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("konutDetay")]
    public partial class konutDetay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public konutDetay()
        {
            Kategori = new HashSet<Kategori>();
        }

        [Key]
        public int detayID { get; set; }

        [StringLength(50)]
        public string odaSayisi { get; set; }

        public int? binaYasi { get; set; }

        public int? bulunduguKat { get; set; }

        [StringLength(10)]
        public string katSayisi { get; set; }

        [StringLength(50)]
        public string isitma { get; set; }

        public int? banyoSayisi { get; set; }

        public bool? balkon { get; set; }

        public bool? esyali { get; set; }

        public bool? siteIcerisinde { get; set; }

        public int? aidat { get; set; }

        public bool? krediyeUygun { get; set; }

        public bool? takas { get; set; }

        [StringLength(50)]
        public string cephe { get; set; }

        public bool? yanginAlarm { get; set; }

        public bool? hirsizAlarm { get; set; }

        public bool? amerikanMutfak { get; set; }

        public bool? alaturkaTuvalet { get; set; }

        public bool? asansor { get; set; }

        public bool? dusakabin { get; set; }

        public bool? fiberInternet { get; set; }

        public bool? goruntuluDiafon { get; set; }

        public bool? isicam { get; set; }

        public bool? ankastreMutfak { get; set; }

        public bool? laminat { get; set; }

        public bool? somine { get; set; }

        public bool? guvenlik { get; set; }

        public bool? isiYalitim { get; set; }

        public bool? uydu { get; set; }

        public bool? kapaliGaraj { get; set; }

        public bool? kapici { get; set; }

        public bool? otopark { get; set; }

        public bool? sesYalitim { get; set; }

        public bool? sporAlani { get; set; }

        public bool? havuz { get; set; }

        public bool? oyunParki { get; set; }

        public bool? belediye { get; set; }

        public bool? cami { get; set; }

        public bool? sehirMerkezi { get; set; }

        public bool? hastane { get; set; }

        public bool? market { get; set; }

        public bool? park { get; set; }

        public bool? okul { get; set; }

        public bool? anayol { get; set; }

        public bool? otobusDuragi { get; set; }

        public bool? cadde { get; set; }

        public bool? minibus { get; set; }

        public bool? araKat { get; set; }

        public bool? bahceKati { get; set; }

        public bool? dubleks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kategori> Kategori { get; set; }
    }
}
