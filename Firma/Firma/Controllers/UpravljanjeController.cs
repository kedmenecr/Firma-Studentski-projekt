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

        private bazaContext dB = new bazaContext();


        // GET: Upravljanje
        public ActionResult Index(int? id)
        {
            RacunViewModel rvm = new RacunViewModel();
            rvm.artikli = dB.artikli.ToList();
            rvm.partneri = dB.poslovni_partner.ToList();
            rvm.racuni = dB.racun.ToList();


           


            return View(rvm);
            //art
        }
        public ActionResult PopisPartnera()
        {
            var par = from z in dB.poslovni_partner select z;

            return View(par.SingleOrDefault());


        }
     


        //vrača nam popis svih artikala koje imamo na skladištu 
        public ActionResult PopisArtikla()
        {
            var artikli = from z in dB.artikli select z;

            ViewBag.Title = "Popis artikla";
            return View(artikli.SingleOrDefault());
        }
        public ActionResult PopisaPartnera1()
        {
            var artikli = from z in dB.artikli select z;

            ViewBag.Title = "Popis artikla";
            return View(artikli);
        }

        public ActionResult Azuriraj(int? Id)
        {
            RacunViewModel racun;

            if(Id == null)
            {
                racun = new RacunViewModel();
                ViewBag.Title = "Upis novog racuna";
            }
            else
            {
                //pronađi prvi račun
                //racun = dB.Find(Id);
                //if (racun == null)
                //{
                //    return HttpNotFound();
                //}
                ViewBag.Title = "Ažuriranje računa";
            }
            var racuntitle = dB.artikli.ToList();
            racuntitle.Add(new Artikli { id_artikla = 1 });
            ViewBag.RacunTitle = racuntitle;

            return View();
            //racun



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
                    dB.Entry(racun).State = EntityState.Modified;

                }
                else
                {
                    dB.faktura.Add(racun);

                }
                dB.SaveChanges();
                
            }
            
            ViewBag.Title = "Ažuriranje podataka o racunu";
            return View(racun);
        }

    }
}