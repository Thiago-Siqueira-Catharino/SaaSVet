using SaaSVet.Contexts.Register.Domain.IRepositories;

namespace SaaSVet.Contexts.Register.Application.DeletePetUseCase;

public class DeletePetUseCase
{
    private readonly IPetOwnerRepository _petOwnerRepository;
    private readonly IPetRepository _petRepository;

    public DeletePetUseCase(IPetOwnerRepository petOwnerRepository, IPetRepository petRepository)
    {
        _petOwnerRepository = petOwnerRepository;
        _petRepository = petRepository;
    }

    public async Task RunAsync(DeletePetDto dto)
    {
        var owner = await _petOwnerRepository.FindByIdAsync(dto.ownerId);
        if (owner == null)
            throw new Exception("Owner not found");
        
        var pet = owner.pets.Where(pet => pet.id == dto.petId).FirstOrDefault();
        if (pet == null)
            throw new Exception("Pet not found");
        
        owner.pets.Remove(pet);
        await _petOwnerRepository.SaveAsync(owner);
    }
}