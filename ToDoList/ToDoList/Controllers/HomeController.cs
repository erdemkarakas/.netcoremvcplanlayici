using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoList.Models;
using ToDoList.Models.ViewModels;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<string> oncelikliste = new List<string>();
            oncelikliste.Add("Yüksek Öncelik");
            oncelikliste.Add("Normal Öncelik");
            oncelikliste.Add("Düşük Öncelik");

            ViewBag.oncelik = oncelikliste;

            List<Gorev> listegorev = _db.Gorev.ToList();


            return View(listegorev);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public JsonResult taskkaydet(int id = 0, string bitisTarihi = "", string planAciklama = "", string planKonu = "", string oncelik = "", string tur = "")
        {

            DateTime dt = Convert.ToDateTime(bitisTarihi);

            if (id != 0)
            {

                Gorev g = _db.Gorev.FirstOrDefault(x => x.id == id);

                g.bitisTarihi = dt;
                g.aciklama = planAciklama;
                g.konu = planKonu;
                g.oncelik = oncelik;

                _db.SaveChanges();
            }
            else
            {
                Gorev g = new Gorev { konu = planKonu, aciklama = planAciklama, oncelik = oncelik, tur = tur, eklenmeTarihi = DateTime.Now, bitisTarihi = dt };

                _db.Gorev.Add(g);


                _db.SaveChanges();
            }



            return Json(true);
        }


        public ActionResult DeleteConfirmed(int id)
        {
            Gorev gorev = _db.Gorev.Find(id);
            _db.Gorev.Remove(gorev);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
