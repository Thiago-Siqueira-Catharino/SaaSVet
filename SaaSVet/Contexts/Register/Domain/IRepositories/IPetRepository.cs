using SaaSVet.Contexts.Appointments.Domain.Entities;

namespace SaaSVet.Contexts.Appointments.Domain.IRepositories;

public interface IPetRepository
{
    public Task AddAsync(Pet petToAdd);
}