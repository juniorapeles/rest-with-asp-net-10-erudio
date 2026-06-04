using Serilog;

namespace RestWithASPNET10Erudio.Configurations
{
    public static class LoggingConfig
    {
        public static void AddSerilogLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Debug()
                .CreateLogger();
            builder.Host.UseSerilog();
        }

        public static void UseApplicationLifetimeLogging(this WebApplication app)
        {
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
        }
    }
}
