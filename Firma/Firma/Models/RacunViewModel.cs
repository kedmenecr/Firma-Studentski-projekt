using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Firma.Models.PoslovnaLogika
{
    public class RacunViewModel
    {
        public List<Racun> racuni { get; set; }
        public List<Artikli> artikli { get; set; }
        public List<Poslovni_partner> partneri { get; set; }


    }
}