using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.FactoryLocation_Services;

namespace TicketManager.Api.Controllers
{
    [ApiController]
    public class FactoryLocationController : Controller
    {
        private readonly IFactoryLocationService _factoryLocationService;
        public FactoryLocationController(IFactoryLocationService factoryLocationService)
        {
            _factoryLocationService = factoryLocationService;
        }

        // GET
        [HttpGet("api/factorylocation")]
        public ActionResult GetAllFactoryLocations()
        {
            var locations = _factoryLocationService.GetAllFactoryLocations();
            return Ok(locations);
        }

        // GET
        [HttpGet("api/factorylocation/{id}")]
        public ActionResult GetFactoryLocationById(int id)
        {
            var location = _factoryLocationService.GetFactoryLocationByFactoryLocationId(id);
            return Ok(location);
        }
    }
}