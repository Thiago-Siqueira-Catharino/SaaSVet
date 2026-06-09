namespace SaaSVet.Contexts.Register.Application.ShowOwnedPetsUseCase;

public record ShowOwnedPetsDto
{
    public int OwnerId { get; set; }
}