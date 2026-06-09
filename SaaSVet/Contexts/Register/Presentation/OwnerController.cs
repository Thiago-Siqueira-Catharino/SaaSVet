using Microsoft.AspNetCore.Mvc;
using SaaSVet.Contexts.Register.Application;
using SaaSVet.Contexts.Register.Application.NewOwnerUseCase;

namespace SaaSVet.Contexts.Register.Presentation;

[ApiController]
[Route("api/[controller]")]
public class OwnerController (
    NewOwnerUseCase newOwnerUseCase,
    ShowOwnersUseCase showOwnersUseCase
    ) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddOwner([FromForm]NewOwnerDto dto)
    {
        try
        {
            await newOwnerUseCase.RunAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListOwners()
    {
        try
        {
            return Ok(await showOwnersUseCase.RunAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return  BadRequest(e.Message);
        }
    }
    
}