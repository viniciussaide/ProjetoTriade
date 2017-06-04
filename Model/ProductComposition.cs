namespace Model
{
    public class ProductComposition
    {
        //Classe que contém todos os produtos simples contidos em produtos Compostos
        //Possui uma chave Primária composta de duas chaves sendo estas FKprodutoComposto e FKprodutoSimples
        public int ProductId { get; set; }
        public int ItemId { get; set; }

        public Product Product { get; set; }

        public Product Item { get; set; }

        public int Quantity { get; set; }
    }
}
