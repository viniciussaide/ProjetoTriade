using Database;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class RequisicaoController
    {
        public DBtriade Banco { get; set; }

        public RequisicaoController()
        {
            Banco = new DBtriade();
        }

        public void Salvar(Requisicao requisicao)
        {
            Banco.Requisicao.Add(requisicao);
            Banco.SaveChanges();
        }

        public IEnumerable<Requisicao> Listar()
        {
            return Banco.Requisicao.ToList();
        }

        public Requisicao Selecionar(int id)
        {
            return Banco.Requisicao.Where(x => x.Id == id).First();
        }

        public void Alterar(Requisicao requisicao)
        {
            Requisicao requisicaoSalvar = Banco.Requisicao.Where(x => x.Id == requisicao.Id).First();
            requisicaoSalvar.Funcionario = requisicao.Funcionario;
            requisicaoSalvar.DataRequisicao = requisicao.DataRequisicao;
            requisicaoSalvar.ProdutosNasRequisicoes = requisicao.ProdutosNasRequisicoes;
            Banco.SaveChanges();
        }

        public void Excluir(Requisicao requisicao)
        {
            Requisicao requisicaoExcluir = Banco.Requisicao.Where(x => x.Id == requisicao.Id).First();
            Banco.Set<Requisicao>().Remove(requisicaoExcluir);
            Banco.SaveChanges();
        }
    }
}
