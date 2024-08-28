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

        public ResponseService<TicketTest> DeleteTicketTest(int ticketTestId)
        {

            var ticketTest = _db.TicketTests.Find(ticketTestId);
            if (ticketTest == null)
            {
                return new ResponseService<TicketTest>
                {
                    IsSucess = false,
                    Message = "No ticket test found.",
                    Time = DateTime.UtcNow,
                    Data = ticketTest
                };
            }

            try
            {
                // Deleting process
                _db.TicketTests.Remove(ticketTest);
                // delete
                _db.SaveChanges();
                return new ResponseService<TicketTest>
                {
                    IsSucess = true,
                    Message = "TicketTest deleted.",
                    Time = DateTime.UtcNow,
                    Data = ticketTest
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

        public ResponseService<TicketTest> UpdateTicketTest(TicketTest ticketTest)
        {
            // ToDo: Code updating ticket test BUT if ticket not found ticket neeed to be created
            var existingTicketTest = _db.TicketTests.Find(ticketTest.TicketTestId);

            // if ticket test exist - update ticket test
            if (existingTicketTest != null)
            {
                try
                {
                    // Updating existing ticket test
                    existingTicketTest.TestId = ticketTest.TestId;
                    existingTicketTest.TicketId = ticketTest.TicketId;
                    _db.Update(existingTicketTest);
                    _db.SaveChanges();
                    return new ResponseService<TicketTest>
                    {
                        IsSucess = true,
                        Message = "TicketTest updated.",
                        Time = DateTime.UtcNow,
                        Data = ticketTest
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
            // ticket test does not exist - create ticket test
            else
            {
                var createTicketTestResponse = CreateTicketTests(ticketTest);
                return createTicketTestResponse;
            }
        }


    }
}