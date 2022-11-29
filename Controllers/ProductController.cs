using ecommapp.Data;
using Microsoft.AspNetCore.Mvc;
using ecommapp.Models;

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
            var products = _db.products.ToList();
            return View(products);
        }


        public IActionResult Create(products product)
        {
            if (ModelState.IsValid)
            {
                _db.products.Add(product);
                _db.SaveChanges();
                TempData["success"] = "Product Created succesfully";
                return RedirectToAction("Index");
            }
           return View(product);
        }
    }
}

