using TicketManager.Models.Models;

namespace TicketManager.Services.ProductType_service
{
    public interface IProductTypeService
    {
        public List<ProductType> GetAllProductTypesByFamilyId(int familyId);
        public ProductType GetProductTypeById(int productTypeId);
    }
}