using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CvSitesi.Models.Entity;
using CvSitesi.Repositoires;
namespace CvSitesi.Controllers
{
    public class SosyalmedyaController : Controller
    {
        // GET: Sosyalmedya
        SosylaMedyaRepository repo = new SosylaMedyaRepository();
        public ActionResult Index()
        {
            var sosyalmedya = repo.Tlist();
            return View(sosyalmedya);
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
        public ActionResult Detay(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            return View("Detay", bul);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_Sosyalmedya p)
        {
            p.Durum = true;
            repo.Tekle(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            return View("Guncelle", bul);
        }
        [HttpPost]
        public ActionResult Guncelle(Tbl_Sosyalmedya p)
        {
            var bul = repo.Tgetir(p.Id);
            //var bul = repo.Find(x=>x.Id== p.Id);
            bul.Durum = true;
            bul.Link = p.Link;
            bul.Ikon = p.Ikon;
            bul.Iconad = p.Iconad;
            repo.Tguncelle(bul);
            return RedirectToAction("Index");
        }
    }
}