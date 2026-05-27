namespace SaaSVet.Contexts.Register.Application.NewPetUseCase;

public record NewPetDto
{
    public int ownerId { get; set; }
    public string petName { get; set; }
};