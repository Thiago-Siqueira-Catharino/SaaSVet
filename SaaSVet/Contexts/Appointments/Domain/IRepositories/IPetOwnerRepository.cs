using SaaSVet.Contexts.Appointments.Domain.Entities;

namespace SaaSVet.Contexts.Appointments.Domain.IRepositories;

public interface IPetOwnerRepository
{
    public Task<PetOwner> FindByIdAsync(int id);
    public Task SaveAsync(PetOwner owner);
}