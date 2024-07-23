using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.Product_Services;

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

        [HttpGet("api/productfamily")]
        public ActionResult GetAllProductFamilies()
        {
            var productFamilies = _productService.GetAllProductFamilies();
            return Ok(productFamilies);
        }
    }
}