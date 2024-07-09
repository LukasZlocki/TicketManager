using TicketManager.Models.Models;

namespace TicketManager.Services.LabLocation_Services
{
    public interface ILabLocationService
    {
        public List<LabLocation> GetAllLabLocations();
        public LabLocation GetLablocationByLabLocationId(int labLocationId);
    }
}