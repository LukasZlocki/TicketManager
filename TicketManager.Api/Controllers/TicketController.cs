using Microsoft.AspNetCore.Mvc;
using TicketManager.Models.Models;
using TicketManager.Services;
using TicketManager.Services.Ticket_Services;
using TicketManager.Services.TicketTest_Services;
using TicketManager.Services.TicketTestParameter_Services;

namespace TicketManager.Api.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // POST
        [HttpPost("api/ticketcreate")]
        public IActionResult CreateNewTicket([FromBody] Ticket ticket)
        {
            // step1: create ticket - get ticket id

            ResponseService<Ticket> ticketService = _ticketService.CreateTicket(ticket);
            if (ticketService.IsSucess)
            {
                return Ok("All data saved to database");
            }
            else
            {
                return StatusCode(500, new { message = "An error occurred while saving newticket", error = ticketService.Message});
            }
        }
    }
}
