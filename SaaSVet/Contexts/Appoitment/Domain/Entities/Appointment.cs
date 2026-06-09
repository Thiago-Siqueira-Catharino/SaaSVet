using SaaSVet.Common.Entities;
using SaaSVet.Contexts.Register.Domain.Entities;

namespace SaaSVet.Contexts.Appoitment.Domain.Entities;

public class Appointment : EntityBase
{
    public int PetId { get; }
    public DateTime Date { get; }

    public Appointment(int petId, DateTime date)
    {
        PetId = petId;
        Date = date;
    }
}