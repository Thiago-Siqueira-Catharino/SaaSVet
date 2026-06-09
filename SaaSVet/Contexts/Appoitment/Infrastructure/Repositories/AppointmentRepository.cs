using Microsoft.EntityFrameworkCore;
using SaaSVet.Common.Persistance;
using SaaSVet.Contexts.Appoitment.Domain.Entities;
using SaaSVet.Contexts.Appoitment.Domain.IRepositories;

namespace SaaSVet.Contexts.Appoitment.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly VetDbCotnext _database;
    public AppointmentRepository(VetDbCotnext database)
    {
        _database = database;
    }
    
    public async Task AddAsync(Appointment appointment)
    {
        await _database.Appointments.AddAsync(appointment);
        await _database.SaveChangesAsync();
    }

    public async Task SaveAsync(Appointment appointment)
    {
        _database.Appointments.Update(appointment);
        await _database.SaveChangesAsync();
    }

    public async Task<bool> ExistsConflicAsync(int petId, DateTime windowStart, DateTime windowEnd)
    {
        return await _database.Appointments.AnyAsync( a =>
                a.PetId == petId &&
                a.Date >= windowStart &&
                a.Date <= windowEnd);
    }

    public async Task<Appointment> GetByIdAsync(int id)
    {
        return await _database.Appointments.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<bool> HasFutureAppointmentAsync(int petId)
    {
        return await _database.Appointments.AnyAsync(p => 
            p.PetId == petId && 
            p.Date >= DateTime.Now);

    }

    public async Task<List<Appointment>> GetByPetIdAsync(int petId)
    {
        return  await _database.Appointments
            .Where(a => a.PetId == petId)
            .ToListAsync();
    }
}