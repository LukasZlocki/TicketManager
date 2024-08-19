using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;
using TicketManager.Services.ProductServices;

namespace TicketManager.Services.Product_Services
{
    public class ProductService : IProductService
    {
        private readonly TicketManagerDbContext _db;

        public ProductService(TicketManagerDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns>List of Product objects</returns>
        public List<Product> GetAllProducts()
        {
            var service = _db.Products.ToList();
            return service;
        }

        /// <summary>
        /// Returns product by its primary key
        /// </summary>
        /// <param name="priductId"></param>
        /// <returns></returns>
        public Product GetProductById(int productId)
        {
            var service = _db.Products.FirstOrDefault(id => id.ProductId == productId);
            return service ?? new Product();
        }
    }
}