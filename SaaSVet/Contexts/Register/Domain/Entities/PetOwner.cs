namespace SaaSVet.Contexts.Register.Domain.Entities;

public class PetOwner
{
    public int id { get; private set; }
    public string name { get; set; }
    public List<Pet> pets { get; set; }

    public PetOwner()
    { }

    public PetOwner(int id, string name)
    {
        this.id = id;
        this.name = name;
        pets = [];
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