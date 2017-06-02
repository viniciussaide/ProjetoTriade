namespace Model
{
    public class ProductComposition
    {
        //Classe que contém todos os produtos simples contidos em produtos Compostos
        //Possui uma chave Primária composta de duas chaves sendo estas FKprodutoComposto e FKprodutoSimples
        public int IdProdutoComposto { get; set; }

        public int IdProdutoSimples { get; set; }

        //Relacionamentos com os objetos ProdutoComposto e ProdutoSimples
        public Product ProdutoComposto { get; set; }
        public Product ProdutoSimples { get; set; }

        //Quantidade de produtos simples contidos no produto composto
        public int Quantidade { get; set; }
    }
}
