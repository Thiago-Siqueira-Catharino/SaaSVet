using SaaSVet.Contexts.Appoitment.Domain.Entities;

namespace SaaSVet.Contexts.Appoitment.Domain.IRepositories;

public interface IAppointmentRepository
{
    public Task AddAsync(Appointment appointment);
    public Task SaveAsync(Appointment appointment);
    public Task<bool> ExistsConflicAsync(int petId, DateTime windowStart, DateTime windowEnd);
    public Task<Appointment> GetByIdAsync(int id);
    public Task<bool> HasFutureAppointmentAsync(int petId);
    public Task<List<Appointment>> GetByPetIdAsync(int petId);
    
}