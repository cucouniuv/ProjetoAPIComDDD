using System;
using System.Threading.Tasks;
using Api.Domain.DTO;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Post([FromBody] EmpresaDTO empresaDTO)
        {
            try
            {
                await _empresaService.AddEmpresaAsync(empresaDTO);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest("Parâmetro id e id do objeto empresa são diferentes.");
            }

            var emp = await _empresaService.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }

            //emp.Nome = empresa.Nome;
            //emp.Cnpj = empresa.Cnpj;
            //emp.DataFundacao = empresa.DataFundacao;

            //TODO: Criar método para alterar nome, outro para cnpj, blablabla

            await _empresaService.UpdateAsync(emp);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _empresaService.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }

            await _empresaService.RemoveAsync(emp);

            return NoContent();
        }
    }
}