using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.ReportType_Services;

namespace TicketManager.Api.Controllers
{
    public class ReportTypeController : Controller
    {
        private readonly IReportTypeService _reportTypeService;

        public ReportTypeController(IReportTypeService reportTypeService)
        {
            _reportTypeService = reportTypeService;
        }

        // GET
        [HttpGet("api/reporttypes")]
        public ActionResult GetAllLabLocations()
        {
            var reportTytpes = _reportTypeService.GetAllReportTypes();
            return Ok(reportTytpes);
        }

        // GET
        [HttpGet("api/reporttype/{id}")]
        public ActionResult GetReportType(int id)
        {
            var reportType = _reportTypeService.GetReportTypeById(id);
            return Ok(reportType);
        }
    }
}