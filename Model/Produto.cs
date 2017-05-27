using System.Collections.Generic;

namespace Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }

        public virtual ICollection<ProdutosNasRequisicoes> ProdutosNasRequisicoes { get; set; }
    }
}
