namespace ClenaArchitecture.Domain.Abstractions;
public abstract class EntityDto
{

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeleteAt { get; set; }
    public bool IsDeleted { get; set; }
}
