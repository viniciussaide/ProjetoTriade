using Controller;
using Model;
using System;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormCompositeProduct : Form
	{
        public Product Product { get; set; }
        //Formulário que controla o CRUD de produtos Composto
        public FormCompositeProduct(Product produto)
		{
			InitializeComponent();
			ProductsController produtosController = new ProductsController();

			listViewProdutosDaComposicao.Columns.Add("Produto");
			listViewProdutosDaComposicao.Columns.Add("Quantidade");
			listViewProdutosDaComposicao.View = View.Details;
			listViewProdutosDaComposicao.Columns[0].Width = 260;
			listViewProdutosDaComposicao.Columns[1].Width = 80;
            listViewProdutosDaComposicao.FullRowSelect = true;

            this.Product = produto;
            if (produto == null)
            {
                btnDelete.Visible = false;
            }
            else
            {
                txtProductName.Text = produto.Name;
                txtCostValue.Text = produto.CostValue.ToString();
                txtSellValue.Text = produto.SellValue.ToString();

                listViewProdutosDaComposicao.Items.Clear();
                decimal totalCusto = 0;
                //Lista todos os produtos simples relacionados com o produto composto selecionado e calcula o preço de custo total
                foreach (ProductComposition produtosDaComposicao in produto.Itens)
                {
                    string[] row = { produtosDaComposicao.Item.Name, produtosDaComposicao.Quantity.ToString() };
                    var item = new ListViewItem(row)
                    {
                        Tag = produtosDaComposicao.Item
                    };
                    listViewProdutosDaComposicao.Items.Add(item);
                    decimal valorCusto = produtosDaComposicao.Item.CostValue *
                                         produtosDaComposicao.Quantity;
                    totalCusto += valorCusto;
                }
                txtCostValue.Text = totalCusto.ToString();
            }
        }

		//Botão Salvar
		private void BtnSave_Click(object sender, EventArgs e)
		{
			//Product produtoComposto = new Product();
			ProductsController produtosController = new ProductsController();
			ProductCompositionController produtosDaComposicaoController = new ProductCompositionController();

			//Verifica caso queriam salvar com campos ainda vazios
			if (txtCostValue.Text != "" || txtSellValue.Text != "" || txtProductName.Text != "" || listViewProdutosDaComposicao.Items.Count > 0)
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
				//Verifica se o item selecionado existe na lista
				else if (Product != null)
				{
					//Exclui todos os relacionamentos antigos com produtos simples
					produtosDaComposicaoController.Remove(Product);

                    Product.Name = txtProductName.Text;
                    Product.CostValue = txtCost;
                    Product.SellValue = txtSell;
					produtosController.Update(Product);

					//Insere ou renova relacionamentos com todos os produtos simples da listagem
					for (int i = 0; i < listViewProdutosDaComposicao.Items.Count; i++)
					{
						ProductComposition produtosDaComposicao = new ProductComposition();
						Product produtoSimples = (Product)listViewProdutosDaComposicao.Items[i].Tag;

						produtosDaComposicao.ProductId = Product.Id;
						produtosDaComposicao.ItemId = produtoSimples.Id;
						produtosDaComposicao.Quantity =
							int.Parse(listViewProdutosDaComposicao.Items[i].SubItems[1].Text);

						produtosDaComposicaoController.Insert(produtosDaComposicao);
					}
					MessageBox.Show(@"Produto alterado com sucesso", @"Sucesso ao alterar",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
				else
				{
                    //Insere novo produto composto
                    Product produtoComposto = new Product()
                    {
                        Name = txtProductName.Text,
                        CostValue = txtCost,
                        SellValue = txtSell,
                        Type = ProductType.Composto
                    };
					produtosController.Insert(produtoComposto);

					//Insere relacionamentos com todos os produtos simples da listagem
					for (int i = 0; i < listViewProdutosDaComposicao.Items.Count; i++)
					{
						ProductComposition produtosDaComposicao = new ProductComposition();
						Product produtoSimples = (Product)listViewProdutosDaComposicao.Items[i].Tag;

						produtosDaComposicao.ProductId = produtoComposto.Id;
						produtosDaComposicao.ItemId = produtoSimples.Id;
						produtosDaComposicao.Quantity =
							int.Parse(listViewProdutosDaComposicao.Items[i].SubItems[1].Text);

						produtosDaComposicaoController.Insert(produtosDaComposicao);
					}
					MessageBox.Show(@"Novo produto salvo com sucesso!", @"Sucesso ao salvar",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
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
			ProductsController produtosController = new ProductsController();
			ProductCompositionController produtosDaComposicaoController = new ProductCompositionController();
			//Verifica se produto existe na lista
			if (Product != null)
			{
				//Exclui todos os produtos simples relacionados ao produto composto selecionado
				produtosDaComposicaoController.Remove(Product);

				//Exclui o produto composto
				produtosController.Remove(Product);
				MessageBox.Show(@"Produto excluído com sucesso", @"Sucesso ao excluir",
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
			else
			{
				MessageBox.Show(@"Produto selecionado não existe", @"Produto não existe",
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		//Botão Remover
		private void BtnRemoveProduct_Click(object sender, EventArgs e)
		{
		    Product produtoSimples = new Product();
			decimal totalCusto = 0;

			//Remove todos os produtos selecionados da listagem
			foreach (ListViewItem eachItem in listViewProdutosDaComposicao.SelectedItems)
			{
				listViewProdutosDaComposicao.Items.Remove(eachItem);
			}

			//Recalcula o preço de custo após remoção dos itens
			for (int i = 0; i < listViewProdutosDaComposicao.Items.Count; i++)
			{
				produtoSimples = (Product)listViewProdutosDaComposicao.Items[i].Tag;
				decimal valorCusto = produtoSimples.CostValue *
									 int.Parse(listViewProdutosDaComposicao.Items[i].SubItems[1].Text);
				totalCusto += valorCusto;
			}

			//Atualiza preço de custo
			if (totalCusto == 0)
			{
				txtCostValue.Text = "0,00";
			}
			else
			{
				txtCostValue.Text = totalCusto.ToString();
			}
		}

		//Botão Adicionar
		private void BtnAddProduct_Click(object sender, EventArgs e)
		{
			ProductsController produtosController = new ProductsController();
		    Product produtoSimples = new Product();

			//Abre um novo formulário para inserir novo produto simples na listagem
			//O mesmo retorna um id do produto selecionado e a quantidade contida do produto simples no produto composto
			using (var form = new FormAddProduct(produtosController.ListSimpleProducts()))
			{
				var result = form.ShowDialog();

				if (result == DialogResult.OK)
				{
					decimal totalCusto = 0;

					//Recupera dados do formulário
					int productId = form.ProductId;
					int quantity = form.Quantity;

					produtoSimples = produtosController.SelectSimpleProduct(productId);
					string[] row = { produtoSimples.Name, quantity.ToString() };

                    //Insere o produto na listagem
                    var item = new ListViewItem(row)
                    {
                        Tag = produtoSimples
                    };
                    foreach (ListViewItem listItem in listViewProdutosDaComposicao.Items)
                    {
                        Product produtoNaLista = (Product)listItem.Tag;
                        Product produtoAdicionado = (Product)item.Tag;
                        if (produtoNaLista.Id == produtoAdicionado.Id)
                        {
                            listViewProdutosDaComposicao.Items.Remove(listItem);
                        }
                    }
                    listViewProdutosDaComposicao.Items.Add(item);
                    listViewProdutosDaComposicao.Sorting = SortOrder.Ascending;
                    //Recalcula o preço de custo do produto composto
                    for (int i = 0; i < listViewProdutosDaComposicao.Items.Count; i++)
					{
						produtoSimples = (Product)listViewProdutosDaComposicao.Items[i].Tag;
						decimal valorCusto = produtoSimples.CostValue *
											 int.Parse(listViewProdutosDaComposicao.Items[i].SubItems[1].Text);
						totalCusto += valorCusto;
					}
					txtCostValue.Text = totalCusto.ToString();
				}
			}
		}
	}
}