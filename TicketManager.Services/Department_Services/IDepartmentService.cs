using TicketManager.Models.Models;

namespace TicketManager.Services.Department_Services
{
    public interface IDepartmentService
    {
        public List<Department> GetAllDepartmentsByFactoryLocationId(int factoryLocationId);
        public Department GetDepartmentByDepartmentId(int departmentId);
    }
}