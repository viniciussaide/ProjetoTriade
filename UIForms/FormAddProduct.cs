using Model;
using System;
using System.Windows.Forms;

namespace UIForms
{
	public partial class FormAddProduct : Form
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }

		private Product[] ProductList;

		//Método construtor
		//Formulário se altera de acordo com a forma que foi chamado
		//Assim o mesmo formulário pode retornar produtos simples ou todos os produtos
		public FormAddProduct(Product[] ProductList)
		{
			InitializeComponent();

			this.ProductList = ProductList;
		}

		protected override void OnLoad(EventArgs e)
		{
			comboBoxProductName.DataSource = ProductList;
			comboBoxProductName.DisplayMember = "Name";
			comboBoxProductName.ValueMember = "Id";
			comboBoxProductName.SelectedIndex = -1;

			base.OnLoad(e);
		}

		//Botão OK
		private void BtnOk_Click(object sender, EventArgs e)
		{
			//Verifica se produto existe na lista
			if (comboBoxProductName.SelectedItem != null)
			{
				//Atualiza o ID e a quantidade a serem resgatados pelo formulario que necessitar
				ProductId = int.Parse(comboBoxProductName.SelectedValue.ToString());
				Quantity = int.Parse(txtQuantity.Text);

				//Verifica se quantidade selecionada é maior que zero
				if (Quantity > 0)
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					MessageBox.Show(@"Selecione uma quantidade maior que zero para adicionar produto", @"Selecione uma quantidade",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			else
			{
				MessageBox.Show(@"Selecione um produto antes de prosseguir", @"Selecione um produto",
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}
}