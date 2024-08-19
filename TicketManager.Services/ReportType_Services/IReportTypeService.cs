using TicketManager.Models.Models;

namespace TicketManager.Services.ReportType_Services
{
    public interface IReportTypeService
    {
        public List<ProductType> GetAllProductTypes();
        public List<ProductType> GetAllProductTypesByFamilyId(int familyId);
        public ProductType GetProductTypeById(int productTypeId);
    }
}