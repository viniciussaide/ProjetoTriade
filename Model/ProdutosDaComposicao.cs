using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProdutosDaComposicao
    {
        [Required]
        [Key, Column(Order = 1)]
        public int FKprodutoComposto { get; set; }

        [Required]
        [Key, Column(Order = 2)]
        public int FKprodutoSimples { get; set; }

        [ForeignKey("FKprodutoComposto")]
        //public virtual ICollection<ProdutoComposto> ProdutoComposto { get; set; }
        public ProdutoComposto ProdutoComposto { get; set; }

        [ForeignKey("FKprodutoSimples")]
        //public virtual ICollection<ProdutoSimples> ProdutoSimples { get; set; }
        public ProdutoSimples ProdutoSimples { get; set; }

        public int QuantidadeContidaDoProdutoSimples { get; set; }
    }
}
