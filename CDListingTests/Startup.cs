using CDListingTests.Configuration;
using Microsoft.Extensions.Configuration;

namespace CDListingTests
{
    public class Startup
    {
        private readonly IdentitySettings _identitySettings = new IdentitySettings();
        public static IdentitySettings IdentitySettings { get; private set; }

        public Startup()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            configuration.Bind(_identitySettings);

            IdentitySettings = _identitySettings;
        


    }
}
