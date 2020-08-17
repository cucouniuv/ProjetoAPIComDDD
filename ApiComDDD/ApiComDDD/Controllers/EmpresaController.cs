using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmpresa()
        {
            try
            {
                var users = await _empresaService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var empresa = await _empresaService.GetByIdAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Empresa empresa)
        {
            await _empresaService.AddAsync(empresa);

            return CreatedAtAction(
                nameof(GetEmpresa),
                new { id = empresa.Id }, empresa);
        }
    }
}