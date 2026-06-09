using SaaSVet.Contexts.Register.Domain.Entities;
using SaaSVet.Contexts.Register.Domain.IRepositories;
using SaaSVet.Contexts.Register.Infrastructure.Persistance;

namespace SaaSVet.Contexts.Register.Infrastructure.Repositories;

public class OwnerRepository : IPetOwnerRepository
{
    private readonly RegisterDbContext _database;
    public OwnerRepository(RegisterDbContext database)
    {
        _database =  database;
    }

    public async Task<PetOwner> FindByIdAsync(int id)
    {
        return await _database.PetOwners.FindAsync(id);
    }

    public async Task AddAsync(PetOwner newOwner)
    {
        await _database.PetOwners.AddAsync(newOwner);
        await _database.SaveChangesAsync();
    }

    public async Task SaveAsync(PetOwner newOwner)
    {
        _database.PetOwners.Update(newOwner);
        await _database.SaveChangesAsync();
    }
}