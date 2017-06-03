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
        public int id_artikla { get; set; }
        public string ime_artikla { get; set; }
        public string opis { get; set; }
        public decimal cijena { get; set; }
        public int porez { get; set; }

        public static implicit operator List<object>(Artikli v)
        {
            throw new NotImplementedException();
        }
    }
}