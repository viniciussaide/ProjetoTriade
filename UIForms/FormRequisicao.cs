using Controller;
using Model;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIForms
{
	public partial class FormRequisicao : Form
	{
		public FormRequisicao()
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
					listViewProdutosNaRequisicao.Items.Add(item);

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
			Request requisicao = new Request();
			RequisicaoController requisicaoController = new RequisicaoController();
			ProdutosNasRequisicoesController produtosNasRequisicoesController = new ProdutosNasRequisicoesController();

			//Verifica caso queriam salvar com campos ainda vazios
			if (datePickerDataDaRequisicao.Text != "" || txtFuncionario.Text != "" || listViewProdutosNaRequisicao.Items.Count > 0)
			{
				requisicao = requisicaoController.Selecionar(datePickerDataDaRequisicao.Value, txtFuncionario.Text);
				//Verifica se existe requisição aberta com a data e o funcionario selecionados
				if (requisicao != null)
				{
					//Caso exita o relacionamento, exclui todos os relacionamentos de produtos que compunham a requisição
					produtosNasRequisicoesController.Excluir(requisicao);

					//Insere ou renova os relacionamentos de produtos da listagem que compõe a requisição
					for (int i = 0; i < listViewProdutosNaRequisicao.Items.Count; i++)
					{
						ProductRequest produtosNasRequisicoes = new ProductRequest();
						Product produto = (Product)listViewProdutosNaRequisicao.Items[i].Tag;

						produtosNasRequisicoes.IdRequisicao = requisicao.Id;
						produtosNasRequisicoes.IdProduto = produto.Id;
						produtosNasRequisicoes.Quantidade = int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);

						produtosNasRequisicoesController.Salvar(produtosNasRequisicoes);
					}
					MessageBox.Show(@"Requisição alterada com sucesso!", @"Sucesso ao salvar",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

						produtosNasRequisicoes.IdRequisicao = requisicao.Id;
						produtosNasRequisicoes.IdProduto = produto.Id;
						produtosNasRequisicoes.Quantidade = int.Parse(listViewProdutosNaRequisicao.Items[i].SubItems[1].Text);

						produtosNasRequisicoesController.Salvar(produtosNasRequisicoes);
					}
					MessageBox.Show(@"Nova requisição salva com sucesso!", @"Sucesso ao salvar",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			else
			{
				MessageBox.Show(@"Existem campos vazios, por favor preencha todos os campos.", @"Campos vazios",
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