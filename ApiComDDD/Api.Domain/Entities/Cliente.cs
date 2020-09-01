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

        public double CalcularPercentualDeDesconto()
        {
            //TODO: Lista sempre vem null
            if ((ListaDeComprasDoCliente == null) || (ListaDeComprasDoCliente.Count <= 0))
                return 0.15;

             if (ListaDeComprasDoCliente
                .Any(lista => (lista.Data.Year - DateTime.Now.Year) >= 1))
                    return 0.05;

            return 0;
        }
    }
}
