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
    
    public IEnumerator<Racun> GetEnumerator()
    {
        return racuni.GetEnumerator();
    }

        public IEnumerator<Artikli> GetEnumerator1()
        {
            return artikli.GetEnumerator();
        }
        public IEnumerator<Poslovni_partner> GetEnumerator2()
        {
            return partneri.GetEnumerator();
        }
    }
}