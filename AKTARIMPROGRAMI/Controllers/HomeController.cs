using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AKTARIMPROGRAMI.Models;


namespace AKTARIMPROGRAMI.Controllers
{
    public class HomeController : Controller
    {
       
      
        public ActionResult Login()
        {
         
            return View();
        }

        // Giriş sayfası verilerini işlemek için Post işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(users model)
        {
            AktarimEntities aktarımdb = new AktarimEntities();
            if (model.nameSurname == null)
            {
                ViewBag.Visibility = "hidden";
                ViewBag.UserDolu = "hidden";
                return View();
            }
            else
            {

                var user = aktarımdb.users.Where(m => m.password == model.password && m.nameSurname == model.nameSurname).FirstOrDefault();
                if (user != null)
                {
                    Session["UserName"] = user.nameSurname;
                    Session["UserId"] = user.id;
                    Session["password"] = user.password;

                    return RedirectToAction("Index", "anaSayfa");
                }
                else
                {
                    ViewBag.Visibility = "visible";
                    return View();
                }
            }
            //if (ModelState.IsValid)
            //{
            //    // Burada kullanıcı adı ve şifre doğrulaması yapabilirsiniz.
            //    // Örnek olarak, basit bir doğrulama yapalım.
            //    if (Session["UserName"] == model.nameSurname && model.password == Session["password"])
            //    {
            //        // Kullanıcı başarılı bir şekilde giriş yaptıysa bir işlem yapabilirsiniz.
            //        // Örneğin, başka bir sayfaya yönlendirebilirsiniz.
            //        return RedirectToAction("Index", "anaSayfa");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış!");
            //    }
            //}

            return View(model);
        }
    }
}