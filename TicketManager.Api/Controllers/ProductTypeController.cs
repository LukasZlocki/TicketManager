using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.ProductTypeServices;

namespace TicketManager.Api.Controllers
{
    [ApiController]
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        // GET
        [HttpGet("api/producttypebyproductfamily/{id}")]
        public ActionResult GetProductTypesByProductFamily(int id)
        {
            var productTypes = _productTypeService.GetAllProductTypesByFamilyId(id);
            return Ok(productTypes);
        }

        // GET
        [HttpGet("api/producttype/{id}")]
        public ActionResult GetProductType(int id)
        {
            var productType = _productTypeService.GetProductTypeById(id);
            return Ok(productType);
        }

        // GET
        [HttpGet("api/producttypes")]
        public ActionResult GetAllProductTypes()
        {
            var productTypes = _productTypeService.GetAllProductTypes();
            return Ok(productTypes);
        }

    }
}