using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Firma.Models.PoslovnaLogika
{
    [Table("poslovni_partner")]
    public class Poslovni_partner
    {
       [Key]
        [Display(Name = "ID")]
        public int id_poslovni_partner { get; set; }
        [Display(Name = "Naziv")]
        public string naziv { get; set; }
        [Display(Name = "Adresa")]
        public string adresa { get; set; }
        [Display(Name = "OIB")]
        public int oib { get; set; }
        [Display(Name = "Telefon")]
        public string telefon { get; set; }
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [Display(Name = "Oznaka banke")]
        public string oznaka_banke { get; set; }
        [Display(Name = "SWIFT")]
        public string SWIFT_broj_banke { get; set; }
        [Display(Name = "Osnivanje")]
        public string podaci_o_osnivanju { get; set; }
        [Display(Name = "Odgovorna osoba")]
        public string naziv_odgovorne_osobe { get; set; }

    }
}