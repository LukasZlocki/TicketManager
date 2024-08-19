using TicketManager.Models.Models;

namespace TicketManager.Services.Ticket_Services
{
    public interface ITicketService
    {
        public ResponseService<Ticket> CreateTicket(Ticket ticket);
    }
}
