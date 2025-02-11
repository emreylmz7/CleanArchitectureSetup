using ClenaArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations;

internal sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        // Configure properties
        builder.Property(u => u.FirstName)
               .HasColumnType("varchar(50)")
               .IsRequired();

        builder.Property(u => u.LastName)
               .HasColumnType("varchar(50)")
               .IsRequired();

        builder.Property(u => u.UserName)
               .HasColumnType("varchar(15)")
               .IsRequired();

        builder.Property(u => u.Email)
               .HasColumnType("varchar(50)")
               .IsRequired();

        builder.HasIndex(u => u.UserName).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
    }
}