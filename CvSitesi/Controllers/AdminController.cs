using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvSitesi.Models.Entity;
using CvSitesi.Repositoires;

namespace CvSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AdminRepository repo = new AdminRepository();
        public ActionResult Index()
        {
            var admin = repo.Tlist();
            return View(admin);
        }
        public ActionResult Detay(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            return View("Detay", bul);
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            return View("Guncelle", bul);
        }
        [HttpPost]
        public ActionResult Guncelle(Tbl_Admin p)
        {
            var bul = repo.Find(x => x.Id == p.Id);
            bul.Ad = p.Ad;
            bul.Soyad = p.Soyad;
            bul.Sifre = p.Sifre;
            bul.Mail = p.Mail;
            bul.Kullaniciadi = p.Kullaniciadi;
            repo.Tguncelle(bul);
            return RedirectToAction("Index");
        }
    }
}