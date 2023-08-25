using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XpTest.Application.DTOs;
using XpTest.Application.Services;
using XpTest.Application.Services.Interfaces;

namespace XpTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<ActionResult> PostClientAsync([FromBody] ClientDTO clientDto)
        {
            var result = await _clientService.CreateAsync(clientDto);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllClientsAsync()
        {
            var result = await _clientService.GetAllAsync();
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdClientAsync(int id)
        {
            var result = await _clientService.GetByIdAsync(id);
            if(result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateClientAsync([FromBody] ClientDTO clientDto)
        {
            var result = await _clientService.UpdateAsync(clientDto);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteClientAsync(int id)
        {
            var result = await _clientService.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
