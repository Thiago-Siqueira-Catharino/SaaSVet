using SaaSVet.Contexts.Appoitment.Domain.Entities;
using SaaSVet.Contexts.Appoitment.Domain.IRepositories;

namespace SaaSVet.Contexts.Appoitment.Application.CreateAppointmentUseCase;

public class CreateAppointmentUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;
    public CreateAppointmentUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task RunsAsync(CreateAppointmentDto createAppointmentDto)
    {
        int petId = createAppointmentDto.PetId;
        DateTime date = createAppointmentDto.Date;
        DateTime windowEnd = date.AddHours(1);
        
        bool conflict = await _appointmentRepository.ExistsConflicAsync(petId, date, windowEnd);
        if (conflict)
            throw new Exception("There is a schedule conflict");
        
        Appointment appointment = new Appointment(petId, date);
        await _appointmentRepository.AddAsync(appointment);
    }
}