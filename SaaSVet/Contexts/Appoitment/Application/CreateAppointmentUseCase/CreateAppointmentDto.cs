namespace SaaSVet.Contexts.Appoitment.Application.CreateAppointmentUseCase;

public record CreateAppointmentDto
{
    public int PetId { get; set; }
    public DateTime Date { get; set; }
}