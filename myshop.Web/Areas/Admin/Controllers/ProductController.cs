using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myshop.Entities.Interfaces;
using myshop.Entities.Models;

namespace myshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork=unitOfWork;
            _webHostEnvironment=webHostEnvironment;
        }

        public IActionResult Index()
        {
            var products = _unitOfWork.ProductRepository.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var ProductViewModel = new ProductViewModel
            {
                Product = new Product(),
                Items = _unitOfWork.CategoryRepository.GetAll().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
            };
            return View(ProductViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel  productViewModel , IFormFile file)
        {
            if(ModelState.IsValid)
            {
                var rootpath = _webHostEnvironment.WebRootPath; // to get wwwroot path .
                if(file !=null)
                {
                    var filename = Guid.NewGuid().ToString();
                    var upload = Path.Combine(rootpath, @"Images\Products");
                    var fileExtension = Path.GetExtension(file.FileName);

                    using (var filestream = new FileStream(Path.Combine(upload, filename+fileExtension), FileMode.OpenOrCreate))
                    {
                        file.CopyTo(filestream);    
                    }
                    productViewModel.Product.Image = @"Images\Products\"+filename+fileExtension;
                }
                _unitOfWork.ProductRepository.Add(productViewModel.Product);
                _unitOfWork.Complete();
                TempData["create"] = "Item has Created Successfully";
                return RedirectToAction("Index");

            }
            return View(productViewModel);
        }
    }
}
