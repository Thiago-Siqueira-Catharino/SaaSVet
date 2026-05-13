using Microsoft.AspNetCore.Mvc;
using SaaSVet.Contexts.Auth.Application;
using SaaSVet.Contexts.Auth.Application.Dtos;

namespace SaaSVet.Contexts.Auth.Presentation;

[ApiController]
[Route("auth")]
public class UserController(NovoUsuarioUseCase _novoUsuario) : ControllerBase
{
    [HttpGet("/ping")]
    public IActionResult GetPing()
    {
        int num = new Random().Next(0, 2);

        if (num == 0)
        {
            Console.WriteLine(num);
            return Ok("pong");
        }
        
        return Ok("go drinking (vai tomando)");
    }

    [HttpPost("/cadastrar")]
    public async Task<IActionResult> Cadastrar(NovoUsuarioDto novoUsuario)
    {
        await _novoUsuario.Run(novoUsuario);
        return Ok();
    }
}