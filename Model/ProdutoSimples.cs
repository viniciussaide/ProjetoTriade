using System.Collections.Generic;

namespace Model
{
    public class ProdutoSimples : Produto
    {
        public virtual ICollection<ProdutosDaComposicao> ProdutosDaComposicao { get; set; }
    }
}
