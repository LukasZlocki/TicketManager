using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketManager.Models.Models;
using TicketManager.Services;
using TicketManager.Services.Ticket_Services;
using TicketManager.Services.TicketTest_Services;
using TicketManager.Services.TicketTestParameter_Services;

namespace TicketManager.Api.Controllers
{
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketTestService _ticketTestService;
        private readonly ITicketTestParameterService _ticketTestParameterService;

        public TicketController(ITicketService ticketService, ITicketTestService ticketTestService, ITicketTestParameterService ticketTestParameterService) //
        {
            _ticketService = ticketService;
            _ticketTestService = ticketTestService;
            _ticketTestParameterService = ticketTestParameterService;
        }

        // GET
        [HttpGet("api/ticketbyid/{id}")]
        public ActionResult GetTicketById(int id)
        {
            var ticket = _ticketService.GetTicket(id);
            return Ok(ticket);
        }

        // GET
        [HttpGet("api/ticketdetailsbyid/{id}")]
        public ActionResult GetTicketDetailsById(int id)
        {
            var ticketDetailed = _ticketService.GetTicketDetails(id);
            return Ok(ticketDetailed);
        }

        // GET
        [HttpGet("api/getticketbylablocation/{id}")]
        public IActionResult GetTicketByLabLocationId(int id)
        {
            var tickets = _ticketService.GetTicketsByLabLocation(id);
            return Ok(tickets);
        }

        // GET
        [HttpGet("api/getticketbyuseremail/{email}")]
        public IActionResult GetTicketByLabLocationId(string email)
        {
            var tickets = _ticketService.GetTicketsByUserEmail(email);
            return Ok(tickets);
        }

        // GET
        [HttpGet("api/getticket/{id}")]
        public IActionResult GetTicketsByUserEmail(int id)
        {
            var ticket = _ticketService.GetTicket(id);
            return Ok(ticket);
        }

        // GET
        [HttpGet("api/getticketdetails/{id}")]
        public IActionResult GetTicketDetails(int id)
        {
            var ticket = _ticketService.GetTicketDetails(id);
            return Ok(ticket);
        }


        // POST
        [HttpPost("api/ticketcreate")]
        public IActionResult CreateNewTicket([FromBody] Ticket ticket)
        {
            // step1: create ticket - get ticket id
            Ticket _ticket = new Ticket
            {
                RequestorEmail = ticket.RequestorEmail,
                ImplementedAt = ticket.ImplementedAt,
                StartedAt = ticket.StartedAt,
                FinishedAt = ticket.FinishedAt,
                DepartmentId = ticket.DepartmentId,
                LabLocationId = ticket.LabLocationId,
                ProductId = ticket.ProductId,
                StatusId = 1,
            };
            ResponseService<Ticket> ticketService = _ticketService.CreateTicket(_ticket);
            if (ticketService.IsSucess)
            {
                // ad ticket id to ticket object
                ticket.TicketId = _ticket.TicketId;
                // step2: add Ticket id to TicketTest and its subclasses
                foreach (var ticketTest in ticket.TicketTests)
                {
                    ticketTest.TicketId = ticketService.Data.TicketId;
                }
            }
            else
            {
                return StatusCode(500, new { message = "An error occurred while saving the ticket", error = ticketService.Message });
            }

            // step3: save tickettest -get tickettest id
            // save each tickettest to database one by one. retrive tickettest id.
            int _ticketTestCounter = 0;
            foreach (var ticketTest in ticket.TicketTests)
            {
                ResponseService<TicketTest> ticketTestService = _ticketTestService.CreateTicketTests(ticketTest);
                if (ticketTestService.IsSucess)
                {
                    ticket.TicketTests[_ticketTestCounter].TicketTestId = ticketTestService.Data.TicketTestId;
                    foreach (var _ticketTestParameter in ticketTest.TicketTestParameters)
                    {
                        // add ticket test id to each ticket test parameter
                        _ticketTestParameter.TicketTestId = ticket.TicketTests[_ticketTestCounter].TicketTestId;
                    }

                }
                else
                {
                    return StatusCode(500, new { message = "An error occurred while saving the ticket test", error = ticketTestService.Message });
                }
                _ticketTestCounter++;
            }

            // ToDo: Code saving ticket test parameters to database
            //var ticketTestParameter = ticket;
            int _ticketTestCounter2 = 0;
            foreach (var ticketTest in ticket.TicketTests)
            {
                foreach (var ticketTestParameter in ticketTest.TicketTestParameters)
                {
                    ResponseService<TicketTestParameter> ticketTestParameterService = _ticketTestParameterService.CreateTicketTestParameter(ticketTestParameter);
                    if (ticketTestParameterService.IsSucess)
                    {
                        // Do Nothing (?)
                    }
                    else
                    {
                        return StatusCode(500, new { message = "An error occurred while saving the ticket test parameter", error = ticketTestParameterService.Message });
                    }
                }
                _ticketTestCounter2++;
            }

            return Ok("All data saved to database");
        }

        // PATCH
        [HttpPatch("api/ticketupdate")]
        public IActionResult UpdateTicket([FromBody] Ticket ticket)
        {
            // ToDo: Code update / create ticket tests lits
            int _ticketTestCounter = 0;
            foreach (var ticketTest in ticket.TicketTests)
            {
                ResponseService<TicketTest> ticketTestService = _ticketTestService.UpdateTicketTest(ticketTest);
                if (ticketTestService.IsSucess)
                {
                    ticket.TicketTests[_ticketTestCounter].TicketTestId = ticketTestService.Data.TicketTestId;
                    foreach (var _ticketTestParameter in ticketTest.TicketTestParameters)
                    {
                        // add ticket test id to each ticket test parameter
                        _ticketTestParameter.TicketTestId = ticket.TicketTests[_ticketTestCounter].TicketTestId;
                    }

                }
                else
                {
                    return StatusCode(500, new { message = "An error occurred while saving the ticket test", error = ticketTestService.Message });
                }
                _ticketTestCounter++;
            }
            // ToDo: Code update / create ticket test parameters to database
            // start coding here !!
            foreach (var ticketTest in ticket.TicketTests)
            {
                foreach (var ticketTestParameter in ticketTest.TicketTestParameters)
                {
                    ResponseService<TicketTestParameter> ticketTestParameterService = _ticketTestParameterService.UpdateTicketTestParameter(ticketTestParameter);
                    if (ticketTestParameterService.IsSucess)
                    {
                        continue;
                    }
                    else
                    {
                        return StatusCode(500, new { message = "An error occurred while saving the ticket test parameter", error = ticketTestParameterService.Message });
                    }
                }
            }
            return Ok("All data saved to database");
        }


        // DELETE
        [HttpDelete("api/deleteticket/{id}")]
        public IActionResult DeleteTicket(int Id)
        {
            var ticket = _ticketService.GetTicketDetails(Id);
            if (ticket == null)
            {
                return StatusCode(500, new { message = "No ticket in database.", error = "no ticket in Db." });
            }
            else
            {
                // Delete ticket tests parameter list.
                foreach (var ticketTest in ticket.TicketTests)
                {
                    // Gathering ticket test parameter ids to remove
                    List<int> ticketTestParametersIdsToRemove = new List<int>();
                    foreach (var ticketTestParameter in ticketTest.TicketTestParameters)
                    {
                        ticketTestParametersIdsToRemove.Add(ticketTestParameter.TicketTestParameterId);
                    }
                    // Removing ticket test parameters
                    foreach (var ticketTestParameterId in ticketTestParametersIdsToRemove)
                    {
                        var responseTicketTestParameter = _ticketTestParameterService.DeleteTicketTestParameter(ticketTestParameterId);
                        if (!responseTicketTestParameter.IsSucess)
                        {
                            return StatusCode(500, new { message = "An error occurred while deleting the ticket test parameter.", error = responseTicketTestParameter.Message });
                        }
                    }
                }

                // Delete ticket test list.
                List<int> ticketTestsIdsToRemove = new List<int>();
                foreach (var ticketTest in ticket.TicketTests)
                {
                    ticketTestsIdsToRemove.Add(ticketTest.TicketTestId);

                }

                foreach (int ticketTestId in ticketTestsIdsToRemove)
                {
                    var responseTicketTest = _ticketTestService.DeleteTicketTest(ticketTestId);
                    if (!responseTicketTest.IsSucess)
                    {
                        return StatusCode(500, new { message = "An error occurred while deleting the ticket test.", error = responseTicketTest.Message });
                    }
                }

                // Delete ticket - write service
                var responseTicket = _ticketService.DeleteTicket(ticket.TicketId);
                if (!responseTicket.IsSucess)
                {
                    return StatusCode(500, new { message = "An error occurred while deleting the ticket.", error = responseTicket.Message });
                }
            }
            return Ok("Ticket deleted from database");
        }

    }
}
