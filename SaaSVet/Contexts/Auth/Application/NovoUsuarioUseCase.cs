using Microsoft.AspNetCore.Identity;
using SaaSVet.Contexts.Auth.Application.Dtos;
using SaaSVet.Contexts.Auth.Domain.Entities;

namespace SaaSVet.Contexts.Auth.Application;

public class NovoUsuarioUseCase(UserManager<Usuario> _userManager)
{
    public async Task Run(NovoUsuarioDto dto)
    {
        Usuario novoUsuario = new Usuario {
            UserName = dto.email,
            nome = dto.nome,
            Email =  dto.email,
        };
        
        var result = await _userManager.CreateAsync(novoUsuario, dto.senha);
        
        if (result.Succeeded)
            await _userManager.AddToRoleAsync(novoUsuario, "Usuario");

        else
            throw new  Exception(result.Errors.First().Description);
    }
}