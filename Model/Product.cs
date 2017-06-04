using System.Collections.Generic;

namespace Model
{
    public class Product
    {
        //Classe base para objetos do tipo Produto.
        //Produtos Simples e Compostos herdam desta classe
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal CostValue { get; set; }

        public decimal SellValue { get; set; }

        public ProductType Type { get; set; }

        public virtual ICollection<ProductComposition> Products { get; set; }

        public virtual ICollection<ProductComposition> Itens { get; set; }

        public virtual ICollection<ProductRequest> Requests { get; set; }
    }

    public enum ProductType
    {
        Simples,
        Composto
    }
}
