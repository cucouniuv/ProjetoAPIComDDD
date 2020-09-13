using Api.Domain.Entities;
using Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace Api.Tests
{
    public class ClienteTests
    {
        [Theory]
        [InlineData(0.15)]
        public void CalcularPercentualDeDescontoParaClienteNovo(double valorEsperado)
        {
            // Arrange
            Endereco enderecoCliente = new Endereco(
                    "Rua 1",
                    "Maring�",
                    "Paran�",
                    ""
                );

            Cliente cliente = new Cliente("Joao", enderecoCliente);

            /*Endereco enderecoCompra = new Endereco(
                    "Rua 50",
                    "Foz do igua�u",
                    "Paran�",
                    ""
                );

            List<ProdutosDaCompra> listaDeProdutosDaCompra = new List<ProdutosDaCompra>();
            */

            //Compra compra = new Compra(new DateTime(), enderecoCompra, cliente, listaDeProdutosDaCompra);

            // Act
            double valorResultado = cliente.CalcularPercentualDeDesconto(1);

            // Assert
            Assert.Equal(valorEsperado, valorResultado);
        }
    }
}
