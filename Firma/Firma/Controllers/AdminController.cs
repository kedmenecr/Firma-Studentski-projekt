using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Firma.Models;
using Firma.Models.PoslovnaLogika;

namespace Firma.Controllers
{
    public class AdminController : Controller
    {
        private bazaContext racundb = new bazaContext();
        private bazaContext artikli_odabirdb = new bazaContext();

        private bazaContext zaposleniciDb = new bazaContext();
        private bazaContext racuniDB = new bazaContext();

        // GET: Admin

        public ActionResult Pop2()
        {
            var artikli = from a in racundb.artikli select a;
            var zap = zaposleniciDb.zaposlenik.ToList().Find(x => x.id_zaposlenik == 1);
            ViewBag.Zap = zap.ime + " " + zap.prezime;
            var odabirArtikla = artikli_odabirdb.artikli.ToList();
            ViewBag.Art_oda = odabirArtikla;
            return View(artikli);
            
        }

        public ActionResult Popis()
        {
            var popis = from s in artikli_odabirdb.artikli select s;
            ViewBag.Title = "Popis proizvoda";
            return View(popis);
        }
        public ActionResult Azuriraj(int? Id)
        {
            Admin s;
            //vracanje ako je id null
            if (Id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                s = new Admin();
                ViewBag.Title = "Upis novog studenta";

            }
            else
            {
                s = racundb.admini.Find(Id);
                //nadji prvog studenta koji ima jedna id
                if (s == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Title = "Ažuriranje podataka o studentu";

            }
            

            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(
            [Bind(Include = "id_admin,ime")] Admin s)
        {

            //provjera datum
          
            if (ModelState.IsValid)
            {
                if (s.id_admin != 0)
                {
                    racundb.Entry(s).State = EntityState.Modified;

                }
                else
                {
                    racundb.admini.Add(s);

                }
                racundb.SaveChanges();
                return RedirectToAction("Popis");
            }
          
            ViewBag.Title = "Ažuriranje podataka o studentu";
            return View(s);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}