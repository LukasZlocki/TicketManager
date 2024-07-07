using TicketManager.Infrastructure.Persistance;
using TicketManager.Models.Models;

namespace TicketManager.Infrastructure.Seeders
{
    public class DbSeeder
    {
        private readonly TicketManagerDbContext _dbContext;

        public DbSeeder (TicketManagerDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            // Seed TicketManager db
            if(await _dbContext.Database.CanConnectAsync())
            {
                // Seed FactoryLocations db
                if (!_dbContext.FactoryLocations.Any())
                {
                    var factoryLoc1 = new FactoryLocation()
                    {
                        Country = "USA",
                        Factory = "HOP"
                    };
                    _dbContext.FactoryLocations.Add(factoryLoc1);

                    var factoryLoc2 = new FactoryLocation()
                    {
                        Country = "Poland",
                        Factory = "WRC"
                    };
                    _dbContext.FactoryLocations.Add(factoryLoc2);

                    var factoryLoc3 = new FactoryLocation()
                    {
                        Country = "Poland",
                        Factory = "WRL"
                    };
                    _dbContext.FactoryLocations.Add(factoryLoc3);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("FactoryLocations data exist - no need to seed.");
                }

                // Seed Departments db
                if (!_dbContext.Departments.Any())
                {
                    var department1 = new Department()
                    {
                        DepartmentDescription = "Test Department 1",
                        FactoryLocationId = 1
                    };
                    _dbContext.Departments.Add(department1);

                    var department2 = new Department()
                    {
                        DepartmentDescription = "Test Department 2",
                        FactoryLocationId = 2
                    };
                    _dbContext.Departments.Add(department2);

                    var department3 = new Department()
                    {
                        DepartmentDescription = "Test Department 3",
                        FactoryLocationId = 3
                    };
                    _dbContext.Departments.Add(department3);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("Departments data exist - no need to seed.");
                }

                // Seed LabLocations db
                if (!_dbContext.LabLocations.Any())
                {
                    var labLoc1 = new LabLocation()
                    {
                        Country = "USA",
                        Factory = "HOP"
                    };
                    _dbContext.LabLocations.Add(labLoc1);

                    var labLoc2 = new LabLocation()
                    {
                        Country = "Poland",
                        Factory = "WRC"
                    };
                    _dbContext.LabLocations.Add(labLoc2);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("LabLocations data exist - no need to seed.");
                }

                // Seed ProductDisplacements db
                if (!_dbContext.ProductDisplacements.Any())
                {
                    var displacement1 = new ProductDisplacement()
                    {
                        Displacement = 400,
                        ProductId = 1
                    };
                    _dbContext.ProductDisplacements.Add(displacement1);

                    var displacement2 = new ProductDisplacement()
                    {
                        Displacement = 30,
                        ProductId = 2
                    };
                    _dbContext.ProductDisplacements.Add(displacement2);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("ProductDisplacements data exist - no need to seed.");
                }

                // Seed ProductTypes db
                if (!_dbContext.ProductTypes.Any())
                {
                    var type1 = new ProductType()
                    {
                        ProductTypeDesc = "OMR",
                        ProductId = 1
                    };
                    _dbContext.ProductTypes.Add(type1);

                    var type2 = new ProductType()
                    {
                        ProductTypeDesc = "ON",
                        ProductId = 2
                    };
                    _dbContext.ProductTypes.Add(type2);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("ProductTypes data exist - no need to seed.");
                }

                // Seed Products db
                if (!_dbContext.Products.Any())
                {
                    var product1 = new Product()
                    {
                        ProductFamilly = "Motor",
                        ProductTypeId = 1,
                        ProductDisplacementId = 1
                    };
                    _dbContext.Products.Add(product1);

                    var product2 = new Product()
                    {
                        ProductFamilly = "Steering",
                        ProductTypeId = 2,
                        ProductDisplacementId = 2
                    };
                    _dbContext.Products.Add(product2);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("Products data exist - no need to seed.");
                }

                // Seed ReportStructures db
                if (!_dbContext.ReportStructures.Any())
                {
                    var structure1 = new ReportStructure()
                    {
                        FolderDescription = "00 Test description folder",
                        ReportTypeId = 1
                    };
                    _dbContext.ReportStructures.Add(structure1);

                    var structure2 = new ReportStructure()
                    {
                        FolderDescription = "10 Test result folder",
                        ReportTypeId = 1
                    };
                    _dbContext.ReportStructures.Add(structure2);

                    var structure3 = new ReportStructure()
                    {
                        FolderDescription = "1 Test description folder",
                        ReportTypeId = 2
                    };
                    _dbContext.ReportStructures.Add(structure3);

                    var structure4 = new ReportStructure()
                    {
                        FolderDescription = "2 Test result folder",
                        ReportTypeId = 2
                    };
                    _dbContext.ReportStructures.Add(structure4);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("ReportStructures data exist - no need to seed.");
                }

                // Seed ReportTypes db
                if (!_dbContext.ReportTypes.Any())
                {
                    var reptype1 = new ReportType()
                    {
                        ReportShortType = "MER",
                        ReportDescription = "Motor Engineering Report"
                    };
                    _dbContext.ReportTypes.Add(reptype1);

                    var reptype2 = new ReportType()
                    {
                        ReportShortType = "SER",
                        ReportDescription = "Steering Engineering Report"
                    };
                    _dbContext.ReportTypes.Add(reptype2);

                    var reptype3 = new ReportType()
                    {
                        ReportShortType = "CTR",
                        ReportDescription = "Custom Test Request"
                    };
                    _dbContext.ReportTypes.Add(reptype3);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("ReportTypes data exist - no need to seed.");
                }

                // Seed Tests db
                if (!_dbContext.Tests.Any())
                {
                    var test1 = new Test()
                    {
                        TestDescription = "Leakage",
                        TestUnits ="l/min"
                    };
                    _dbContext.Tests.Add(test1);

                    var test2 = new Test()
                    {
                        TestDescription = "Slippage",
                        TestUnits = "RPM"
                    };
                    _dbContext.Tests.Add(test2);

                    var test3 = new Test()
                    {
                        TestDescription = "Input Torque",
                        TestUnits = "daNm"
                    };
                    _dbContext.Tests.Add(test3);


                    var test4 = new Test()
                    {
                        TestDescription = "Pressure Drop",
                        TestUnits = "bar"
                    };
                    _dbContext.Tests.Add(test4);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("Tests data exist - no need to seed.");
                }

                // Seed Tickets db
                if (!_dbContext.Tickets.Any())
                {
                    var ticket1 = new Ticket()
                    {
                        RequestorEmail = "req1@email.com",
                        ImplementedAt = DateTime.UtcNow,
                        StartedAt = DateTime.UtcNow,
                        FinishedAt =DateTime.UtcNow,
                        DepartmentId = 1,
                        LabLocationId = 1,
                        ProductId = 1,
                        StatusId = 3
                    };
                    _dbContext.Tickets.Add(ticket1);

                    var ticket2 = new Ticket()
                    {
                        RequestorEmail = "req2@email.com",
                        ImplementedAt = DateTime.UtcNow,
                        //StartedAt = DateTime.UtcNow,
                        //FinishedAt = DateTime.UtcNow,
                        DepartmentId = 1,
                        LabLocationId = 1,
                        ProductId = 1,
                        StatusId = 1
                    };
                    _dbContext.Tickets.Add(ticket2);

                    var ticket3 = new Ticket()
                    {
                        RequestorEmail = "req3@email.com",
                        ImplementedAt = DateTime.UtcNow,
                        StartedAt = DateTime.UtcNow,
                        //FinishedAt = DateTime.UtcNow,
                        DepartmentId = 1,
                        LabLocationId = 1,
                        ProductId = 1,
                        StatusId = 2
                    };
                    _dbContext.Tickets.Add(ticket3);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("Tickets data exist - no need to seed.");
                }

                // Seed TicketStatuses db
                if (!_dbContext.TicketStatuses.Any())
                {
                    var status1 = new TicketStatus()
                    {
                        StatusDescription = "Waiting"
                    };
                    _dbContext.TicketStatuses.Add(status1);

                    var status2 = new TicketStatus()
                    {
                        StatusDescription = "In Progress"
                    };
                    _dbContext.TicketStatuses.Add(status2);

                    var status3 = new TicketStatus()
                    {
                        StatusDescription = "Finished"
                    };
                    _dbContext.TicketStatuses.Add(status3);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("TicketStatuses data exist - no need to seed.");
                }

                // Seed TicketTests db
                if (!_dbContext.TicketTests.Any())
                {
                    var tickettest1 = new TicketTest()
                    {
                        TestParameter = 5,
                        TestId = 1,
                        TicketId = 1
                    };
                    _dbContext.TicketTests.Add(tickettest1);

                    var tickettest2 = new TicketTest()
                    {
                        TestParameter = 10,
                        TestId = 2,
                        TicketId = 1
                    };
                    _dbContext.TicketTests.Add(tickettest2);

                    var tickettest3 = new TicketTest()
                    {
                        TestParameter = 30,
                        TestId = 2,
                        TicketId = 2
                    };
                    _dbContext.TicketTests.Add(tickettest3);

                    var tickettest4 = new TicketTest()
                    {
                        TestParameter = 2,
                        TestId = 1,
                        TicketId = 3
                    };
                    _dbContext.TicketTests.Add(tickettest4);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("TicketTests data exist - no need to seed.");
                }
            }
        }

    }
}