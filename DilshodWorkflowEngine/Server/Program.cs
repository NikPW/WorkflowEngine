using DilshodWorkflowEngine.Server;
using Microsoft.AspNetCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace DilshodWorkflowEngine.Server
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Error()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");

                CreateWebHostBuilder(args)

                    .Build().Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");

                return -1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>().UseSerilog((h, l) => l
                .ReadFrom.Configuration(h.Configuration)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Error()
                .Enrich.FromLogContext()
                .WriteTo.File($"Logs/{DateTime.Now:yyyy-dd-MM-HH}.log")
                .WriteTo.Console(theme: AnsiConsoleTheme.Code));
    }
}
