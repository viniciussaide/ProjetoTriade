using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ProdutosNasRequisicoes
    {
        [Required]
        [Key, Column(Order = 1)]
        public int IdRequisicao { get; set; }

        [Required]
        [Key, Column(Order = 2)]
        public int IdProduto { get; set; }

        [ForeignKey("IdRequisicao")]
        public Requisicao Requisicao { get; set; }

        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

        public int QuantidadeDeProdutos { get; set; }
    }
}
