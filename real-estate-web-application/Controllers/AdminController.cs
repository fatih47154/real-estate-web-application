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
            try
            {
                string date = DateTime.Now.ToShortDateString();
                konutDetay yeniKonutDetay = new konutDetay();
                yeniKonutDetay = detayVeri;
                yeniKonutDetay.ilanID = ilanVeri.ilanID;
                db.konutDetay.Add(yeniKonutDetay);

                Ilan yeniIlan = new Ilan();
                yeniIlan = ilanVeri;
                yeniIlan.tarih = Convert.ToDateTime(date);

                db.Ilan.Add(yeniIlan);
                db.SaveChanges();

                TempData["a"] = ilanVeri.baslik+" Başlıklı İlan Eklendi.";
            }
            catch (Exception)
            {
                TempData["a"] = "İlan Silinirken Bir Hata Ortaya Çıktı";
            }

            return RedirectToAction("ilanListele");
        }

        public ActionResult konutSil(int ilanID)
        {
            Ilan ilan = db.Ilan.FirstOrDefault(x => x.ilanID == ilanID);
            konutDetay detay = db.konutDetay.FirstOrDefault(x => x.ilanID == ilanID);

            try
            {
                db.Ilan.Remove(ilan);
                db.konutDetay.Remove(detay);
                db.SaveChanges();
                TempData["a"] = ilan.baslik + " Başlıklı İlan Silindi";
            }
            catch (Exception)
            {
                TempData["a"] = "İlan Silinirken Bir Hata Ortaya Çıktı";
            }

            return RedirectToAction("ilanListele");
        }
    }
}