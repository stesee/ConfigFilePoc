using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ConfigFilePoc
{
  // Common configuration things https://docs.microsoft.com/en-us/dotnet/core/extensions/configuration
  // Configuration - file provider https://docs.microsoft.com/en-us/dotnet/core/extensions/configuration-providers#file-configuration-provider
  internal class Program
  {
    private static async Task Main(string[] args)
    {
      var options = ReadOptions(args);
      Console.WriteLine($"ConfigFileOptionsPoco.Enabled={options.Enabled}");
      Console.WriteLine($"ConfigFileOptionsPoco.AutoRetryDelay={options.AutoRetryDelay}");
    }

    private static ConfigFileOptionsPoco ReadOptions(string[] args)
    {
      var options = new ConfigFileOptionsPoco();

      var host = Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, configuration) =>
      {
        configuration.Sources.Clear();
        var env = hostingContext.HostingEnvironment;
        configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
        var configurationRoot = configuration.Build();
        configurationRoot.GetSection(nameof(ConfigFileOptionsPoco)).Bind(options);
      }).Build();

      return options;
    }
  }
}