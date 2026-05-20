using SaaSVet.Contexts.Appointments.Domain.IRepositories;

namespace SaaSVet.Contexts.Appointments.Application.NewOwnerUseCase;

public class NewOwnerUseCase
{
    private readonly IPetOwnerRepository _petOwnerRepository;

    public NewOwnerUseCase(IPetOwnerRepository petOwnerRepository)
    {
        _petOwnerRepository = petOwnerRepository;
    }

    public async Task RunAsync(NewOwnerDto newOwnerDto)
    {
        PetOwner
    }
}