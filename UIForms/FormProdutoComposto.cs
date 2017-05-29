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
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            if (txtCostValue.Text != "" || txtSellValue.Text != "" || comboBoxProductName.Text != "")
            {
                if (produtosController.Selecionar(comboBoxProductName.Text) != null)
                {
                    if (!decimal.TryParse(txtCostValue.Text, out decimal txtCost))
                    {
                        MessageBox.Show("Valor de custo digitado não é válido", "Valor incorreto",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (!decimal.TryParse(txtSellValue.Text, out decimal txtSell))
                    {
                        MessageBox.Show("Valor de venda digitado não é válido", "Valor incorreto",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        ProdutoComposto produtoComposto = produtosController.SelecionarProdutosCompostos(comboBoxProductName.Text);
                        produtoComposto.PrecoCusto = txtCost;
                        produtoComposto.PrecoVenda = txtSell;
                        produtosController.Alterar(produtoComposto);
                        MessageBox.Show("Produto alterado com sucesso", "Sucesso ao alterar",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        comboBoxProductName.DataSource = produtosController.ListarProdutosCompostos();
                        comboBoxProductName.SelectedItem = produtoComposto;
                    }

                }
                else
                {
                    if (!decimal.TryParse(txtCostValue.Text, out decimal txtCost))
                    {
                        MessageBox.Show("Valor de custo digitado não é válido", "Valor incorreto",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (!decimal.TryParse(txtSellValue.Text, out decimal txtSell))
                    {
                        MessageBox.Show("Valor de venda digitado não é válido", "Valor incorreto",
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
                        MessageBox.Show("Novo produto salvo com sucesso!", "Sucesso ao salvar",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        comboBoxProductName.DataSource = produtosController.ListarProdutosCompostos();
                        comboBoxProductName.SelectedItem = produtoComposto;
                    }
                }

            }
            else
            {
                MessageBox.Show("Existem campos vazios, por favor preencha todos os campos", "Campos vazios",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            if (comboBoxProductName.Text != "")
            {
                if (produtosController.Selecionar(comboBoxProductName.Text) != null)
                {
                    Produto produto = produtosController.Selecionar(comboBoxProductName.Text);
                    produtosController.Excluir(produto);
                    MessageBox.Show("Produto excluído com sucesso", "Sucesso ao excluir",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    comboBoxProductName.DataSource = produtosController.ListarProdutosCompostos();
                    comboBoxProductName.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Produto selecionado não existe", "Produto não existe",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto antes de excluir", "Produto não selecionado",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void ComboBoxProductName_TextChanged(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            if (produtosController.SelecionarProdutosCompostos(comboBoxProductName.Text) != null)
            {
                Produto produto = produtosController.Selecionar(comboBoxProductName.Text);
                txtCostValue.Text = produto.PrecoCusto.ToString();
                txtSellValue.Text = produto.PrecoVenda.ToString();
            }
            else
            {
                txtCostValue.Text = "";
                txtSellValue.Text = "";
            }
        }
    }
}
