using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.ProductFamily_Services
{
    public class ProductFamilyService : IProductFamilyService
    {
        private readonly TicketManagerDbContext _db;

        public ProductFamilyService(TicketManagerDbContext db)
        {
            _db = db;
        }

        public List<ProductFamily> GetAllProductFamilies()
        {
            var families = _db.ProductFamilies.ToList();
            return families;
        }

        public ProductFamily GetProductFamilyById(int productFamilyId)
        {
            var family = _db.ProductFamilies.FirstOrDefault(id => id.ProductFamilyId == productFamilyId);
            return family ?? new ProductFamily();
        }   
    }
}