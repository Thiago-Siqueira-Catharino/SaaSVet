using SaaSVet.Contexts.Register.Domain.Entities;

namespace SaaSVet.Contexts.Register.Domain.IRepositories;

public interface IPetRepository
{
    public Task AddAsync(Pet petToAdd);
    public Task<Pet> FindByIdAsync(int petId);
    public Task SaveAsync(Pet petToUpdate);
    public Task<List<Pet>> GetByOwnerIdAsync(int ownerId);
}