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
        public DbSet<Perdoruesi> Perdoruesit { get; set; }

        public DbSet<Aeroplani> Aeroplani { get; set; }
        public DbSet<Fluturimi>Fluturimet { get; set; }
        public DbSet<Rezervimi> Rezervimet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Qyteti>()
            .HasOne(p => p.Shteti)
            .WithMany()
            .HasForeignKey(p => p.ShtetiId) //Foreign Key
            .OnDelete(DeleteBehavior.Restrict);
          
            modelBuilder.Entity<Fluturimi>()
              .HasOne(p => p.Aeroplani)
              .WithMany()
              .HasForeignKey(p => p.AeroplaniId) //Foreign Key
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fluturimi>()
                .HasOne(cf => cf.Qyteti)
                .WithMany()
                .HasForeignKey(cf => cf.QytetiId)
                 .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Rezervimi>()
         .HasOne(p => p.Fluturimi)
         .WithMany()
         .HasForeignKey(p => p.FluturimiId) //Foreign Key
         .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
