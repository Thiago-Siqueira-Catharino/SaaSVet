namespace SaaSVet.Common.Entities;

public class EntityBase
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime DeletedAt { get; private set; }
    public bool IsDeleted { get; private set; }

    public EntityBase()
    {
        CreatedAt = DateTime.Now;
    }

    public void Delete()
    {
        DeletedAt = DateTime.Now;
        IsDeleted = true;
    }
}