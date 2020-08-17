using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public DateTime DataFundacao { get; set; }

    }
}
