using Microsoft.EntityFrameworkCore;

namespace AirlineTicketsReservation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

    }
}
