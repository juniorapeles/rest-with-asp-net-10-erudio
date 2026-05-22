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

    builder.Services.AddControllers();
    builder.Services.AddDatabaseConfiguration(builder.Configuration);
    builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);
    builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
    builder.Services.AddScoped<IPersonServicesV2, PersonServicesImplV2>();
    builder.Services.AddScoped<IBookServices, BookServicesImpl>();
    builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));



    var app = builder.Build();
    var banner = @"
        ███████╗██████╗ ██╗   ██╗██████╗ ██╗ ██████╗      ██████╗ ██╗ ██╗
        ██╔════╝██╔══██╗██║   ██║██╔══██╗██║██╔═══██╗    ██╔════╝████████╗
        █████╗  ██████╔╝██║   ██║██║  ██║██║██║   ██║    ██║     ╚██╔═██╔╝
        ██╔══╝  ██╔══██╗██║   ██║██║  ██║██║██║   ██║    ██║     ████████╗
        ███████╗██║  ██║╚██████╔╝██████╔╝██║╚██████╔╝    ╚██████╗╚██╔═██╔╝
        ╚══════╝╚═╝  ╚═╝ ╚═════╝ ╚═════╝ ╚═╝ ╚═════╝      ╚═════╝ ╚═╝ ╚═╝
        ";

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(banner);
    Console.ResetColor();

    app.Lifetime.ApplicationStarted.Register(() =>
    {
        var addresses = app.Urls.Any()
            ? string.Join(", ", app.Urls)
            : "No bound URLs reported";

        Log.Information(
            "Application started. Environment={Environment}; ContentRoot={ContentRoot}; Urls={Urls}",
            app.Environment.EnvironmentName,
            app.Environment.ContentRootPath,
            addresses);
    });

    app.Lifetime.ApplicationStopping.Register(() =>
        Log.Information("Application stopping"));

    app.Lifetime.ApplicationStopped.Register(() =>
        Log.Information("Application stopped"));

    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }

    app.UseAuthorization();
    app.MapControllers();

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
