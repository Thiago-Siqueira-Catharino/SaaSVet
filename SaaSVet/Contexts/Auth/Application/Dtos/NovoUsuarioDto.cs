namespace SaaSVet.Contexts.Auth.Application.Dtos;

public record NovoUsuarioDto (
    string nome,
    string email,
    string senha
    );