using SaaSVet.Contexts.Register.Domain.Entities;

namespace SaaSVet.Contexts.Register.Domain.IRepositories;

public interface IPetOwnerRepository
{
    public Task<PetOwner> FindByIdAsync(int id);
    public Task SaveAsync(PetOwner owner);
    public Task AddAsync(PetOwner owner);
    public Task<List<PetOwner>> GetAllAsync();
}