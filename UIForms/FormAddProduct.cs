using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace UIForms
{
    public partial class FormAddProduct : Form
    {
        public int productId { get; set; }
        public int quantidade { get; set; }

        //Método construtor
        //Formulário se altera de acordo com a forma que foi chamado
        //Assim o mesmo formulário pode retornar produtos simples ou todos os produtos
        public FormAddProduct(IList<Produto> listaDeProdutos)
        {
            InitializeComponent();
            comboBoxProductName.DataSource = listaDeProdutos;
            comboBoxProductName.DisplayMember = "Nome";
            comboBoxProductName.ValueMember = "Id";
            comboBoxProductName.SelectedIndex = -1;
        }

        public FormAddProduct(IList<ProdutoSimples> listaDeProdutosSimples)
        {
            InitializeComponent();
            comboBoxProductName.DataSource = listaDeProdutosSimples;
            comboBoxProductName.DisplayMember = "Nome";
            comboBoxProductName.ValueMember = "Id";
            comboBoxProductName.SelectedIndex = -1;
        }

        //Botão OK
        private void btnOk_Click(object sender, System.EventArgs e)
        {
            //Verifica se produto existe na lista
            if (comboBoxProductName.SelectedItem != null)
            {
                //Atualiza o ID e a quantidade a serem resgatados pelo formulario que necessitar
                productId = int.Parse(comboBoxProductName.SelectedValue.ToString());
                quantidade = int.Parse(txtQuantity.Text);

                //Verifica se quantidade selecionada é maior que zero
                if (quantidade > 0)
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
