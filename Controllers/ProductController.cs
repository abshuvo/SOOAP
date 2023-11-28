using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoapTrail.Models;
using SoapTrail.Services;

namespace SoapTrail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            _productService.UpdateProduct(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
