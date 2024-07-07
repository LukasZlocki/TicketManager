using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;

namespace TicketManager.Infrastructure.Persistance
{
    public class TicketManagerDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<FactoryLocation> FactoryLocations { get; set; }
        public DbSet<LabLocation> LabLocations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDisplacement> ProductDisplacements { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ReportStructure> ReportStructures { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketTest> TicketTests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=TicketManager;User ID=SA;Password=TicketManager!1;TrustServerCertificate=true");
        }
    }
}