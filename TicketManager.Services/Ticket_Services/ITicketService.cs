using TicketManager.Models.Models;

namespace TicketManager.Services.Ticket_Services
{
    public interface ITicketService
    {
        public ResponseService<Ticket> CreateTicket(Ticket ticket);
        public List<Ticket> GetTicketsByLabLocation(int labLocationId);
        public List<Ticket> GetTicketsByUserEmail(string userEmail);
        public Ticket GetTicket(int ticketId);
        public Ticket GetTicketDetails(int ticketId);
        public ResponseService<Ticket> DeleteTicket(int ticketId);
    }
}
