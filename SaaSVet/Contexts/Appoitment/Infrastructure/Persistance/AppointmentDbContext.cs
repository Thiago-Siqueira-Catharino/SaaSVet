using Microsoft.EntityFrameworkCore;
using SaaSVet.Contexts.Appoitment.Domain.Entities;

namespace SaaSVet.Contexts.Appoitment.Infrastructure.Persistance;

public class AppointmentDbContext : DbContext
{
    public DbSet<Appointment> Appoitments { get; set; }

    public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
            .HasKey(a => a.PetId);
    }
}