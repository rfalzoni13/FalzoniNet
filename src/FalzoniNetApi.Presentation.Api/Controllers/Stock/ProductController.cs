using FalzoniNetApi.Domain.Dtos.Stock;
using FalzoniNetApi.Domain.Interfaces.Services.Stock;
using FalzoniNetApi.Presentation.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FalzoniNetApi.Presentation.Api.Controllers.Stock
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<ProductDTO>
    {
        public ProductController(IProductService service)
            :base(service)
        {
        }

        [SwaggerOperation(summary: $"Listar todos os produtos", description: "Obtém todos os registros de produtos")]
        [SwaggerResponse(200, "Success", typeof(List<ProductDTO>), ["application/json"])]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpGet("GetAll")]
        public override IActionResult GetAll() => base.GetAll();

        [SwaggerOperation(summary: $"Listar produto por id", description: "Obtém produto através do id passado via parâmetro")]
        [SwaggerResponse(200, "Success", typeof(ProductDTO), ["application/json"])]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpGet("Get/{id}")]
        public override IActionResult Get([SwaggerParameter("Id do produto", Required = true)] Guid id) => base.Get(id);


        [SwaggerOperation(summary: $"Inserir produto", description: "Cria um novo registro de produto")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpPost("Create")]
        public override IActionResult Create([FromBody, SwaggerRequestBody("Objeto do produto", Required = true)] ProductDTO dto) => base.Create(dto);

        [SwaggerOperation(summary: $"Atualizar produto", description: "Atualiza um registro de produto existente")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpPut("Update")]
        public override IActionResult Update([FromBody, SwaggerRequestBody("Objeto do produto", Required = true)] ProductDTO dto) => base.Update(dto);

        [SwaggerOperation(summary: $"Remover produto", description: "Deleta um registro de produto através do id passado via parâmetro")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpDelete("Delete/{id}")]
        public override IActionResult Delete(Guid id) => base.Delete(id);
    }
}
