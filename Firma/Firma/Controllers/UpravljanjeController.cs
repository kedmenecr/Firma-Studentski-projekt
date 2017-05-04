using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Firma.Models;
using Firma.Models.PoslovnaLogika;

namespace Firma.Controllers
{
    public class 
        UpravljanjeController : Controller
    {
        private bazaContext artikliDb = new bazaContext();
        

        // GET: Upravljanje
        public ActionResult Index()
        {
            var artikli = from z in artikliDb.artikli select z;
            return View(artikli);
        }

        public ActionResult Unos()
        {

            return View();
        }


    }
}