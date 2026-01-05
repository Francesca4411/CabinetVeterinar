using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CabinetVeterinarWeb.Models;

namespace CabinetVeterinarWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Owner> Owners => Set<Owner>();
        public DbSet<Pet> Pets => Set<Pet>();
        public DbSet<Vet> Vets => Set<Vet>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Review> Reviews => Set<Review>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Appointment>()
                .HasOne(a => a.Review)
                .WithOne(r => r.Appointment)
                .HasForeignKey<Review>(r => r.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
