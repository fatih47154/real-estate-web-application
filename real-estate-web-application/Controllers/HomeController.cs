using real_estate_web_application.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            var rsm = db.Resim.ToList();
            ViewBag.kullaniciSayisi = kln.LongCount();
            ViewBag.ilanSayisi = ilanlar.LongCount();
            ViewBag.yorumSayisi = yorum.LongCount();
            ViewBag.resim = rsm;          
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
            List<Ilan> kiralikIlanlar = db.Ilan.Where(x => x.durum == "kiralik").ToList();
            List<Resim> resimler = db.Resim.Where(x => x.vitrinResim == true).ToList();
            ViewBag.kiralikIlanlar = kiralikIlanlar;
            ViewBag.resim = resimler;
            return View();
        }
        public ActionResult Satilik()
        {
            List<Ilan> satilikIlanlar = db.Ilan.Where(x => x.durum == "satilik").ToList();
            List<Resim> resimler = db.Resim.Where(x => x.vitrinResim == true).ToList();
            ViewBag.satilikIlanlar = satilikIlanlar;
            ViewBag.resim = resimler;
            return View();
        }
        public ActionResult Ilanlar()
        {
            var rsm = db.Resim.ToList();
            ViewBag.resim = rsm;
            List<Ilan> ilan = db.Ilan.ToList();
            return View(ilan);
        }

        public ActionResult ilanDetay(int id)
        {
            ViewBag.siteDetay = db.SiteOzellikleri.FirstOrDefault(x=>x.siteID == 1);
            ViewBag.admin = db.Kullanicilar.FirstOrDefault(x => x.admin == true);
            ViewBag.ilan = db.Ilan.FirstOrDefault(x => x.ilanID == id);
            ViewBag.detay = db.konutDetay.FirstOrDefault(x => x.ilanID == id);
            List<Resim> resim = db.Resim.Where(x=>x.ilanID == id).ToList();
            List<Resim> resimm = new List<Resim>();
            foreach (var item in resim)
            {  
                resimm.Add(item);
            }
            ViewBag.resim = resimm;

            List<yorum> yorum = new List<yorum>();
            yorum = db.yorum.Where(x => x.onay == true).ToList();
            


            return View(yorum);
        }

        public ActionResult kullaniciKayit(Kullanicilar kullaniciVeri, HttpPostedFileBase resim)
        {
            var k = db.Kullanicilar.FirstOrDefault(x => x.kullaniciAdi == kullaniciVeri.kullaniciAdi);
            if(k == null)
            {
                Kullanicilar yeniKullanici = new Kullanicilar();
                yeniKullanici = kullaniciVeri;
                
                if (resim != null)
                {
                    Image img = Image.FromStream(resim.InputStream);
                    string url = "/images/" + Guid.NewGuid() + Path.GetExtension(resim.FileName);
                    img.Save(Server.MapPath(url));
                    
                        Resim yeniRsm = new Resim();
                        yeniRsm.resimUrl = url;
                        db.Resim.Add(yeniRsm);
                        db.SaveChanges();
                        yeniKullanici.resimID = yeniRsm.resimID;
                        db.Kullanicilar.Add(yeniKullanici);
                        db.SaveChanges();
                    
                }
                TempData["a"] = kullaniciVeri.ad + " İsimli Kullanıcı Kaydedildi .";
            }
            else
            {
                TempData["a"] = kullaniciVeri.kullaniciAdi + " Kullanıcı Adı Kullanılıyor .";
            }
            return RedirectToAction("");
        }

        [HttpPost]
        public ActionResult girisYap(string kullaniciAdi, string sifre)
        {
            emlakDB db = new emlakDB();
            Kullanicilar k = db.Kullanicilar.Where(x => x.kullaniciAdi == kullaniciAdi && x.sifre == sifre && x.admin == true).SingleOrDefault();
            if (k == null)
            {
                TempData["a"] = "Kullanıcı Bulunamadı !!";
                return View();
            }
            else
            {
                Session["HomeKullanici"] = k;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult cikisYap()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult yorumYap(yorum yorumVeri)
        {
            yorum yeniYorum  = new yorum();
            string date = DateTime.Now.ToShortDateString();
            yeniYorum = yorumVeri;
            yeniYorum.eklenmeTarihi = Convert.ToDateTime(date);
            db.yorum.Add(yeniYorum);
            db.SaveChanges();
            return RedirectToAction("ilanDetay" , yorumVeri.ilanID);
        }



    }
}