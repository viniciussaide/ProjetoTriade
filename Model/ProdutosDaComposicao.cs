using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ProdutosDaComposicao
    {
        [Required]
        [Key, Column(Order = 0)]
        public int FKprodutoComposto { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public int FKprodutoSimples { get; set; }

        [ForeignKey("FKprodutoComposto")]
        public ProdutoComposto ProdutoComposto { get; set; }

        [ForeignKey("FKprodutoSimples")]
        public ProdutoSimples ProdutoSimples { get; set; }

        public int QuantidadeContidaDoProdutoSimples { get; set; }

        public virtual ICollection<ProdutoComposto> ListaProdutoComposto { get; set; }
        public virtual ICollection<ProdutoSimples> ListaProdutoSimples { get; set; }
    }
}
