using Controller;
using Model;
using System;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormProdutoSimples : Form
    {
        //Formulário que controla o CRUD de produtos simples
        public FormProdutoSimples()
        {
            InitializeComponent();
            ProdutosController produtosController = new ProdutosController();
            comboBoxProductName.DataSource = produtosController.ListarProdutosSimples();
            comboBoxProductName.DisplayMember = "Nome";
            comboBoxProductName.ValueMember = "Id";
            comboBoxProductName.SelectedIndex = -1;
        }

        //Botão Salvar
        private void BtnSave_Click(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();

            //Ignorar inserção, alteração e exclusão cado campos estejam vazios
            if (txtCostValue.Text !="" || txtSellValue.Text != "" || comboBoxProductName.Text !="")
            {
                //Condição que determina se produto já existia ou será criado um novo produto
                if (comboBoxProductName.SelectedItem != null)
                {
                    //Conversão id de um produto selecionado em (int)
                    if (int.TryParse(comboBoxProductName.SelectedValue.ToString(), out int id))
                    {
                        //Verificação se produto realmente existe no banco
                        if (produtosController.Selecionar(id) != null)
                        {
                            //Conversão de texto para decimal dos preços de custo e de venda
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
                                //Atualização de um produto existente
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
                    //Conversão de texto para decimal dos preços de custo e de venda
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
                        //Inserção de um novo produto no banco
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

        //Botão Excluir
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            int id = int.Parse(comboBoxProductName.SelectedValue.ToString());
            //Condição caso queiram excluir um produto antes de selecionar o nome do mesmo
            if (comboBoxProductName.Text != "")
            {
                //Verificação se o produto selecionado existe no banco
                if (produtosController.Selecionar(id) != null)
                {
                    ProdutosDaComposicaoController produtosDaComposicaoController =
                        new ProdutosDaComposicaoController();
                    int totalRelacionamentos = produtosDaComposicaoController.TotalRelacionamentosProdutoSimples(id);

                    //Verificação caso queira excluir um produto simples que tem relacionamentos com produtos compostos
                    if (totalRelacionamentos > 0)
                    {
                        MessageBox.Show(@"Existem "+ totalRelacionamentos + @" produtos compostos que contém o produto. Exclua estes relacionamentos antes de excluir o produto",
                            @"Produto contido em Composições",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        //Exclusão do produto
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

        //Combobox para seleção ou inserção do nome de um produto
        private void ComboBoxProductName_TextChanged(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            //Verifica se produto existe na lista
            if (comboBoxProductName.SelectedItem != null)
            {
                int.TryParse(comboBoxProductName.SelectedValue.ToString(), out int id);
                ProdutoSimples produtoSimples = produtosController.SelecionarProdutosSimples(id);
                //Verifica se produto existe no banco
                if (produtoSimples != null)
                {
                    //Caso exista preencha o preço de custo e preço de venda atual
                    txtCostValue.Text = produtoSimples.PrecoCusto.ToString();
                    txtSellValue.Text = produtoSimples.PrecoVenda.ToString();
                }
                else
                {
                    //Se não existir zerar os preços
                    txtCostValue.Text = "0,00";
                    txtSellValue.Text = "0,00";
                }
            }
            else
            {
                //Se não existir zerar os preços
                txtCostValue.Text = "0,00";
                txtSellValue.Text = "0,00";
            }
        }
    }
}
