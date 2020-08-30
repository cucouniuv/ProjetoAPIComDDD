using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/produtosdacompra")]
    [ApiController]
    public class ProdutosDaCompraController : ControllerBase
    {
        private readonly IProdutosDaCompraService _produtosDaCompraService;

        public ProdutosDaCompraController(IProdutosDaCompraService produtosDaCompraService)
        {
            _produtosDaCompraService = produtosDaCompraService;
        }

        [HttpGet]
        public async Task<ActionResult> GetProdutosDaCompra()
        {
            try
            {
                var dados = await _produtosDaCompraService.GetAllAsync();
                return Ok(dados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}