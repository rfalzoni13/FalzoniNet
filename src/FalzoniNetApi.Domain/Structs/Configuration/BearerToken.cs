using FalzoniNetApi.Domain.Filters.Account;
using Swashbuckle.AspNetCore.Annotations;

namespace FalzoniNetApi.Domain.Structs.Configuration
{
    [SwaggerSchemaFilter(typeof(BearerTokenSchamaFilter))]
    public struct BearerToken
    {
        [SwaggerSchema("Token de retorno")]
        public string? Token { get; init; }

        [SwaggerSchema("Data de expiração", Nullable = false)]
        public DateTime? ExpiresIn { get; init; }

        public BearerToken(string? token, DateTime expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
    }
}
