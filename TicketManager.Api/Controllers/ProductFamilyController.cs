using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.ProductFamily_Services;

namespace TicketManager.Api.Controllers
{
    public class ProductFamilyController : Controller
    {
        private readonly IProductFamilyService _productFamilyService;

        public ProductFamilyController(IProductFamilyService productFamilyService)
        {
            _productFamilyService = productFamilyService;
        }

        // GET
        [HttpGet("api/productfamily/{id}")]
        public ActionResult GetProductFamilyById(int id)
        {
            var family = _productFamilyService.GetProductFamilyById(id);
            return Ok(family);
        }

        // GET
        [HttpGet("api/productfamilies")]
        public ActionResult GetAllProductFamilies()
        {
            var families = _productFamilyService.GetAllProductFamilies();
            return Ok(families);
        }
    }
}