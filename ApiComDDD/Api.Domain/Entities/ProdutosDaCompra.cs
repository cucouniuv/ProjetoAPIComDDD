namespace Api.Domain.Entities
{
    public class ProdutosDaCompra: Entity
    {
        public int Id { get; private set; }

        public Produto Produto { get; private set; }

        public double Preco { get; private set; }

        public double Desconto { get; private set; }

        public ProdutosDaCompra(Produto produto, double preco, double desconto)
        {
            Produto = produto;
            Preco = preco;
            Desconto = desconto;
        }
    }
}
