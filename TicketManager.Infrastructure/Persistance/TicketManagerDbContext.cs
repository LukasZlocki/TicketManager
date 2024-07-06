using Microsoft.EntityFrameworkCore;

namespace TicketManager.Infrastructure.Persistance
{
    class TicketManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=TicketManager;User ID=SA;Password=TicketManager!1;TrustServerCertificate=true");
        }
    }
}
