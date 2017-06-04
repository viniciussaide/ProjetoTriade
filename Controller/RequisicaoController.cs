using System;
using Model;
using System.Data.Entity;
using System.Linq;

namespace Controller
{
    public class RequisicaoController
    {
        //Classe que controla o CRUD das requisições

        //Declaração da variavel banco que controla as tabelas
        public DBtriade Banco { get; set; }

        //Método Construtor
        public RequisicaoController()
        {
            Banco = new DBtriade();
        }

        //Inserir requisicao no banco
        public void Salvar(Request requisicao)
        {
            Banco.Requisicao.Add(requisicao);
            Banco.SaveChanges();
        }

        //Listar todas as requisições
        public Request[] Listar()
        {
            return Banco.Requisicao.Include(x => x.Produtos).ToArray();
        }

        //Seleciona uma requisição passando uma data e um funcionário
        public Request Selecionar(DateTime data, string funcionario)
        {
            return Banco.Requisicao.Where(r => r.Funcionario == funcionario).FirstOrDefault(r => r.DataRequisicao == data);
        }

        //Altera uma requisição pre-selecionada
        public void Alterar(Request requisicao)
        {
            Request requisicaoSalvar = Banco.Requisicao.FirstOrDefault(x => x.Id == requisicao.Id);
            requisicaoSalvar.Funcionario = requisicao.Funcionario;
            requisicaoSalvar.DataRequisicao = requisicao.DataRequisicao;
            Banco.SaveChanges();
        }

        //Exclui uma requisição
        public void Excluir(Request requisicao)
        {
            var requisicaoExcluir = Banco.Requisicao.First(x => x.Id == requisicao.Id);
            Banco.Set<Request>().Remove(requisicaoExcluir);
            Banco.SaveChanges();
        }
    }
}
