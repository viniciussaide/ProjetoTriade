using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ProdutosNasRequisicoes
    {
        //Classe que contém todos os produtos contidos nas requisições feitas
        //Possui uma chave Primária composta de duas chaves sendo estas IdRequisicao e IdProduto
        [Required]
        [Key, Column(Order = 1)]
        public int IdRequisicao { get; set; }

        [Required]
        [Key, Column(Order = 2)]
        public int IdProduto { get; set; }

        //Relacionamentos com os objetos Requisicao e Produto
        [ForeignKey("IdRequisicao")]
        public Requisicao Requisicao { get; set; }

        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

        //Quantidade de produtos contido na requisição
        public int QuantidadeDeProdutos { get; set; }
    }
}
