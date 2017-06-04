using System;
using Model;
using System.Data.Entity;
using System.Linq;

namespace Controller
{
    public class RequestController
    {
        //Classe que controla o CRUD das requisições

        //Declaração da variavel banco que controla as tabelas
        public DBtriade DBtriade { get; set; }

        //Método Construtor
        public RequestController()
        {
            DBtriade = new DBtriade();
        }

        //Inserir requisicao no banco
        public void Insert(Request Request)
        {
            DBtriade.Requisicao.Add(Request);
            DBtriade.SaveChanges();
        }

        //Listar todas as requisições
        public Request[] List()
        {
            return DBtriade.Requisicao.Include(x => x.Products).ToArray();
        }

        //Seleciona uma requisição passando uma data e um funcionário
        public Request Select(DateTime requestDate, string worker)
        {
            return DBtriade.Requisicao.Where(r => r.Worker == worker).FirstOrDefault(r => r.RequestDate == requestDate);
        }

        //Altera uma requisição pre-selecionada
        public void Update(Request Request)
        {
            Request requisicaoSalvar = DBtriade.Requisicao.FirstOrDefault(x => x.Id == Request.Id);
            requisicaoSalvar.Worker = Request.Worker;
            requisicaoSalvar.RequestDate = Request.RequestDate;
            DBtriade.SaveChanges();
        }

        //Exclui uma requisição
        public void Remove(Request Request)
        {
            var requisicaoExcluir = DBtriade.Requisicao.First(x => x.Id == Request.Id);
            DBtriade.Set<Request>().Remove(requisicaoExcluir);
            DBtriade.SaveChanges();
        }
    }
}
