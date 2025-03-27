using FalzoniNetApi.Domain.Structs.Configuration;
using FalzoniNetApi.Presentation.Api.Models.Common;
using FalzoniNetApi.Service.Configuration;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FalzoniNetApi.Presentation.Api.Controllers.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ResponseModel _model;
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _model = new ResponseModel();
            _accountService = accountService;
        }

        [SwaggerOperation(summary: $"Login de usuário", description: "Obtém o token do usuário através de login e senha")]
        [SwaggerResponse(200, "Success", typeof(BearerToken), ["application/json"])]
        [SwaggerResponse(400, "Bad Request")]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([SwaggerRequestBody("Objeto de dados de login", Required = true)] LoginData data)
        {
            try
            {
                var token = await _accountService.GenerateTokenAsync(data);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(_model.SetBadRequest(ex.Message));
            }
        }
    }
}
