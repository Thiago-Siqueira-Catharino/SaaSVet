using Microsoft.AspNetCore.Mvc;
using SaaSVet.Contexts.Register.Application.DeletePetUseCase;
using SaaSVet.Contexts.Register.Application.NewOwnerUseCase;
using SaaSVet.Contexts.Register.Application.NewPetUseCase;

namespace SaaSVet.Contexts.Register.Presentation;

[ApiController]
[Route("api/[controller]")]
public class PetController(
    NewPetUseCase newPetUseCase,
    NewOwnerUseCase newOwnerUseCase,
    DeletePetUseCase deletePetUseCase
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
}