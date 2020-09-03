using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public class ProdutosDaCompra: Entity
    {
        [Key]
        public int Id { get; private set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }

        public double Preco { get; private set; }
        public double Desconto { get; private set; }

        public double Quantidade { get; private set; }

        [ForeignKey("Compra")]
        public int CompraId { get; private set; }
        public Compra Compra { get; private set; }

        /*
        'No suitable constructor found for entity type 'ProdutosDaCompra'. The following constructors 
        had parameters that could not be bound to properties of the entity type: cannot 
        bind 'produto', 'compra' in 'ProdutosDaCompra(Produto produto, double preco, 
        double desconto, Compra compra)'.'
         */
        public ProdutosDaCompra() { }

        public ProdutosDaCompra(Produto produto, double preco, double desconto, double quantidade, Compra compra)
        {
            Produto = produto;
            Preco = preco;
            Desconto = desconto;
            Quantidade = quantidade;
            Compra = compra;
        }
    }
}
