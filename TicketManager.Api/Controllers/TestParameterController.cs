using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.TestParameter_Services;

namespace TicketManager.Api.Controllers
{
    [ApiController]
    public class TestParameterController : Controller
    {
        private readonly ITestParameterServices _parameterServices;

        public TestParameterController(ITestParameterServices parameterServices)
        {
            _parameterServices = parameterServices;
        }

        // GET
        [HttpGet("api/parametersbytestid/{id}")]
        public ActionResult GetTestParametersByTestId(int id)
        {
            var parameters = _parameterServices.GetTestParametersByTestId(id);
            return Ok(parameters);
        }
    }
}
