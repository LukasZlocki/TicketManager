using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;
using TicketManager.Services.ProductTypeServices;

namespace TicketManager.Services.ProductType_Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly TicketManagerDbContext _db;

        public ProductTypeService(TicketManagerDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns all product types from database
        /// </summary>
        /// <returns>List of productType objects</returns>
        public List<ProductType> GetAllProductTypes()
        {
            var service = _db.ProductTypes.ToList();
            return service;
        }

        /// <summary>
        /// Returns product types by product family primary key
        /// </summary>
        /// <param name="familyId"></param>
        /// <returns>List of ProductType objects</returns>
        public List<ProductType> GetAllProductTypesByFamilyId(int familyId)
        {
            var service = _db.ProductTypes
                .Where(id => id.ProductFamilyId == familyId)
                    .ToList();
            return service;
        }

        /// <summary>
        /// Returns product type by its primary key
        /// </summary>
        /// <param name="productTypeId"></param>
        /// <returns>ProductType object</returns>
        public ProductType GetProductTypeById(int productTypeId)
        {
            var service = _db.ProductTypes.FirstOrDefault(id => id.ProductTypeId == productTypeId);
            return service ?? new ProductType();
        }
    }
}