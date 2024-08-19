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

        /// <summary>
        /// Returns test object by its primary key
        /// </summary>
        /// <param name="testId"></param>
        /// <returns>Test object</returns>
        public Test GetTestById(int testId)
        {
            var service = _db.Tests.FirstOrDefault(id => id.TestId == testId);
            return service ?? new Test();
        }

        /// <summary>
        /// Returns all tests related to lab locations by lab loaction primary key
        /// </summary>
        /// <param name="labLocationId"></param>
        /// <returns></returns>
        public List<Test> GetTestsByLabLocation(int labLocationId)
        {
            var service = _db.Tests
                .Where(id => id.LabLocationId == labLocationId)
                    .ToList();
            return service;
        }
    }
}