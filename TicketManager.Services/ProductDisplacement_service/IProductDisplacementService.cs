using TicketManager.Models.Models;

namespace TicketManager.Services.ProductDisplacement_service
{
    public interface IProductDisplacementService
    {
        public List<ProductDisplacement> GetProductDisplacementsByProductFamilyId(int productFamilyId);
        public ProductDisplacement GetProductDisplacementById(int productDisplacementId);
    }
}