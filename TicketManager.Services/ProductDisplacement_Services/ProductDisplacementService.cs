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

        /// <summary>
        /// Returns all product displacements
        /// </summary>
        /// <returns>List of product displacement objects></returns>
        public List<ProductDisplacement> GetAllProductDisplacements()
        {
            var service = _db.ProductDisplacements.ToList();
            return service;
        }

        /// <summary>
        /// Returns product displacement by its primary id
        /// </summary>
        /// <param name="productDisplacementId"></param>
        /// <returns>ProductDisplacement object</returns>
        public ProductDisplacement GetProductDisplacementById(int productDisplacementId)
        {
            var service = _db.ProductDisplacements.FirstOrDefault(id => id.ProductDisplacementId == productDisplacementId);
            return service ?? new ProductDisplacement();
        }

        /// <summary>
        /// Returns all displacements related to product family by product family primary key 
        /// </summary>
        /// <param name="productFamilyId"></param>
        /// <returns>List of OriductDisplacement objects</returns>
        public List<ProductDisplacement> GetProductDisplacementsByProductFamilyId(int productFamilyId)
        {
            var service = _db.ProductDisplacements.Where(pr => pr.ProductFamilyId == productFamilyId).ToList();
            return service;
        }
    }
}