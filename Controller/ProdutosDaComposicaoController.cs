using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class ProdutosDaComposicaoController
    {
        //Classe que controla o CRUD da composição dos produtos compostos

        //Declaração da variavel banco que controla as tabelas
        public DBtriade Banco { get; set; }

        //Método Construtor
        public ProdutosDaComposicaoController()
        {
            Banco = new DBtriade();
        }

        //Insere um relacionamento de um produto simples em uma composição de um produto composto
        public void Salvar(ProductComposition produtosDaComposicao)
        {
            Banco.ProdutosDaComposicao.Add(produtosDaComposicao);
            Banco.SaveChanges();
        }

        //Lista todos os relacionamentos de composição entre produtos simples com seus produtos compostos
        public IList<ProductComposition> Listar()
        {
            return Banco.ProdutosDaComposicao.ToList();
        }

        //Seleciona todos os produtos simples relacionados com um id de um produto composto
        public IQueryable<ProductComposition> Selecionar(int id)
        {
            return Banco.ProdutosDaComposicao.Where(x => x.IdProdutoComposto == id);
        }

        //Conta em quantas composições o id do produto simples esta fazendo relações 
        public int TotalRelacionamentosProdutoSimples(int id)
        {
            return Banco.ProdutosDaComposicao.Count(x => x.IdProdutoSimples == id);
        }

        //Altera um relacionamento de um produto simples em uma composição de um produto composto pre-selecionado
        public void Alterar(ProductComposition produtosDaComposicao)
        {
            var produtosDaComposicaoSalvar = Banco.ProdutosDaComposicao
                .Where(x => x.IdProdutoComposto == produtosDaComposicao.IdProdutoComposto).First(x => x.IdProdutoSimples == produtosDaComposicao.IdProdutoSimples);
            produtosDaComposicaoSalvar.Quantidade = produtosDaComposicao.Quantidade;
            Banco.SaveChanges();
        }

        //Exclui um relacionamento de um produto simples em uma composição de um produto composto pre-selecionado
        public void Excluir(ProductComposition produtosDaComposicao)
        {
            var produtosDaComposicaoExcluir = Banco.ProdutosDaComposicao
                .Where(x => x.IdProdutoComposto == produtosDaComposicao.IdProdutoComposto)
                .First(x => x.IdProdutoSimples == produtosDaComposicao.IdProdutoSimples);
            Banco.Set<ProductComposition>().Remove(produtosDaComposicaoExcluir);
            Banco.SaveChanges();
        }

        //Exclui todos os relacionamentos de composição que um produto composto possui
        public void Excluir(Product produto)
        {
            var count = Banco.ProdutosDaComposicao.Count(x => x.IdProdutoComposto == produto.Id);
            if (count > 0)
            {
                var produtosDaComposicaoExcluir =
                    Banco.ProdutosDaComposicao.Where(x => x.IdProdutoComposto == produto.Id);
                Banco.ProdutosDaComposicao.RemoveRange(produtosDaComposicaoExcluir);
                Banco.SaveChanges();
            }
        }
    }
}
