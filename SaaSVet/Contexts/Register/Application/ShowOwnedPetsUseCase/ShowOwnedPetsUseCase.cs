using SaaSVet.Contexts.Register.Domain.IRepositories;
using SaaSVet.Contexts.Register.Domain.Entities;

namespace SaaSVet.Contexts.Register.Application.ShowOwnedPetsUseCase;

public class ShowOwnedPetsUseCase
{
    private readonly IPetRepository _petRepository;
    private readonly IPetOwnerRepository _petOwnerRepository;

    public ShowOwnedPetsUseCase(IPetRepository petRepository, IPetOwnerRepository petOwnerRepository)
    {
        _petRepository = petRepository;
        _petOwnerRepository = petOwnerRepository;
    }

    public async Task<List<Pet>> RunAsync(ShowOwnedPetsDto dto)
    {
        PetOwner owner = await _petOwnerRepository.FindByIdAsync(dto.OwnerId);
        if (owner == null) 
            throw new ArgumentException($"Owner with id {dto.OwnerId} does not exist");
        
        List<Pet> pets = await _petRepository.GetByOwnerIdAsync(dto.OwnerId);
        return pets;
    }
}