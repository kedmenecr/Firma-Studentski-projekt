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

        private bazaContext racuniDB = new bazaContext();
        // GET: Upravljanje
        public ActionResult Index()
        {
            var artikli = from z in artikliDb.artikli select z;
            return View(artikli);
        }

        public ActionResult Azuriraj(int? Id)
        {
            Fraktura racun;

            if(Id == null)
            {
                racun = new Fraktura();
                ViewBag.Title = "Upis novog racuna";
            }
            else
            {
                //pronađi prvi račun
                racun = racuniDB.racun.Find(Id);
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
            [Bind(Include = "id_racun,ime_artikla,id_proizvod,cijena,porez,ukupna_cijena,ukupna_kolicina")] Fraktura racun)
        {
            if (ModelState.IsValid)
            {
                if (racun.id_racun != 0)
                {
                    racuniDB.Entry(racun).State = EntityState.Modified;

                }
                else
                {
                    racuniDB.racun.Add(racun);

                }
                racuniDB.SaveChanges();
                
            }
            
            ViewBag.Title = "Ažuriranje podataka o racunu";
            return View(racun);
        }

    }
}