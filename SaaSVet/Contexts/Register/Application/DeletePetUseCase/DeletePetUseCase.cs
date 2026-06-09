using SaaSVet.Contexts.Appoitment.Domain.IRepositories;
using SaaSVet.Contexts.Register.Domain.IRepositories;

namespace SaaSVet.Contexts.Register.Application.DeletePetUseCase;

public class DeletePetUseCase
{
    private readonly IPetOwnerRepository _petOwnerRepository;
    private readonly IPetRepository _petRepository;
    private readonly IAppointmentRepository _appointmentRepository;

    public DeletePetUseCase(IPetOwnerRepository petOwnerRepository, IPetRepository petRepository, IAppointmentRepository appointmentRepository)
    {
        _petOwnerRepository = petOwnerRepository;
        _petRepository = petRepository;
        _appointmentRepository = appointmentRepository;
    }

    public async Task RunAsync(DeletePetDto dto)
    {
        var owner = await _petOwnerRepository.FindByIdAsync(dto.ownerId);
        if (owner == null)
            throw new Exception("Owner not found");
        
        var pet = await _petRepository.FindByIdAsync(dto.petId);
        if (pet == null)
            throw new Exception("Pet not found");
        
        if(await _appointmentRepository.HasFutureAppointmentAsync(pet.Id))
            throw new Exception("This pet still has appointments");
        
        pet.Delete();
        await _petRepository.SaveAsync(pet);
    }
}