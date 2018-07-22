using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using real_estate_web_application.Models;

namespace real_estate_web_application.Controllers
{
    public class AdminController : Controller
    {
        emlakDB db = new emlakDB();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult siteOzellikleri()
        {
            var goster = db.SiteOzellikleri.ToList();
            var a = goster.FirstOrDefault(x => x.siteID == 1);
            ViewBag.siteOzellikleri = a;
            return View();
        }

        public ActionResult kullaniciListele()
        {
            var kln = db.Kullanicilar.ToList();
            ViewBag.Kullanicilar = kln;
            return View();
        }

        [HttpPost]
        public void kullaniciSil(int id)
        {
            Kullanicilar k = db.Kullanicilar.FirstOrDefault(x => x.kullaniciID == id);
            db.Kullanicilar.Remove(k);
            db.SaveChanges();            
        }

        [HttpPost]
        public void adminSil(int id)
        {
            Kullanicilar k = db.Kullanicilar.FirstOrDefault(x => x.kullaniciID == id);
            db.Kullanicilar.Remove(k);
            db.SaveChanges();
        }

        public ActionResult ilanListele()
        {
            ViewBag.ilanlar = db.Ilan.ToList();
            return View();
        }

        //Bitmedi
        public ActionResult ilanSil(int ilanID)
        {
            Ilan ilan = db.Ilan.FirstOrDefault(x => x.ilanID == ilanID);
            
            db.Ilan.Remove(ilan);
            db.SaveChanges();
            return RedirectToAction("ilanListele");
        }

        public ActionResult konutEkle()
        {
            ViewBag.iller = db.il.OrderBy(x => x.IL_ADI).ToList();
            ViewBag.ilceler = db.ilce.ToList();
            ViewBag.semtler = db.semt.ToList();
            ViewBag.mahalleKoyler = db.mahalle_koy.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult konutEkle(Ilan ilanVeri,konutDetay detayVeri)
        {
            db.konutDetay.Add(detayVeri);
            db.Ilan.Add(ilanVeri);
            db.SaveChanges();
            return RedirectToAction("ilanListele");
        }
    }
}