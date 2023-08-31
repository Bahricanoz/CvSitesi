using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvSitesi.Models.Entity;
using CvSitesi.Repositoires;

namespace CvSitesi.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        MesajlarRepository repo = new MesajlarRepository();
        public ActionResult Index()
        {
            var mesajlar = repo.Tlist();
            return View(mesajlar);
        }
        public ActionResult Sil(int id)
        {
            var bul = repo.Find(x => x.Id == id);
            repo.Tsil(bul);
            return RedirectToAction("Index");
        }
    }
}