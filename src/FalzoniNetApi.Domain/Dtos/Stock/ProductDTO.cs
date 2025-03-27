using FalzoniNetApi.Domain.Dtos.Base;
using FalzoniNetApi.Domain.Filters.Stock;
using Swashbuckle.AspNetCore.Annotations;

namespace FalzoniNetApi.Domain.Dtos.Stock
{
    [SwaggerSchemaFilter(typeof(ProductSchemaFilter))]
    public class ProductDTO : BaseDTO
    {
        [SwaggerSchema("Nome do produto", Nullable = false)]
        public string? Name { get; set; }

        [SwaggerSchema("Preço do produto", Format = "decimal", Nullable = false)]
        public decimal Price { get; set; }

        [SwaggerSchema("Valor do desconto", Format = "decimal", Nullable = false)]
        public decimal Discount { get; set; }
    }
}
