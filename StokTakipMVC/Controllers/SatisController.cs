using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipMVC.Modals.Entity;
namespace StokTakipMVC.Controllers
{
    public class SatisController : Controller
    {
        MVCDBSTOKEntities1 db = new MVCDBSTOKEntities1();
        // GET: Satis
        public ActionResult Index()
        {
            var values = db.TBLSATISLAR.ToList();
            return View(values);
           
        }



        [HttpGet]
        public ActionResult NewSatis()
        {
            return View();
        }


        [HttpPost]
        public ActionResult NewSatis(TBLSATISLAR s1)
        {
            db.TBLSATISLAR.Add(s1);
            db.SaveChanges();
            return View("Index");
        }
    }
}