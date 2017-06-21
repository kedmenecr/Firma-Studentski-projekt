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
    public class RacunController : Controller
    {
        private bazaContext dB = new bazaContext();
        // GET: Racun

        public ActionResult Index()
        {
            ViewBag.Title = "Baza računa";
            return View();
        }

        public ActionResult Details(int id)
        {
            var rvm = (from a in dB.racun
                       join c in dB.artikli on a.id_artikla equals c.id_artikla
                       join d in dB.poslovni_partner on a.id_poslovni_partner equals d.id_poslovni_partner
                       where a.id_racun == id
                       select new RacunViewModel()
                       {
                           racuni = a,
                           artikli = c,
                           partneri = d
                       }
                      ).SingleOrDefault();


            return View(rvm);
        }


        public ActionResult Unos()
        {
            var popis = from a in dB.artikli select a;
            var popis2 = from b in dB.poslovni_partner select b;
            var popis3 = from c in dB.racun select c;
            ViewBag.List = popis.ToList();
            ViewBag.List1 = popis2.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Unos([Bind(Include = "id_poslovni_partner, id_artikla")] Racun r)
        {
            dB.racun.Add(r);
            dB.SaveChanges();
            return RedirectToAction("Popis");
        }
        public ActionResult Azuriraj(int? id)
        {
            Racun r;

            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                // Iskoristiti ćemo pozivanje Azuriraj metode bez Id-a za upis novog studenta.
                r = new Racun();
                ViewBag.Title = "Upis novog zaposlenika";
            }
            else
            {
                r = dB.racun.Find(id);
                if (r == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Title = "Ažuriranje podataka o poslovnome partneru";
            }


            return View(r);
        }

        // Preopterećujemo (overloading) Azuriraj() metodu. 
        // Metoda koja se poziva prilikom http POST requesta.
        // Atribut Bind je drugi sigurnosni mehanizam koji onemogućava znonamjerno
        // mijenjanje atributa koji nisu za to predviđeni (over-posting).
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(
            [Bind(Include = "id_racun,id_artikla,id_poslovni_partner")] Racun r)
        {

            // provjera da li je model prošao validaciju
            if (ModelState.IsValid)
            {
                if (r.id_racun != 0)
                {
                    // EF - označavanje da je zapis izmjenjen i da se treba napraviti update.
                    // Treba eksplicitno označiti ako je entitet kreiran izvan postojećeg koteksta.
                    dB.Entry(r).State = EntityState.Modified;
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

                    dB.racun.Add(r);
                }
                dB.SaveChanges();

                return RedirectToAction("Popis");
            }

            ViewBag.Title = "Ažuriranje podataka o artiklu";
            return View(r);
        }
        public ActionResult Popis()
        {
            var popis = from a in dB.racun select a;
            return View(popis);
        }
        public ActionResult Edit()
        {
            var a = from b in dB.racun select b;
            return View(a);
        }



    }
}
