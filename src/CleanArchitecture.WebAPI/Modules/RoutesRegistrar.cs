namespace CleanArchitecture.WebAPI.Modules;

public static class RoutesRegistrar
{
    public static void RegisterRoutes(this IEndpointRouteBuilder app)
    {
        app.RegisterEmployeeRoutes();
        app.RegisterAuthRoutes();
    }   
}
