using ClenaArchitecture.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.WebAPI.Middlewares;

public static class ExtensionsMiddleware
{
    public static void CreateFirstUser(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            if (!userManager.Users.Any(p => p.UserName == "admin"))
            {
                AppUser user = new()
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Emre",
                    LastName = "Yılmaz",
                    EmailConfirmed = true,
                    CreatedAt = DateTime.Now
                };

                user.CreateUserId = user.Id;

                userManager.CreateAsync(user, "1").Wait();
            }
        }
    }
}
