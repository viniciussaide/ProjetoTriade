using Database;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class ProdutosNasRequisicoesController
    {
        public DBtriade Banco { get; set; }

        public ProdutosNasRequisicoesController()
        {
            Banco = new DBtriade();
        }

        public void Salvar(ProdutosNasRequisicoes produtoNasRequisicoes)
        {
            Banco.ProdutosNasRequisicoes.Add(produtoNasRequisicoes);
            Banco.SaveChanges();
        }

        public IEnumerable<ProdutosNasRequisicoes> Listar()
        {
            return Banco.ProdutosNasRequisicoes.ToList();
        }

        //public ProdutosNasRequisicoes Selecionar(int id)
        //{
        //    return Banco.ProdutosNasRequisicoes.Where(x => x.IdRequisicao == id).First();
        //}

        public void Alterar(ProdutosNasRequisicoes produtoNasRequisicoes)
        {
            ProdutosNasRequisicoes produtoNasRequisicoesSalvar =
                Banco.ProdutosNasRequisicoes
                .Where(x => x.IdRequisicao == produtoNasRequisicoes.IdRequisicao)
                .Where(x => x.IdProduto == produtoNasRequisicoes.IdProduto).First();
            produtoNasRequisicoesSalvar.QuantidadeDeProdutos = produtoNasRequisicoes.QuantidadeDeProdutos;
            Banco.SaveChanges();
        }

        public void Excluir(ProdutosNasRequisicoes produtoNasRequisicoes)
        {
            ProdutosNasRequisicoes produtoNasRequisicoesExcluir =
                Banco.ProdutosNasRequisicoes
                .Where(x => x.IdRequisicao == produtoNasRequisicoes.IdRequisicao)
                .Where(x => x.IdProduto == produtoNasRequisicoes.IdProduto).First();
            Banco.Set<ProdutosNasRequisicoes>().Remove(produtoNasRequisicoesExcluir);
            Banco.SaveChanges();
        }
    }
}
