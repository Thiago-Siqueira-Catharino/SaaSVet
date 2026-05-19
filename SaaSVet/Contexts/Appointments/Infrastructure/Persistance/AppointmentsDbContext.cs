using Microsoft.EntityFrameworkCore;
using SaaSVet.Contexts.Appointments.Domain.Entities;

namespace SaaSVet.Contexts.Appointments.Infrastructure.Persistance;

public class AppointmentsDbContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<PetOwner> PetOwners { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    public AppointmentsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>()
            .HasOne(p => p.owner)
            .WithMany(o => o.pets);
        
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.pet)
            .WithMany(p => p.appointments);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.clinic)
            .WithMany(c => c.appointments);
    }
}