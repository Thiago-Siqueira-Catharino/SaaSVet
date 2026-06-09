using Microsoft.AspNetCore.Mvc;
using SaaSVet.Contexts.Register.Application.DeletePetUseCase;
using SaaSVet.Contexts.Register.Application.NewOwnerUseCase;
using SaaSVet.Contexts.Register.Application.NewPetUseCase;
using SaaSVet.Contexts.Register.Application.ShowOwnedPetsUseCase;

namespace SaaSVet.Contexts.Register.Presentation;

[ApiController]
[Route("api/[controller]")]
public class PetController(
    NewPetUseCase newPetUseCase,
    DeletePetUseCase deletePetUseCase,
    ShowOwnedPetsUseCase showOwnedPetsUseCase
    ) : ControllerBase
{
    [HttpPost("pet/add")]
    public async Task<IActionResult> AddPet(NewPetDto pet)
    {
        await newPetUseCase.RunsAsync(pet);
        return Ok();
    }

    [HttpPost("pet/remove")]
    public async Task<IActionResult> RemovePet(DeletePetDto pet)
    {
        await deletePetUseCase.RunAsync(pet);
        return Ok();
    }

    [HttpGet("pet/all/{OwnerId}")]
    public async Task<IActionResult> ShowAllPets([FromRoute] ShowOwnedPetsDto dto)
    {
        try
        {
            return Ok(await showOwnedPetsUseCase.RunAsync(dto));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}