using TicketManager.Models.Models;

namespace TicketManager.Services.ProductServices
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int productId);
    }
}