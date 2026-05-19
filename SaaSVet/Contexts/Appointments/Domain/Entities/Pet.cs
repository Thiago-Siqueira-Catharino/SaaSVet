namespace SaaSVet.Contexts.Appointments.Domain.Entities;

public class Pet
{
    public List<Appointment> appointments { get; private set; }
    public PetOwner owner { get; private set; }
    public string name { get; private set; }

    public Pet()
    { }

    public Pet(PetOwner owner, string name)
    {
        this.owner = owner;
        this.name = name;
        appointments = new List<Appointment>();
    }

    public void AddAppointment(Appointment appointment)
    {
        this.appointments.Add(appointment);
    }

    public List<Appointment> GetAppointments()
    {
        return appointments;
    }
}