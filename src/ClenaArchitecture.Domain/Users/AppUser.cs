using Microsoft.AspNetCore.Identity;

namespace ClenaArchitecture.Domain.Users;

public sealed class AppUser : IdentityUser<Guid>
{
    public AppUser()
    {
        Id = Guid.CreateVersion7();
    }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => $"{FirstName} {LastName}";

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
