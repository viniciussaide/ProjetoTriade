using Controller;
using Model;
using System;
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

            UpdateList();
        }

        public void UpdateList()
        {
            RequestController RequestController = new RequestController();
            Request[] Requests = RequestController.List();
            listViewRequisicoes.Items.Clear();
            foreach (Request Request in Requests)
            {
                string[] row = { String.Format("{0:dd/MM/yyyy}", Request.RequestDate), Request.Worker, Request.Products.Count.ToString() };
                var item = new ListViewItem(row)
                {
                    Tag = Request
                };
                listViewRequisicoes.Items.Add(item);
            }
        }
        private void BtnRequisicao_Click(object sender, EventArgs e)
        {
            using (var form = new FormRequest(null))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    UpdateList();
                }
            }
        }

        private void ListViewRequisicoes_DoubleClick(object sender, EventArgs e)
        {
            if (listViewRequisicoes.SelectedItems[0].SubItems[0].Text != "")
            {
                using (var form = new FormRequest((Request)listViewRequisicoes.SelectedItems[0].Tag))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        UpdateList();
                    }
                }
            }
        }
    }
}
