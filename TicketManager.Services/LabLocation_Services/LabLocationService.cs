using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.LabLocation_Services
{
    public class LabLocationService : ILabLocationService
    {
        private readonly TicketManagerDbContext _db;
        
        public LabLocationService(TicketManagerDbContext db)
        {
            _db = db;   
        }

        /// <summary>
        /// Returns all lab locations
        /// </summary>
        /// <returns>list of LabLocation objects</returns>
        public List<LabLocation> GetAllLabLocations()
        {
            var service = _db.LabLocations.ToList();
            return service;
        }

        /// <summary>
        /// Returns lab location by primary key
        /// </summary>
        /// <param name="labLocationId"></param>
        /// <returns></returns>
        public LabLocation GetLablocationByLabLocationId(int labLocationId)
        {
            var service = _db.LabLocations.FirstOrDefault(id => id.LabLocationId == labLocationId);
            return service ?? new LabLocation();
        }
    }
}