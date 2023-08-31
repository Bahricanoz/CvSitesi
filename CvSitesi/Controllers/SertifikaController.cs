using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvSitesi.Models.Entity;
using CvSitesi.Repositoires;

namespace CvSitesi.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        SertifikalarımRepository repo = new SertifikalarımRepository();
        public ActionResult Index()
        {
            var sertifika = repo.Tlist();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_Sertifikalarim p)
        {
            repo.Tekle(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Getir(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            ViewBag.stf = id;
            return View("Getir", bul);
        }
        [HttpPost]
        public ActionResult Getir(Tbl_Sertifikalarim p)
        {
            var deger = repo.Find(x => x.Id == p.Id);
            deger.Sertifkaad = p.Sertifkaad;
            deger.Tarih = p.Tarih;
            repo.Tguncelle(deger);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            repo.Tsil(bul);
            return RedirectToAction("Index");
        }
    }
}