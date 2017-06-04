using System.Collections.Generic;

namespace Model
{
    public class Product
    {
        //Classe base para objetos do tipo Produto.
        //Produtos Simples e Compostos herdam desta classe
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal PrecoCusto { get; set; }

        public decimal PrecoVenda { get; set; }

        public TipoProduto Tipo { get; set; }

        public virtual ICollection<ProductComposition> Produtos { get; set; }

        public virtual ICollection<ProductComposition> Itens { get; set; }

        public virtual ICollection<ProductRequest> Requisicoes { get; set; }
    }

    public enum TipoProduto
    {
        Simples,
        Composto
    }
}
