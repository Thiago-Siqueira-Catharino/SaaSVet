using Microsoft.EntityFrameworkCore;
using SaaSVet.Common.Persistance;
using SaaSVet.Contexts.Register.Domain.Entities;
using SaaSVet.Contexts.Register.Domain.IRepositories;


namespace SaaSVet.Contexts.Register.Infrastructure.Repositories;

public class PetRepository : IPetRepository
{
    public readonly VetDbCotnext _database;
    public PetRepository(VetDbCotnext database)
    {
        _database = database;
    }

    public async Task AddAsync(Pet pet)
    {
        await  _database.Pets.AddAsync(pet);
        await _database.SaveChangesAsync();
    }

    public async Task<Pet> FindByIdAsync(int petId)
    {
        return await _database.Pets.FirstOrDefaultAsync(p => p.Id == petId);
    }

    public async Task SaveAsync(Pet petToUpdate)
    {
        _database.Pets.Update(petToUpdate);
        await _database.SaveChangesAsync();
    }

    public async Task<List<Pet>> GetByOwnerIdAsync(int ownerId)
    {
        return await _database.Pets
            .AsNoTracking()
            .Where(p => p.owner.Id == ownerId && p.IsDeleted == false)
            .ToListAsync();
    }
}