using Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class Compra: Entity
    {
        [Key]
        public int Id { get; private set; }

        public DateTime Data { get; private set; }

        public Endereco Endereco { get; private set; }

        public List<ProdutosDaCompra> ListaDeProdutosDaCompra { get; private set; }

        public Compra(DateTime data, Endereco endereco, List<ProdutosDaCompra> listaDeProdutosDaCompra)
        {
            Data = data;
            Endereco = endereco;
            ListaDeProdutosDaCompra = listaDeProdutosDaCompra;
        }

        public double CalcularValorTotalDaCompra()
        {
            return 0;
        }

    }
}
