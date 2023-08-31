using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using CvSitesi.Models.Entity;
using CvSitesi.Repositoires;

namespace CvSitesi.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        YetenekRepository repo = new YetenekRepository();
        DboCvEntities db = new DboCvEntities();
        public ActionResult Index()
        {
            var yetenek = repo.Tlist(); // var yetenek = db.Tbl_Yetenek.ToList(); 
            return View(yetenek);
        }
        public ActionResult Sil(int id)
        {
            
            var bul = repo.Find(x => x.Id == id); 
            repo.Tsil(bul);
            // repository desing pattern kullanmadan 
            // var bul = db.Tbl_Yetenek.Find(id);
            //  db.Tbl_Yetenek.Remove(bul);
            // db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_Yetenek p)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            repo.Tekle(p); 
            // db.Tbl_Yetenek.Add(p) 
            // db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            return View("Guncelle", bul);
        }
        [HttpPost]
        public ActionResult Guncelle(Tbl_Yetenek p)
        {
            if (!ModelState.IsValid)
            {
                return View("Guncelle");
            }
            var deger = repo.Find(x => x.Id == p.Id);
            deger.oran = p.oran;
            deger.Yetenekad = p.Yetenekad;
            repo.Tguncelle(deger);
            return RedirectToAction("Index");
        }
    }
}