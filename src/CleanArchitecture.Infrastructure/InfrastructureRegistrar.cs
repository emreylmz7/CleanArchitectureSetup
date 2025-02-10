using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Repositories;
using ClenaArchitecture.Domain.Employees;
using GenericRepository;
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


        return services;
    }
}
