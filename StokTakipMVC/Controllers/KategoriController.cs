using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipMVC.Modals.Entity;


namespace StokTakipMVC.Controllers
{
    public class KategoriController : Controller
    {
        MVCDBSTOKEntities1 db = new MVCDBSTOKEntities1();
        // GET: Kategori
        public ActionResult Index()
        {
            var values = db.TBLKATEGORILER.ToList();
            return View(values);
        }


        [HttpGet] //sadece sayfa yüklenirse işlem yapmamayı sağlar bu olmazsa her seferinde null bir kategori ekler
        public ActionResult NewKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewKategori(TBLKATEGORILER k1)
        {
            db.TBLKATEGORILER.Add(k1);
            db.SaveChanges();
            return RedirectToAction("Index/");
        }


        public ActionResult Delete(int id)
        {

            var kategori = db.TBLKATEGORILER.Find(id);

            //kategoriid ürünlerde birisi ile ilişkili o yüzden silerken urunlerdeki ürünü de silmemek için kategori kısmını boşaltıyoruz.
            var relatedRecords = db.TBLURUNLER.Where(u => u.URUNKATEGORI == id);
            foreach (var record in relatedRecords)
            {
                record.URUNKATEGORI = null;
            }


            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");



        }


        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir", kategori);
        }


        public ActionResult Guncelle(TBLKATEGORILER k1)
        {
            var kategori = db.TBLKATEGORILER.Find(k1.KATEGORIID);
            kategori.KATEGORIAD = k1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}