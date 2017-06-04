using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Windows.Forms;

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
            DBtriade.ProductComposition.Add(ProductComposition);
            DBtriade.SaveChanges();
        }

        //Lista todos os relacionamentos de composição entre produtos simples com seus produtos compostos
        public IList<ProductComposition> List()
        {
            return DBtriade.ProductComposition.ToList();
        }

        //Seleciona todos os produtos simples relacionados com um id de um produto composto
        public IQueryable<ProductComposition> Select(int id)
        {
            return DBtriade.ProductComposition.Where(x => x.ProductId == id);
        }

        //Conta em quantas composições o id do produto simples esta fazendo relações 
        public int CountProductOnComposition(int id)
        {
            return DBtriade.ProductComposition.Count(x => x.ItemId == id);
        }

        //Altera um relacionamento de um produto simples em uma composição de um produto composto pre-selecionado
        public void Update(ProductComposition ProductComposition)
        {
            var produtosDaComposicaoSalvar = DBtriade.ProductComposition
                .Where(x => x.ProductId == ProductComposition.ProductId).First(x => x.ItemId == ProductComposition.ItemId);
            produtosDaComposicaoSalvar.Quantity = ProductComposition.Quantity;
            DBtriade.SaveChanges();
        }

        //Exclui um relacionamento de um produto simples em uma composição de um produto composto pre-selecionado
        public void Remove(ProductComposition ProductComposition)
        {
            var produtosDaComposicaoExcluir = DBtriade.ProductComposition
                .Where(x => x.ProductId == ProductComposition.ProductId)
                .First(x => x.ItemId == ProductComposition.ItemId);
            DBtriade.Set<ProductComposition>().Remove(produtosDaComposicaoExcluir);
            DBtriade.SaveChanges();
        }

        //Exclui todos os relacionamentos de composição que um produto composto possui
        public void Remove(Product product)
        {
            var count = DBtriade.ProductComposition.Count(x => x.ProductId == product.Id);
            if (count > 0)
            {
                var produtosDaComposicaoExcluir =
                    DBtriade.ProductComposition.Where(x => x.ProductId == product.Id);
                DBtriade.ProductComposition.RemoveRange(produtosDaComposicaoExcluir);
                DBtriade.SaveChanges();
            }
        }
    }
}
