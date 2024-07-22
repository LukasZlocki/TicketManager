using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.Product_Services
{
    public class ProductService : IProductService
    {
        private readonly TicketManagerDbContext _db;

        public ProductService(TicketManagerDbContext db)
        {
            _db = db;
        }

        public List<Product> GetAllProductFamilies()
        {
            var service = _db.Products.ToList();
            return service;
        }

        public Product GetProductById(int priductId)
        {
            var service = _db.Products.FirstOrDefault(id => id.ProductId == priductId);
            return service ?? new Product();
        }
    }
}