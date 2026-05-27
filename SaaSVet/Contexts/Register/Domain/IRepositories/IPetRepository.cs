using SaaSVet.Contexts.Register.Domain.Entities;

namespace SaaSVet.Contexts.Register.Domain.IRepositories;

public interface IPetRepository
{
    public Task AddAsync(Pet petToAdd);
}