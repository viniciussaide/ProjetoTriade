using Controller;
using Model;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            ProdutoSimples produtoSimples = new ProdutoSimples()
            {
                Nome = txtProductName.Text,
                PrecoCusto = decimal.Parse(txtCostValue.Text),
                PrecoVenda = decimal.Parse(txtSellValue.Text)
            };
            produtosController.Salvar(produtoSimples);
        }
    }
}
