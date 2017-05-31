using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormPrincipal : Form
    {
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
