using Model;
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
		public void Salvar(Product product)
		{
			Banco.Produtos.Add(product);
			Banco.SaveChanges();
		}

		//Listar todos os produtos independente se este é simples ou composto
		public Product[] Listar()
		{
			return Banco.Produtos.ToArray();
		}

		//Lista todos os produtos compostos
		public Product[] ListarProdutosCompostos()
		{
			return Banco.Produtos.Where(x => x.Tipo == TipoProduto.Composto).ToArray();
		}

		//Lista todos os produtos simples
		public Product[] ListarProdutosSimples()
		{
		    return Banco.Produtos.Where(x => x.Tipo == TipoProduto.Simples).ToArray();
        }

		//Seleciona um produto (simples ou composto) usando seu id
		public Product Selecionar(int id)
		{
			return Banco.Produtos.FirstOrDefault(x => x.Id == id);
		}

		//Seleciona um produto (simples ou composto) usando seu nome
		public Product Selecionar(string nome)
		{
			return Banco.Produtos.FirstOrDefault(x => x.Nome == nome);
		}

		//Seleciona um produto simples usando seu id
		public Product SelecionarProdutosSimples(int id)
		{
			return Banco.Produtos.Where(x => x.Tipo == TipoProduto.Simples).FirstOrDefault(x => x.Id == id);
		}

		//Seleciona um produto  composto usando seu id
		public Product SelecionarProdutosCompostos(int id)
		{
			return Banco.Produtos.Where(x => x.Tipo == TipoProduto.Composto).FirstOrDefault(x => x.Id == id);
		}

		//Altera um produto (simples ou composto) que foi pre-selecionado
		public void Alterar(Product produto)
		{
			var produtoSalvar = Banco.Produtos.First(x => x.Id == produto.Id);
			produtoSalvar.Nome = produto.Nome;
			produtoSalvar.PrecoCusto = produto.PrecoCusto;
			produtoSalvar.PrecoVenda = produto.PrecoVenda;
			Banco.SaveChanges();
		}

		//Exclui um produto (simples ou composto) que foi pre-selecionado
		public void Excluir(Product produto)
		{
			var produtoExcluir = Banco.Produtos.Where(x => x.Id == produto.Id);
			Banco.Produtos.RemoveRange(produtoExcluir);
			Banco.SaveChanges();
		}
	}
}