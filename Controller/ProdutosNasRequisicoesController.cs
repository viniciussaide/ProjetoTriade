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
        public void Salvar(ProductRequest produtoNasRequisicoes)
        {
            Banco.ProdutosNasRequisicoes.Add(produtoNasRequisicoes);
            Banco.SaveChanges();
        }

        //Lista todos os produtos contidos em todas as requisições
        public ProductRequest[] Listar()
        {
            return Banco.ProdutosNasRequisicoes.ToArray();
        }

        //public ProdutosNasRequisicoes Selecionar(int id)
        //{
        //    return Banco.ProdutosNasRequisicoes.First(x => x.IdRequisicao == id);
        //}

        //Altera um produto contido na requisição pre-selecionado
        public void Alterar(ProductRequest produtoNasRequisicoes)
        {
            var produtoNasRequisicoesSalvar =
                Banco.ProdutosNasRequisicoes
                .Where(x => x.RequisicaoId == produtoNasRequisicoes.RequisicaoId)
                .First(x => x.ProductId == produtoNasRequisicoes.ProductId);
            produtoNasRequisicoesSalvar.Quantidade = produtoNasRequisicoes.Quantidade;
            Banco.SaveChanges();
        }

        //Exclui todos os produtos contidos em uma requisição
        public void Excluir(Request requisicao)
        {
            var count = Banco.ProdutosNasRequisicoes.Count(x => x.RequisicaoId == requisicao.Id);
            if (count > 0)
            {
                var produtosNaRequisicao =
                    Banco.ProdutosNasRequisicoes.Where(x => x.RequisicaoId == requisicao.Id);
                Banco.ProdutosNasRequisicoes.RemoveRange(produtosNaRequisicao);
                Banco.SaveChanges();
            }
        }
    }
}
