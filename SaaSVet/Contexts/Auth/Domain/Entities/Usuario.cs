using Microsoft.AspNetCore.Identity;
using SaaSVet.Contexts.Auth.Domain.ValueObjects;

namespace SaaSVet.Contexts.Auth.Domain.Entities;

public class Usuario : IdentityUser
{
    public string nome { get; set; }
    public cpf cpf { get; set; }
}