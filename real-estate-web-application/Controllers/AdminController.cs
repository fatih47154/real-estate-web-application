using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using real_estate_web_application.Models;
using System.Drawing;
using System.IO;

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

        [HttpPost]
        public ActionResult siteOzellikleri(SiteOzellikleri veri, HttpPostedFileBase resim)
        {
            SiteOzellikleri degisecekVeri = db.SiteOzellikleri.Where(x => x.siteID == 1).SingleOrDefault();
            if (resim != null)
            {
                Image img = Image.FromStream(resim.InputStream);

                string url = "/images/" + Guid.NewGuid() + Path.GetExtension(resim.FileName);
                img.Save(Server.MapPath(url));

                degisecekVeri.email = veri.email;
                degisecekVeri.ad = veri.ad;
                degisecekVeri.cepTel = veri.cepTel;
                degisecekVeri.telefon = veri.telefon;
                degisecekVeri.hakkimizda = veri.hakkimizda;
                degisecekVeri.misyon = veri.misyon;
                degisecekVeri.adres = veri.adres;

                Resim rsm = db.Resim.Where(x => x.resimID == veri.resimID).SingleOrDefault();
                if (rsm == null)
                {
                    Resim yeniRsm = new Resim();
                    yeniRsm.resimUrl = url;
                    db.Resim.Add(yeniRsm);
                    db.SaveChanges();
                    degisecekVeri.resimID = yeniRsm.resimID;
                    db.SaveChanges();
                }
                else
                {
                    rsm.resimUrl = url;
                    degisecekVeri.resimID = rsm.resimID;
                    db.SaveChanges();
                }
            }
            else
            {
                degisecekVeri = veri;
                db.SaveChanges();
            }

            return RedirectToAction("siteOzellikleri");
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
            
            
            try
            {
                
                TempData["b"] =k.ad+" "+k.soyad+" İsimli Admin Silindi";
                db.Kullanicilar.Remove(k);
                db.SaveChanges();
            }
            catch (Exception)
            {

                
            }
            //return RedirectToAction("kullaniciListele");

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

        public ActionResult konutDuzenle(int ilanID)
        {
            Ilan ilan = db.Ilan.FirstOrDefault(x => x.ilanID == ilanID);
            konutDetay detay = db.konutDetay.FirstOrDefault(x => x.ilanID == ilanID);

            ViewBag.iller = db.il.OrderBy(x => x.IL_ADI).ToList();
            ViewBag.ilceler = db.ilce.ToList();
            ViewBag.semtler = db.semt.ToList();
            ViewBag.mahalleKoyler = db.mahalle_koy.ToList();

            ViewBag.ilan = ilan;
            ViewBag.detay = detay;
            return View();
        }


        [HttpPost]
        public ActionResult konutDuzenle(int ilanID,Ilan ilanVeri, konutDetay detayVeri)
        {
            var ilan = db.Ilan.FirstOrDefault(x => x.ilanID == ilanID);
            var detay = db.konutDetay.FirstOrDefault(x => x.ilanID == ilanID);
            
            ilan = ilanVeri;
            ilan.baslik = ilanVeri.baslik;
            string date = DateTime.Now.ToShortDateString();
            ilan.tarih = Convert.ToDateTime(date);
            detay = detayVeri;
            db.SaveChanges();


            return RedirectToAction("ilanListele");
        }
    }
}