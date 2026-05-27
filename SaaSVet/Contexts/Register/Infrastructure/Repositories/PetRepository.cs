using SaaSVet.Contexts.Register.Domain.Entities;
using SaaSVet.Contexts.Register.Domain.IRepositories;
using SaaSVet.Contexts.Register.Infrastructure.Persistance;

namespace SaaSVet.Contexts.Register.Infrastructure.Repositories;

public class PetRepository : IPetRepository
{
    public readonly AppointmentsDbContext _database;
    public PetRepository(AppointmentsDbContext database)
    {
        _database = database;
    }

    public async Task AddAsync(Pet pet)
    {
        await  _database.Pets.AddAsync(pet);
        await _database.SaveChangesAsync();
    }
}