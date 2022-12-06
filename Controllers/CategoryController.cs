using Microsoft.AspNetCore.Mvc;
using ecommapp.Data;
using ecommapp.Models;
using System.Collections.Generic;


namespace CG_VAK_BooksWeb.Controllers
{
    public class CategoryController : Controller
    {


        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoriesList = _db.categories.ToList();
            return View(categoriesList);
        }

        //Get
        public IActionResult Create()
        {
            IEnumerable<Category> categories = _db.categories.ToList();
            return View(categories);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {

            if (ModelState.IsValid)
            {
                var iscategoryexists = _db.categories.FirstOrDefault(x => x.Name == category.Name || x.OrderOfDisplay == category.OrderOfDisplay);
                if (iscategoryexists != null)
                {
                    TempData["error"] = "Categoty/Order Of Display exists already";
                    return View(category);
                }
                else
                {
                    _db.categories.Add(category);
                    _db.SaveChanges();
                    TempData["success"] = "Catergory Created succesfully";
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            //var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            var category = _db.categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.OrderOfDisplay.ToString())
            {
                ModelState.AddModelError("customError", "Display name should not match with displayorder");
            }
            var iscategoryexists = _db.categories.FirstOrDefault(x => x.Name == category.Name && x.OrderOfDisplay == category.OrderOfDisplay);
            if (iscategoryexists != null)
            {
                TempData["info"] = "No Changes are detected";
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                _db.categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Catergory Updated succesfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            var category = _db.categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _db.categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Catergory Deleted succesfully";
            return RedirectToAction("Index");

        }
    }
}

