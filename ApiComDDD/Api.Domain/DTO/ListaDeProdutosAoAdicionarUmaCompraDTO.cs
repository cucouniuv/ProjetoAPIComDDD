namespace Api.Domain.DTO
{
    public class ListaDeProdutosAoAdicionarUmaCompraDTO
    {
        public int IdDoProduto { get; set; }

        public double Preco { get; set; }

        public double Desconto { get; set; }

        public double Quantidade { get; set; }
    }
}
