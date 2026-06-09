using Microsoft.EntityFrameworkCore;
using SaaSVet.Contexts.Appoitment.Domain.Entities;
using SaaSVet.Contexts.Register.Domain.Entities;

namespace SaaSVet.Common.Persistance;

public class VetDbCotnext : DbContext
{
    public DbSet<Appointment>  Appointments { get; set; }
    public DbSet<PetOwner> PetOwners { get; set; }
    public DbSet<Pet> Pets { get; set; }

    public VetDbCotnext(DbContextOptions<VetDbCotnext> options) :  base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>()
            .HasOne(p => p.owner)
            .WithMany(o => o.pets)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Appointment>()
            .HasOne<Pet>()
            .WithMany()
            .HasForeignKey(a => a.PetId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}