using Database;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class ProdutosNasRequisicoesController
    {
        //Classe que controla o CRUD dos produtos contidos em requisições

        //Declaração da variavel banco que controla as tabelas
        public DBtriade Banco { get; set; }

        //Método Contrutor
        public ProdutosNasRequisicoesController()
        {
            Banco = new DBtriade();
        }

        //Insere um produto contido em uma requisição
        public void Salvar(ProdutosNasRequisicoes produtoNasRequisicoes)
        {
            Banco.ProdutosNasRequisicoes.Add(produtoNasRequisicoes);
            Banco.SaveChanges();
        }

        //Lista todos os produtos contidos em todas as requisições
        public IEnumerable<ProdutosNasRequisicoes> Listar()
        {
            return Banco.ProdutosNasRequisicoes.ToList();
        }

        //public ProdutosNasRequisicoes Selecionar(int id)
        //{
        //    return Banco.ProdutosNasRequisicoes.First(x => x.IdRequisicao == id);
        //}

        //Altera um produto contido na requisição pre-selecionado
        public void Alterar(ProdutosNasRequisicoes produtoNasRequisicoes)
        {
            var produtoNasRequisicoesSalvar =
                Banco.ProdutosNasRequisicoes
                .Where(x => x.IdRequisicao == produtoNasRequisicoes.IdRequisicao)
                .First(x => x.IdProduto == produtoNasRequisicoes.IdProduto);
            produtoNasRequisicoesSalvar.QuantidadeDeProdutos = produtoNasRequisicoes.QuantidadeDeProdutos;
            Banco.SaveChanges();
        }

        //Exclui todos os produtos contidos em uma requisição
        public void Excluir(Requisicao requisicao)
        {
            var count = Banco.ProdutosNasRequisicoes.Count(x => x.IdRequisicao == requisicao.Id);
            if (count > 0)
            {
                var produtosNaRequisicao =
                    Banco.ProdutosNasRequisicoes.Where(x => x.IdRequisicao == requisicao.Id);
                Banco.ProdutosNasRequisicoes.RemoveRange(produtosNaRequisicao);
                Banco.SaveChanges();
            }
        }
    }
}
