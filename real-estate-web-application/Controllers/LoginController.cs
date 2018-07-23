using real_estate_web_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace real_estate_web_application.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string kullaniciAdi,string sifre)
        {
            emlakDB db = new emlakDB();
            Kullanicilar k = db.Kullanicilar.Where(x => x.kullaniciAdi == kullaniciAdi && x.sifre == sifre && x.admin == true).SingleOrDefault();
            if(k == null)
            {
                TempData["a"] = "Kullanıcı Bulunamadı !!";
                return View();
            }
            else
            {
                Session["Kullanici"] = k;
                return RedirectToAction("Index", "Admin");
            }
        }
        
    }
    }
