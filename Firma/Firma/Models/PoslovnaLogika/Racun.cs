using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Firma.Models.PoslovnaLogika
{
    [Table("faktura")]
    public class Racun
    {
        [Key]
        public int id_racun { get; set; }
        public int  id_art { get; set; }
        public int id_part { get; set; }

    }
}