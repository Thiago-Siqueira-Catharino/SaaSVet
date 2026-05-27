namespace SaaSVet.Contexts.Appointments.Domain.Entities;

public class Pet
{
    public int id { get; set; }
    public PetOwner owner { get; private set; }
    public string name { get; private set; }

    public Pet()
    { }

    public Pet(PetOwner owner, string name)
    {
        this.owner = owner;
        this.name = name;
    }
}