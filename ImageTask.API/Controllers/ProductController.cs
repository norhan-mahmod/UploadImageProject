using AutoMapper;
using ImageTask.API.Dtos;
using ImageTask.Core;
using ImageTask.Core.Entities;
using ImageTask.MVC.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImageTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IMapper mapper;

        public ProductController(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet] // Get : api/Product
        public async Task<ActionResult<List<ProductDto>>> Index()
        {
            var products = await productRepo.GetAllAsync();
            var productsViewModel = new List<ProductDto>();
            foreach (var product in products)
            {
                var productvm = new ProductDto()
                {
                    Name = product.Name,
                    Price = product.Price,
                    ImageSource = DocumentSetting.ConvertToImageSource(product.Image)
                };
                productsViewModel.Add(productvm);
            }
            return Ok(productsViewModel);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public ActionResult<ProductDto> Create([FromForm]ProductDto model)
        {
            var product = mapper.Map<Product>(model);
            productRepo.Add(product);
            return Ok(model);
        }
    }
}
