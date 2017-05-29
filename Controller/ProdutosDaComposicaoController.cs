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

        public ProdutosDaComposicao Selecionar(int id)
        {
            return Banco.ProdutosDaComposicao.Where(x => x.FKprodutoComposto == id).First();
        }

        public void Alterar(ProdutosDaComposicao produtosDaComposicao)
        {
            ProdutosDaComposicao produtosDaComposicaoSalvar = 
                Banco.ProdutosDaComposicao
                .Where(x => x.FKprodutoComposto == produtosDaComposicao.FKprodutoComposto)
                .Where(x => x.FKprodutoSimples == produtosDaComposicao.FKprodutoSimples).First();
            produtosDaComposicaoSalvar.QuantidadeContidaDoProdutoSimples = produtosDaComposicao.QuantidadeContidaDoProdutoSimples;
            Banco.SaveChanges();
        }

        public void Excluir(ProdutosDaComposicao produtosDaComposicao)
        {
            ProdutosDaComposicao produtosDaComposicaoExcluir =
                Banco.ProdutosDaComposicao
                .Where(x => x.FKprodutoComposto == produtosDaComposicao.FKprodutoComposto)
                .Where(x => x.FKprodutoSimples == produtosDaComposicao.FKprodutoSimples).First();
            Banco.Set<ProdutosDaComposicao>().Remove(produtosDaComposicaoExcluir);
            Banco.SaveChanges();
        }

        public void Excluir(Produto produto)
        {
            int count = Banco.ProdutosDaComposicao.Where(x => x.FKprodutoComposto == produto.Id).Count();
            if (count > 0)
            {
                ProdutosDaComposicao produtosDaComposicaoExcluir =
                    Banco.ProdutosDaComposicao
                    .Where(x => x.FKprodutoComposto == produto.Id).First();
                Banco.Set<ProdutosDaComposicao>().Remove(produtosDaComposicaoExcluir);
                Banco.SaveChanges();
            }
        }
    }
}
