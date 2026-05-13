using Microsoft.AspNetCore.Mvc;

namespace SaaSVet.Contexts.Auth.Presentation;

[ApiController]
[Route("api/[controller]")]
public class UserController() : ControllerBase
{
    [HttpGet("/ping")]
    public IActionResult GetPing()
    {
        return Ok("pong");
    }
}