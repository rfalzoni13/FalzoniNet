using FalzoniNetApi.Domain.Dtos.Base;
using FalzoniNetApi.Domain.Filters.Register;
using Swashbuckle.AspNetCore.Annotations;

namespace FalzoniNetApi.Domain.Dtos.Register
{
    [SwaggerSchemaFilter(typeof(CustomerSchemaFilter))]
    public class CustomerDTO : BaseDTO
    {
        [SwaggerSchema("Nome do cliente", Nullable = false)]
        public string? Name { get; set; }

        [SwaggerSchema("Nome do cliente", Nullable = false)]
        public string? Document { get; set; }
    }
}
