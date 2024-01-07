using AirlineTicketsReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketsReservation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        public DbSet<Shteti> Shteti { get; set; }

        public DbSet<Qyteti> Qyteti { get; set; }
        public DbSet<Kontakti> Kontakti { get; set; }
        public DbSet<Perdoruesi> Perdoruesit { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Qyteti>()
            .HasOne(p => p.Shteti)
            .WithMany()
            .HasForeignKey(p => p.ShtetiId) //Foreign Key
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
