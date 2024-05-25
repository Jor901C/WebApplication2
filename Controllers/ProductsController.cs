using Microsoft.AspNetCore.Mvc;
using prj.Models;
using prj.Services.Interfaces;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest();
            var product = _productService.Get(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product == null)
                return BadRequest();
            _productService.Add(product);
            return Ok(product);
        }
    }
}