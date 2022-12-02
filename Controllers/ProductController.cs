using ecommapp.Data;
using Microsoft.AspNetCore.Mvc;
using ecommapp.Models;
using System.Collections.Generic;

namespace ecommapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           IEnumerable<products> products = _db.products.ToList();
            return View(products);
        }


        public IActionResult Create()
        {
            IEnumerable<products> products = _db.products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Create(products product)
        {
              _db.products.Add(product);
                _db.SaveChanges();
                TempData["success"] = "Product Created succesfully";
                return RedirectToAction("Index");
           
        }

       public IActionResult Edit(int? Id)
        {
            var product = _db.products.FirstOrDefault(c => c.Id == Id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(products product)

        {
                _db.products.Add(product);
                _db.SaveChanges();
                return View(product);
                TempData["success"] = "Product Updated succesfully";
           
        }

        [HttpPost]
        public IActionResult Delete(int? Id)
        {
            
                var product = _db.products.FirstOrDefault(c => c.Id == Id);
                _db.products.Remove(product);
                _db.SaveChanges();
                ViewBag.Message = "Your value delete successfully";
            
            return View();
        }

    }
}

