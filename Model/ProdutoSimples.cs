using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ProdutoSimples : Produto
    {
        public int Quantidade { get; set; }

        public virtual ICollection<ProdutosDaComposicao> ProdutosDaComposicao { get; set; }
    }
}
