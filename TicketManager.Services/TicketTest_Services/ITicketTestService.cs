using TicketManager.Models.Models;

namespace TicketManager.Services.TicketTest_Services
{
    public interface ITicketTestService
    {
        public List<TicketTest> GetTicketTestsByTicketId(int ticketId);
        public TicketTest GetTicketTestByTicketTestId(int ticketTestId);
        public ResponseService<TicketTest> CreateTicketTests(TicketTest ticketTestList);
    }
}