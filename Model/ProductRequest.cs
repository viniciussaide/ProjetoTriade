namespace Model
{
    public class ProductRequest
    {
        //Classe que contém todos os produtos contidos nas requisições feitas
        //Possui uma chave Primária composta de duas chaves sendo estas IdRequisicao e IdProduto
        public int RequestId { get; set; }
        
        public int ProductId { get; set; }

        //Relacionamentos com os objetos Requisicao e Produto
        public Request Request { get; set; }
        public Product Product { get; set; }

        //Quantidade de produtos contido na requisição
        public int Quantity { get; set; }
    }
}
