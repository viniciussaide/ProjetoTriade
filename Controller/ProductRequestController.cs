using Model;
using System.Linq;

namespace Controller
{
    public class ProductRequestController
    {
        //Classe que controla o CRUD dos produtos contidos em requisições

        //Declaração da variavel banco que controla as tabelas
        public DBtriade DBtriade { get; set; }

        //Método Contrutor
        public ProductRequestController()
        {
            DBtriade = new DBtriade();
        }

        //Insere um produto contido em uma requisição
        public void Insert(ProductRequest ProductRequest)
        {
            DBtriade.ProductRequest.Add(ProductRequest);
            DBtriade.SaveChanges();
        }

        //Lista todos os produtos contidos em todas as requisições
        public ProductRequest[] List()
        {
            return DBtriade.ProductRequest.ToArray();
        }

        //Altera um produto contido na requisição pre-selecionado
        public void Update(ProductRequest ProductRequest)
        {
            var produtoNasRequisicoesSalvar =
                DBtriade.ProductRequest
                .Where(x => x.RequestId == ProductRequest.RequestId)
                .First(x => x.ProductId == ProductRequest.ProductId);
            produtoNasRequisicoesSalvar.Quantity = ProductRequest.Quantity;
            DBtriade.SaveChanges();
        }

        //Exclui todos os produtos contidos em uma requisição
        public void Remove(Request Request)
        {
            var count = DBtriade.ProductRequest.Count(x => x.RequestId == Request.Id);
            if (count > 0)
            {
                var produtosNaRequisicao =
                    DBtriade.ProductRequest.Where(x => x.RequestId == Request.Id);
                DBtriade.ProductRequest.RemoveRange(produtosNaRequisicao);
                DBtriade.SaveChanges();
            }
        }
    }
}
