using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Services.TicketTest_Services
{
    public class TicketTestService : ITicketTestService
    {
        private readonly TicketManagerDbContext _db;

        public TicketTestService(TicketManagerDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns ticket test by its primary key
        /// </summary>
        /// <param name="ticketTestId"></param>
        /// <returns>TicketTest object</returns>
        public TicketTest GetTicketTestByTicketTestId(int ticketTestId)
        {
            var service = _db.TicketTests
                .Include(t => t.Test)
                    .FirstOrDefault(id => id.TicketTestId == ticketTestId);
            return service ?? new TicketTest();
        }

        /// <summary>
        /// Returns list of ticket tests object related to ticket primary key
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns>List of TicketTest objects</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<TicketTest> GetTicketTestsByTicketId(int ticketId)
        {
            var service = _db.TicketTests
                .Include(t => t.Test)
                    .Where(id => id.TicketId == ticketId)
                        .ToList();
            return service;
        }

        /// <summary>
        /// Save ticket tests object
        /// </summary>
        /// <param name="ticketTest"></param>
        /// <returns></returns>
        public ResponseService<TicketTest> CreateTicketTests(TicketTest ticketTest)
        {
            try
            {
                TicketTest _ticketTest = new TicketTest { 
                        TestId = ticketTest.TestId,
                        TicketId = ticketTest.TicketId
                    };

                _db.TicketTests.Add(_ticketTest);
                
                // Add
                _db.SaveChanges();
                return new ResponseService<TicketTest>
                {
                    IsSucess = true,
                    Message = "TicketTest added.",
                    Time = DateTime.UtcNow,
                    Data = _ticketTest
                };
            }
            catch (Exception e)
            {
                return new ResponseService<TicketTest>
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