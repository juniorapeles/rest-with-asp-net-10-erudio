using RestWithASPNET10Erudio.Configurations;
using RestWithASPNET10Erudio.Repositories;
using RestWithASPNET10Erudio.Repositories.Impl;
using RestWithASPNET10Erudio.Services;
using RestWithASPNET10Erudio.Services.Impl;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

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
Log.Information("API INTEGRA iniciada com sucesso em {Time:dd/MM/yyyy HH:mm:ss}", DateTime.UtcNow);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
