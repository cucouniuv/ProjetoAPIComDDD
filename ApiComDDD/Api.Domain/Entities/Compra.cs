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

        public Compra() { }

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

        public void AdicionarCodidoDaCompraNaListaDeProdutos(int codigo)
        {
            foreach(var x in ListaDeProdutosDaCompra)
            {
                x.AtualizarCodigoDaCompra(codigo);
            }
        }

    }
}
