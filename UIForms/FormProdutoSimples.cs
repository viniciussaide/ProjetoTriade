using Controller;
using Model;
using System;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormProdutoSimples : Form
    {
        public FormProdutoSimples()
        {
            InitializeComponent();
            ProdutosController produtosController = new ProdutosController();
            comboBoxProductName.DataSource = produtosController.ListarProdutosSimples();
            comboBoxProductName.DisplayMember = "Nome";
            comboBoxProductName.ValueMember = "Id";
            comboBoxProductName.SelectedIndex = -1;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            //int id = int.Parse(comboBoxProductName.SelectedValue.ToString());
            if (txtCostValue.Text !="" || txtSellValue.Text != "" || comboBoxProductName.Text !="")
            {
                if (comboBoxProductName.SelectedItem != null)
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
                                ProdutoSimples produtoSimples = produtosController.SelecionarProdutosSimples(id);
                                produtoSimples.PrecoCusto = txtCost;
                                produtoSimples.PrecoVenda = txtSell;
                                produtosController.Alterar(produtoSimples);
                                MessageBox.Show(@"Produto alterado com sucesso", @"Sucesso ao alterar",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                comboBoxProductName.DataSource = produtosController.ListarProdutosSimples();
                                comboBoxProductName.SelectedItem = produtoSimples;
                            }

                        }
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
                        ProdutoSimples produtoSimples = new ProdutoSimples()
                        {
                            Nome = comboBoxProductName.Text,
                            PrecoCusto = txtCost,
                            PrecoVenda = txtSell
                        };
                        produtosController.Salvar(produtoSimples);
                        MessageBox.Show(@"Novo produto salvo com sucesso!", @"Sucesso ao salvar",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        comboBoxProductName.DataSource = produtosController.ListarProdutosSimples();
                        comboBoxProductName.SelectedItem = produtoSimples;
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
            int id = int.Parse(comboBoxProductName.SelectedValue.ToString());
            if (comboBoxProductName.Text != "")
            {
                if (produtosController.Selecionar(id) != null)
                {
                    ProdutosDaComposicaoController produtosDaComposicaoController =
                        new ProdutosDaComposicaoController();
                    int totalRelacionamentos = produtosDaComposicaoController.TotalRelacionamentosProdutoSimples(id);
                    if (totalRelacionamentos > 0)
                    {
                        MessageBox.Show(@"Existem "+ totalRelacionamentos + @" produtos compostos que contém o produto. Exclua estes relacionamentos antes de excluir o produto",
                            @"Produto contido em Composições",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        ProdutoSimples produtoSimples = produtosController.SelecionarProdutosSimples(id);
                        produtosController.Excluir(produtoSimples);
                        MessageBox.Show(@"Produto excluído com sucesso", @"Sucesso ao excluir",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        comboBoxProductName.DataSource = produtosController.ListarProdutosSimples();
                        comboBoxProductName.SelectedItem = -1;
                    }
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
                ProdutoSimples produtoSimples = produtosController.SelecionarProdutosSimples(id);
                if (produtoSimples != null)
                {
                    txtCostValue.Text = produtoSimples.PrecoCusto.ToString();
                    txtSellValue.Text = produtoSimples.PrecoVenda.ToString();
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
