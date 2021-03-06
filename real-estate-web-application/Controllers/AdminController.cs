﻿using System;
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

            var kullanıcılar = db.Kullanicilar.ToList();
            ViewBag.kullaniciSayisi = kullanıcılar.LongCount();
            var ilanlar = db.Ilan.ToList();
            ViewBag.ilanSayisi = ilanlar.LongCount();
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
                
                TempData["b"] =k.ad+" "+k.soyad+" İsimli Kullanıcı Silindi";
                db.Kullanicilar.Remove(k);
                db.SaveChanges();
            }
            catch (Exception)
            {

                TempData["b"] = "Kullanıcı Silinirken Bir Hata Ortaya Çıktı";
            }          
        }

        public ActionResult kullaniciDuzenle(int id)
        {
            ViewBag.guncellenenAdmin = db.Kullanicilar.FirstOrDefault(x => x.kullaniciID == id);            
           
            return View();
        }

        [HttpPost]
        public ActionResult kullaniciDuzenle(int id,Kullanicilar guncellenenAdmin, HttpPostedFileBase kullaniciResim)
        {
            

            Kullanicilar kln = db.Kullanicilar.FirstOrDefault(x => x.kullaniciID == id);
            
            
            if (kullaniciResim != null)
            {
                Image img = Image.FromStream(kullaniciResim.InputStream);
                string url = "/images/" + Guid.NewGuid() + Path.GetExtension(kullaniciResim.FileName);
                img.Save(Server.MapPath(url));
                Resim rsm = db.Resim.Where(x => x.resimID == guncellenenAdmin.resimID).SingleOrDefault();
                if (rsm == null)
                {
                    kln.ad = guncellenenAdmin.ad;
                    kln.soyad = guncellenenAdmin.soyad;
                    kln.kullaniciAdi = guncellenenAdmin.kullaniciAdi;
                    kln.telefon = guncellenenAdmin.telefon;

                    Resim yeniRsm = new Resim();
                    yeniRsm.resimUrl = url;
                    kln.resimID = yeniRsm.resimID;
                    db.Resim.Add(yeniRsm);
                    db.SaveChanges();
                }
                else
                {
                    rsm.resimUrl = url;
                    kln.resimID = rsm.resimID;
                    db.SaveChanges();

                }
            }
            TempData["b"] = kln.ad + " " + kln.soyad + " isimli Admin Güncellendi";
            db.SaveChanges();            
            return RedirectToAction("kullaniciListele");
            
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
        public ActionResult konutEkle(Ilan ilanVeri,konutDetay detayVeri,HttpPostedFileBase vitrinResim, HttpPostedFileBase resim1, HttpPostedFileBase resim2, HttpPostedFileBase resim3, HttpPostedFileBase resim4)
        {
          
                
                string date = DateTime.Now.ToShortDateString();
                konutDetay yeniKonutDetay = new konutDetay();
                yeniKonutDetay = detayVeri;
                yeniKonutDetay.ilanID = ilanVeri.ilanID;
                db.konutDetay.Add(yeniKonutDetay);

                Ilan yeniIlan = new Ilan();
                yeniIlan = ilanVeri;
                yeniIlan.tarih = Convert.ToDateTime(date);

                List<HttpPostedFileBase> resimler = new List<HttpPostedFileBase>();
                resimler.Add(vitrinResim);
                resimler.Add(resim1);
                resimler.Add(resim2);
                resimler.Add(resim3);
                resimler.Add(resim4);
                bool a = true;
                foreach (var item in resimler)
                {
                    
                    Image img = Image.FromStream(item.InputStream);
                    string url = "/images/" + Guid.NewGuid() + Path.GetExtension(item.FileName);
                    img.Save(Server.MapPath(url));

                    Resim yeniRsm = new Resim();
                    yeniRsm.resimUrl = url;
                    yeniRsm.vitrinResim = a;
                    yeniRsm.ilanID = ilanVeri.ilanID;
                    db.Resim.Add(yeniRsm);
                    a = false;
                }

                db.Ilan.Add(yeniIlan);
                db.SaveChanges();

                TempData["a"] = ilanVeri.baslik+" Başlıklı İlan Eklendi.";
            
            

            return RedirectToAction("ilanListele");
        }

        

        //public ActionResult konutSil(int ilanID)
        //{
        //    Ilan ilan = db.Ilan.FirstOrDefault(x => x.ilanID == ilanID);
        //    konutDetay detay = db.konutDetay.FirstOrDefault(x => x.ilanID == ilanID);

        //    try
        //    {
        //        db.Ilan.Remove(ilan);
        //        db.konutDetay.Remove(detay);
        //        db.SaveChanges();
        //        TempData["a"] = ilan.baslik + " Başlıklı İlan Silindi";
        //    }
        //    catch (Exception)
        //    {
        //        TempData["a"] = "İlan Silinirken Bir Hata Ortaya Çıktı";
        //    }

        //    return RedirectToAction("ilanListele");
        //}

        [HttpPost]
        public void ilanSil(int id)
        {
            Ilan kx = db.Ilan.FirstOrDefault(x => x.ilanID == id);            
            List<Resim> rsm = db.Resim.Where(x => x.ilanID == id).ToList();
            List<yorum> yrm = db.yorum.Where(x => x.ilanID == id).ToList();
            konutDetay kd = db.konutDetay.FirstOrDefault(x => x.ilanID == id);
            if (rsm!=null)
            {
                foreach (Resim item in rsm)
                {
                    db.Resim.Remove(item);
                }             

            }
            if (kd != null)
            {
                foreach (yorum item1 in yrm)
                {
                    db.yorum.Remove(item1);
                    
                }
            }

            if (kd != null)
            {
                db.konutDetay.Remove(kd);
            }


            db.SaveChanges();
            try
            {

                TempData["a"] = kx.baslik + " başlıklı ilan Silindi";
                db.Ilan.Remove(kx);
                db.SaveChanges();
            }
            catch (Exception)
            {

                TempData["a"] = "İlan Silinirken Bir Hata Ortaya Çıktı";
            }
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
            Ilan ilan = db.Ilan.Where(x => x.ilanID == ilanID).SingleOrDefault();
            konutDetay detay = db.konutDetay.Where(x => x.ilanID == ilanID).SingleOrDefault();
            

            ilan.aciklama = ilanVeri.aciklama;
            ilan.baslik = ilanVeri.baslik;
            ilan.durum = ilanVeri.durum;
            ilan.fiyat = ilanVeri.fiyat;
            if(ilanVeri.ILCE_ID != 0)
            { 
                ilan.ILCE_ID = ilanVeri.ILCE_ID;
            }
            if (ilanVeri.IL_ID != null)
            {
                ilan.IL_ID = ilanVeri.IL_ID;
            }
            ilan.kategoriID = ilanVeri.kategoriID;
            if (ilanVeri.MAH_ID != null)
            {
                ilan.MAH_ID = ilanVeri.MAH_ID;
            }
            ilan.metrekare = ilanVeri.metrekare;
            if (ilanVeri.SEMT_ID != null)
            {
                ilan.SEMT_ID = ilanVeri.SEMT_ID;
            }
            ilan.vitrin = ilanVeri.vitrin;
            string date = DateTime.Now.ToShortDateString();
            ilan.tarih = Convert.ToDateTime(date);

            detay.aidat = detayVeri.aidat;
            detay.alaturkaTuvalet = detayVeri.alaturkaTuvalet;
            detay.amerikanMutfak = detayVeri.amerikanMutfak;
            detay.anayol = detayVeri.anayol;
            detay.ankastreMutfak = detayVeri.ankastreMutfak;
            detay.araKat = detayVeri.araKat;
            detay.asansor = detayVeri.asansor;
            detay.bahceKati = detayVeri.bahceKati;
            detay.balkon = detayVeri.balkon;
            detay.banyoSayisi = detayVeri.banyoSayisi;
            detay.belediye = detayVeri.belediye;
            detay.binaYasi = detayVeri.binaYasi;
            detay.bulunduguKat = detayVeri.bulunduguKat;
            detay.cadde = detayVeri.cadde;
            detay.cami = detayVeri.cami;
            detay.dubleks = detayVeri.dubleks;
            detay.dusakabin = detayVeri.dusakabin;
            detay.esyali = detayVeri.esyali;
            detay.fiberInternet = detayVeri.fiberInternet;
            detay.goruntuluDiafon = detayVeri.goruntuluDiafon;
            detay.guvenlik = detayVeri.guvenlik;
            detay.hastane = detayVeri.hastane;
            detay.havuz = detayVeri.havuz;
            detay.hirsizAlarm = detayVeri.hirsizAlarm;
            detay.isicam = detayVeri.isicam;
            detay.isitma = detayVeri.isitma;
            detay.isiYalitim = detayVeri.isiYalitim;
            detay.kapaliGaraj = detayVeri.kapaliGaraj;
            detay.kapici = detayVeri.kapici;
            detay.katSayisi = detayVeri.katSayisi;
            detay.krediyeUygun = detayVeri.krediyeUygun;
            detay.laminat = detayVeri.laminat;
            detay.market = detayVeri.market;
            detay.minibus = detayVeri.minibus;
            if (detayVeri.odaSayisi != "default")
            {
                detay.odaSayisi = detayVeri.odaSayisi;
            }
            detay.okul = detayVeri.okul;
            detay.otobusDuragi = detayVeri.otobusDuragi;
            detay.otopark = detayVeri.otopark;
            detay.oyunParki = detayVeri.oyunParki;
            detay.park = detayVeri.park;
            detay.sehirMerkezi = detayVeri.sehirMerkezi;
            detay.sesYalitim = detayVeri.sesYalitim;
            detay.siteIcerisinde = detayVeri.siteIcerisinde;
            detay.somine = detayVeri.somine;
            detay.sporAlani = detayVeri.sporAlani;
            detay.takas = detayVeri.takas;
            detay.uydu = detayVeri.uydu;
            detay.yanginAlarm = detayVeri.yanginAlarm;
            
            db.SaveChanges();

            TempData["a"] = ilan.baslik + " Başlıklı İlan Güncellendi";
            return RedirectToAction("ilanListele");
        }
        public ActionResult cikisYap()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            ViewBag.TumYorumlar = db.yorum.OrderByDescending(x => x.yorumID).ToList();
            return View();
        }
        [HttpPost]
        public void YorumSil(int id)
        {
            yorum y = db.yorum.FirstOrDefault(x => x.yorumID == id);
            try
            {
                TempData["a"] = y.icerik + " içerikli yorum silinmiştir";
                db.yorum.Remove(y);
                db.SaveChanges();
            }
            catch (Exception)
            {

               
            }
           
            
        }
       
        public ActionResult YorumOnay(int id)
        {
            yorum y = db.yorum.FirstOrDefault(x => x.yorumID==id);
            y.onay =true;
            db.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumOnayGeri(int id)
        {
            yorum y = db.yorum.FirstOrDefault(x => x.yorumID == id);
            y.onay = false;
            db.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}