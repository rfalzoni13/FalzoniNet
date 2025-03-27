using FalzoniNetApi.Utils.Structs;
using Microsoft.Extensions.Configuration;

namespace FalzoniNetApi.Utils.Helpers
{
    public class ConfigurationHelper
    {
        public static string? ConnectionString { get; set; }
        public static string? Provider { get; set; }

        #region Structs
        //public static GoogleAuthConfiguration GoogleAuthConfiguration { get; set; }
        //public static FacebookAuthConfiguration FacebookAuthConfiguration { get; set; }
        public static TokenConfiguration TokenConfiguration { get; set; }
        #endregion

        #region Methods
        public static void LoadConfiguration(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
            Provider = configuration["ConnectionStrings:Provider"];

            //GoogleAuthConfiguration = new GoogleAuthConfiguration(
            //    clientId: configuration["Authentication:Google:ClientId"],
            //    clientSecret: configuration["Authentication:Google:ClientSecret"]);

            //FacebookAuthConfiguration = new FacebookAuthConfiguration(
            //    clientId: configuration["Authentication:Facebook:ClientId"],
            //    clientSecret: configuration["Authentication:Facebook:ClientSecret"]);

            TokenConfiguration = new TokenConfiguration(
                audience: configuration["JWT:Audience"]!,
                issuer: configuration["JWT:Issuer"]!,
                secretKey: configuration["JWT:SecretKey"]!);
        }
        #endregion
    }
}
