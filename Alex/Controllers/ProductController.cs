using Alex.Models;
using Alex.ViewModels;
using Alex.JoinModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alex.Controllers
{
    public class ProductController : Controller
    {
        public ProductContext db;
        public ProductController(ProductContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            ViewModel obj = new ViewModel();
            obj.countries = db.countries.ToList();
            obj.products = db.products.ToList();
           IEnumerable <WithCountryName> A = new List<WithCountryName>();
            A = obj.products.Join(obj.countries,
                u => u.CountryId,
                p => p.Id,
                (u, p) => new WithCountryName
                {
                    Id = u.Id,
                    Name = u.Name,
                    Price = u.Price,
                    Quantity = u.Quantity,
                    Country = p.Name
                }

                );

            return View(A);
        }
        public IActionResult Show(int id)
        {
            ViewModel obj = new ViewModel();
            obj.countries = db.countries.ToList();
            obj.products = db.products.ToList();
            IEnumerable<WithCountryName> A = new List<WithCountryName>();
            A = obj.products.Join(obj.countries,
                u => u.CountryId,
                p => p.Id,
                (u, p) => new WithCountryName
                {
                    Id = u.Id,
                    Name = u.Name,
                    Price = u.Price,
                    Quantity = u.Quantity,
                    Country = p.Name
                }

                );
            WithCountryName B = new WithCountryName();
            B = A.FirstOrDefault(u => u.Id == id);
            
            return View(B);
        }
        public IActionResult Delete(int id)
        {
            OneModel obj = new OneModel();
            obj.product = db.products.FirstOrDefault(u => u.Id == id);
            db.products.Remove(obj.product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Change(int id)
        {
            ViewBag.ID = id;
            ViewBag.Name = db.countries.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Change(Product produs)
        {
            db.products.Update(produs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            ViewBag.Name = db.countries.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product produs)
        {
            db.products.Add(produs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
