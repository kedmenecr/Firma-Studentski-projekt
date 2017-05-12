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
        public ActionResult Index(int? idArt)
        {
            //proslijeđujemo artikli ,zaposlenika i firmu koja plača
            var art = artikliDb.artikli.ToList().Find(x => x.id_artikla == idArt);

            var artDrop = artikliDb.artikli.ToList();
            
            ViewBag.artDrop = artDrop;

            var zap = zaposleniciDb.zaposlenik.ToList().Find(x => x.id_zaposlenik == 1);
            ViewBag.Zap = zap.ime + " " + zap.prezime;
            
            return View(art);
        }
        public ActionResult OdabirPartnera(int idPar)
        {

            var par = poslovnipartnetDb.poslovniparner.ToList().Find(x => x.id_poslovni_partner == idPar);
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
                racun = racuniDb.racun.Find(Id);
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
                    racuniDb.racun.Add(racun);

                }
                racuniDb.SaveChanges();
                
            }
            
            ViewBag.Title = "Ažuriranje podataka o racunu";
            return View(racun);
        }

    }
}