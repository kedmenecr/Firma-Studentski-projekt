using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Firma.Models.PoslovnaLogika
{

    [Table("fraktura")]
    public class Faktura
    {
        [Key]
        [Display(Name = "Id Racuna")]
        public int id_racun { get; set; }

        public string ime_artikla { get; set; }

        public int id_proizvod { get; set; }
        public decimal cijena { get; set; }
        public int porez { get; set; }
        public int ukupna_cijena { get; set; }

        public int ukupna_kolicina { get; set; }


    }
}