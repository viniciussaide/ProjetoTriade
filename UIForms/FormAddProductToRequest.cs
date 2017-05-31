using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;

namespace UIForms
{
    public partial class FormAddProductToRequest : Form
    {
        public int productId { get; set; }
        public int quantidade { get; set; }
        public FormAddProductToRequest()
        {
            InitializeComponent();
            ProdutosController produtosController = new ProdutosController();
            comboBoxProductName.DataSource = produtosController.Listar();
            comboBoxProductName.DisplayMember = "Nome";
            comboBoxProductName.ValueMember = "Id";
            comboBoxProductName.SelectedIndex = -1;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (comboBoxProductName.SelectedItem != null)
            {
                productId = int.Parse(comboBoxProductName.SelectedValue.ToString());
                quantidade = int.Parse(txtQuantity.Text);
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
