using Microsoft.AspNetCore.Mvc;
using MinhaApi.Dtos;
using MinhaApi.Services;
using System;
using System.Threading.Tasks;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientsController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientsController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClientDto createClientDto)
        {
            try
            {
                var client = await _clientService.CreateAsync(createClientDto);
                return CreatedAtAction(nameof(Create), new { id = client.Id }, client);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }
    }
}
