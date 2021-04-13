using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTO.Provider;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Interfaces.Provider;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _service;
        public ProviderController(IProviderService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("cnpj")]
        public async Task<ActionResult> Get(string cnpj)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.Get(cnpj);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("cnpj")]
        public async Task<ActionResult> Delete(string cnpj)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.Delete(cnpj);
                if (result == false)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProviderDTO provider)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.Post(provider);
                if (result == false)
                    return NotFound();

                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProviderDTO provider)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.Put(provider);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}