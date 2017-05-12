using Firma.Models.PoslovnaLogika;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Firma.Models
{
    public class bazaContext : DbContext
    {
        //dodavanjae svih baza
        public DbSet<Admin> admini { get; set; }
        public DbSet<Artikli> artikli { get; set; }
        public DbSet<Poslovni_partner> poslovni_partner { get; set; } // poslovniparner --> poslovni_partner
        public DbSet<Tipovi_placanja> tipovi_placanja { get; set; }
        public DbSet<Zaposlenik> zaposlenik { get; set; }
        public DbSet<Faktura> racun { get; set; }

    }
}