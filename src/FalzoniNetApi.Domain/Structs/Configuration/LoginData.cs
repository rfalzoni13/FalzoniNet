using FalzoniNetApi.Domain.Filters.Account;
using Swashbuckle.AspNetCore.Annotations;

namespace FalzoniNetApi.Domain.Structs.Configuration
{
    [SwaggerSchemaFilter(typeof(LoginSchemaFilter))]
    public struct LoginData
    {
        [SwaggerSchema("Apelido do usuário", Nullable = false)]
        public string UserName { get; init; }

        [SwaggerSchema("Senha do usuário", Nullable = false)]
        public string Password { get; init; }

        public LoginData(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
