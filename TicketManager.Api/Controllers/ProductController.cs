using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.ProductServices;

namespace TicketManager.Api.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET
        [HttpGet("api/products")]
        public ActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        // GET
        [HttpGet("api/product/{id}")]
        public ActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }
    }
}