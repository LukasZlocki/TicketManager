using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.TicketTestParameter_Services
{
    public class TicketTestParameterService : ITicketTestParameterService
    {
        private readonly TicketManagerDbContext _db;

        public TicketTestParameterService(TicketManagerDbContext db)
        {
            _db = db;
        }

        public TicketTestParameter GetTicketTestParameterById(int ticketTestParameterId)
        {
            var service = _db.TicketTestParameters.FirstOrDefault(id => id.TicketTestParameterId == ticketTestParameterId);
            return service ?? new TicketTestParameter();
        }

        public List<TicketTestParameter> GetTicketTestParametersByTicketTestId(int ticketTestId)
        {
            var service = _db.TicketTestParameters
                            .Where(id => id.TicketTestId == ticketTestId)
                                .ToList();
            return service;
        }

        public ResponseService<TicketTestParameter> CreateTicketTestParameter(TicketTestParameter ticketTestParameter)
        {
            try
            {
                TicketTestParameter _ticketTestParameter = new TicketTestParameter
                {
                    ParameterValue = ticketTestParameter.ParameterValue,   
                    TestParameterId = ticketTestParameter.TestParameterId,
                    TicketTestId = ticketTestParameter.TicketTestId
                };

                _db.TicketTestParameters.Add(_ticketTestParameter);

                // Add
                _db.SaveChanges();
                return new ResponseService<TicketTestParameter>
                {
                    IsSucess = true,
                    Message = "TicketTestParameter added.",
                    Time = DateTime.UtcNow,
                    Data = _ticketTestParameter
                };
            }
            catch (Exception e)
            {
                return new ResponseService<TicketTestParameter>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = null
                };
            }
        }
        
    }
}
