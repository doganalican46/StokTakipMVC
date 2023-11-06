using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipMVC.Modals.Entity;
namespace StokTakipMVC.Controllers
{
    public class MusteriController : Controller
    {
        MVCDBSTOKEntities1 db = new MVCDBSTOKEntities1();
        // GET: Musteri
        public ActionResult Index()
        {
            var values = db.TBLMUSTERILER.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMusteri(TBLMUSTERILER m1)
        {
            db.TBLMUSTERILER.Add(m1);
            db.SaveChanges();
            return RedirectToAction("Index/");
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", musteri);
        }

        public ActionResult Guncelle(TBLMUSTERILER m1)
        {
            var musteri = db.TBLMUSTERILER.Find(m1.MUSTERIID);
            musteri.MUSTERIAD = m1.MUSTERIAD;
            musteri.MUSTERISOYAD = m1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}