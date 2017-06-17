using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Firma.Models.PoslovnaLogika
{
    [Table("zaposlenik")]
    public class Zaposlenik
    {
        [Key]
        [Display(Name = "ID")]
        public int id_zaposlenik { get; set; }
        [Display(Name = "Ime")]
        public string ime { get; set; }
        [Display(Name = "Prezime")]
        public string prezime { get; set; }
        [Display(Name = "Adresa")]
        public string adresa { get; set; }
        [Display(Name = "Mobitel")]
        public string mobitel { get; set; }
        [Display(Name = "Lozinka")]
        public string lozinka { get; set; }

    }
}