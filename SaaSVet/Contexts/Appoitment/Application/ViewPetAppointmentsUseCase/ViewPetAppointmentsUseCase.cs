using SaaSVet.Contexts.Appoitment.Domain.Entities;
using SaaSVet.Contexts.Appoitment.Domain.IRepositories;

namespace SaaSVet.Contexts.Appoitment.Application.ViewPetAppointmentsUseCase;

public class ViewPetAppointmentsUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;
    public ViewPetAppointmentsUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<Appointment>> RunAsync(ViewPetAppointmentsDto dto)
    {
        return await _appointmentRepository.GetByPetIdAsync(dto.PetId);
    }
}