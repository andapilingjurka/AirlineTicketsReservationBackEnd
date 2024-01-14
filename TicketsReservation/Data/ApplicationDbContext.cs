using TicketsReservation.Model;
using Microsoft.EntityFrameworkCore;

namespace TicketsReservation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        public DbSet<Kontakti> Kontakti { get; set; }


    }
}
