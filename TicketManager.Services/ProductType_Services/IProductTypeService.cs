using TicketManager.Models.Models;

namespace TicketManager.Services.ProductTypeServices
{
    public interface IProductTypeService
    {
        public List<ProductType> GetAllProductTypes();
        public List<ProductType> GetAllProductTypesByFamilyId(int familyId);
        public ProductType GetProductTypeById(int productTypeId);
    }
}