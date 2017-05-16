using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Firma.Models;
using Firma.Models.PoslovnaLogika;
using System.Data.Entity;

namespace Firma.Controllers
{
    public class 
        UpravljanjeController : Controller
    {
        private bazaContext artikliDb = new bazaContext();
        private bazaContext poslovnipartnetDb = new bazaContext();
        private bazaContext racuniDb = new bazaContext();
        private bazaContext zaposleniciDb = new bazaContext();

        
        // GET: Upravljanje
        public ActionResult Index()
        {




            var art = (from a in artikliDb.artikli
                           //from p in poslovnipartnetDb.poslovni_partner
                       join ar in artikliDb.racun on a.id_artikla equals ar.id_artikla
                       //join pp in poslovnipartnetDb.racun on p.id_poslovni_partner equals pp.id_part
                       where ar.id_artikla == a.id_artikla
                       select new { ar.id_artikla }).ToList();


            return View(art);   
        }
        public ActionResult PopisPartnera()
        {
            var par = from z in poslovnipartnetDb.poslovni_partner select z;

            return View(par);


        }
     


        //vrača nam popis svih artikala koje imamo na skladištu 
        public ActionResult PopisArtikla()
        {
            var artikli = from z in racuniDb.artikli select z;

            ViewBag.Title = "Popis artikla";
            return View(artikli);
        }

        public ActionResult Azuriraj(int? Id)
        {
            Faktura racun;

            if(Id == null)
            {
                racun = new Faktura();
                ViewBag.Title = "Upis novog racuna";
            }
            else
            {
                //pronađi prvi račun
                racun = racuniDb.faktura.Find(Id);
                if( racun == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Title = "Ažuriranje računa";
            }
            var racuntitle = artikliDb.artikli.ToList();
            racuntitle.Add(new Artikli { id_artikla = 1 });
            ViewBag.RacunTitle = racuntitle;

            return View(racun);

            
        }


        //validacija
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(
            [Bind(Include = "id_racun,ime_artikla,id_proizvod,cijena,porez,ukupna_cijena,ukupna_kolicina")] Faktura racun)
        {
            if (ModelState.IsValid)
            {
                if (racun.id_racun != 0)
                {
                    racuniDb.Entry(racun).State = EntityState.Modified;

                }
                else
                {
                    racuniDb.faktura.Add(racun);

                }
                racuniDb.SaveChanges();
                
            }
            
            ViewBag.Title = "Ažuriranje podataka o racunu";
            return View(racun);
        }

    }
}