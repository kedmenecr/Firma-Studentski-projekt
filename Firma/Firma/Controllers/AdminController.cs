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
        private bazaContext adminiDb = new bazaContext();

        private bazaContext zaposleniciDb = new bazaContext();

        // GET: Admin

            public ActionResult Pop2()
        {
            var zap = from z in zaposleniciDb.zaposlenik select z;

            return View(zap);
        }
 
        public ActionResult Popis()
        {
            var popis = from s in adminiDb.admini select s;
            ViewBag.Title = "Popis admina";
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
                s = adminiDb.admini.Find(Id);
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
                    adminiDb.Entry(s).State = EntityState.Modified;

                }
                else
                {
                    adminiDb.admini.Add(s);

                }
                adminiDb.SaveChanges();
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