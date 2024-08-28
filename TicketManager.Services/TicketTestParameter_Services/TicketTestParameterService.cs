using System.Net.Sockets;
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

        public ResponseService<TicketTestParameter> DeleteTicketTestParameter(int ticketTestParameterId)
        {
            var ticketTestParameter = _db.TicketTestParameters.Find(ticketTestParameterId);
            if (ticketTestParameter == null)
            {
                return new ResponseService<TicketTestParameter>
                {
                    IsSucess = false,
                    Message = "No ticket test parameter found.",
                    Time = DateTime.UtcNow,
                    Data = ticketTestParameter
                };
            }

            try
            {
                // Deleting process
                _db.TicketTestParameters.Remove(ticketTestParameter);
                // delete
                _db.SaveChanges();
                return new ResponseService<TicketTestParameter>
                {
                    IsSucess = true,
                    Message = "TicketTestParameter deleted.",
                    Time = DateTime.UtcNow,
                    Data = ticketTestParameter
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

        public ResponseService<TicketTestParameter> UpdateTicketTestParameter(TicketTestParameter ticketTestParameter)
        {
            // Updating ticket test parameter BUT if not found ticket test parameter to be created
            var existingTicketTestParameter = _db.TicketTestParameters.Find(ticketTestParameter.TicketTestParameterId);
            if (existingTicketTestParameter != null)
            {
                try
                {
                    existingTicketTestParameter.TicketTestParameterId = ticketTestParameter.TicketTestParameterId;
                    existingTicketTestParameter.ParameterValue = ticketTestParameter.ParameterValue;
                    existingTicketTestParameter.TestParameterId = ticketTestParameter.TestParameterId;
                    existingTicketTestParameter.TicketTestId = ticketTestParameter.TicketTestId;
                    _db.Update(existingTicketTestParameter);
                    _db.SaveChanges();
                    return new ResponseService<TicketTestParameter>
                    {
                        IsSucess = true,
                        Message = "TicketTestParameter updated.",
                        Time = DateTime.UtcNow,
                        Data = ticketTestParameter
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
            else
            {
                // ticket test parameter does not exist - create ticket test parameter
                var createTicketTestParameterResponse = CreateTicketTestParameter(ticketTestParameter);
                return createTicketTestParameterResponse;
            }
        }
    }
}
