using ClenaArchitecture.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations;

internal sealed class EmployeeConfiguration: IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.OwnsOne(p => p.PersonalInformation, builder =>
        {
            builder.Property(i => i.TcNo).HasColumnName("TCNO");
            builder.Property(i => i.Phone1).HasColumnName("Phone1");
            builder.Property(i => i.Phone2).HasColumnName("Phone2");
            builder.Property(i => i.Email).HasColumnName("Email");
        });

        builder.OwnsOne(p => p.Address, builder =>
        {
            builder.Property(i => i.Street).HasColumnName("Street");
            builder.Property(i => i.State).HasColumnName(")");
            builder.Property(i => i.City).HasColumnName("City");
            builder.Property(i => i.Country).HasColumnName("Country");
            builder.Property(i => i.ZipCode).HasColumnName("ZipCode");
        });

        builder.Property(p => p.Salary).HasColumnType("money");
    }
       
}
