using TicketManager.Models.Models;

namespace TicketManager.Services.ProductFamily_Services
{
    public interface IProductFamilyService
    {
        public List<ProductFamily> GetAllProductFamilies();
        public ProductFamily GetProductFamilyById(int productFamilyId);
    }
}