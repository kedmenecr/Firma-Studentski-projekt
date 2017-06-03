using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Firma.Models.PoslovnaLogika
{
    [Table("artikli")]
    public class Artikli
    {
        [Key]
        [Display(Name ="Id")]
        public int id_artikla { get; set; }

        [Display(Name ="Ime")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string ime_artikla { get; set; }
        [Display(Name = "Opis")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string opis { get; set; }
        [Display(Name ="Cijena")]
        public decimal cijena { get; set; }
        [Display(Name ="Porez")]
        public int porez { get; set; }

        
    }
}