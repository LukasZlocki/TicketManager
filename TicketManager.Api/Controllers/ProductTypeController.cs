using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.ProductType_Services;

namespace TicketManager.Api.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet("api/producttypebyproductfamily/{id}")]
        public ActionResult GetProductTypesByProductFamily(int id)
        {
            var productTypes = _productTypeService.GetAllProductTypesByFamilyId(id);
            return Ok(productTypes);
        }

        [HttpGet("api/producttype/{id}")]
        public ActionResult GGetProductType(int id)
        {
            var productTypes = _productTypeService.GetProductTypeById(id);
            return Ok(productTypes);
        }
    }
}