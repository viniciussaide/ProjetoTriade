using Controller;
using Model;
using System;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormSimpleProducts : Form
    {
        public Product Product { get; set; }
        //Formulário que controla o CRUD de produtos simples
        public FormSimpleProducts(Product Product)
        {
            InitializeComponent();
            this.Product = Product;
            if (Product == null)
            {
                btnDelete.Visible = false;
            }
            else
            {
                txtProductName.Text = Product.Name;
                txtCostValue.Text = Product.CostValue.ToString();
                txtSellValue.Text = Product.SellValue.ToString();
            }
        }

        //Botão Salvar
        private void BtnSave_Click(object sender, EventArgs e)
        {
            ProductsController ProductsController = new ProductsController();
            //Ignorar inserção, alteração e exclusão cado campos estejam vazios
            if (txtCostValue.Text !="" || txtSellValue.Text != "" || txtProductName.Text !="")
            {
                //Condição que determina se produto já existia ou será criado um novo produto
                if (Product != null)
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
                        Product.Name = txtProductName.Text;
                        Product.CostValue = txtCost;
                        Product.SellValue = txtSell;
                        ProductsController.Update(Product);
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
                        Product simpleProduct = new Product()
                        {
                            Name = txtProductName.Text,
                            CostValue = txtCost,
                            SellValue = txtSell,
                            Type = ProductType.Simples
                        };
                        ProductsController.Insert(simpleProduct);
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
            ProductsController ProductsController = new ProductsController();
            //Verificação se o produto selecionado existe no banco
            if (Product != null)
            {
                ProductCompositionController ProductCompositionController =
                    new ProductCompositionController();
                int countComposition = ProductCompositionController.CountProductOnComposition(Product.Id);

                //Verificação caso queira excluir um produto simples que tem relacionamentos com produtos compostos
                if (countComposition > 0)
                {
                    MessageBox.Show(@"Existem "+ countComposition + @" produtos compostos que contém o produto. Exclua estes relacionamentos antes de excluir o produto",
                        @"Produto contido em Composições",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    //Exclusão do produto
                    Product simpleProduct = ProductsController.SelectSimpleProduct(Product.Id);
                    ProductsController.Remove(simpleProduct);
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
