using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace RestWithASPNET10Erudio.Configurations
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveConfiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                var connectionString = configuration[
                    "MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ArgumentNullException(nameof(connectionString), "Connection string for MSSQL Server is not configured.");
                }
                try
                {
                    Log.Information("Executing database migrations");

                    using var evolveConnection = new SqlConnection(connectionString);
                    var evolve = new Evolve(
                        evolveConnection,
                        msg =>
                        {
                            if (msg == "Executing Migrate...")
                            {
                                return;
                            }

                            Log.Information("{MigrationMessage}", msg);
                        })
                    {
                        Locations = new[] { "db/migrations","db/dataset" },
                        IsEraseDisabled = true,
                        CommandTimeout = 60
                    };
                    evolve.Migrate();

                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Database migration failed");
                    throw;
                }
            }
            return services;
        }
    }
}
