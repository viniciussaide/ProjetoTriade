using Controller;
using Model;
using System;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormProdutoComposto : Form
	{
        public Product produto { get; set; }
        //Formulário que controla o CRUD de produtos Composto
        public FormProdutoComposto(Product produto)
		{
			InitializeComponent();
			ProdutosController produtosController = new ProdutosController();

			listViewProdutosDaComposicao.Columns.Add("Produto");
			listViewProdutosDaComposicao.Columns.Add("Quantidade");
			listViewProdutosDaComposicao.View = View.Details;
			listViewProdutosDaComposicao.Columns[0].Width = 260;
			listViewProdutosDaComposicao.Columns[1].Width = 80;
            listViewProdutosDaComposicao.FullRowSelect = true;

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

                listViewProdutosDaComposicao.Items.Clear();
                decimal totalCusto = 0;
                //Lista todos os produtos simples relacionados com o produto composto selecionado e calcula o preço de custo total
                foreach (ProductComposition produtosDaComposicao in produto.Itens)
                {
                    string[] row = { produtosDaComposicao.Item.Nome, produtosDaComposicao.Quantidade.ToString() };
                    var item = new ListViewItem(row);
                    item.Tag = produtosDaComposicao.Item;
                    listViewProdutosDaComposicao.Items.Add(item);
                    decimal valorCusto = produtosDaComposicao.Item.PrecoCusto *
                                         produtosDaComposicao.Quantidade;
                    totalCusto += valorCusto;
                }
                txtCostValue.Text = totalCusto.ToString();
            }
        }

		//Botão Salvar
		private void BtnSave_Click(object sender, EventArgs e)
		{
			//Product produtoComposto = new Product();
			ProdutosController produtosController = new ProdutosController();
			ProdutosDaComposicaoController produtosDaComposicaoController = new ProdutosDaComposicaoController();

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
				else if (produto != null)
				{
					//Exclui todos os relacionamentos antigos com produtos simples
					produtosDaComposicaoController.Excluir(produto);

                    produto.Nome = txtProductName.Text;
                    produto.PrecoCusto = txtCost;
                    produto.PrecoVenda = txtSell;
					produtosController.Alterar(produto);

					//Insere ou renova relacionamentos com todos os produtos simples da listagem
					for (int i = 0; i < listViewProdutosDaComposicao.Items.Count; i++)
					{
						ProductComposition produtosDaComposicao = new ProductComposition();
						Product produtoSimples = (Product)listViewProdutosDaComposicao.Items[i].Tag;

						produtosDaComposicao.ProdutoId = produto.Id;
						produtosDaComposicao.ItemId = produtoSimples.Id;
						produtosDaComposicao.Quantidade =
							int.Parse(listViewProdutosDaComposicao.Items[i].SubItems[1].Text);

						produtosDaComposicaoController.Salvar(produtosDaComposicao);
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
                        Nome = txtProductName.Text,
                        PrecoCusto = txtCost,
                        PrecoVenda = txtSell,
                        Tipo = TipoProduto.Composto
                    };
					produtosController.Salvar(produtoComposto);

					//Insere relacionamentos com todos os produtos simples da listagem
					for (int i = 0; i < listViewProdutosDaComposicao.Items.Count; i++)
					{
						ProductComposition produtosDaComposicao = new ProductComposition();
						Product produtoSimples = (Product)listViewProdutosDaComposicao.Items[i].Tag;

						produtosDaComposicao.ProdutoId = produtoComposto.Id;
						produtosDaComposicao.ItemId = produtoSimples.Id;
						produtosDaComposicao.Quantidade =
							int.Parse(listViewProdutosDaComposicao.Items[i].SubItems[1].Text);

						produtosDaComposicaoController.Salvar(produtosDaComposicao);
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
			ProdutosController produtosController = new ProdutosController();
			ProdutosDaComposicaoController produtosDaComposicaoController = new ProdutosDaComposicaoController();
			//Verifica se produto existe na lista
			if (produto != null)
			{
				//Exclui todos os produtos simples relacionados ao produto composto selecionado
				produtosDaComposicaoController.Excluir(produto);

				//Exclui o produto composto
				produtosController.Excluir(produto);
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
		private void btnRemoveProduct_Click(object sender, EventArgs e)
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
				decimal valorCusto = produtoSimples.PrecoCusto *
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
		private void btnAddProduct_Click(object sender, EventArgs e)
		{
			ProdutosController produtosController = new ProdutosController();
		    Product produtoSimples = new Product();

			//Abre um novo formulário para inserir novo produto simples na listagem
			//O mesmo retorna um id do produto selecionado e a quantidade contida do produto simples no produto composto
			using (var form = new FormAddProduct(produtosController.ListarProdutosSimples()))
			{
				var result = form.ShowDialog();

				if (result == DialogResult.OK)
				{
					decimal totalCusto = 0;

					//Recupera dados do formulário
					int productId = form.productId;
					int quantity = form.quantidade;

					produtoSimples = produtosController.SelecionarProdutosSimples(productId);
					string[] row = { produtoSimples.Nome, quantity.ToString() };
					var item = new ListViewItem(row);

					//Insere o produto na listagem
					item.Tag = produtoSimples;
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
						decimal valorCusto = produtoSimples.PrecoCusto *
											 int.Parse(listViewProdutosDaComposicao.Items[i].SubItems[1].Text);
						totalCusto += valorCusto;
					}
					txtCostValue.Text = totalCusto.ToString();
				}
			}
		}
	}
}