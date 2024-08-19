using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.TicketTest_Services;

namespace TicketManager.Api.Controllers
{
    [ApiController]
    public class TicketTestController : Controller
    {
        private readonly ITicketTestService _ticketTestService;

        public TicketTestController(ITicketTestService ticketTestService)
        {
            _ticketTestService = ticketTestService;
        }

        // GET
        [HttpGet("api/tickettestsbyticketid/{id}")]
        public ActionResult GetTicketTestsByTicketId(int id)
        {
            var ticketTests = _ticketTestService.GetTicketTestsByTicketId(id);
            return Ok(ticketTests);
        }

        // GET
        [HttpGet("api/tickettest/{id}")]
        public ActionResult GetTicketTestById(int id)
        {
            var ticketTest = _ticketTestService.GetTicketTestByTicketTestId(id);
            return Ok(ticketTest);
        }
    }
}
