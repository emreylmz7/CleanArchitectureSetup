namespace ClenaArchitecture.Domain.Abstractions;
public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeleteAt { get; set; }
    public bool IsDeleted { get; set; }
}
