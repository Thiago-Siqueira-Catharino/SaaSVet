using SaaSVet.Contexts.Appoitment.Domain.IRepositories;

namespace SaaSVet.Contexts.Appoitment.Application.CancelAppointmentUseCase;

public class CancelAppointmentUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;
    public CancelAppointmentUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task RunAsync(CancelAppointmentDto dto)
    {
        Domain.Entities.Appointment toCancel = await _appointmentRepository.GetByIdAsync(dto.AppointmentId);
        if (toCancel == null)
            throw new Exception("Appointment not found");
        
        toCancel.Delete();
        await _appointmentRepository.SaveAsync(toCancel);
    }
}