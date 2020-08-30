using Api.Domain.ValueObjects;
using System.Collections.Generic;

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
            return 0;
        }
    }
}
