using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CvSitesi.Models.Entity;
using CvSitesi.Repositoires;
namespace CvSitesi.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DboCvEntities db = new DboCvEntities();
        DeneyimRepository repo = new DeneyimRepository();
       
        public ActionResult Index()
        {
            var deneyim = repo.Tlist();
            return View(deneyim);
        }
        public ActionResult Aktifyap(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            bul.Durum = true;
            repo.Tguncelle(bul);
            return RedirectToAction("Index");
        }
        public ActionResult Pasifyap(int id)
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
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(Tbl_Deneyimlerim p)
        {
            p.Durum = true;
            repo.Tekle(p);
            return RedirectToAction("Index");
        }
        [HttpGet] 
        public ActionResult DeneyimGuncelle(int id)
        {
            var bul = repo.Tgetir(id);
            return View(bul);
        }
        [HttpPost] 
        public ActionResult DeneyimGuncelle(Tbl_Deneyimlerim p)
        {
            var bul = repo.Find(x => x.Id == p.Id);
            bul.Durum = true;
            bul.DeneyimAd = p.DeneyimAd;
            bul.İcerik = p.İcerik;
            bul.Tarih = p.Tarih;
            bul.Unvan = p.Unvan;
            repo.Tguncelle(bul);
            return RedirectToAction("Index");
        }
    }
}