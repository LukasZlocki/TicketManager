using TicketManager.Models.Models;

namespace TicketManager.Services.TestParameter_Services
{
    public interface ITestParameterServices
    {
        public List<TestParameter> GetTestParametersByTestId(int testId);
        public TestParameter GetTestParameterById(int testParameterId);
    }
}
