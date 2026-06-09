using SaaSVet.Common.Entities;
using SaaSVet.Contexts.Register.Domain.ValueObjects;

namespace SaaSVet.Contexts.Register.Domain.Entities;

public class PetOwner : EntityBase
{
    public string name { get; set; }
    public Cpf Cpf { get; set; }
    public List<Pet> pets { get; set; }

    public PetOwner()
    { }

    public PetOwner(string name, string cpf)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Name cannot be null or empty");
        
        this.Cpf = new Cpf(cpf);
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