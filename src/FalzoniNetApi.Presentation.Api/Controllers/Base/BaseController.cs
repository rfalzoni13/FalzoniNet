using FalzoniNetApi.Domain.Dtos.Base;
using FalzoniNetApi.Domain.Interfaces.Services.Base;
using FalzoniNetApi.Presentation.Api.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace FalzoniNetApi.Presentation.Api.Controllers.Base
{
    [ApiController]
    public class BaseController<TDTO> : ControllerBase
        where TDTO : BaseDTO, new()
    {
        private ResponseModel _model;
        private readonly IBaseService<TDTO> _service;

        public BaseController(IBaseService<TDTO> service)
        {
            _model = new ResponseModel();
            _service = service;
        }

        [HttpGet("GetAll")]
        public virtual IActionResult GetAll()
        {
            try
            {
                var o = _service.GetAll();

                return Ok(o);
            }
            catch (Exception ex)
            {
                return BadRequest(_model.SetBadRequest(ex.Message));
            }
        }

        [HttpGet("Get/{id}")]
        public virtual IActionResult Get(Guid id)
        {
            try
            {
                var o = _service.Get(id);

                return Ok(o);
            }
            catch (Exception ex)
            {
                return BadRequest(_model.SetBadRequest(ex.Message));
            }
        }

        [HttpPost("Create")]
        public virtual IActionResult Create([FromBody] TDTO dto)
        {
            try
            {
                _service.Create(dto);

                return StatusCode(StatusCodes.Status201Created, _model.SetCreated("Registro inserido com sucesso" ));
            }
            catch (Exception ex)
            {
                return BadRequest(_model.SetBadRequest(ex.Message));
            }
        }

        [HttpPut("Update")]
        public virtual IActionResult Update([FromBody] TDTO dto)
        {
            try
            {
                _service.Update(dto);

                return Ok(_model.SetSuccess("Registro atualizado com sucesso" ));
            }
            catch (Exception ex)
            {
                return BadRequest(_model.SetBadRequest(ex.Message));
            }
        }

        [HttpDelete("Delete/{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);

                return Ok(_model.SetSuccess("Registro removido com sucesso"));
            }
            catch (Exception ex)
            {
                return BadRequest(_model.SetBadRequest(ex.Message));
            }
        }
    }
}
