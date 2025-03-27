using FalzoniNetApi.Domain.Dtos.Register;
using FalzoniNetApi.Domain.Interfaces.Services.Register;
using FalzoniNetApi.Presentation.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FalzoniNetApi.Presentation.Api.Controllers.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<CustomerDTO>
    {
        public CustomerController(ICustomerService service)
            :base(service)
        {
        }

        [SwaggerOperation(summary: "Listar todos os clientes", description: "Obtém todos os registros de clientes")]
        [SwaggerResponse(200, "Success", typeof(List<CustomerDTO>), ["application/json"])]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpGet("GetAll")]
        public override IActionResult GetAll() => base.GetAll();

        [SwaggerOperation(summary: $"Listar cliente por id", description: "Obtém cliente através do id passado via parâmetro")]
        [SwaggerResponse(200, "Success", typeof(CustomerDTO), ["application/json"])]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpGet("Get/{id}")]
        public override IActionResult Get([SwaggerParameter("Id do cliente", Required = true)] Guid id) => base.Get(id);

        [SwaggerOperation(summary: "Inserir cliente", description: "Cria um novo registro de cliente")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpPost("Create")]
        public override IActionResult Create([FromBody, SwaggerRequestBody(Description = "Objeto do cliente", Required = true)] CustomerDTO dto) => base.Create(dto);

        [SwaggerOperation(summary: "Atualizar cliente", description: "Atualiza um registro de cliente existente")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpPut("Update")]
        public override IActionResult Update([FromBody, SwaggerRequestBody("Objeto do cliente", Required = true)] CustomerDTO dto) => base.Update(dto);

        [SwaggerOperation(summary: "Remover cliente", description: "Deleta um registro de cliente através do id passado via parâmetro")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpDelete("Delete/{id}")]
        public override IActionResult Delete(Guid id) => base.Delete(id);
    }
}
