using TicketManager.Models.Models;

namespace TicketManager.Services.TicketTest_Services
{
    public interface ITicketTestService
    {
        public List<TicketTest> GetTicketTestsByTicketId(int ticketId);
        public TicketTest GetTicketTestByTicketTestId(int ticketTestId);
        public ResponseService<TicketTest> CreateTicketTests(TicketTest ticketTestList);
        public ResponseService<TicketTest> UpdateTicketTest(TicketTest ticketTest);
        public ResponseService<TicketTest> DeleteTicketTest(int ticketTestId);
    }
}