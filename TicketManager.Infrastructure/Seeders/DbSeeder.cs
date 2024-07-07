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
                    _dbContext.FactoryLocations.Add(factoryLoc3);

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

                // Seed ReportStructure db
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

            }
        }

    }
}