using ClenaArchitecture.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ClenaArchitecture.Domain.Abstractions;
public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }

    #region Audit Log
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public Guid CreateUserId { get; set; } = default!;
    public string CreateUserName => GetCreateUserName();
    public DateTime? UpdateAt { get; set; }
    public Guid? UpdateUserId { get; set; }
    public string UpdateUserName => GetUpdateUserName();
    public DateTime? DeleteAt { get; set; }
    public bool IsDeleted { get; set; }
    public Guid? DeleteUserId { get; set; }
    #endregion

    private string GetCreateUserName()
    {
        HttpContextAccessor httpContextAccessor = new();
        var userManager = httpContextAccessor.HttpContext.RequestServices.GetRequiredService<UserManager<AppUser>>();
        AppUser appUser = userManager.Users.First(p => p.Id == CreateUserId);
        return appUser.FullName;
    }
    private string GetUpdateUserName()
    {
        if (UpdateUserId is null)
            return string.Empty;

        HttpContextAccessor httpContextAccessor = new();
        var userManager = httpContextAccessor.HttpContext.RequestServices.GetRequiredService<UserManager<AppUser>>();
        AppUser appUser = userManager.Users.First(p => p.Id == UpdateUserId);
        return appUser.FullName;
    }
}
