using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvSitesi.Repositoires;
using CvSitesi.Models.Entity;

namespace CvSitesi.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        HakkimdaRepository repo = new HakkimdaRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var deger = repo.Tlist();
            return View(deger);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hakkımda p)
        {
            var deger = repo.Find(x => x.Id == 2);
            deger.Resim = p.Resim;
            deger.Aciklama = p.Aciklama;
            deger.Ad = p.Ad;
            deger.Soyad = p.Soyad;
            deger.Okul = p.Okul;
            deger.Mail = p.Mail;
            deger.Telefon = p.Telefon;
            repo.Tguncelle(deger);
            return RedirectToAction("Index");
        }
    }
}