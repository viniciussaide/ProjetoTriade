namespace Model
{
    public class ProductRequest
    {
        //Classe que contém todos os produtos contidos nas requisições feitas
        //Possui uma chave Primária composta de duas chaves sendo estas IdRequisicao e IdProduto
        public int RequisicaoId { get; set; }
        
        public int ProductId { get; set; }

        //Relacionamentos com os objetos Requisicao e Produto
        public Request Requisicao { get; set; }
        public Product Produto { get; set; }

        //Quantidade de produtos contido na requisição
        public int Quantidade { get; set; }
    }
}
