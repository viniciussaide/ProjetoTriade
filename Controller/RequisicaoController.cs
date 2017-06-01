using System;
using Database;
using Model;
using System.Collections.Generic;
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
        public void Salvar(Requisicao requisicao)
        {
            Banco.Requisicao.Add(requisicao);
            Banco.SaveChanges();
        }

        //Listar todas as requisições
        public IEnumerable<Requisicao> Listar()
        {
            return Banco.Requisicao.ToList();
        }

        //Seleciona uma requisição passando uma data e um funcionário
        public Requisicao Selecionar(DateTime data, string funcionario)
        {
            return Banco.Requisicao.Where(r => r.Funcionario == funcionario).FirstOrDefault(r => r.DataRequisicao == data);
        }

        //Altera uma requisição pre-selecionada
        public void Alterar(Requisicao requisicao)
        {
            var requisicaoSalvar = Banco.Requisicao.First(x => x.Id == requisicao.Id);
            requisicaoSalvar.Funcionario = requisicao.Funcionario;
            requisicaoSalvar.DataRequisicao = requisicao.DataRequisicao;
            requisicaoSalvar.ProdutosNasRequisicoes = requisicao.ProdutosNasRequisicoes;
            Banco.SaveChanges();
        }

        //Exclui uma requisição
        public void Excluir(Requisicao requisicao)
        {
            var requisicaoExcluir = Banco.Requisicao.First(x => x.Id == requisicao.Id);
            Banco.Set<Requisicao>().Remove(requisicaoExcluir);
            Banco.SaveChanges();
        }
    }
}
