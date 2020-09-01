using Api.Domain.Entities;
using Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Api.Domain.DTO
{
    public class DadosDeUmaCompraDTO
    {
        public int IdDaCompra { get; set; }

        public DateTime DataDaCompra { get; set; }

        public Endereco EnderecoDeEntrega { get; set; }

        public string NomeDoCliente { get; set; }

        public Endereco EnderecoDoCliente { get; set; }

        public List<ProdutosDaCompra> ListaDeProdutosDaCompra { get; set; }

        public double ValorTotalDaCompra { get; set; }
    }
}
