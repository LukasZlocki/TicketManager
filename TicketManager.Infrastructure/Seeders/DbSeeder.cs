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
            // Seed Departments db
            if(await _dbContext.Database.CanConnectAsync())
            {
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
                    _dbContext.FactoryLocations.Add(factoryLoc2);

                    await _dbContext.SaveChangesAsync();
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

            }
        }

    }
}