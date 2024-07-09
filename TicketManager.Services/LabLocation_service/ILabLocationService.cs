using TicketManager.Models.Models;

namespace TicketManager.Services.LabLocation_service
{
    public interface ILabLocationService
    {
        public List<LabLocation> GetAllLabLocations();
        public LabLocation GetLablocationByLabLocationId(int labLocationId);
    }
}