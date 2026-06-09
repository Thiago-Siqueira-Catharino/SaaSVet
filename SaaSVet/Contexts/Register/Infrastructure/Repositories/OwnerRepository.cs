using SaaSVet.Common.Persistance;
using SaaSVet.Contexts.Register.Domain.Entities;
using SaaSVet.Contexts.Register.Domain.IRepositories;

namespace SaaSVet.Contexts.Register.Infrastructure.Repositories;

public class OwnerRepository : IPetOwnerRepository
{
    private readonly VetDbCotnext _database;
    public OwnerRepository(VetDbCotnext database)
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