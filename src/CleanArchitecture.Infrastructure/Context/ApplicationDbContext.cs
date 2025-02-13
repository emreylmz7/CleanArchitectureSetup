using ClenaArchitecture.Domain.Abstractions;
using ClenaArchitecture.Domain.Employees;
using ClenaArchitecture.Domain.Users;
using GenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Context;
internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Ignore<IdentityUserClaim<Guid>>();
        modelBuilder.Ignore<IdentityRoleClaim<Guid>>();
        modelBuilder.Ignore<IdentityUserToken<Guid>>();
        modelBuilder.Ignore<IdentityUserLogin<Guid>>();
        modelBuilder.Ignore<IdentityUserRole<Guid>>();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Entity>();

        HttpContextAccessor httpContextAccessor = new();
        string userIdString = httpContextAccessor.HttpContext!.User.Claims.First(p => p.Type == "user-id").Value;
        Guid userId = Guid.Parse(userIdString);

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(p => p.CreatedAt)
                    .CurrentValue = DateTime.Now;
                entry.Property(p => p.CreateUserId)
                    .CurrentValue = userId;
            }

            if (entry.State == EntityState.Modified)
            {
                if (entry.Property(p => p.IsDeleted).CurrentValue == true )
                {
                    entry.Property(p => p.DeleteAt)
                    .CurrentValue = DateTime.Now;

                    entry.Property(p => p.DeleteUserId)
                    .CurrentValue = userId;
                }
                else
                {
                    entry.Property(p => p.UpdateAt)
                    .CurrentValue = DateTime.Now;

                    entry.Property(p => p.UpdateUserId)
                    .CurrentValue = userId;
                }
            }

            if (entry.State == EntityState.Deleted)
            {
                throw new ArgumentException("Soft delete is not allowed");
            }

        }


        return base.SaveChangesAsync(cancellationToken);
    }
}
