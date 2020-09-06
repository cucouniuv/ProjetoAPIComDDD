using Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Domain.Entities
{
    public class Cliente: Entity
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public Endereco Endereco { get; private set; }

        public List<Compra> ListaDeComprasDoCliente { get; private set; }

        public Cliente(string nome)
        {
            Nome = nome;
        }

        public Cliente(string nome, Endereco endereco)
        {
            Nome = nome;
            Endereco = endereco;
        }

        public double CalcularPercentualDeDesconto(int compraId)
        {
            if ((ListaDeComprasDoCliente == null) || (ListaDeComprasDoCliente.Count <= 0))
                return 0.15;

            bool existeCompraAnterior = ListaDeComprasDoCliente.Any(lista => lista.Id < compraId);
            if (!existeCompraAnterior)
                return 0.15;

            bool existeCompraComUmAnoOuMais =
                ListaDeComprasDoCliente.Any(lista => (DateTime.Now.Year - lista.Data.Year) >= 1);
            
            if (existeCompraComUmAnoOuMais)
                return 0.05;

            return 0;
        }
    }
}
