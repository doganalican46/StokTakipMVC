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
            List<SelectListItem> values = (from x in db.TBLKATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KATEGORIAD,
                                               Value = x.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.kategoriler = values;
            return View("UrunGetir", urun);

        }

        public ActionResult Guncelle(TBLURUNLER u1)
        {
            var urun = db.TBLURUNLER.Find(u1.URUNID);
            
            urun.URUNAD = u1.URUNAD;
            urun.MARKA = u1.MARKA;
            //urun.URUNKATEGORI = u1.URUNKATEGORI;
            urun.FIYAT = u1.FIYAT;
            urun.STOK = u1.STOK;
            var kategori = db.TBLKATEGORILER.Where(m => m.KATEGORIID == u1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = kategori.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}