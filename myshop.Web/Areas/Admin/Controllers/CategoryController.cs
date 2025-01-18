using Microsoft.AspNetCore.Mvc;
using myshop.DataAcess.Data;
using myshop.Entities.Interfaces;
using myshop.Entities.Models;


namespace myshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            // var categories = _context.Categories.OrderByDescending(d=>d.CreatedDate).ToList();   
            var categories = _unitOfWork.CategoryRepository.GetAll();
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
                //_context.Categories.Add(category);
                //_context.SaveChanges();
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Complete();
                TempData["create"] = "Item has Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //var category = _unitOfWork.CategoryRepository.Get(Id);
            var category = _unitOfWork.CategoryRepository.Get(x => x.Id == Id);
            if (Id == null || category == null)
            {
                return View("404");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //_context.Categories.Update(category);
            //_context.SaveChanges();
            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Complete();
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
            //var category = _context.Categories.Find(Id);
            var category = _unitOfWork.CategoryRepository.Get(x => x.Id == Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int? Id)
        {
            //var category = _context.Categories.Find(Id);
            //_context.Categories.Remove(category);
            //_context.SaveChanges();
            var category = _unitOfWork.CategoryRepository.Get(x => x.Id == Id);
            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.Complete();
            TempData["delete"] = "Item has Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
