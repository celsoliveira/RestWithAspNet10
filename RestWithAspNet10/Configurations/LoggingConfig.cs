using Serilog;

namespace RestWithAspNet10.Configurations
{
    public static class LoggingConfig 
    {
        public static void AddSerilogLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)   // configurações appsetings.json
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug()
                .CreateLogger();

                builder.Host.UseSerilog();

            // Conigure logging .NET
            /* 
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();
            builder.Logging.AddEventSourceLogger();

            //Optional: Set Minimum log level
            builder.Logging.SetMinimumLevel(LogLevel.Information);
            */
        }
    }
}
