using Microsoft.EntityFrameworkCore;
using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.Ticket_Services
{
    public class TicketService : ITicketService
    {
        private readonly TicketManagerDbContext _db;

        public TicketService(TicketManagerDbContext db)
        {
            _db = db;
        }

        public ResponseService<Ticket> CreateTicket(Ticket ticket)
        {
            try
            {
                _db.Tickets.Add(ticket);
                // Add
                _db.SaveChanges();
                return new ResponseService<Ticket>
                {
                    IsSucess = true,
                    Message = "Order added.",
                    Time = DateTime.UtcNow,
                    Data = ticket
                };
            }
            catch (Exception e)
            {
                return new ResponseService<Ticket>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = ticket
                };
            }
        }

        public ResponseService<Ticket> DeleteTicket(int ticketId)
        {
            var ticket = _db.Tickets.Find(ticketId);
            if (ticket == null)
            {
                return new ResponseService<Ticket>
                {
                    IsSucess = false,
                    Message = "No ticket found.",
                    Time = DateTime.UtcNow,
                    Data = ticket
                };
            }

            try
            {
                // Deleting process
                _db.Tickets.Remove(ticket);
                // delete
                _db.SaveChanges();
                return new ResponseService<Ticket>
                {
                    IsSucess = true,
                    Message = "TicketTest deleted.",
                    Time = DateTime.UtcNow,
                    Data = ticket
                };
            }
            catch (Exception e)
            {
                return new ResponseService<Ticket>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = null
                };
            }
        }

        public Ticket GetTicket(int ticketId)
        {
            var service = _db.Tickets.FirstOrDefault(id => id.TicketId == ticketId);
            return service ?? new Ticket();
        }

        public Ticket GetTicketDetails(int ticketId)
        {
            var service = _db.Tickets
                .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                .FirstOrDefault(id => id.TicketId == ticketId);
            return service ?? new Ticket();
        }

        public List<Ticket> GetTicketsByLabLocation(int labLocationId)
        {
            var service = _db.Tickets
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                .Where(id => id.LabLocationId == labLocationId).ToList();
            return service;
        }

        public List<Ticket> GetTicketsByUserEmail(string userEmail)
        {
            var service = _db.Tickets
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                .Where(e => e.RequestorEmail == userEmail)
                .ToList();
            return service;
        }
    }
}
