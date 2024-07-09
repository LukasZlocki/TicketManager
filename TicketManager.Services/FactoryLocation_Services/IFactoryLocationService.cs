using TicketManager.Models.Models;

namespace TicketManager.Services.FactoryLocation_Services
{
    public interface IFactoryLocationService
    {
        public List<FactoryLocation> GetAllFactoryLocations();
        public FactoryLocation GetFactoryLocationByFactoryLocationId(int factoryLocationId);
    }
}