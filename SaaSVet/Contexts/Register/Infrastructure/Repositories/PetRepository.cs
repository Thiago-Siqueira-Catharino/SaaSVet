using Microsoft.EntityFrameworkCore;
using SaaSVet.Contexts.Register.Domain.Entities;
using SaaSVet.Contexts.Register.Domain.IRepositories;
using SaaSVet.Contexts.Register.Infrastructure.Persistance;

namespace SaaSVet.Contexts.Register.Infrastructure.Repositories;

public class PetRepository : IPetRepository
{
    public readonly RegisterDbContext _database;
    public PetRepository(RegisterDbContext database)
    {
        _database = database;
    }

    public async Task AddAsync(Pet pet)
    {
        await  _database.Pets.AddAsync(pet);
        await _database.SaveChangesAsync();
    }

    public async Task<List<Pet>> GetByOwnerIdAsync(int ownerId)
    {
        return await _database.Pets.Where(p => p.owner.id == ownerId).ToListAsync();
    }
}