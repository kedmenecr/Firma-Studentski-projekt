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
        public int id_zaposlenik { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string adresa { get; set; }
        public string mobitel { get; set; }
        public string lozinka { get; set; }

    }
}