using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ProdutosDaComposicao
    {
        //Classe que contém todos os produtos simples contidos em produtos Compostos
        //Possui uma chave Primária composta de duas chaves sendo estas FKprodutoComposto e FKprodutoSimples
        [Required]
        [Key, Column(Order = 0)]
        public int FKprodutoComposto { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public int FKprodutoSimples { get; set; }

        //Relacionamentos com os objetos ProdutoComposto e ProdutoSimples
        [ForeignKey("FKprodutoComposto")]
        public ProdutoComposto ProdutoComposto { get; set; }

        [ForeignKey("FKprodutoSimples")]
        public ProdutoSimples ProdutoSimples { get; set; }

        //Quantidade de produtos simples contidos no produto composto
        public int QuantidadeContidaDoProdutoSimples { get; set; }
    }
}
