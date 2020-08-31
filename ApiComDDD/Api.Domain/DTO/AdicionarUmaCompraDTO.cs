using Api.Domain.Entities;
using Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Api.Domain.DTO
{
    public class AdicionarUmaCompraDTO
    {
        public int ClienteId { get; set; }
        public DateTime DataDaCompra { get; set; }

        public string RuaDeEntrega { get; set; }
        public string CidadeDeEntrega { get; set; }
        public string EstadoDeEntrega { get; set; }
        public string CEPDeEntrega { get; set; }

        public List<ListaDeProdutosAoAdicionarUmaCompraDTO> ListaDeProdutosDaCompra { get; set; }
    }
}
