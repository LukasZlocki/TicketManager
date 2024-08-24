using TicketManager.Models.Models;

namespace TicketManager.Services.TicketTestParameter_Services
{
    public interface ITicketTestParameterService
    {
        public List<TicketTestParameter> GetTicketTestParametersByTicketTestId(int ticketTestId);
        public TicketTestParameter GetTicketTestParameterById(int ticketTestParameterId);
        public ResponseService<TicketTestParameter> CreateTicketTestParameter(TicketTestParameter ticketTestParameter);
        public ResponseService<TicketTestParameter> DeleteTicketTestParameter(int ticketTestParameterId);
    }
}
