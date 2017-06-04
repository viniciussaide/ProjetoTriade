using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class ProductCompositionController
    {
        //Classe que controla o CRUD da composição dos produtos compostos

        //Declaração da variavel banco que controla as tabelas
        public DBtriade DBtriade { get; set; }

        //Método Construtor
        public ProductCompositionController()
        {
            DBtriade = new DBtriade();
        }

        //Insere um relacionamento de um produto simples em uma composição de um produto composto
        public void Insert(ProductComposition ProductComposition)
        {
            DBtriade.ProdutosDaComposicao.Add(ProductComposition);
            DBtriade.SaveChanges();
        }

        //Lista todos os relacionamentos de composição entre produtos simples com seus produtos compostos
        public IList<ProductComposition> List()
        {
            return DBtriade.ProdutosDaComposicao.ToList();
        }

        //Seleciona todos os produtos simples relacionados com um id de um produto composto
        public IQueryable<ProductComposition> Select(int id)
        {
            return DBtriade.ProdutosDaComposicao.Where(x => x.ProductId == id);
        }

        //Conta em quantas composições o id do produto simples esta fazendo relações 
        public int CountProductOnComposition(int id)
        {
            return DBtriade.ProdutosDaComposicao.Count(x => x.ItemId == id);
        }

        //Altera um relacionamento de um produto simples em uma composição de um produto composto pre-selecionado
        public void Update(ProductComposition ProductComposition)
        {
            var produtosDaComposicaoSalvar = DBtriade.ProdutosDaComposicao
                .Where(x => x.ProductId == ProductComposition.ProductId).First(x => x.ItemId == ProductComposition.ItemId);
            produtosDaComposicaoSalvar.Quantity = ProductComposition.Quantity;
            DBtriade.SaveChanges();
        }

        //Exclui um relacionamento de um produto simples em uma composição de um produto composto pre-selecionado
        public void Remove(ProductComposition ProductComposition)
        {
            var produtosDaComposicaoExcluir = DBtriade.ProdutosDaComposicao
                .Where(x => x.ProductId == ProductComposition.ProductId)
                .First(x => x.ItemId == ProductComposition.ItemId);
            DBtriade.Set<ProductComposition>().Remove(produtosDaComposicaoExcluir);
            DBtriade.SaveChanges();
        }

        //Exclui todos os relacionamentos de composição que um produto composto possui
        public void Remove(Product product)
        {
            var count = DBtriade.ProdutosDaComposicao.Count(x => x.ProductId == product.Id);
            if (count > 0)
            {
                var produtosDaComposicaoExcluir =
                    DBtriade.ProdutosDaComposicao.Where(x => x.ProductId == product.Id);
                DBtriade.ProdutosDaComposicao.RemoveRange(produtosDaComposicaoExcluir);
                DBtriade.SaveChanges();
            }
        }
    }
}
