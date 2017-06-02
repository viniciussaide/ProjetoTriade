using System.Collections.Generic;

namespace Model
{
    public enum TipoProduto
    {
        Simples,
        Composto
    }

    public class Product
    {
        //Classe base para objetos do tipo Produto.
        //Produtos Simples e Compostos herdam desta classe
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public TipoProduto Tipo { get; set; }

        public virtual ICollection<ProductRequest> ProdutosNasRequisicoes { get; set; }

        public virtual ICollection<ProductComposition> ProdutosCompostos { get; set; }
        public virtual ICollection<ProductComposition> ProdutosSimples { get; set; }
    }
}
