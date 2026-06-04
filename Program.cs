using RestWithASPNET10Erudio.Configurations;
using RestWithASPNET10Erudio.Repositories;
using RestWithASPNET10Erudio.Services;
using RestWithASPNET10Erudio.Services.Impl;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.AddSerilogLogging();

    Log.Information("Starting application bootstrap");

    builder.Services.AddControllers()
        .AddContentNegotiation();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddOpenAPIConfig();
    builder.Services.AddSwaggerConfig();

    builder.Services.AddDatabaseConfiguration(builder.Configuration);
    builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);
    builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
    builder.Services.AddScoped<IPersonServicesV2, PersonServicesImplV2>();
    builder.Services.AddScoped<IBookServices, BookServicesImpl>();
    builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));



    var app = builder.Build();
    app.UseApplicationLifetimeLogging();

    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }

    app.UseAuthorization();
    app.MapControllers();
    app.UseSwaggerSpecification();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
