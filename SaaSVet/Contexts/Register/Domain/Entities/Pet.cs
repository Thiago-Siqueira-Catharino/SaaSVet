using SaaSVet.Common.Entities;

namespace SaaSVet.Contexts.Register.Domain.Entities;

public class Pet : EntityBase
{
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