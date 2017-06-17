using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Firma.Models;
using System.IO;
using Firma.Models.PoslovnaLogika;

namespace Firma.Controllers
{
    [Authorize(Roles ="Admin, Zaposlenik")]
    public class PartneriController : Controller
    {
        private bazaContext dB = new bazaContext();
        // GET: Partneri
        public ActionResult Index()
        {
            ViewBag.Title = "Baza poslovnih partnera";
            return View();
        }

        // Ažuriranje podataka o studentu
        // GET: Student/Azuriraj/1
        // Metoda koja se poziva prilikom http GET requesta
        public ActionResult Azuriraj(int? id)
        {
            Poslovni_partner p;

            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                // Iskoristiti ćemo pozivanje Azuriraj metode bez Id-a za upis novog studenta.
                p = new Poslovni_partner();
                ViewBag.Title = "Upis novog zaposlenika";
            }
            else
            {
                p = dB.poslovni_partner.Find(id);
                if (p == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Title = "Ažuriranje podataka o poslovnome partneru";
            }


            return View(p);
        }

        // Preopterećujemo (overloading) Azuriraj() metodu. 
        // Metoda koja se poziva prilikom http POST requesta.
        // Atribut Bind je drugi sigurnosni mehanizam koji onemogućava znonamjerno
        // mijenjanje atributa koji nisu za to predviđeni (over-posting).
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(
            [Bind(Include = "id_poslovni_partner,naziv,adresa,oib,telefon,email,oznaka_banke,SWIFT_broj_banke,podaci_o_osnivanju,naziv_odgovorne_osobe")] Poslovni_partner p)
        {

            // provjera da li je model prošao validaciju
            if (ModelState.IsValid)
            {
                if (p.id_poslovni_partner != 0)
                {
                    // EF - označavanje da je zapis izmjenjen i da se treba napraviti update.
                    // Treba eksplicitno označiti ako je entitet kreiran izvan postojećeg koteksta.
                    dB.Entry(p).State = EntityState.Modified;
                }
                else
                {
                    // EF - upis novog zapisa u bazu podataka

                    // Sve ovo nam ne treba ako koristimo Auto Increment opciju na MySql bazi
                    // int noviId;
                    // // ako tablica nije prazna
                    // if (studentiDb.Studenti.Any())
                    //     noviId = (from st in studentiDb.Studenti select st).Max(x => x.Id) + 1;
                    // else
                    //     noviId = 1;
                    // s.Id = noviId;

                    dB.poslovni_partner.Add(p);
                }
                dB.SaveChanges();

                return RedirectToAction("Popis");
            }

            ViewBag.Title = "Ažuriranje podataka o artiklu";
            return View(p);
        }

        // Brisanje studenta
        // GET metoda
        public ActionResult Obrisi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poslovni_partner p = dB.poslovni_partner.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "Brisanje studenta";
            return View(p);
        }

        // POST
        // Pošto get i post metode imaju isti potpis, post metodu smo nazvali drugačije
        // ali smo u atributima metode naveli o kojoj se akcijskoj metodi radi.
        [HttpPost, ActionName("Obrisi")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiPotvrda(int id)
        {
            // EF delete
            Poslovni_partner p = dB.poslovni_partner.Find(id);
            dB.poslovni_partner.Remove(p);
            dB.SaveChanges();
            // EF EOF delete
            return RedirectToAction("Popis");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // više na http://en.wikipedia.org/wiki/List_of_HTTP_status_codes
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // EF - dohvat sloga po ID-u
            Poslovni_partner p = dB.poslovni_partner.Find(id);
            if (p == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                // ili ovako kraće
                return HttpNotFound();
            }
            // Vraćamo view sa modelom kao ulaznim parametrom
            ViewBag.Title = "Detaljno o studentu";
            return View(p);
        }
        public ActionResult Popis(string naziv)
        {

            var popis = from a in dB.poslovni_partner select a;
            // filtriranja
            if (!String.IsNullOrEmpty(naziv))
                popis = popis.Where(st => (st.naziv).ToUpper().Contains(naziv.ToUpper()));
            return View(popis);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}



