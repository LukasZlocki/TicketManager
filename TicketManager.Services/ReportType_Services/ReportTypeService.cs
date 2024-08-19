using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;
using TicketManager.Services.ReportTypeServices;

namespace TicketManager.Services.ReportType_Services
{
    public class ReportTypeService : IReportTypeService
    {
        private readonly TicketManagerDbContext _db;

        public ReportTypeService(TicketManagerDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns all report  types 
        /// </summary>
        /// <returns>List of ReportType objects</returns>
        public List<ReportType> GetAllReportTypes()
        {
            var service = _db.ReportTypes.ToList();
            return service;
        }

        /// <summary>
        /// Returns report type by its primary key
        /// </summary>
        /// <param name="reportTypeId"></param>
        /// <returns></returns>
        public ReportType GetReportTypeById(int reportTypeId)
        {
            var service = _db.ReportTypes.FirstOrDefault(id => id.ReportTypeId == reportTypeId);
            return service ?? new ReportType();
        }
    }
}