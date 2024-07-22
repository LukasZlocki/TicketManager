using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.LabLocation_Services;

namespace TicketManager.Api.Controllers
{
    public class LabLocationController : Controller
    {
        private readonly ILabLocationService _labLocationService;

        public LabLocationController(ILabLocationService labLocationService)
        {
            _labLocationService = labLocationService;
        }

        // GET
        [HttpGet("api/lablocation")]
        public ActionResult GetAllLabLocations()
        {
            var locations = _labLocationService.GetAllLabLocations();
            return Ok(locations);
        }

        // GET
        [HttpGet("api/lablocation/{id}")]
        public ActionResult GetLabLocationById(int id)
        {
            var locations = _labLocationService.GetLablocationByLabLocationId(id);
            return Ok(locations);
        }

    }
}