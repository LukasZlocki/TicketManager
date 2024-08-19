using TicketManager.Models.Models;

namespace TicketManager.Services.LabLocationServices
{
    public interface ILabLocationService
    {
        public List<LabLocation> GetAllLabLocations();
        public LabLocation GetLablocationByLabLocationId(int labLocationId);
    }
}