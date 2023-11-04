using System.Reflection;
using WidgetsBE.Api.Services;
using WidgetsBE.Application;
using WidgetsBE.Persistence;
using WidgetsBE.Persistence.Repositories;
using MediatR;
using WidgetsBE.Application.Widgets.GetWidgets;
using WidgetsBE.Shared;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddAutoMapper(cfg => Assembly.GetExecutingAssembly(), PersistenceAssembly.GetPersistenceAssembly.Value, ApplicationAssembly.GetApplicationAssembly.Value, SharedAssembly.GetSharedAssembly.Value);

builder.Services.AddScoped<IWidgetsRepository, WidgetsRepository>();
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(GetWidgetsQuery).Assembly); });

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<WidgetsService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();