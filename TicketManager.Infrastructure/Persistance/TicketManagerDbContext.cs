using Microsoft.EntityFrameworkCore;
using TicketManager.Models;

namespace TicketManager.Infrastructure.Persistance
{
    class TicketManagerDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=TicketManager;User ID=SA;Password=TicketManager!1;TrustServerCertificate=true");
        }
    }
}