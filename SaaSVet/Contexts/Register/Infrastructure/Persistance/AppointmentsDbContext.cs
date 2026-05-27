using Microsoft.EntityFrameworkCore;
using SaaSVet.Contexts.Register.Domain.Entities;

namespace SaaSVet.Contexts.Register.Infrastructure.Persistance;

public class AppointmentsDbContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<PetOwner> PetOwners { get; set; }

    public AppointmentsDbContext(DbContextOptions<AppointmentsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>()
            .HasOne(p => p.owner)
            .WithMany(o => o.pets);

        modelBuilder.Entity<PetOwner>();
    }
}