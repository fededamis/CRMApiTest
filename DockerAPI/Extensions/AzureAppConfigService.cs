using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerAPI.Extensions
{    
    public static class AzureAppConfigService
    {
        public static readonly string AppConfigEndpoint = "AzureAppConfig:Endpoint";
        public static readonly string AzureKeyVaultEndpoint = "AzureKeyVault:Endpoint";

        public static IHostBuilder UseAzAppConfiguration(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureAppConfiguration((hostBuilderContext, configBuilder) =>
            {
                var config = configBuilder.Build();
                var credentials = new DefaultAzureCredential();

                configBuilder.AddAzureAppConfiguration(appConfigOptions =>
                {
                    //Connect to App Configuration Store using the App Configuration Endpoint and default Azure Credential Token
                    appConfigOptions.Connect(new Uri(config[AppConfigEndpoint]), credentials);

                    //Use App Configuration Service Configuration Provider to connect to Azure Key Vault
                    appConfigOptions.ConfigureKeyVault(keyvault =>
                    {
                        keyvault.SetCredential(credentials);
                    });
                });                   
            });
        }
    }
}
