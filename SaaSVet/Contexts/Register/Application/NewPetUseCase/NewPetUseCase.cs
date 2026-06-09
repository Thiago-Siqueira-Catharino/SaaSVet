using SaaSVet.Contexts.Register.Domain.Entities;
using SaaSVet.Contexts.Register.Domain.IRepositories;

namespace SaaSVet.Contexts.Register.Application.NewPetUseCase;

public class NewPetUseCase
{
    private readonly IPetRepository _petRepository;
    private readonly IPetOwnerRepository _petOwnerRepository;

    public NewPetUseCase(IPetRepository petRepository, IPetOwnerRepository petOwnerRepository)
    {
        _petRepository = petRepository;
        _petOwnerRepository = petOwnerRepository;
    }

    public async Task RunsAsync(NewPetDto newPet)
    {
        PetOwner owner = await _petOwnerRepository.FindByIdAsync(newPet.ownerId);
        if (owner == null)
            throw new ArgumentException($"Owner with id {newPet.ownerId} does not exist");
        
        Pet petToAdd = new Pet(owner, newPet.petName);
        owner.AddPet(petToAdd);
        
        await _petRepository.AddAsync(petToAdd);
        await _petOwnerRepository.SaveAsync(owner);
    }
}