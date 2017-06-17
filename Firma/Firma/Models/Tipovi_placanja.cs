using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Firma.Models.PoslovnaLogika
{
    [Table("tipovi_placanja")]
    public class Tipovi_placanja
    {
        [Key]
        [Display(Name = "ID")]
        public string id_tipovi_placanja { get; set; }
        [Display(Name = "Tip placanja")]
        public string tip_placanja { get; set; }
        [Display(Name = "Opis")]
        public string opis { get; set; }

        [Display(Name = "Komentar")]
        public string komentar { get; set; }
    }
}