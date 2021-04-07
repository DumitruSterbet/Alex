using Alex.Models;
using Alex.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alex.Controllers
{
    public class CountryController : Controller
    {
        public ProductContext db;
       public CountryController(ProductContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.countries.ToList()) ;
        }
        public IActionResult Show(int id)
        {
            OneModel obj = new OneModel();
            obj.country = db.countries.FirstOrDefault(u => u.Id == id);
            return View(obj.country);
        }
        public IActionResult Delete (int id)
        {
            OneModel obj = new OneModel();
            obj.country = db.countries.FirstOrDefault(u => u.Id == id);
            db.countries.Remove(obj.country);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
       
        public IActionResult Change(int id)
        {
            ViewBag.ID = id;

            return View();
        }
        [HttpPost]
        public IActionResult Change (Country country)
        {
            db.countries.Update(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(Country country)
        {
            db.countries.Add(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
