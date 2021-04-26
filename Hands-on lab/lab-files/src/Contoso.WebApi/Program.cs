using Contoso.Azure.KeyVault;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace Contoso.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var buildConfig = config.Build();
                    config.AddEnvironmentVariables();
                    var azureServiceTokenProvider = new AzureServiceTokenProvider();
                    var keyVaultClient = new KeyVaultClient( new KeyVaultClient.AuthenticationCallback(
                       azureServiceTokenProvider.KeyVaultTokenCallback));
                    config.AddAzureKeyVault(KeyVaultConfig.GetKeyVaultEndpoint(buildConfig["KeyVaultName"]),
                        keyVaultClient,new DefaultKeyVaultSecretManager());                    
                })
                .ConfigureLogging(options => 
                {
                    options.ClearProviders();
                    options.AddConsole();                    
                })
                .UseStartup<Startup>();
    }
}