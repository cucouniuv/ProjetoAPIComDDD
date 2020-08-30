using Api.Domain.Entities;
using Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Api.Domain.DTO
{
    public class DadosDeUmaCompraDTO
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public Endereco Endereco { get; set; }

        public List<ProdutosDaCompra> ListaDeProdutosDaCompra { get; set; }
    }
}
