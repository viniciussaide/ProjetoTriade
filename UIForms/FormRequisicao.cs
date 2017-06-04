using Controller;
using Model;
using System;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormRequisicao : Form
	{
        public Request requisicao { get; set; }

        public FormRequisicao(Request requisicao)
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

            this.requisicao = requisicao;
            if (requisicao == null)
            {
                btnDelete.Visible = false;
            }
            else
            {
                datePickerDataDaRequisicao.Value = requisicao.DataRequisicao;
                txtFuncionario.Text = requisicao.Funcionario;
                listViewProdutosNaRequisicao.Items.Clear();
                decimal totalCusto = 0;
                decimal valorCusto = 0;
                ProdutosController ProdutosController = new ProdutosController();
                //Lista todos os produtos simples relacionados com o produto composto selecionado e calcula o preço de custo total
                foreach (ProductRequest produtosNaRequisicao in requisicao.Produtos)
                {
                    Product produto = ProdutosController.Selecionar(produtosNaRequisicao.ProductId);
                    valorCusto = produto.PrecoCusto * 
                        produtosNaRequisicao.Quantidade;
                    totalCusto += valorCusto;

                    string[] row = {
                        produto.Nome,
                        produtosNaRequisicao.Quantidade.ToString(),
                        produto.PrecoCusto.ToString(),
                        valorCusto.ToString()
                    };
                    var item = new ListViewItem(row);
                    item.Tag = produto;
                    listViewProdutosNaRequisicao.Items.Add(item);

                }
                txtCostValue.Text = totalCusto.ToString();
            }
        }

		//Botão Remover
		private void btnRemoveProduct_Click(object sender, EventArgs e)
		{
			Product produto = new Product();
			decimal totalCusto = 0;
			//Remove todos os produtos selecionados da listagem
			foreach (ListViewItem eachItem in listViewProdutosNaRequisicao.SelectedItems)
			{
				listViewProdutosNaRequisicao.Items.Remove(eachItem);
			}

			//Recalcula preço de custo total
			for (int i = 0; i < listViewProdutosNaRequisicao.Items.Count; i++)
			{
				produto = (Product)listViewProdutosNaRequisicao.Items[i].Tag;
				decimal subtotal = produto.PrecoCusto *
								   int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);
				totalCusto += subtotal;
			}

			//Atualiza o preço de custo
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
			Product produto = new Product();
			//Abre um novo formulário para inserir novo produto (simples ou composto) na listagem
			//O mesmo retorna um id do produto selecionado e a quantidade contida do produto simples no produto composto
			using (var form = new FormAddProduct(produtosController.Listar()))
			{
				var result = form.ShowDialog();
				if (result == DialogResult.OK)
				{
					decimal totalCusto = 0;

					//Recupera dados do formulário
					int productId = form.productId;
					int quantity = form.quantidade;

					produto = produtosController.Selecionar(productId);

					//Calcula o subtotal do produto selecionado
					string subtotalProduto = (produto.PrecoCusto * quantity).ToString();

					string[] row = { produto.Nome, quantity.ToString(), produto.PrecoCusto.ToString(), subtotalProduto };
					var item = new ListViewItem(row);

					//Insere o produto na listagem
					item.Tag = produto;
                    foreach (ListViewItem listItem in listViewProdutosNaRequisicao.Items)
                    {
                        Product produtoNaLista = (Product)listItem.Tag;
                        if (produtoNaLista.Id == produto.Id)
                        {
                            listViewProdutosNaRequisicao.Items.Remove(listItem);
                        }
                    }
                    listViewProdutosNaRequisicao.Items.Add(item);
                    listViewProdutosNaRequisicao.Sorting = SortOrder.Ascending;
                    //Recalcula o preço de custo do produto composto
                    for (int i = 0; i < listViewProdutosNaRequisicao.Items.Count; i++)
					{
						produto = (Product)listViewProdutosNaRequisicao.Items[i].Tag;
						decimal subtotal = produto.PrecoCusto *
											 int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);
						totalCusto += subtotal;
					}
					txtCostValue.Text = totalCusto.ToString();
				}
			}
		}

		//Botão Salvar
		private void btnSave_Click(object sender, EventArgs e)
		{
			RequisicaoController requisicaoController = new RequisicaoController();
			ProdutosNasRequisicoesController produtosNasRequisicoesController = new ProdutosNasRequisicoesController();

			//Verifica caso queriam salvar com campos ainda vazios
			if (datePickerDataDaRequisicao.Text != "" || txtFuncionario.Text != "" || listViewProdutosNaRequisicao.Items.Count > 0)
			{
				//Verifica se existe requisição aberta com a data e o funcionario selecionados
				if (requisicao != null)
				{
					//Caso exita o relacionamento, exclui todos os relacionamentos de produtos que compunham a requisição
					produtosNasRequisicoesController.Excluir(requisicao);

                    requisicao.Funcionario = txtFuncionario.Text;
                    requisicao.DataRequisicao = datePickerDataDaRequisicao.Value;
                    requisicaoController.Alterar(requisicao);

                    //Insere ou renova os relacionamentos de produtos da listagem que compõe a requisição
                    for (int i = 0; i < listViewProdutosNaRequisicao.Items.Count; i++)
					{
						ProductRequest produtosNasRequisicoes = new ProductRequest();
						Product produto = (Product)listViewProdutosNaRequisicao.Items[i].Tag;

						produtosNasRequisicoes.RequisicaoId = requisicao.Id;
						produtosNasRequisicoes.ProductId = produto.Id;
						produtosNasRequisicoes.Quantidade = int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);

						produtosNasRequisicoesController.Salvar(produtosNasRequisicoes);
					}
					MessageBox.Show(@"Requisição alterada com sucesso!", @"Sucesso ao salvar",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
				else
				{
					//Caso não exista a requisição insere uma nova
					requisicao = new Request();
					requisicao.Funcionario = txtFuncionario.Text;
					requisicao.DataRequisicao = datePickerDataDaRequisicao.Value;
					requisicaoController.Salvar(requisicao);

					//Insere os relacionamentos de produtos da listagem que compõe a requisição
					for (int i = 0; i < listViewProdutosNaRequisicao.Items.Count; i++)
					{
						ProductRequest produtosNasRequisicoes = new ProductRequest();
						Product produto = (Product)listViewProdutosNaRequisicao.Items[i].Tag;

						produtosNasRequisicoes.RequisicaoId = requisicao.Id;
						produtosNasRequisicoes.ProductId = produto.Id;
						produtosNasRequisicoes.Quantidade = int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);

						produtosNasRequisicoesController.Salvar(produtosNasRequisicoes);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RequisicaoController requisicaoController = new RequisicaoController();
            ProdutosNasRequisicoesController produtosNasRequisicoesController = new ProdutosNasRequisicoesController();
            if (requisicao != null)
            {
                //Caso exita o relacionamento, exclui todos os relacionamentos de produtos que compunham a requisição
                produtosNasRequisicoesController.Excluir(requisicao);
                requisicaoController.Excluir(requisicao);
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

        //private async void listViewProdutosNaRequisicao_ItemActivate(object sender, EventArgs e)
        //{
        //	var task = VaiNoBancoAsync();

        //	//Mostrar tela de carregamento

        //	var produto = await task;

        //	//Tirar tela de carregamento
        //}

        //public Task<Product> VaiNoBancoAsync()
        //{
        //	Func<Product> acao = delegate ()
        //	{
        //		var controller = new ProdutosController();

        //		return controller.Selecionar(1);
        //	};

        //	return Task.Run(acao);
        //}
    }
}