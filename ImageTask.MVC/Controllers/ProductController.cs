using AutoMapper;
using ImageTask.Core;
using ImageTask.Core.Entities;
using ImageTask.MVC.Helper;
using ImageTask.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImageTask.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IMapper mapper;

        public ProductController(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductViewModel>>> Index()
        {
            var products = await productRepo.GetAllAsync();
            var productsViewModel = new List<ProductViewModel>();
            foreach(var product in products)
            {
                var productvm = new ProductViewModel()
                {
                    Name = product.Name,
                    Price = product.Price,
                    ImageSource = DocumentSetting.ConvertToImageSource(product.Image)
                };
                productsViewModel.Add(productvm);
            }
            return View(productsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductViewModel());
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = mapper.Map<Product>(model);
                productRepo.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
