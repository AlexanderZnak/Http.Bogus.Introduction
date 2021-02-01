using AutomationTests.Configuration;
using Microsoft.Extensions.Configuration;

namespace AutomationTests
{
    public class Startup
    {

        public Startup()
        {
            var configuraion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            configuraion.Bind(ConfigManager.GetInstance());
        }
    }
}
