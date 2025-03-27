using FalzoniNetApi.Domain.Filters.Account;
using Swashbuckle.AspNetCore.Annotations;

namespace FalzoniNetApi.Domain.Dtos.Identity
{
    [SwaggerSchemaFilter(typeof(UserSchemaFilter))]
    public class ApplicationUserDTO
    {
        [SwaggerSchema("Id de registro", ReadOnly = true)]
        public Guid Id { get; set; }

        [SwaggerSchema("Nome completo do usuário", Nullable = false)]
        public string? FullName { get; set; }

        [SwaggerSchema("Apelido do usuário", Nullable = false)]
        public string? UserName { get; set; }

        [SwaggerSchema("E-mail do usuário", Nullable = false)]
        public string? Email { get; set; }

        [SwaggerSchema("Telefone do usuário", Nullable = false)]
        public string? PhoneNumber { get; set; }

        [SwaggerSchema("Senha do usuário", Nullable = false)]
        public string? Password { get; set; }
    }
}
