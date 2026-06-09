using Microsoft.AspNetCore.Mvc;
using SaaSVet.Contexts.Register.Application.NewOwnerUseCase;

namespace SaaSVet.Contexts.Register.Presentation;

[ApiController]
[Route("api/[controller]")]
public class OwnerController (
    NewOwnerUseCase newOwnerUseCase
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
    
}