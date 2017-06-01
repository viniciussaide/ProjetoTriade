using System.Collections.Generic;

namespace Model
{
    public class Produto
    {
        //Classe base para objetos do tipo Produto.
        //Produtos Simples e Compostos herdam desta classe
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }

        public virtual ICollection<ProdutosNasRequisicoes> ProdutosNasRequisicoes { get; set; }
    }
}
