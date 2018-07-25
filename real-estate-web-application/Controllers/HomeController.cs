using real_estate_web_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace real_estate_web_application.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        emlakDB db = new emlakDB();
        public ActionResult Index()
        {
            var kln = db.Kullanicilar.ToList();            
            var ilanlar = db.Ilan.ToList();
            var yorum = db.yorum.ToList();
            ViewBag.kullaniciSayisi = kln.LongCount();
            ViewBag.ilanSayisi = ilanlar.LongCount();
            ViewBag.yorumSayisi = yorum.LongCount();           
            ViewBag.iln = ilanlar;
            
                      
                                 
            return View();
        }
        public ActionResult Hakkimizda()
        {
            List<SiteOzellikleri> site = db.SiteOzellikleri.ToList();            
            return View(site);  
        }
        public ActionResult Kiralik()
        {
            List<Ilan> ilan = db.Ilan.ToList();
            return View(ilan);
        }
        public ActionResult Satilik()
        {
            List<Ilan> satilikIlanlar = db.Ilan.Where(x => x.durum == "satilik").ToList();
            ViewBag.satilikIlanlar = satilikIlanlar;
            return View();
        }
        public ActionResult Ilanlar()
        {
            List<Ilan> ilan = db.Ilan.ToList();
            return View(ilan);
        }

        public ActionResult ilanDetay(int id)
        {
            ViewBag.siteDetay = db.SiteOzellikleri.FirstOrDefault(x=>x.siteID == 1);
            ViewBag.admin = db.Kullanicilar.FirstOrDefault(x => x.admin == true);
            ViewBag.ilan = db.Ilan.FirstOrDefault(x => x.ilanID == id);
            ViewBag.detay = db.konutDetay.FirstOrDefault(x => x.ilanID == id);
            List<Resim> resim = db.Resim.ToList();
            List<Resim> resimm = new List<Resim>();
            foreach (var item in resim)
            {  
                resimm.Add(item);
            }
            ViewBag.resim = resimm;
            List<Ilan> yorumlar = db.Ilan.Where(x => x.ilanID == id).ToList();
            ViewBag.yorumlar = yorumlar;
            return View();
        }
    }
}