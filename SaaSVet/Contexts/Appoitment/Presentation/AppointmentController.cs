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
    [HttpPost("/create")]
    public async Task<IActionResult> CreateAppointmentUseCase(CreateAppointmentDto dto)
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

    [HttpPost("/cancel")]
    public async Task<IActionResult> CancelAppointmentUseCase(CancelAppointmentDto dto)
    {
        try
        {
            await cancelAppointmentUseCase.RunAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/get/petId={petId}")]
    public async Task<IActionResult> GetByPetId(ViewPetAppointmentsDto dto)
    {
        try
        {
            List<Domain.Entities.Appointment> appointments = await petAppointmentUseCase.RunAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}