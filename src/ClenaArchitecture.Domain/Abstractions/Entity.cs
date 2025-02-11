namespace ClenaArchitecture.Domain.Abstractions;
public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }

    #region Audit Log
    public DateTime CreatedAt { get; set; }
    public Guid CreateUserId { get; set; } = default!;
    public DateTime? UpdateAt { get; set; }
    public Guid? UpdateUserId { get; set; } 
    public DateTime? DeleteAt { get; set; }
    public bool IsDeleted { get; set; }
    public Guid? DeleteUserId { get; set; }
    #endregion
}
