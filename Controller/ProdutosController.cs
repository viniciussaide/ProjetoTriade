using Database;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class ProdutosController
    {
        //Classe que controla o CRUD de produtos (simples ou compostos)

        //Declaração da variavel banco que controla as tabelas
        public DBtriade Banco { get; set; }

        //Método Construtor
        public ProdutosController()
        {
            Banco = new DBtriade();
        }

        //Inserir produto simples no banco
        public void Salvar(ProdutoSimples produtoSimples)
        {
            Banco.Produtos.Add(produtoSimples);
            Banco.SaveChanges();
        }

        //Inserir produto composto no banco
        public void Salvar(ProdutoComposto produtoComposto)
        {
            Banco.Produtos.Add(produtoComposto);
            Banco.SaveChanges();
        }

        //Listar todos os produtos independente se este é simples ou composto
        public IList<Produto> Listar()
        {
            return Banco.Produtos.ToList();
        }

        //Lista todos os produtos compostos
        public IList<ProdutoComposto> ListarProdutosCompostos()
        {
            return Banco.ProdutosCompostos.ToList();
        }

        //Lista todos os produtos simples
        public IList<ProdutoSimples> ListarProdutosSimples()
        {
            return Banco.ProdutosSimples.ToList();
        }

        //Seleciona um produto (simples ou composto) usando seu id
        public Produto Selecionar(int id)
        {
            return Banco.Produtos.FirstOrDefault(x => x.Id == id);
        }

        //Seleciona um produto (simples ou composto) usando seu nome
        public Produto Selecionar(string nome)
        {
            return Banco.Produtos.FirstOrDefault(x => x.Nome == nome);
        }

        //Seleciona um produto simples usando seu id
        public ProdutoSimples SelecionarProdutosSimples(int id)
        {
            return Banco.ProdutosSimples.FirstOrDefault(x => x.Id == id);
        }

        //Seleciona um produto  composto usando seu id
        public ProdutoComposto SelecionarProdutosCompostos(int id)
        {
            return Banco.ProdutosCompostos.FirstOrDefault(x => x.Id == id);
        }

        //Altera um produto (simples ou composto) que foi pre-selecionado
        public void Alterar(Produto produto)
        {
            var produtoSalvar = Banco.ProdutosSimples.First(x => x.Id == produto.Id);
            produtoSalvar.Nome = produto.Nome;
            produtoSalvar.PrecoCusto = produto.PrecoCusto;
            produtoSalvar.PrecoVenda = produto.PrecoVenda;
            Banco.SaveChanges();
        }

        //Altera um produto simples que foi pre-selecionado
        public void Alterar(ProdutoSimples produtoSimples)
        {
            var produtoSalvar = Banco.ProdutosSimples.First(x => x.Id == produtoSimples.Id);
            produtoSalvar.Nome = produtoSimples.Nome;
            produtoSalvar.PrecoCusto = produtoSimples.PrecoCusto;
            produtoSalvar.PrecoVenda = produtoSimples.PrecoVenda;
            Banco.SaveChanges();
        }

        //Altera um produto composto que foi pre-selecionado
        public void Alterar(ProdutoComposto produtoComposto)
        {
            var produtoSalvar = Banco.ProdutosCompostos.First(x => x.Id == produtoComposto.Id);
            produtoSalvar.Nome = produtoComposto.Nome;
            produtoSalvar.PrecoCusto = produtoComposto.PrecoCusto;
            produtoSalvar.PrecoVenda = produtoComposto.PrecoVenda;
            produtoSalvar.ProdutosDaComposicao = produtoComposto.ProdutosDaComposicao;
            Banco.SaveChanges();
        }


        //Exclui um produto (simples ou composto) que foi pre-selecionado
        public void Excluir(Produto produto)
        {
            var produtoExcluir = Banco.Produtos.Where(x => x.Id == produto.Id);
            Banco.Produtos.RemoveRange(produtoExcluir);
            Banco.SaveChanges();
        }
    }
}
