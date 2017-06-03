﻿using System;
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
    public class AdminController : Controller
    {
        private bazaContext dB = new bazaContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Title = "Baza zaposlenika";
            return View();
        }

        // Ažuriranje podataka o studentu
        // GET: Student/Azuriraj/1
        // Metoda koja se poziva prilikom http GET requesta
        public ActionResult Azuriraj(int? id)
        {
            Zaposlenik z;

            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                // Iskoristiti ćemo pozivanje Azuriraj metode bez Id-a za upis novog studenta.
                z = new Zaposlenik();
                ViewBag.Title = "Upis novog zaposlenika";
            }
            else
            {
                z = dB.zaposlenik.Find(id);
                if (z == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Title = "Ažuriranje podataka o zaposleniku";
            }


            return View(z);
        }

        // Preopterećujemo (overloading) Azuriraj() metodu. 
        // Metoda koja se poziva prilikom http POST requesta.
        // Atribut Bind je drugi sigurnosni mehanizam koji onemogućava znonamjerno
        // mijenjanje atributa koji nisu za to predviđeni (over-posting).
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(
            [Bind(Include = "id_zaposlenik,ime,prezime,prezime,adresa,mobitel,lozinka")] Zaposlenik z)
        {

            // provjera da li je model prošao validaciju
            if (ModelState.IsValid)
            {
                if (z.id_zaposlenik != 0)
                {
                    // EF - označavanje da je zapis izmjenjen i da se treba napraviti update.
                    // Treba eksplicitno označiti ako je entitet kreiran izvan postojećeg koteksta.
                    dB.Entry(z).State = EntityState.Modified;
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

                    dB.zaposlenik.Add(z);
                }
                dB.SaveChanges();

                return RedirectToAction("Popis");
            }

            ViewBag.Title = "Ažuriranje podataka o zaposleniku";
            return View(z);
        }

        // Brisanje studenta
        // GET metoda
        public ActionResult Obrisi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposlenik z = dB.zaposlenik.Find(id);
            if (z == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "Brisanje studenta";
            return View(z);
        }

        // POST
        // Pošto get i post metode imaju isti potpis, post metodu smo nazvali drugačije
        // ali smo u atributima metode naveli o kojoj se akcijskoj metodi radi.
        [HttpPost, ActionName("Obrisi")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiPotvrda(int id)
        {
            // EF delete
            Zaposlenik z = dB.zaposlenik.Find(id);
            dB.zaposlenik.Remove(z);
            dB.SaveChanges();
            // EF EOF delete
            return RedirectToAction("Popis");
        }

        public ActionResult Popis(string naziv)
        {

            var popis = from s in dB.zaposlenik select s;
            // filtriranja
            if (!String.IsNullOrEmpty(naziv))
                popis = popis.Where(st => (st.ime + " " + st.prezime).ToUpper().Contains(naziv.ToUpper()));
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
