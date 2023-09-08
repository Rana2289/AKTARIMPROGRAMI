using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AKTARIMPROGRAMI.Models;

namespace AKTARIMPROGRAMI.Controllers
{
    public class anaSayfaController : Controller
    {
        private AktarimEntities db = new AktarimEntities(); // DbContext nesnenizi burada oluşturun.

        public ActionResult Index()
        {
            var veriler = db.users.ToList(); // users tablosundaki verileri çekin.

            return View(veriler);
        }
        public ActionResult veriler()
        {
            return View();
        }
    }
}