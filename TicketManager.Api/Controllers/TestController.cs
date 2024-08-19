using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.Test_Services;

namespace TicketManager.Api.Controllers
{
    [ApiController]
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        // GET
        [HttpGet("api/testbylablocation/{id}")]
        public ActionResult GetAllTestsByLabLocationId(int id)
        {
            var tests = _testService.GetTestsByLabLocation(id);
            return Ok(tests);
        }
    }
}
