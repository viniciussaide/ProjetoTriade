using Controller;
using Model;
using System;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormProdutoSimples : Form
    {
        public Product produto { get; set; }
        //Formulário que controla o CRUD de produtos simples
        public FormProdutoSimples(Product produto)
        {
            InitializeComponent();
            this.produto = produto;
            if (produto == null)
            {
                btnDelete.Visible = false;
            }
            else
            {
                txtProductName.Text = produto.Nome;
                txtCostValue.Text = produto.PrecoCusto.ToString();
                txtSellValue.Text = produto.PrecoVenda.ToString();
            }
        }

        //Botão Salvar
        private void BtnSave_Click(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            //Ignorar inserção, alteração e exclusão cado campos estejam vazios
            if (txtCostValue.Text !="" || txtSellValue.Text != "" || txtProductName.Text !="")
            {
                //Condição que determina se produto já existia ou será criado um novo produto
                if (produto != null)
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
                        produto.Nome = txtProductName.Text;
                        produto.PrecoCusto = txtCost;
                        produto.PrecoVenda = txtSell;
                        produtosController.Alterar(produto);
                        MessageBox.Show(@"Produto alterado com sucesso", @"Sucesso ao alterar",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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
                        Product produtoSimples = new Product()
                        {
                            Nome = txtProductName.Text,
                            PrecoCusto = txtCost,
                            PrecoVenda = txtSell,
                            Tipo = TipoProduto.Simples
                        };
                        produtosController.Salvar(produtoSimples);
                        MessageBox.Show(@"Novo produto salvo com sucesso!", @"Sucesso ao salvar",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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
            //Verificação se o produto selecionado existe no banco
            if (produto != null)
            {
                ProdutosDaComposicaoController produtosDaComposicaoController =
                    new ProdutosDaComposicaoController();
                int totalRelacionamentos = produtosDaComposicaoController.TotalRelacionamentosProdutoSimples(produto.Id);

                //Verificação caso queira excluir um produto simples que tem relacionamentos com produtos compostos
                if (totalRelacionamentos > 0)
                {
                    MessageBox.Show(@"Existem "+ totalRelacionamentos + @" produtos compostos que contém o produto. Exclua estes relacionamentos antes de excluir o produto",
                        @"Produto contido em Composições",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    //Exclusão do produto
                    Product produtoSimples = produtosController.SelecionarProdutosSimples(produto.Id);
                    produtosController.Excluir(produtoSimples);
                    MessageBox.Show(@"Produto excluído com sucesso", @"Sucesso ao excluir",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(@"Produto selecionado não existe", @"Produto não existe",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
