using Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Api.Domain.Entities
{
    public class Compra: Entity
    {
        [Key]
        public int Id { get; private set; }

        public DateTime Data { get; private set; }

        public Endereco Endereco { get; private set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }

        public List<ProdutosDaCompra> ListaDeProdutosDaCompra { get; private set; }

        public Compra() { }

        public Compra(DateTime data, Endereco endereco, Cliente cliente, List<ProdutosDaCompra> listaDeProdutosDaCompra)
        {
            Data = data;
            Endereco = endereco;
            Cliente = cliente;
            ListaDeProdutosDaCompra = listaDeProdutosDaCompra;
        }

        public double CalcularValorTotalDaCompra()
        {
            if (ListaDeProdutosDaCompra.Count == 0)
                return 0;

            double percentualDesconto = Cliente.CalcularPercentualDeDesconto();
            
            double valorTotalDaListaDeProdutos = ListaDeProdutosDaCompra
                .Where(x => x.CompraId == Id)
                .Select(x => x.Preco - x.Desconto)
                .Sum();

            return (valorTotalDaListaDeProdutos - (percentualDesconto * valorTotalDaListaDeProdutos));
        }

        public void AtribuirListaDeProdutosDaCompra(List<ProdutosDaCompra> lista)
        {
            ListaDeProdutosDaCompra = lista;
        }
    }
}
