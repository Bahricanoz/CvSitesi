using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CvSitesi.Models.Entity;
namespace CvSitesi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
       
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            DboCvEntities db = new DboCvEntities();
            var bilgiler = db.Tbl_Admin.FirstOrDefault(x => x.Kullaniciadi == p.Kullaniciadi && x.Sifre == p.Sifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullaniciadi, false);
                Session["Kullaniciadi"] = bilgiler.Kullaniciadi.ToString();
                return RedirectToAction("Index", "Hakkımda");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}