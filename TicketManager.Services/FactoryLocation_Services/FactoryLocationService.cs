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

        /// <summary>
        /// Returns all factory locations
        /// </summary>
        /// <returns>List of FactoryLocation objects</returns>
        public List<FactoryLocation> GetAllFactoryLocations()
        {
            var service = _db.FactoryLocations.ToList();
            return service;
        }

        /// <summary>
        /// Returns factory location object by its primary key
        /// </summary>
        /// <param name="factoryLocationId"></param>
        /// <returns>FactoryLocation object</returns>
        public FactoryLocation GetFactoryLocationByFactoryLocationId(int factoryLocationId)
        {
            var service = _db.FactoryLocations.FirstOrDefault(id => id.FactoryLocationId == factoryLocationId);
            return service ?? new FactoryLocation();
        }
    }
}