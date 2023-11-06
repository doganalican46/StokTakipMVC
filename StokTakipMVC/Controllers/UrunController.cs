using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipMVC.Modals.Entity;
namespace StokTakipMVC.Controllers
{
    public class UrunController : Controller
    {
        MVCDBSTOKEntities1 db = new MVCDBSTOKEntities1();
        // GET: Urun
        public ActionResult Index()
        {
            var values = db.TBLURUNLER.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult NewUrun()
        {
            List<SelectListItem> values = (from x in db.TBLKATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.KATEGORIAD,
                                               Value=x.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.kategoriler = values;

            return View();
        }

        [HttpPost]
        public ActionResult NewUrun(TBLURUNLER u1)
        {
            var kategori = db.TBLKATEGORILER.Where(m => m.KATEGORIID == u1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            u1.TBLKATEGORILER = kategori;
            db.TBLURUNLER.Add(u1);
            db.SaveChanges();
            return RedirectToAction("Index/");
        }


        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            return View("UrunGetir", urun);

        }

        public ActionResult Guncelle(TBLURUNLER u1)
        {
            var kategori = db.TBLKATEGORILER.Find(u1.KATEGORIID);
            kategori.KATEGORIAD = u1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}