using Database;
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
        public void Salvar(ProdutosDaComposicao produtosDaComposicao)
        {
            Banco.ProdutosDaComposicao.Add(produtosDaComposicao);
            Banco.SaveChanges();
        }

        //Lista todos os relacionamentos de composição entre produtos simples com seus produtos compostos
        public IList<ProdutosDaComposicao> Listar()
        {
            return Banco.ProdutosDaComposicao.ToList();
        }

        //Seleciona todos os produtos simples relacionados com um id de um produto composto
        public IQueryable<ProdutosDaComposicao> Selecionar(int id)
        {
            return Banco.ProdutosDaComposicao.Where(x => x.FKprodutoComposto == id);
        }

        //Conta em quantas composições o id do produto simples esta fazendo relações 
        public int TotalRelacionamentosProdutoSimples(int id)
        {
            return Banco.ProdutosDaComposicao.Count(x => x.FKprodutoSimples == id);
        }

        //Altera um relacionamento de um produto simples em uma composição de um produto composto pre-selecionado
        public void Alterar(ProdutosDaComposicao produtosDaComposicao)
        {
            var produtosDaComposicaoSalvar = Banco.ProdutosDaComposicao
                .Where(x => x.FKprodutoComposto == produtosDaComposicao.FKprodutoComposto).First(x => x.FKprodutoSimples == produtosDaComposicao.FKprodutoSimples);
            produtosDaComposicaoSalvar.QuantidadeContidaDoProdutoSimples = produtosDaComposicao.QuantidadeContidaDoProdutoSimples;
            Banco.SaveChanges();
        }

        //Exclui um relacionamento de um produto simples em uma composição de um produto composto pre-selecionado
        public void Excluir(ProdutosDaComposicao produtosDaComposicao)
        {
            var produtosDaComposicaoExcluir = Banco.ProdutosDaComposicao
                .Where(x => x.FKprodutoComposto == produtosDaComposicao.FKprodutoComposto)
                .First(x => x.FKprodutoSimples == produtosDaComposicao.FKprodutoSimples);
            Banco.Set<ProdutosDaComposicao>().Remove(produtosDaComposicaoExcluir);
            Banco.SaveChanges();
        }

        //Exclui todos os relacionamentos de composição que um produto composto possui
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
