namespace FalzoniNetApi.Utils.Structs
{
    public struct TokenConfiguration
    {
        public string Audience { get; init; }
        public string Issuer { get; init; }
        public string SecretKey { get; init; }

        public TokenConfiguration(string audience, string issuer, string secretKey)
        {
            Audience = audience;
            Issuer = issuer;
            SecretKey = secretKey;
        }
    }
}