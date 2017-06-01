using System;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormPrincipal : Form
    {
        //Formulário principal para seleção da função a ser executada
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastrarProdutosSimples_Click(object sender, EventArgs e)
        {
            FormProdutoSimples formProdutoSimples = new FormProdutoSimples();
            formProdutoSimples.ShowDialog();
        }

        private void btnCadastrarProdutoComposto_Click(object sender, EventArgs e)
        {
            FormProdutoComposto formProdutoComposto = new FormProdutoComposto();
            formProdutoComposto.ShowDialog();
        }

        private void btnRequisicao_Click(object sender, EventArgs e)
        {
            FormRequisicao formRequisicao = new FormRequisicao();
            formRequisicao.ShowDialog();
        }
    }
}
