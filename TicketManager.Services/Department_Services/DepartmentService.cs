using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.Department_Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly TicketManagerDbContext _db;

        public DepartmentService(TicketManagerDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns all departments in database
        /// </summary>
        /// <returns>List of Department objects</returns>
        public List<Department> GetAllDepartments()
        {
            var service = _db.Departments.ToList();
            return service;
        }

        /// <summary>
        /// Returns list of departments object which are located in factory by factory primary key.
        /// </summary>
        /// <param name="factoryLocationId"></param>
        /// <returns>List of Department</returns>
        public List<Department> GetAllDepartmentsByFactoryLocationId(int factoryLocationId)
        {
            var service = _db.Departments
                .Where(id => id.FactoryLocationId == factoryLocationId)
                    .ToList();
            return service;
        }

        /// <summary>
        /// Returns department object by primary key.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Department object</returns>
        public Department GetDepartmentByDepartmentId(int departmentId)
        {
            var service = _db.Departments.FirstOrDefault(id => id.DepartmentId == departmentId);
            return service ?? new Department();
        }
    }
}