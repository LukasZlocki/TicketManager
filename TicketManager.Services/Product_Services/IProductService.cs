using TicketManager.Models.Models;

namespace TicketManager.Services.Product_Services
{
    public interface IProductService
    {
        public List<Product> GetAllProductFamilies();
        public Product GetProductById(int priductId);
    }
}