using TicketManager.Models.Models;

namespace TicketManager.Services.ReportType_Services
{
    public interface IReportTypeService
    {
        List<ReportType> GetAllReportTypes();
        ReportType GetReportTypeById(int reportTypeId);
    }
}