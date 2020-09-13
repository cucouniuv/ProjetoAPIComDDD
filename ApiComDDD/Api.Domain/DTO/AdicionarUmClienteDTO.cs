namespace Api.Domain.DTO
{
    public class AdicionarUmClienteDTO
    {
        public string NomeDoCliente { get; set; }

        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}
