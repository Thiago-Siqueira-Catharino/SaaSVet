namespace SaaSVet.Contexts.Register.Application.NewOwnerUseCase;

public record NewOwnerDto
{
    public string name { get; set; }
    public string Cpf { get; set; }
};