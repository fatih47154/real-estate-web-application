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
            List<Ilan> ilan = db.Ilan.ToList();
            return View(ilan);
        }
        public ActionResult Ilanlar()
        {
            List<Ilan> ilan = db.Ilan.ToList();
            return View(ilan);
        }
    }
}