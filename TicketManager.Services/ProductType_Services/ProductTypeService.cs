using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.ProductType_Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly TicketManagerDbContext _db;

        public ProductTypeService(TicketManagerDbContext db)
        {
            _db = db;
        }

        public List<ProductType> GetAllProductTypesByFamilyId(int familyId)
        {
            var service = _db.ProductTypes
                .Where(id => id.ProductId == familyId)
                    .ToList();
            return service;
        }

        public ProductType GetProductTypeById(int productTypeId)
        {
            var service = _db.ProductTypes.FirstOrDefault(id => id.ProductTypeId == productTypeId);
            return service ?? new ProductType();
        }
    }
}
