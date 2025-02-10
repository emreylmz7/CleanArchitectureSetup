using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.WebAPI;
using CleanArchitecture.WebAPI.Controllers;
using CleanArchitecture.WebAPI.Modules;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.RateLimiting;
using Scalar.AspNetCore;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors();
builder.Services.AddOpenApi(); // OpenAPI servisini projeye ekliyoruz.

builder.Services.AddControllers().AddOData(opt => opt
        .Select()
        .Filter()
        .Count()
        .Expand()
        .OrderBy()
        .SetMaxTop(null)
        .AddRouteComponents("odata", AppODataController.GetEdmModel())
);
builder.Services.AddRateLimiter( x => 
x.AddFixedWindowLimiter("fixed", cfg =>
{
    cfg.QueueLimit = 100;
    cfg.Window = TimeSpan.FromMinutes(1);
    cfg.PermitLimit = 10;
    cfg.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
}));

builder.Services.AddExceptionHandler<ExceptionHandler>().AddProblemDetails();

var app = builder.Build();

app.MapOpenApi(); // OpenAPI servisini projeye ekliyoruz.
app.MapScalarApiReference(); // Scalar API Reference servisini projeye ekliyoruz.

app.MapDefaultEndpoints();

app.UseCors(x => x
    .AllowAnyHeader()
    .AllowCredentials()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin => true));

app.RegisterRoutes();

app.UseExceptionHandler();

app.MapControllers().RequireRateLimiting("fixed");
app.Run();


