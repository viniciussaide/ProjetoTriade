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

            UpdateList();
        }

        public void UpdateList()
        {
            ProductsController produtosController = new ProductsController();
            Product[] listaProdutos = produtosController.List();
            listViewProdutos.Items.Clear();
            foreach (Product produto in listaProdutos)
            {
                string[] row = { produto.Name, "R$" + produto.CostValue.ToString(), "R$" + produto.SellValue.ToString(), produto.Type.ToString() };
                var item = new ListViewItem(row)
                {
                    Tag = produto
                };
                listViewProdutos.Items.Add(item);
            }
            listViewProdutos.Sorting = SortOrder.Ascending;
        }

        private void BtnProdutoSimples_Click(object sender, System.EventArgs e)
        {
            using (var form = new FormSimpleProducts(null))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    UpdateList();
                }
            }
        }

        private void BtnProdutoComposto_Click(object sender, System.EventArgs e)
        {
            using (var form = new FormCompositeProduct(null))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    UpdateList();
                }
            }
        }

        private void ListViewProdutos_DoubleClick(object sender, System.EventArgs e)
        {
            if (listViewProdutos.SelectedItems[0].SubItems[0].Text != "")
            {
                if (listViewProdutos.SelectedItems[0].SubItems[3].Text == "Simples")
                {
                    using (var form = new FormSimpleProducts((Product)listViewProdutos.SelectedItems[0].Tag))
                    {
                        var result = form.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            UpdateList();
                        }
                    }
                }
                else if (listViewProdutos.SelectedItems[0].SubItems[3].Text == "Composto")
                {
                    using (var form = new FormCompositeProduct((Product)listViewProdutos.SelectedItems[0].Tag))
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
}
