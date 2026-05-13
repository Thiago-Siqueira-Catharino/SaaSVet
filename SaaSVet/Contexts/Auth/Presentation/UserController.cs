using Microsoft.AspNetCore.Mvc;

namespace SaaSVet.Contexts.Auth.Presentation;

[ApiController]
[Route("api/[controller]")]
public class UserController() : ControllerBase
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
}