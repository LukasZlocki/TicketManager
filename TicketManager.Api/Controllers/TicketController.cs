﻿using Microsoft.AspNetCore.Mvc;
using TicketManager.Models.Models;
using TicketManager.Services;
using TicketManager.Services.Ticket_Services;

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

        // POST
        [HttpPost("api/ticketcreateefcore")]
        public IActionResult CreateNewTicketEfCore([FromBody] Ticket ticket)
        {
            ResponseService<Ticket> ticketService = _ticketService.CreateTicketEfCore(ticket);
            if (ticketService.IsSucess)
            {
                return Ok("All data saved to database");
            }
            else
            {
                return StatusCode(500, new { message = "An error occurred while saving newticket ef core good practise", error = ticketService.Message });
            }
        }
    }
}
