using SaaSVet.Contexts.Register.Domain.Entities;
using SaaSVet.Contexts.Register.Domain.IRepositories;

namespace SaaSVet.Contexts.Register.Application;

public class ShowOwnersUseCase
{
    private readonly IPetOwnerRepository _petOwnerRepository;
    public ShowOwnersUseCase(IPetOwnerRepository petOwnerRepository)
    {
        _petOwnerRepository = petOwnerRepository;
    }

    public async Task<List<PetOwner>> RunAsync()
    {
        return await _petOwnerRepository.GetAllAsync();
    }
}