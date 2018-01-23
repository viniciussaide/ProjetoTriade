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
            DBtriade.Request.Add(Request);
            DBtriade.SaveChanges();
        }

        //Listar todas as requisições
        public Request[] List()
        {
            return DBtriade.Request.Include(x => x.Products).ToArray();
        }

        //Seleciona uma requisição passando uma data e um funcionário
        public Request Select(DateTime requestDate, string worker)
        {
            return DBtriade.Request.Where(r => r.Worker == worker).FirstOrDefault(r => r.RequestDate == requestDate);
        }

        //Seleciona uma lista de requisições de um período requisitado
        public Request[] Select(DateTime startDate, DateTime endDate)
        {
            return DBtriade.Request.Where(r =>r.RequestDate >= startDate).Where(r => r.RequestDate <= endDate).ToArray();
        }

        //Altera uma requisição pre-selecionada
        public void Update(Request Request)
        {
            Request requisicaoSalvar = DBtriade.Request.FirstOrDefault(x => x.Id == Request.Id);
            requisicaoSalvar.Worker = Request.Worker;
            requisicaoSalvar.RequestDate = Request.RequestDate;
            DBtriade.SaveChanges();
        }

        //Exclui uma requisição
        public void Remove(Request Request)
        {
            var requisicaoExcluir = DBtriade.Request.First(x => x.Id == Request.Id);
            DBtriade.Set<Request>().Remove(requisicaoExcluir);
            DBtriade.SaveChanges();
        }
    }
}
