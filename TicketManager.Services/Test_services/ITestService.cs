using TicketManager.Models.Models;

namespace TicketManager.Services.Test_Services
{
    public interface ITestService
    {
        public List<Test> GetTestsByLabLocation(int labLocationId);
        public Test GetTestById(int testId);
    }
}