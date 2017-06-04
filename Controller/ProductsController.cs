using Model;
using System.Linq;

namespace Controller
{
    public class ProductsController
	{
		//Classe que controla o CRUD de produtos (simples ou compostos)

		//Declaração da variavel banco que controla as tabelas
		public DBtriade DBtriade { get; set; }

		//Método Construtor
		public ProductsController()
		{
			DBtriade = new DBtriade();
		}

		//Inserir produto simples no banco
		public void Insert(Product product)
		{
			DBtriade.Product.Add(product);
			DBtriade.SaveChanges();
		}

		//Listar todos os produtos independente se este é simples ou composto
		public Product[] List()
		{
			return DBtriade.Product.OrderBy(x => x.Name).ToArray();
		}

		//Lista todos os produtos compostos
		public Product[] ListCompositeProducts()
		{
			return DBtriade.Product.Where(x => x.Type == ProductType.Composto).ToArray();
		}

		//Lista todos os produtos simples
		public Product[] ListSimpleProducts()
		{
		    return DBtriade.Product.Where(x => x.Type == ProductType.Simples).ToArray();
        }

		//Seleciona um produto (simples ou composto) usando seu id
		public Product Select(int id)
		{
			return DBtriade.Product.FirstOrDefault(x => x.Id == id);
		}

		//Seleciona um produto (simples ou composto) usando seu nome
		public Product Select(string name)
		{
			return DBtriade.Product.FirstOrDefault(x => x.Name == name);
		}

		//Seleciona um produto simples usando seu id
		public Product SelectSimpleProduct(int id)
		{
			return DBtriade.Product.Where(x => x.Type == ProductType.Simples).FirstOrDefault(x => x.Id == id);
		}

		//Seleciona um produto  composto usando seu id
		public Product SelectCompositeProduct(int id)
		{
			return DBtriade.Product.Where(x => x.Type == ProductType.Composto).FirstOrDefault(x => x.Id == id);
		}

		//Altera um produto (simples ou composto) que foi pre-selecionado
		public void Update(Product product)
		{
			var produtoSalvar = DBtriade.Product.First(x => x.Id == product.Id);
			produtoSalvar.Name = product.Name;
			produtoSalvar.CostValue = product.CostValue;
			produtoSalvar.SellValue = product.SellValue;
			DBtriade.SaveChanges();
		}

		//Exclui um produto (simples ou composto) que foi pre-selecionado
		public void Remove(Product product)
		{
			var produtoExcluir = DBtriade.Product.Where(x => x.Id == product.Id);
			DBtriade.Product.RemoveRange(produtoExcluir);
			DBtriade.SaveChanges();
		}
	}
}