using DAPAssessment_MVC.Models;
using DAPAssessment_MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DAPAssessment_MVC.Controllers
{
   

    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _repository.GetAllProductsAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ProductViewModel = new ProductViewModel
                {
                    Name = model.Name,
                    Price = model.Price,
                    Category = model.Category
                };
                await _repository.CreateProductAsync(ProductViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }

}
