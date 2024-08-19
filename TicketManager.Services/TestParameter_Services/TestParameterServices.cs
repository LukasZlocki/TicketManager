using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.TestParameter_Services
{
    public class TestParameterServices : ITestParameterServices
    {
        private readonly TicketManagerDbContext _db;

        public TestParameterServices(TicketManagerDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns test parameters by primary key
        /// </summary>
        /// <param name="testParameterId"></param>
        /// <returns>TestParameters object</returns>
        public TestParameter GetTestParameterById(int testParameterId)
        {
            var service = _db.TestParameters.FirstOrDefault(id => id.TestParameterId == testParameterId);
            return service;
        }

        /// <summary>
        /// Returns list of test parameters by test id foreign key
        /// </summary>
        /// <param name="testId"></param>
        /// <returns>List of TestParameters objects</returns>
        public List<TestParameter> GetTestParametersByTestId(int testId)
        {
            var service = _db.TestParameters.Where(id => id.TestId == testId).ToList();
            return service;
        }
    }
}
