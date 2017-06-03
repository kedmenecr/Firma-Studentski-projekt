using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Firma.Models.PoslovnaLogika
{
    [Table("admin")]
    public class Admin
    {   [Key]
        [Display(Name ="ID")]
        public int id_admin { get; set; }
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