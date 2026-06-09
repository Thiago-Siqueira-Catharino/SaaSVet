using Microsoft.EntityFrameworkCore;
using SaaSVet.Contexts.Appoitment.Domain.Entities;
using SaaSVet.Contexts.Appoitment.Domain.IRepositories;
using SaaSVet.Contexts.Appoitment.Infrastructure.Persistance;

namespace SaaSVet.Contexts.Appoitment.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    public readonly AppointmentDbContext _appointmentDbContext;

    public AppointmentRepository(AppointmentDbContext appointmentDbContext)
    {
        _appointmentDbContext = appointmentDbContext;
    }
    
    public async Task AddAsync(Appointment appointment)
    {
        await _appointmentDbContext.Appoitments.AddAsync(appointment);
        await _appointmentDbContext.SaveChangesAsync();
    }

    public async Task SaveAsync(Appointment appointment)
    {
        _appointmentDbContext.Update(appointment);
        await _appointmentDbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsConflicAsync(int petId, DateTime windowStart, DateTime windowEnd)
    {
        return await _appointmentDbContext.Appoitments.AnyAsync( a =>
                a.PetId == petId &&
                a.Date >= windowStart &&
                a.Date <= windowEnd);
    }

    public async Task<Appointment> GetByIdAsync(int id)
    {
        return await _appointmentDbContext.Appoitments.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<Appointment>> GetByPetIdAsync(int petId)
    {
        return  await _appointmentDbContext.Appoitments
            .Where(a => a.PetId == petId)
            .ToListAsync();
    }
}