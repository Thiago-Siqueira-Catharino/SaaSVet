using SaaSVet.Common.Entities;
using SaaSVet.Contexts.Register.Domain.Entities;

namespace SaaSVet.Contexts.Appoitment.Domain.Entities;

public class Appointment : EntityBase
{
    public int PetId { get; private set;  }
    public DateTime ScheduledFor { get; private set;  }

    public Appointment()
    { }

    public Appointment(int petId, DateTime date)
    {
        if (petId <= 0 || petId == null)
            throw new ArgumentNullException("Pet Id must not be null, empty or lesser than 0.");
        
        if (date < DateTime.Now.AddSeconds(-1))
            throw new ArgumentOutOfRangeException("Date must be in the future.");
        
        PetId = petId;
        ScheduledFor = date;
    }
}