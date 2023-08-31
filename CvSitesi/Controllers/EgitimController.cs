using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvSitesi.Models.Entity;
using CvSitesi.Repositoires;

namespace CvSitesi.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        DboCvEntities db = new DboCvEntities();
        EgitimRepository repo = new EgitimRepository();
        public ActionResult Index()
        {
            var egitim = repo.Tlist();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_Egitimhayati p)
        {
            repo.Tekle(p);
            return  RedirectToAction("Index");
        }
        public ActionResult sil(int id)
        {
           var bul= repo.Find(x=>x.Id == id);
            repo.Tsil(bul);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var bul = repo.Tgetir(id);
            return View("Guncelle", bul);
        }
        [HttpPost]
        public ActionResult Guncelle(Tbl_Egitimhayati p)
        {
            var deger = repo.Find(x => x.Id == p.Id);
            deger.Okulad = p.Okulad;
            deger.Tur = p.Tur;
            deger.Bolum = p.Bolum;
            deger.Notort = p.Notort;
            deger.Tarih = p.Tarih;
            repo.Tguncelle(deger);
            return RedirectToAction("Index");
        }
    }
}