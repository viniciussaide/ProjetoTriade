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
            return Banco.Requisicao.First(x => x.Id == id);
        }

        public void Alterar(Requisicao requisicao)
        {
            var requisicaoSalvar = Banco.Requisicao.First(x => x.Id == requisicao.Id);
            requisicaoSalvar.Funcionario = requisicao.Funcionario;
            requisicaoSalvar.DataRequisicao = requisicao.DataRequisicao;
            requisicaoSalvar.ProdutosNasRequisicoes = requisicao.ProdutosNasRequisicoes;
            Banco.SaveChanges();
        }

        public void Excluir(Requisicao requisicao)
        {
            var requisicaoExcluir = Banco.Requisicao.First(x => x.Id == requisicao.Id);
            Banco.Set<Requisicao>().Remove(requisicaoExcluir);
            Banco.SaveChanges();
        }
    }
}
