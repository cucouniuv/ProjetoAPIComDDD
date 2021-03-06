﻿using System;
using System.Threading.Tasks;
using Api.Domain.DTO;
using Api.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/compra")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCompra()
        {
            try
            {
                var dados = await _compraService.GetAllAsync();
                return Ok(dados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DadosDeUmaCompraDTO>> PegarCompraPorId(int id)
        {
            var dados = await _compraService.PegarDadosDeUmaCompraPorId(id);

            if (dados == null)
            {
                return NotFound();
            }

            return dados;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarUmaCompraDTO adicionarUmaCompraDTO)
        {
            try
            {
                await _compraService.AdicionarUmaCompraAsync(adicionarUmaCompraDTO);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}