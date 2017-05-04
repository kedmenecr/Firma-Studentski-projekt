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
        public string id_tipovi_placanja { get; set; }
        public string tip_placanja { get; set; }
        public string opis { get; set; }
        public string komentar { get; set; }
    }
}