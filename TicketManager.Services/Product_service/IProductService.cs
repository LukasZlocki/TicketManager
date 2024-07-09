using TicketManager.Models.Models;

namespace TicketManager.Services.Product_service
{
    public interface IProductService
    {
        public List<Product> GetAllProductFamilies();
        public Product GetProductById(int priductId);
    }
}