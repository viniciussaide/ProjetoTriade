using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace UIForms
{
    public partial class FormRequisicao : Form
    {
        public FormRequisicao()
        {
            InitializeComponent();

            datePickerDataDaRequisicao.Format = DateTimePickerFormat.Custom;
            datePickerDataDaRequisicao.CustomFormat = "dd-MM-yyyy";

            listViewProdutosNaRequisicao.Columns.Add("Produto");
            listViewProdutosNaRequisicao.Columns.Add("Qtde");
            listViewProdutosNaRequisicao.Columns.Add("Preço Custo UN");
            listViewProdutosNaRequisicao.Columns.Add("Subtotal");
            listViewProdutosNaRequisicao.View = View.Details;
            listViewProdutosNaRequisicao.Columns[0].Width = 180;
            listViewProdutosNaRequisicao.Columns[1].Width = 40;
            listViewProdutosNaRequisicao.Columns[2].Width = 100;
            listViewProdutosNaRequisicao.Columns[3].Width = 80;
        }


        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            decimal totalCusto = 0;
            foreach (ListViewItem eachItem in listViewProdutosNaRequisicao.SelectedItems)
            {
                listViewProdutosNaRequisicao.Items.Remove(eachItem);
            }
            for (int i = 0; i < listViewProdutosNaRequisicao.Items.Count; i++)
            {
                produto = (Produto)listViewProdutosNaRequisicao.Items[i].Tag;
                decimal subtotal = produto.PrecoCusto *
                                   int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);
                totalCusto += subtotal;
            }
            if (totalCusto == 0)
            {
                txtCostValue.Text = "0,00";
            }
            else
            {
                txtCostValue.Text = totalCusto.ToString();
            }
            
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using (var form = new FormAddProductToRequest())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ProdutosController produtosController = new ProdutosController();
                    Produto produto = new Produto();
                    decimal totalCusto = 0;
                    int productId = form.productId;
                    int quantity = form.quantidade;

                    produto = produtosController.Selecionar(productId);
                    string subtotalProduto = (produto.PrecoCusto * quantity).ToString();
                    string[] row = { produto.Nome, quantity.ToString(), produto.PrecoCusto.ToString(), subtotalProduto };
                    var item = new ListViewItem(row);

                    item.Tag = produto;
                    listViewProdutosNaRequisicao.Items.Add(item);
                    for (int i = 0; i < listViewProdutosNaRequisicao.Items.Count; i++)
                    {
                        produto = (Produto)listViewProdutosNaRequisicao.Items[i].Tag;
                        decimal subtotal = produto.PrecoCusto *
                                             int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);
                        totalCusto += subtotal;
                    }
                    txtCostValue.Text = totalCusto.ToString();
                }
            }
        }

    }
}
