using Controller;
using Model;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormProdutos : Form
    {
        public FormProdutos()
        {
            InitializeComponent();

            listViewProdutos.Columns.Add("Produto");
            listViewProdutos.Columns.Add("Preço de Custo UN");
            listViewProdutos.Columns.Add("Preço de Venda UN");
            listViewProdutos.Columns.Add("Tipo do Produto");
            listViewProdutos.View = View.Details;
            listViewProdutos.Columns[0].Width = 200;
            listViewProdutos.Columns[1].Width = 130;
            listViewProdutos.Columns[2].Width = 130;
            listViewProdutos.Columns[3].Width = 100;
            listViewProdutos.FullRowSelect = true;

            AtualizarLista();
        }

        public void AtualizarLista()
        {
            ProdutosController produtosController = new ProdutosController();
            Product[] listaProdutos = produtosController.Listar();
            listViewProdutos.Items.Clear();
            foreach (Product produto in listaProdutos)
            {
                string[] row = { produto.Nome, "R$" + produto.PrecoCusto.ToString(), "R$" + produto.PrecoVenda.ToString(), produto.Tipo.ToString() };
                var item = new ListViewItem(row);
                item.Tag = produto;
                listViewProdutos.Items.Add(item);
            }
            listViewProdutos.Sorting = SortOrder.Ascending;
        }

        private void btnProdutoSimples_Click(object sender, System.EventArgs e)
        {
            using (var form = new FormProdutoSimples(null))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    AtualizarLista();
                }
            }
        }

        private void btnProdutoComposto_Click(object sender, System.EventArgs e)
        {
            using (var form = new FormProdutoComposto(null))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    AtualizarLista();
                }
            }
        }

        private void listViewProdutos_DoubleClick(object sender, System.EventArgs e)
        {
            if (listViewProdutos.SelectedItems[0].SubItems[0].Text != "")
            {
                if (listViewProdutos.SelectedItems[0].SubItems[3].Text == "Simples")
                {
                    using (var form = new FormProdutoSimples((Product)listViewProdutos.SelectedItems[0].Tag))
                    {
                        var result = form.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            AtualizarLista();
                        }
                    }
                }
                else if (listViewProdutos.SelectedItems[0].SubItems[3].Text == "Composto")
                {
                    using (var form = new FormProdutoComposto((Product)listViewProdutos.SelectedItems[0].Tag))
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
}
