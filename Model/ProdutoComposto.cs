using System.Collections.Generic;

namespace Model
{
    public class ProdutoComposto : Produto
    {
        //public ProdutosDaComposicao ProdutosDaComposicao { get; set; }
        public virtual ICollection<ProdutosDaComposicao> ProdutosDaComposicao { get; set; }
    }
}
