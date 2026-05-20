namespace SaaSVet.Contexts.Appointments.Application.NewPetUseCase;

public record NewPetDto
{
    public int ownerId { get; set; }
    public string petName { get; set; }
};