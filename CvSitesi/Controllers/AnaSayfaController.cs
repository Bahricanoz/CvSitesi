using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvSitesi.Models.Entity;
namespace CvSitesi.Controllers
{
    [AllowAnonymous]
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        DboCvEntities db = new DboCvEntities();
        // Hakkımda Listesi
        public ActionResult Index()
        {
            var hakkimda = db.Tbl_Hakkımda.ToList();
            return View(hakkimda);
        }
        // Deneyimlerim
        public PartialViewResult Deneyimlerim()
        {
            var deneyimlerim = db.Tbl_Deneyimlerim.OrderByDescending(x=>x.Id).Where(x=>x.Durum == true).ToList();
            return PartialView(deneyimlerim);
        }
        // Eğtim hayatım
        public PartialViewResult Egitimhayatim()
        {
            var egitim = db.Tbl_Egitimhayati.OrderByDescending(x=>x.Id).ToList();
            return PartialView(egitim);
        }
        // yetenklerim
        public PartialViewResult Yeteneklerim()
        {
            var yetenek = db.Tbl_Yetenek.ToList();
            return PartialView(yetenek);
        }
        // projeler
        public PartialViewResult Projeler()
        {
            var proje = db.Tbl_Projelerim.Where(x=>x.Durum == true).ToList();
            return PartialView(proje);
        }
        // sertifikalar
        public PartialViewResult Sertifikalar()
        {
            var sertifika = db.Tbl_Sertifikalarim.ToList();
            return PartialView(sertifika);
        }
        // sosyalmedya
        public PartialViewResult Sosyalmedya()
        {
            var sosyalmedya = db.Tbl_Sosyalmedya.Where(x=>x.Durum == true).ToList();
            return PartialView(sosyalmedya);
        }
        // mesaj gönderme
        [HttpGet]
        public PartialViewResult Mesaj()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Mesaj(Tbl_Mesajlar p)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("Mesaj");
            }
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_Mesajlar.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }
}