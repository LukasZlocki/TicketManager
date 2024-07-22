using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;
using TicketManager.Services.Test_Services;

namespace TicketManager.Services.Test_services
{
    public class TestService : ITestService
    {
        private readonly TicketManagerDbContext _db;

        public TestService(TicketManagerDbContext db)
        {
            _db = db;
        }

        public Test GetTestById(int testId)
        {
            var service = _db.Tests.FirstOrDefault(id => id.TestId == testId);
            return service ?? new Test();
        }

        public List<Test> GetTestsByLabLocation(int labLocationId)
        {
            var service = _db.Tests
                .Where(id => id.LabLocationId == labLocationId)
                    .ToList();
            return service;
        }
    }
}