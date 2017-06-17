﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Firma.Controllers
{
    [Authorize(Roles ="Admin, Zaposlenik")]
    public class RacunController : Controller
    {
        // GET: Racun
        public ActionResult Index()
        {
            return View();
        }
    }
}