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
            this.WindowState = FormWindowState.Maximized;
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProdutos formProdutos = new FormProdutos();
            formProdutos.ShowDialog();
        }

        private void requisiçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRequestList formRequestList = new FormRequestList();
            formRequestList.ShowDialog();
        }
    }
}
