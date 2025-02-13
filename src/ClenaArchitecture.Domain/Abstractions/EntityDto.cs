namespace ClenaArchitecture.Domain.Abstractions;
public abstract class EntityDto
{

    public Guid Id { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public Guid CreateUserId { get; set; }
    public string CreateUserName { get; set; } = default!;
    public DateTime? UpdateAt { get; set; }
    public Guid? UpdateUserId { get; set; }
    public string? UpdateUserName { get; set; }
    public DateTime? DeleteAt { get; set; }
    public bool IsDeleted { get; set; }
}
