namespace SaaSVet.Contexts.Appointments.Domain.Entities;

public class PetOwner
{
    public string name { get; set; }
    public List<Pet> pets { get; set; }

    public PetOwner()
    { }

    public PetOwner(string name)
    {
        this.name = name;
        this.pets = [];
    }

    public void AddPet(Pet pet)
    {
        pets.Add(pet);
    }
    
    public void RemovePet(Pet pet)
    {
        pets.Remove(pet);
    }

    public List<Pet> GetPets()
    {
        return pets;
    }
}