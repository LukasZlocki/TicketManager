using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.ProductDisplacement_Services;

namespace TicketManager.Api.Controllers
{
    public class ProductDisplacementController : Controller
    {
        private readonly IProductDisplacementService _productDisplacementService;

        public ProductDisplacementController(IProductDisplacementService productDisplacementService)
        {
            _productDisplacementService = productDisplacementService;
        }

        [HttpGet("api/productdisplacementbyproductfamily/{id}")]
        public ActionResult GetProductDisplacementByProductFamily(int id)
        {
            var displacements = _productDisplacementService.GetProductDisplacementsByProductFamilyId(id);
            return Ok(displacements);
        }
    }
}