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
        public int poslovni_partner { get; set; }
        public string naziv { get; set; }
        public string adresa { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public string oznaka_banke { get; set; }
        public string SWIFT_broj_banke { get; set; }
        public string podaci_o_osnivanju { get; set; }
        public string naziv_odgovorne_osobe { get; set; }

    }
}