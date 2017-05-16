using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Firma.Models.PoslovnaLogika
{
    public class RacunViewModel
    {
        public IEnumerable<Artikli> artikli { get; set; }
        public IEnumerable<Poslovni_partner> partneri { get; set; }
    }
}