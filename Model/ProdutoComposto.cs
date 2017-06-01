using System.Collections.Generic;

namespace Model
{
    public class ProdutoComposto : Produto
    {
        public virtual ICollection<ProdutosDaComposicao> ProdutosDaComposicao { get; set; }
    }
}
