using SaaSVet.Contexts.Register.Domain.Entities;
using SaaSVet.Contexts.Register.Domain.IRepositories;

namespace SaaSVet.Contexts.Register.Application.NewOwnerUseCase;

public class NewOwnerUseCase
{
    private readonly IPetOwnerRepository _petOwnerRepository;

    public NewOwnerUseCase(IPetOwnerRepository petOwnerRepository)
    {
        _petOwnerRepository = petOwnerRepository;
    }

    public async Task RunAsync(NewOwnerDto newOwnerDto)
    {
        PetOwner newOwner = new PetOwner(newOwnerDto.name, newOwnerDto.Cpf);
        await _petOwnerRepository.AddAsync(newOwner);
    }
}