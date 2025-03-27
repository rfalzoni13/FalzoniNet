using FalzoniNetApi.Domain.Filters.Account;
using Swashbuckle.AspNetCore.Annotations;

namespace FalzoniNetApi.Domain.Structs.Configuration
{
    [SwaggerSchemaFilter(typeof(BearerTokenSchamaFilter))]
    public struct BearerToken
    {
        public string? Token { get; init; }
        public DateTime? ExpiresIn { get; init; }

        public BearerToken(string? token, DateTime expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
    }
}
