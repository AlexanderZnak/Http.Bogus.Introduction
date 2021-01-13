namespace CDListingTests.Configuration
{
    public class ConfigManager
    {
        private static ConfigManager _configManager = new ConfigManager();

        private ConfigManager()
        {
        }

        public static ConfigManager GetInstance() => _configManager;

        public IdentitySettings IdentitySettings { get; set; }
    }
}
