using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.FactoryLocation_Services
{
    public class FactoryLocationService : IFactoryLocationService
    {
        private readonly TicketManagerDbContext _db;

        public FactoryLocationService(TicketManagerDbContext db)
        {
            _db = db;
        }

        public List<FactoryLocation> GetAllFactoryLocations()
        {
            var service = _db.FactoryLocations.ToList();
            return service;
        }

        public FactoryLocation GetFactoryLocationByFactoryLocationId(int factoryLocationId)
        {
            var service = _db.FactoryLocations.FirstOrDefault(id => id.FactoryLocationId == factoryLocationId);
            return service ?? new FactoryLocation();
        }
    }
}