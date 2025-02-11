using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Options;
using CleanArchitecture.Infrastructure.Repositories;
using ClenaArchitecture.Domain.Employees;
using ClenaArchitecture.Domain.Users;
using GenericRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace CleanArchitecture.Infrastructure;

public static class InfrastructureRegistrar
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());


        // Identity servislerini ekliyoruz. Bu Usermanager in DI 'ı için gerekli.UserManager kullanmıcaksak gerek yok buna.
        services
            .AddIdentity<AppUser,IdentityRole<Guid>>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 1;
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.SignIn.RequireConfirmedEmail = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.ConfigureOptions<JwtOptionsSetup>();

        // Scrutor kütüphanesini kullanarak bağımlılık enjeksiyonu için otomatik tarama yapıyoruz.
        services.Scan(opt => opt
            // Bu assembly (CleanArchitecture.Infrastructure) içindeki tüm sınıfları tarıyoruz.
            .FromAssemblies(typeof(InfrastructureRegistrar).Assembly)
            // Sadece public olmayan (internal veya private) sınıfları dahil ediyoruz.
            .AddClasses(publicOnly: false)
            // Aynı arayüze sahip birden fazla sınıf varsa, önce kayıtlı olanı koruyoruz (Skip stratejisi).
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            // Bulunan sınıfları, uyguladıkları arayüzler üzerinden kaydediyoruz.
            .AsImplementedInterfaces()
            // Kayıt edilen sınıfların yaşam süresini Scoped (istek bazlı) olarak belirliyoruz.
            .WithScopedLifetime());

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer();

        services.AddAuthorization();


        return services;
    }
}
