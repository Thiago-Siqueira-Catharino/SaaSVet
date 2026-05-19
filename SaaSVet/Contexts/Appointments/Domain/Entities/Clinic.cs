namespace SaaSVet.Contexts.Appointments.Domain.Entities;

public class Clinic
{
    public string name { get; private set; }
    public string address { get; private set; }
    public List<Appointment> appointments { get; private set; }

    public Clinic()
    {
        
    }

    public Clinic(string name, string address)
    {
        this.name = name;
        this.address = address;
        appointments = new List<Appointment>();
    }

    public void AddAppointment(Appointment appointment)
    {
        appointments.Add(appointment);
    }
    
    public void RemoveAppointment(Appointment appointment)
    {
        appointments.Remove(appointment);
    }
}