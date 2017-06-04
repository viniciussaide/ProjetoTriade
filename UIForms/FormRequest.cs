using Controller;
using Model;
using System;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormRequest : Form
	{
        public Request Request { get; set; }

        public FormRequest(Request Request)
		{
			InitializeComponent();

			datePickerDataDaRequisicao.Format = DateTimePickerFormat.Custom;
			datePickerDataDaRequisicao.CustomFormat = "dd-MM-yyyy";
			datePickerDataDaRequisicao.Value = DateTime.Today;

			listViewProdutosNaRequisicao.Columns.Add("Produto");
			listViewProdutosNaRequisicao.Columns.Add("Qtde");
			listViewProdutosNaRequisicao.Columns.Add("Preço Custo UN");
			listViewProdutosNaRequisicao.Columns.Add("Subtotal");
			listViewProdutosNaRequisicao.View = View.Details;
			listViewProdutosNaRequisicao.Columns[0].Width = 180;
			listViewProdutosNaRequisicao.Columns[1].Width = 40;
			listViewProdutosNaRequisicao.Columns[2].Width = 100;
			listViewProdutosNaRequisicao.Columns[3].Width = 80;
            listViewProdutosNaRequisicao.FullRowSelect = true;

            this.Request = Request;
            if (Request == null)
            {
                btnDelete.Visible = false;
            }
            else
            {
                datePickerDataDaRequisicao.Value = Request.RequestDate;
                txtFuncionario.Text = Request.Worker;
                listViewProdutosNaRequisicao.Items.Clear();
                decimal totalCostValue = 0;
                decimal costValue = 0;
                ProductsController ProductsController = new ProductsController();
                //Lista todos os produtos simples relacionados com o produto composto selecionado e calcula o preço de custo total
                foreach (ProductRequest ProductRequest in Request.Products)
                {
                    Product Product = ProductsController.Select(ProductRequest.ProductId);
                    costValue = Product.CostValue * 
                        ProductRequest.Quantity;
                    totalCostValue += costValue;

                    string[] row = {
                        Product.Name,
                        ProductRequest.Quantity.ToString(),
                        Product.CostValue.ToString(),
                        costValue.ToString()
                    };
                    var item = new ListViewItem(row)
                    {
                        Tag = Product
                    };
                    listViewProdutosNaRequisicao.Items.Add(item);

                }
                txtCostValue.Text = totalCostValue.ToString();
            }
        }

		//Botão Remover
		private void BtnRemoveProduct_Click(object sender, EventArgs e)
		{
			Product Product = new Product();
			decimal totalCostValue = 0;
			//Remove todos os produtos selecionados da listagem
			foreach (ListViewItem eachItem in listViewProdutosNaRequisicao.SelectedItems)
			{
				listViewProdutosNaRequisicao.Items.Remove(eachItem);
			}

			//Recalcula preço de custo total
			for (int i = 0; i < listViewProdutosNaRequisicao.Items.Count; i++)
			{
				Product = (Product)listViewProdutosNaRequisicao.Items[i].Tag;
				decimal subtotal = Product.CostValue *
								   int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);
				totalCostValue += subtotal;
			}

			//Atualiza o preço de custo
			if (totalCostValue == 0)
			{
				txtCostValue.Text = "0,00";
			}
			else
			{
				txtCostValue.Text = totalCostValue.ToString();
			}
		}

		//Botão Adicionar
		private void BtnAddProduct_Click(object sender, EventArgs e)
		{
			ProductsController ProductsController = new ProductsController();
			Product Product = new Product();
			//Abre um novo formulário para inserir novo produto (simples ou composto) na listagem
			//O mesmo retorna um id do produto selecionado e a quantidade contida do produto simples no produto composto
			using (var form = new FormAddProduct(ProductsController.List()))
			{
				var result = form.ShowDialog();
				if (result == DialogResult.OK)
				{
					decimal totalCostValue = 0;

					//Recupera dados do formulário
					int productId = form.ProductId;
					int quantity = form.Quantity;

					Product = ProductsController.Select(productId);

					//Calcula o subtotal do produto selecionado
					string subtotalProduct = (Product.CostValue * quantity).ToString();

					string[] row = { Product.Name, quantity.ToString(), Product.CostValue.ToString(), subtotalProduct };
                    //Insere o produto na listagem
                    var item = new ListViewItem(row)
                    {
                        Tag = Product
                    };
                    foreach (ListViewItem listItem in listViewProdutosNaRequisicao.Items)
                    {
                        Product produtoNaLista = (Product)listItem.Tag;
                        if (produtoNaLista.Id == Product.Id)
                        {
                            listViewProdutosNaRequisicao.Items.Remove(listItem);
                        }
                    }
                    listViewProdutosNaRequisicao.Items.Add(item);
                    listViewProdutosNaRequisicao.Sorting = SortOrder.Ascending;
                    //Recalcula o preço de custo do produto composto
                    for (int i = 0; i < listViewProdutosNaRequisicao.Items.Count; i++)
					{
						Product = (Product)listViewProdutosNaRequisicao.Items[i].Tag;
						decimal subtotal = Product.CostValue *
											 int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);
						totalCostValue += subtotal;
					}
					txtCostValue.Text = totalCostValue.ToString();
				}
			}
		}

		//Botão Salvar
		private void BtnSave_Click(object sender, EventArgs e)
		{
			RequestController RequestController = new RequestController();
			ProductRequestController ProductRequestController = new ProductRequestController();

			//Verifica caso queriam salvar com campos ainda vazios
			if (datePickerDataDaRequisicao.Text != "" || txtFuncionario.Text != "" || listViewProdutosNaRequisicao.Items.Count > 0)
			{
				//Verifica se existe requisição aberta com a data e o funcionario selecionados
				if (Request != null)
				{
					//Caso exita o relacionamento, exclui todos os relacionamentos de produtos que compunham a requisição
					ProductRequestController.Remove(Request);

                    Request.Worker = txtFuncionario.Text;
                    Request.RequestDate = datePickerDataDaRequisicao.Value;
                    RequestController.Update(Request);

                    //Insere ou renova os relacionamentos de produtos da listagem que compõe a requisição
                    for (int i = 0; i < listViewProdutosNaRequisicao.Items.Count; i++)
					{
						ProductRequest ProductRequest = new ProductRequest();
						Product Product = (Product)listViewProdutosNaRequisicao.Items[i].Tag;

						ProductRequest.RequestId = Request.Id;
						ProductRequest.ProductId = Product.Id;
						ProductRequest.Quantity = int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);

						ProductRequestController.Insert(ProductRequest);
					}
					MessageBox.Show(@"Requisição alterada com sucesso!", @"Sucesso ao salvar",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
				else
				{
                    //Caso não exista a requisição insere uma nova
                    Request = new Request()
                    {
                        Worker = txtFuncionario.Text,
                        RequestDate = datePickerDataDaRequisicao.Value
                    };
                    RequestController.Insert(Request);

					//Insere os relacionamentos de produtos da listagem que compõe a requisição
					for (int i = 0; i < listViewProdutosNaRequisicao.Items.Count; i++)
					{
						ProductRequest ProductRequest = new ProductRequest();
						Product Product = (Product)listViewProdutosNaRequisicao.Items[i].Tag;

						ProductRequest.RequestId = Request.Id;
						ProductRequest.ProductId = Product.Id;
						ProductRequest.Quantity = int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);

						ProductRequestController.Insert(ProductRequest);
					}
					MessageBox.Show(@"Nova requisição salva com sucesso!", @"Sucesso ao salvar",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
			}
			else
			{
				MessageBox.Show(@"Existem campos vazios, por favor preencha todos os campos.", @"Campos vazios",
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            RequestController RequestController = new RequestController();
            ProductRequestController ProductRequestController = new ProductRequestController();
            if (Request != null)
            {
                //Caso exita o relacionamento, exclui todos os relacionamentos de produtos que compunham a requisição
                ProductRequestController.Remove(Request);
                RequestController.Remove(Request);
                MessageBox.Show(@"Requisição excluída com sucesso!", @"Sucesso ao excluir",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(@"Selecione uma requisição entes de excluir!", @"Erro ao excluir",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}