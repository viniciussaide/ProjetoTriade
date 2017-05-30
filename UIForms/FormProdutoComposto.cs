using Controller;
using Database;
using Model;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Configuration;

namespace UIForms
{
    public partial class FormProdutoComposto : Form
    {
        public FormProdutoComposto()
        {
            InitializeComponent();
            ProdutosController produtosController = new ProdutosController();
            comboBoxProductName.DataSource = produtosController.ListarProdutosCompostos();
            comboBoxProductName.DisplayMember = "Nome";
            comboBoxProductName.ValueMember = "Id";
            comboBoxProductName.SelectedIndex = -1;
            listViewProdutosDaComposicao.Columns.Add("Produto");
            listViewProdutosDaComposicao.Columns.Add("Quantidade");
            listViewProdutosDaComposicao.View = View.Details;
            listViewProdutosDaComposicao.Columns[0].Width = 260;
            listViewProdutosDaComposicao.Columns[1].Width = 80;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            if (txtCostValue.Text != "" || txtSellValue.Text != "" || comboBoxProductName.Text != "")
            {
                if (int.TryParse(comboBoxProductName.SelectedValue.ToString(), out int id))
                {
                    if (produtosController.Selecionar(id) != null)
                    {
                        if (!decimal.TryParse(txtCostValue.Text, out decimal txtCost))
                        {
                            MessageBox.Show(@"Valor de custo digitado não é válido", @"Valor incorreto",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else if (!decimal.TryParse(txtSellValue.Text, out decimal txtSell))
                        {
                            MessageBox.Show(@"Valor de venda digitado não é válido", @"Valor incorreto",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            ProdutoComposto produtoComposto = produtosController.SelecionarProdutosCompostos(id);
                            produtoComposto.PrecoCusto = txtCost;
                            produtoComposto.PrecoVenda = txtSell;
                            produtosController.Alterar(produtoComposto);
                            MessageBox.Show(@"Produto alterado com sucesso", @"Sucesso ao alterar",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            comboBoxProductName.DataSource = produtosController.ListarProdutosCompostos();
                            comboBoxProductName.SelectedItem = produtoComposto;
                        }

                    }
                    else
                    {
                        if (!decimal.TryParse(txtCostValue.Text, out decimal txtCost))
                        {
                            MessageBox.Show(@"Valor de custo digitado não é válido", @"Valor incorreto",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else if (!decimal.TryParse(txtSellValue.Text, out decimal txtSell))
                        {
                            MessageBox.Show(@"Valor de venda digitado não é válido", @"Valor incorreto",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            ProdutoComposto produtoComposto = new ProdutoComposto()
                            {
                                Nome = comboBoxProductName.Text,
                                PrecoCusto = txtCost,
                                PrecoVenda = txtSell
                            };
                            produtosController.Salvar(produtoComposto);
                            MessageBox.Show(@"Novo produto salvo com sucesso!", @"Sucesso ao salvar",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            comboBoxProductName.DataSource = produtosController.ListarProdutosCompostos();
                            comboBoxProductName.SelectedItem = produtoComposto;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Existem campos vazios, por favor preencha todos os campos", @"Campos vazios",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            ProdutosDaComposicaoController produtosDaComposicaoController = new ProdutosDaComposicaoController();
            if (comboBoxProductName.SelectedIndex != -1)
            {
                int.TryParse(comboBoxProductName.SelectedValue.ToString(), out int id);
                if (produtosController.Selecionar(id) != null)
                {
                    Produto produto = produtosController.Selecionar(id);
                    produtosDaComposicaoController.Excluir(produto);
                    produtosController.Excluir(produto);
                    MessageBox.Show(@"Produto excluído com sucesso", @"Sucesso ao excluir",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    comboBoxProductName.DataSource = produtosController.ListarProdutosCompostos();
                    comboBoxProductName.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show(@"Produto selecionado não existe", @"Produto não existe",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show(@"Selecione um produto antes de excluir", @"Produto não selecionado",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void ComboBoxProductName_TextChanged(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            if (comboBoxProductName.SelectedItem != null)
            {
                int.TryParse(comboBoxProductName.SelectedValue.ToString(), out int id);
                Produto produto = produtosController.Selecionar(id);
                if (produto != null)
                {
                    txtCostValue.Text = produto.PrecoCusto.ToString();
                    txtSellValue.Text = produto.PrecoVenda.ToString();
                }
                else
                {
                    txtCostValue.Text = "0,00";
                    txtSellValue.Text = "0,00";
                }
            }
            else
            {
                txtCostValue.Text = "0,00";
                txtSellValue.Text = "0,00";
            }
        }
    }
}