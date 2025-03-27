using FalzoniNetApi.Domain.Entities.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace FalzoniNetApi.Domain.Dtos.Base
{
    public abstract class BaseDTO
    {
        [SwaggerSchema("Id de registro", ReadOnly = true)]
        public Guid Id { get; set; }

        [SwaggerSchema("Data de criação de registro")]
        public DateTime Created { get; set; }

        [SwaggerSchema("Data de modificação de registro")]
        public DateTime? Modified { get; set; }
    }
}
