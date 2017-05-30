using Database;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class ProdutosController
    {
        public DBtriade Banco { get; set; }

        public ProdutosController()
        {
            Banco = new DBtriade();
        }

        public void Salvar(ProdutoSimples produtoSimples)
        {
            Banco.Produtos.Add(produtoSimples);
            Banco.SaveChanges();
        }

        public void Salvar(ProdutoComposto produtoComposto)
        {
            Banco.Produtos.Add(produtoComposto);
            Banco.SaveChanges();
        }

        public IList<Produto> Listar()
        {
            return Banco.Produtos.ToList();
        }

        public IList<ProdutoComposto> ListarProdutosCompostos()
        {
            return Banco.ProdutosCompostos.ToList();
        }

        public IList<ProdutoSimples> ListarProdutosSimples()
        {
            return Banco.ProdutosSimples.ToList();
        }

        public ProdutoSimples SelecionarProdutosSimples(int id)
        {
            return Banco.ProdutosSimples.FirstOrDefault(x => x.Id == id);
        }

        public ProdutoComposto SelecionarProdutosCompostos(int id)
        {
            return Banco.ProdutosCompostos.FirstOrDefault(x => x.Id == id);
        }

        public Produto Selecionar(int id)
        {
            return Banco.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public Produto Selecionar(string nome)
        {
            return Banco.Produtos.FirstOrDefault(x => x.Nome == nome);
        }

        public void Alterar(Produto produto)
        {
            var produtoSalvar = Banco.ProdutosSimples.First(x => x.Id == produto.Id);
            produtoSalvar.Nome = produto.Nome;
            produtoSalvar.PrecoCusto = produto.PrecoCusto;
            produtoSalvar.PrecoVenda = produto.PrecoVenda;
            Banco.SaveChanges();
        }

        public void Alterar(ProdutoSimples produtoSimples)
        {
            var produtoSalvar = Banco.ProdutosSimples.First(x => x.Id == produtoSimples.Id);
            produtoSalvar.Nome = produtoSimples.Nome;
            produtoSalvar.PrecoCusto = produtoSimples.PrecoCusto;
            produtoSalvar.PrecoVenda = produtoSimples.PrecoVenda;
            produtoSalvar.Quantidade = produtoSimples.Quantidade;
            Banco.SaveChanges();
        }

        public void Alterar(ProdutoComposto produtoComposto)
        {
            var produtoSalvar = Banco.ProdutosCompostos.First(x => x.Id == produtoComposto.Id);
            produtoSalvar.Nome = produtoComposto.Nome;
            produtoSalvar.PrecoCusto = produtoComposto.PrecoCusto;
            produtoSalvar.PrecoVenda = produtoComposto.PrecoVenda;
            Banco.SaveChanges();
        }

        public void Excluir(Produto produto)
        {
            var produtoExcluir = Banco.Produtos.First(x => x.Id == produto.Id);
            Banco.Set<Produto>().Remove(produtoExcluir);
            Banco.SaveChanges();
        }
    }
}
