using Microsoft.AspNetCore.Mvc;
using SaaSVet.Contexts.Appoitment.Application.CancelAppointmentUseCase;
using SaaSVet.Contexts.Appoitment.Application.CreateAppointmentUseCase;
using SaaSVet.Contexts.Appoitment.Application.ViewPetAppointmentsUseCase;

namespace SaaSVet.Contexts.Appoitment.Presentation;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController (
    CreateAppointmentUseCase createAppointmentUseCase,
    CancelAppointmentUseCase cancelAppointmentUseCase,
    ViewPetAppointmentsUseCase  petAppointmentUseCase
    ) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateAppointmentUseCase([FromForm]CreateAppointmentDto dto)
    {
        try
        {
            await createAppointmentUseCase.RunsAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPost("cancel/{AppointmentId}")]
    public async Task<IActionResult> CancelAppointmentUseCase([FromForm]CancelAppointmentDto AppointmentId)
    {
        try
        {
            await cancelAppointmentUseCase.RunAsync(AppointmentId);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("get/{petId}")]
    public async Task<IActionResult> GetByPetId([FromRoute] int petId)
    {
        try
        {
            var dto = new ViewPetAppointmentsDto{PetId = petId};
            List<Domain.Entities.Appointment> appointments = await petAppointmentUseCase.RunAsync(dto);
            return Ok(appointments);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}