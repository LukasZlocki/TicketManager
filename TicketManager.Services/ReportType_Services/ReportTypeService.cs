using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.ReportType_Services
{
    public class ReportTypeService : IReportTypeService
    {
        private readonly TicketManagerDbContext _db;

        public ReportTypeService(TicketManagerDbContext db)
        {
            _db = db;
        }

        public List<ReportType> GetAllReportTypes()
        {
            var service = _db.ReportTypes.ToList();
            return service;
        }

        public ReportType GetReportTypeById(int reportTypeId)
        {
            var service = _db.ReportTypes.FirstOrDefault(id => id.ReportTypeId == reportTypeId);
            return service ?? new ReportType();
        }
    }
}