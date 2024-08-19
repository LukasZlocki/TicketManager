using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.ProductDisplacement_Services;

namespace TicketManager.Api.Controllers
{
    [ApiController]
    public class ProductDisplacementController : Controller
    {
        private readonly IProductDisplacementService _productDisplacementService;

        public ProductDisplacementController(IProductDisplacementService productDisplacementService)
        {
            _productDisplacementService = productDisplacementService;
        }

        // GET
        [HttpGet("api/productdisplacementbyproductfamily/{id}")]
        public ActionResult GetProductDisplacementByProductFamily(int id)
        {
            var displacements = _productDisplacementService.GetProductDisplacementsByProductFamilyId(id);
            return Ok(displacements);
        }

        // GET
        [HttpGet("api/productdisplacements")]
        public ActionResult GetAllProductDisplacements()
        {
            var displacements = _productDisplacementService.GetAllProductDisplacements();
            return Ok(displacements);
        }
    }
}