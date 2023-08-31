using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvSitesi.Models.Entity;
using CvSitesi.Repositoires;

namespace CvSitesi.Controllers
{
    public class ProjeController : Controller
    {
        // GET: Proje
        ProjeRepository repo = new ProjeRepository();
        public ActionResult Index()
        {
            var proje = repo.Tlist();
            return View(proje);
        }
        public ActionResult Aktif(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            bul.Durum = true;
            repo.Tguncelle(bul);
            return RedirectToAction("Index");
        }
        public ActionResult Pasif(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            bul.Durum = false;
            repo.Tguncelle(bul);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            repo.Tsil(bul);
            return RedirectToAction("Index");
        }
        public ActionResult Detay(int id)
        {
            var bul = repo.Tgetir(id);
            return View("Detay", bul);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_Projelerim p)
        {
            p.Durum = true;
            repo.Tekle(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var bul = repo.Tgetir(id);
            return View("Guncelle", bul);
        }
        [HttpPost]
        public ActionResult Guncelle(Tbl_Projelerim p)
        {
            var deger = repo.Find(x => x.Id == p.Id);
            deger.Tarih = p.Tarih;
            deger.Link = p.Link;
            deger.Projeadi = p.Projeadi;
            deger.Açıklama = p.Açıklama;
            deger.Durum = true;
            repo.Tguncelle(deger);
            return RedirectToAction("Index");
        }
    }
}