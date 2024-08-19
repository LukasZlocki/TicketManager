using Microsoft.AspNetCore.Mvc;
using TicketManager.Services.Department_Services;

namespace TicketManager.Api.Controllers
{
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET
        [HttpGet("api/departmentbyfactory/{id}")]
        public ActionResult GetAllDepartmentsByFactoryId(int id)
        {
            var departments = _departmentService.GetAllDepartmentsByFactoryLocationId(id);
            return Ok(departments);
        }

        // GET
        [HttpGet("api/department/{id}")]
        public ActionResult GetDepartment(int id)
        {
            var department = _departmentService.GetDepartmentByDepartmentId(id);
            return Ok(department);
        }

        // GET
        [HttpGet("api/departments")]
        public ActionResult GetAllDepartments()
        {
            var departments = _departmentService.GetAllDepartments();
            return Ok(departments);
        }

    }
}