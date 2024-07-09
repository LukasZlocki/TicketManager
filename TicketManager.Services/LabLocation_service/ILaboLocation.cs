using TicketManager.Models.Models;

namespace TicketManager.Services.LabLocation_service
{
    public interface ILaboLocation
    {
        public List<LabLocation> GetAllLabLocations();
        public LabLocation GetLablocationByLabLocationId(int labLocationId);
    }
}