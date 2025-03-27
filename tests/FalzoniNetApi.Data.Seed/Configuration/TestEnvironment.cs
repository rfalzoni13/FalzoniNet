using Microsoft.Extensions.Configuration;

namespace FalzoniNetApi.Data.Seed.Configuration
{
    public static class TestEnvironment
    {
        public static IConfiguration LoadEnvironmentTest(string file)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(file, false, false)
                .AddEnvironmentVariables()
                .Build();

            return configuration;
        }
    }
}
