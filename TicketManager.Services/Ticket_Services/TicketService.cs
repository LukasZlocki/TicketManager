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

        public ResponseService<Ticket> CreateTicketEfCore(Ticket ticket)
        {
            // Creating ticket service according to ef core good practise 
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
    }
}
