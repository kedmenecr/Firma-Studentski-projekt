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
        public int id_admin { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string adresa { get; set; }
        public string mobitel { get; set; }
        public string lozinka { get; set; }




    }
}