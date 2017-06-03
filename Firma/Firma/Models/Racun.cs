using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Firma.Models.PoslovnaLogika
{
    [Table("racun")]
    public class Racun
    {
        [Key]
        [Display(Name = "ID")]
        public int id_racun { get; set; }
        [Display(Name = "ID artikla")]
        public int id_artikla { get; set; }
        [Display(Name = "ID partnera")]
        public int id_poslovni_partner { get; set; }

       
    }
}