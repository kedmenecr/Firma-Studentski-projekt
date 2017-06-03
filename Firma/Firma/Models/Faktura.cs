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
        [Display(Name = "ID")]
        public int id_racun { get; set; }

        [Display(Name = "Ime artikla")]
        public string ime_artikla { get; set; }

        [Display(Name = "ID proizvoda")]
        public int id_proizvod { get; set; }
        [Display(Name = "Cijena")]
        public decimal cijena { get; set; }
        [Display(Name = "Porez")]
        public int porez { get; set; }
        [Display(Name = "Ukupna cijena")]
        public int ukupna_cijena { get; set; }
        [Display(Name = "Ukupna kolicina")]
        public int ukupna_kolicina { get; set; }


    }
}