using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;

namespace WebApi1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var instrumentationKey = string.Empty;
            return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                var buildConfig = config.Build();                
                config.AddEnvironmentVariables();
                instrumentationKey = buildConfig["APPINSIGHTS_INSTRUMENTATIONKEY"];                
            })
            .ConfigureLogging(options =>
                {
                    options.ClearProviders();
                    options.AddConsole();
                    options.AddApplicationInsights(instrumentationKey, options => { options.TrackExceptionsAsExceptionTelemetry = true; });
                    options.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Trace);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                  webBuilder.UseStartup<Startup>();
            });
        }
    }
}
