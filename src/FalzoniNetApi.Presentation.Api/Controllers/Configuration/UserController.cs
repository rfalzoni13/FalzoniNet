using FalzoniNetApi.Domain.Dtos.Identity;
using FalzoniNetApi.Presentation.Api.Models.Common;
using FalzoniNetApi.Service.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FalzoniNetApi.Presentation.Api.Controllers.Configuration
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ResponseModel _model;
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _model = new ResponseModel();
            _userService = userService;
        }

        [SwaggerOperation(summary: $"Listar usuários", description: "Obtém todos os usuários registrados")]
        [SwaggerResponse(200, "Success", typeof(List<ApplicationUserDTO>), ["application/json"])]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var obj = _userService.GetAll();

                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(_model.SetBadRequest(ex.Message));
            }
        }

        [SwaggerOperation(summary: $"Listar usuário por id", description: "Obtém usuário através do id passado via parâmetro")]
        [SwaggerResponse(200, "Success", typeof(ApplicationUserDTO), ["application/json"])]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get([SwaggerParameter("Id do usuário", Required = true)] Guid id)
        {
            try
            {
                var obj = await _userService.GetByIdAsync(id);

                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(_model.SetBadRequest(ex.Message));
            }
        }

        [SwaggerOperation(summary: $"Inserir usuário", description: "Cria um novo registro de usuário")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody, SwaggerRequestBody("Objeto do usuário", Required = true)] ApplicationUserDTO dto)
        {
            try
            {
                await _userService.CreateAsync(dto);

                return StatusCode(StatusCodes.Status201Created, new { message = "Usuário inserido com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(_model.SetBadRequest(ex.Message));
            }
        }

        [SwaggerOperation(summary: $"Atualizar usuário", description: "Atualiza um registro de usuário existente")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody, SwaggerRequestBody("Objeto do usuário", Required = true)] ApplicationUserDTO dto)
        {
            try
            {
                await _userService.UpdateAsync(dto);

                return Ok(new { message = "Usuário atualizado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(_model.SetBadRequest(ex.Message));
            }
        }

        [SwaggerOperation(summary: $"Remover usuário", description: "Deleta um registro de usuário através do id passado via parâmetro")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([SwaggerParameter("Id do usuário", Required = true)] Guid id)
        {
            try
            {
                await _userService.DeleteAsync(id);

                return Ok(new { message = "Usuário removido com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(_model.SetBadRequest(ex.Message));
            }
        }
    }
}
