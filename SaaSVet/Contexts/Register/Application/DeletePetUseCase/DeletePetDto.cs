namespace SaaSVet.Contexts.Register.Application.DeletePetUseCase;

public record DeletePetDto
{
    public int ownerId { get; set; }
    public int petId { get; set; }
};