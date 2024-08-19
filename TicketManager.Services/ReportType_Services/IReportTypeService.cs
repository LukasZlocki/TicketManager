using TicketManager.Models.Models;

namespace TicketManager.Services.ReportTypeServices
{
    public interface IReportTypeService
    {
        List<ReportType> GetAllReportTypes();
        ReportType GetReportTypeById(int reportTypeId);
    }
}