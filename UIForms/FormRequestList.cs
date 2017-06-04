using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormRequestList : Form
    {
        public FormRequestList()
        {
            InitializeComponent();

            listViewRequisicoes.Columns.Add("Data da Requisição");
            listViewRequisicoes.Columns.Add("Funcionário");
            listViewRequisicoes.Columns.Add("Quantidade de Produtos");
            listViewRequisicoes.View = View.Details;
            listViewRequisicoes.Columns[0].Width = 150;
            listViewRequisicoes.Columns[1].Width = 200;
            listViewRequisicoes.Columns[2].Width = 150;
            listViewRequisicoes.FullRowSelect = true;

            AtualizarLista();
        }

        public void AtualizarLista()
        {
            RequisicaoController requisicaoController = new RequisicaoController();
            Request[] listaRequisicoes = requisicaoController.Listar();
            listViewRequisicoes.Items.Clear();
            foreach (Request requisicao in listaRequisicoes)
            {
                string[] row = { String.Format("{0:dd/MM/yyyy}", requisicao.DataRequisicao), requisicao.Funcionario, requisicao.Produtos.Count.ToString() };
                var item = new ListViewItem(row);
                item.Tag = requisicao;
                listViewRequisicoes.Items.Add(item);
            }
        }
        private void btnRequisicao_Click(object sender, EventArgs e)
        {
            using (var form = new FormRequisicao(null))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    AtualizarLista();
                }
            }
        }

        private void listViewRequisicoes_DoubleClick(object sender, EventArgs e)
        {
            if (listViewRequisicoes.SelectedItems[0].SubItems[0].Text != "")
            {
                using (var form = new FormRequisicao((Request)listViewRequisicoes.SelectedItems[0].Tag))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        AtualizarLista();
                    }
                }
            }
        }
    }
}
