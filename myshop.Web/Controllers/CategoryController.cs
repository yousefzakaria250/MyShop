using Microsoft.AspNetCore.Mvc;
using myshop.Web.Data;
using myshop.Web.Models;

namespace myshop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context=context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _context.Categories.OrderByDescending(d=>d.CreatedDate).ToList();   
            return View(categories);
        }

        // To Display Form 
        [HttpGet]
        public IActionResult Create() 
        {
            return View(); 
        }

        // To Insert Data comin from form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["create"] = "Item has Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int ?Id)
        {
            var category = _context.Categories.Find(Id);
            if (Id == null || category == null)
            {
                return View("404");
            }
            return View(category);  
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["update"] = "Item has Updated Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int? Id)
        {
            var category = _context.Categories.Find(Id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["delete"] = "Item has Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
