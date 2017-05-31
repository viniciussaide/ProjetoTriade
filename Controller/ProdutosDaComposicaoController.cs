using Database;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class ProdutosDaComposicaoController
    {
        public DBtriade Banco { get; set; }

        public ProdutosDaComposicaoController()
        {
            Banco = new DBtriade();
        }

        public void Salvar(ProdutosDaComposicao produtosDaComposicao)
        {
            Banco.ProdutosDaComposicao.Add(produtosDaComposicao);
            Banco.SaveChanges();
        }

        public IList<ProdutosDaComposicao> Listar()
        {
            return Banco.ProdutosDaComposicao.ToList();
        }

        public IQueryable<ProdutosDaComposicao> Selecionar(int id)
        {
            return Banco.ProdutosDaComposicao.Where(x => x.FKprodutoComposto == id);
        }

        public int TotalRelacionamentosProdutoSimples(int id)
        {
            return Banco.ProdutosDaComposicao.Count(x => x.FKprodutoSimples == id);
        }

        public void Alterar(ProdutosDaComposicao produtosDaComposicao)
        {
            var produtosDaComposicaoSalvar = Banco.ProdutosDaComposicao
                .Where(x => x.FKprodutoComposto == produtosDaComposicao.FKprodutoComposto).First(x => x.FKprodutoSimples == produtosDaComposicao.FKprodutoSimples);
            produtosDaComposicaoSalvar.QuantidadeContidaDoProdutoSimples = produtosDaComposicao.QuantidadeContidaDoProdutoSimples;
            Banco.SaveChanges();
        }

        public void Excluir(ProdutosDaComposicao produtosDaComposicao)
        {
            var produtosDaComposicaoExcluir = Banco.ProdutosDaComposicao
                .Where(x => x.FKprodutoComposto == produtosDaComposicao.FKprodutoComposto)
                .First(x => x.FKprodutoSimples == produtosDaComposicao.FKprodutoSimples);
            Banco.Set<ProdutosDaComposicao>().Remove(produtosDaComposicaoExcluir);
            Banco.SaveChanges();
        }

        public void Excluir(Produto produto)
        {
            var count = Banco.ProdutosDaComposicao.Count(x => x.FKprodutoComposto == produto.Id);
            if (count > 0)
            {
                var produtosDaComposicaoExcluir =
                    Banco.ProdutosDaComposicao.Where(x => x.FKprodutoComposto == produto.Id);
                Banco.ProdutosDaComposicao.RemoveRange(produtosDaComposicaoExcluir);
                Banco.SaveChanges();
            }
        }
    }
}
