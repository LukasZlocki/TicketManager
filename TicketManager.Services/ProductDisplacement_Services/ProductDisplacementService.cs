using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.ProductDisplacement_Services
{
    public class ProductDisplacementService : IProductDisplacementService
    {
        private readonly TicketManagerDbContext _db;

        public ProductDisplacementService(TicketManagerDbContext db)
        {
            _db = db;
        }

        public ProductDisplacement GetProductDisplacementById(int productDisplacementId)
        {
            var service = _db.ProductDisplacements.FirstOrDefault(id => id.ProductDisplacementId == productDisplacementId);
            return service ?? new ProductDisplacement();
        }

        public List<ProductDisplacement> GetProductDisplacementsByProductFamilyId(int productFamilyId)
        {
            var service = _db.ProductDisplacements.Where(pr => pr.ProductId == productFamilyId).ToList();
            return service;
        }
    }
}