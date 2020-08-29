using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class Empresa
    {
        [Key]
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Cnpj { get; private set; }

        public DateTime DataFundacao { get; private set; }

        public Empresa(string nome, string cnpj)
        {
            Nome = nome;
            Cnpj = cnpj;
            DataFundacao = DateTime.Now;
        }

    }
}
