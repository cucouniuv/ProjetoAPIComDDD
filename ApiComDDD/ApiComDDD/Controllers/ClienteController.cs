using System;
using System.Threading.Tasks;
using Api.Domain.DTO;
using Api.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCliente()
        {
            try
            {
                var dados = await _clienteService.GetAllAsync();
                return Ok(dados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarUmClienteDTO adicionarUmClienteDTO)
        {
            try
            {
                await _clienteService.AdicionarClienteAsync(adicionarUmClienteDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                //return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status200OK);
        }

    }
}