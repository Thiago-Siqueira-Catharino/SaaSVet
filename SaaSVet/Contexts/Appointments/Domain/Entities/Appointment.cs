namespace SaaSVet.Contexts.Appointments.Domain.Entities;

public class Appointment
{
    public Pet pet { get; private set; }
    public DateTime date { get; private set; }
    public Clinic clinic { get; private set; }

    public Appointment()
    { }
    
    public Appointment(Pet pet, DateTime date, Clinic clinic)
    {
        this.pet = pet;
        this.date = date;
        this.clinic = clinic;
    }
}