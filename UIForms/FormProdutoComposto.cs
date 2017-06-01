using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormProdutoComposto : Form
    {
        //Formulário que controla o CRUD de produtos Composto
        public FormProdutoComposto()
        {
            InitializeComponent();
            ProdutosController produtosController = new ProdutosController();

            comboBoxProductName.DataSource = produtosController.ListarProdutosCompostos();
            comboBoxProductName.DisplayMember = "Nome";
            comboBoxProductName.ValueMember = "Id";
            comboBoxProductName.SelectedIndex = -1;

            listViewProdutosDaComposicao.Columns.Add("Produto");
            listViewProdutosDaComposicao.Columns.Add("Quantidade");
            listViewProdutosDaComposicao.View = View.Details;
            listViewProdutosDaComposicao.Columns[0].Width = 260;
            listViewProdutosDaComposicao.Columns[1].Width = 80;
        }

        //Botão Salvar
        private void BtnSave_Click(object sender, EventArgs e)
        {
            ProdutoComposto produtoComposto = new ProdutoComposto();
            ProdutosController produtosController = new ProdutosController();
            ProdutosDaComposicaoController produtosDaComposicaoController = new ProdutosDaComposicaoController();

            //Verifica caso queriam salvar com campos ainda vazios
            if (txtCostValue.Text != "" || txtSellValue.Text != "" || comboBoxProductName.Text != "" || listViewProdutosDaComposicao.Items.Count > 0)
            {
                //Conversão de texto para decimal dos preços de custo e de venda
                if (!decimal.TryParse(txtCostValue.Text, out decimal txtCost))
                {
                    MessageBox.Show(@"Valor de custo digitado não é válido", @"Valor incorreto",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (!decimal.TryParse(txtSellValue.Text, out decimal txtSell))
                {
                    MessageBox.Show(@"Valor de venda digitado não é válido", @"Valor incorreto",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                //Verifica se o item selecionado existe na lista
                else if (comboBoxProductName.SelectedIndex != -1)
                {
                    //Conversão id de um produto selecionado em (int)
                    if (int.TryParse(comboBoxProductName.SelectedValue.ToString(), out int id))
                    {
                        //Verifica se produto existe no banco
                        if (produtosController.Selecionar(id) != null)
                        {
                            //Altera produto composto no banco
                            produtoComposto = produtosController.SelecionarProdutosCompostos(id);

                            //Exclui todos os relacionamentos antigos com produtos simples
                            produtosDaComposicaoController.Excluir(produtoComposto);

                            produtoComposto.PrecoCusto = txtCost;
                            produtoComposto.PrecoVenda = txtSell;
                            produtosController.Alterar(produtoComposto);

                            //Insere ou renova relacionamentos com todos os produtos simples da listagem
                            for (int i = 0; i < listViewProdutosDaComposicao.Items.Count; i++)
                            {
                                ProdutosDaComposicao produtosDaComposicao = new ProdutosDaComposicao();
                                ProdutoSimples produtoSimples = (ProdutoSimples)listViewProdutosDaComposicao.Items[i].Tag;

                                produtosDaComposicao.FKprodutoComposto = produtoComposto.Id;
                                produtosDaComposicao.FKprodutoSimples = produtoSimples.Id;
                                produtosDaComposicao.QuantidadeContidaDoProdutoSimples =
                                    int.Parse(listViewProdutosDaComposicao.Items[i].SubItems[1].Text);

                                produtosDaComposicaoController.Salvar(produtosDaComposicao);
                            }
                            MessageBox.Show(@"Produto alterado com sucesso", @"Sucesso ao alterar",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show(@"Produto a ser alterado não encontrado", @"Erro ao alterar",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else
                {
                    //Insere novo produto composto
                    produtoComposto.Nome = comboBoxProductName.Text;
                    produtoComposto.PrecoCusto = txtCost;
                    produtoComposto.PrecoVenda = txtSell;
                    produtosController.Salvar(produtoComposto);

                    //Insere relacionamentos com todos os produtos simples da listagem
                    for (int i = 0; i < listViewProdutosDaComposicao.Items.Count; i++)
                    {
                        ProdutosDaComposicao produtosDaComposicao = new ProdutosDaComposicao();
                        ProdutoSimples produtoSimples = (ProdutoSimples)listViewProdutosDaComposicao.Items[i].Tag;

                        produtosDaComposicao.FKprodutoComposto = produtoComposto.Id;
                        produtosDaComposicao.FKprodutoSimples = produtoSimples.Id;
                        produtosDaComposicao.QuantidadeContidaDoProdutoSimples =
                            int.Parse(listViewProdutosDaComposicao.Items[i].SubItems[1].Text);

                        produtosDaComposicaoController.Salvar(produtosDaComposicao);
                    }
                    MessageBox.Show(@"Novo produto salvo com sucesso!", @"Sucesso ao salvar",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                comboBoxProductName.DataSource = produtosController.ListarProdutosCompostos();
                comboBoxProductName.SelectedItem = produtoComposto;
            }
            else
            {
                MessageBox.Show(@"Existem campos vazios, por favor preencha todos os campos", @"Campos vazios",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //Botão Excluir
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            ProdutosDaComposicaoController produtosDaComposicaoController = new ProdutosDaComposicaoController();
            //Verifica se produto existe na lista
            if (comboBoxProductName.SelectedIndex != -1)
            {
                //Conversão id de um produto selecionado em (int)
                int.TryParse(comboBoxProductName.SelectedValue.ToString(), out int id);
                //Verifica se produto existe no banco
                if (produtosController.Selecionar(id) != null)
                {
                    Produto produto = produtosController.Selecionar(id);

                    //Exclui todos os produtos simples relacionados ao produto composto selecionado
                    produtosDaComposicaoController.Excluir(produto);

                    //Exclui o produto composto
                    produtosController.Excluir(produto);
                    MessageBox.Show(@"Produto excluído com sucesso", @"Sucesso ao excluir",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    comboBoxProductName.DataSource = produtosController.ListarProdutosCompostos();
                    comboBoxProductName.SelectedIndex = -1;
                    comboBoxProductName.Text = "";
                    txtSellValue.Text = "0,00";
                }
                else
                {
                    MessageBox.Show(@"Produto selecionado não existe", @"Produto não existe",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show(@"Selecione um produto antes de excluir", @"Produto não selecionado",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //Combobox para seleção ou inserção do nome de um produto
        private void ComboBoxProductName_TextChanged(object sender, EventArgs e)
        {
            ProdutosController produtosController = new ProdutosController();
            //Verifica se produto existe na lista
            if (comboBoxProductName.SelectedItem != null)
            {
                //Conversão id de um produto selecionado em (int)
                int.TryParse(comboBoxProductName.SelectedValue.ToString(), out int id);
                ProdutoComposto produtoComposto = produtosController.SelecionarProdutosCompostos(id);
                IList<ProdutoSimples> listaProdutoSimples = produtosController.ListarProdutosSimples();

                //Verifica se produto existe no banco
                if (produtoComposto != null)
                {
                    decimal totalCusto = 0;
                    txtSellValue.Text = produtoComposto.PrecoVenda.ToString();
                    listViewProdutosDaComposicao.Items.Clear();
                    //Lista todos os produtos simples relacionados com o produto composto selecionado e calcula o preço de custo total
                    foreach (ProdutosDaComposicao produtosDaComposicao in produtoComposto.ProdutosDaComposicao)
                    {
                        string[] row = { produtosDaComposicao.ProdutoSimples.Nome, produtosDaComposicao.QuantidadeContidaDoProdutoSimples.ToString() };
                        var item = new ListViewItem(row);
                        item.Tag = produtosDaComposicao.ProdutoSimples;
                        listViewProdutosDaComposicao.Items.Add(item);
                        decimal valorCusto = produtosDaComposicao.ProdutoSimples.PrecoCusto *
                                             produtosDaComposicao.QuantidadeContidaDoProdutoSimples;
                        totalCusto += valorCusto;
                    }
                    txtCostValue.Text = totalCusto.ToString();
                }
                else
                {
                    //Caso não exista zera a listagem e os preços
                    listViewProdutosDaComposicao.Items.Clear();
                    txtCostValue.Text = "0,00";
                    txtSellValue.Text = "0,00";
                }
            }
            else
            {
                //Caso não exista zera a listagem e os preços
                listViewProdutosDaComposicao.Items.Clear();
                txtCostValue.Text = "0,00";
                txtSellValue.Text = "0,00";
            }
        }

        //Botão Remover
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            ProdutoSimples produtoSimples = new ProdutoSimples();
            decimal totalCusto = 0;

            //Remove todos os produtos selecionados da listagem
            foreach (ListViewItem eachItem in listViewProdutosDaComposicao.SelectedItems)
            {
                listViewProdutosDaComposicao.Items.Remove(eachItem);
            }

            //Recalcula o preço de custo após remoção dos itens
            for (int i = 0; i < listViewProdutosDaComposicao.Items.Count; i++)
            {
                produtoSimples = (ProdutoSimples)listViewProdutosDaComposicao.Items[i].Tag;
                decimal valorCusto = produtoSimples.PrecoCusto *
                                     int.Parse(listViewProdutosDaComposicao.Items[i].SubItems[1].Text);
                totalCusto += valorCusto;
            }

            //Atualiza preço de custo
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
            ProdutoSimples produtoSimples = new ProdutoSimples();
            //Abre um novo formulário para inserir novo produto simples na listagem
            //O mesmo retorna um id do produto selecionado e a quantidade contida do produto simples no produto composto
            using (var form = new FormAddProduct(produtosController.ListarProdutosSimples()))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {

                    decimal totalCusto = 0;

                    //Recupera dados do formulário
                    int productId = form.productId;
                    int quantity = form.quantidade;

                    produtoSimples = produtosController.SelecionarProdutosSimples(productId);
                    string[] row = { produtoSimples.Nome, quantity.ToString() };
                    var item = new ListViewItem(row);

                    //Insere o produto na listagem
                    item.Tag = produtoSimples;
                    listViewProdutosDaComposicao.Items.Add(item);

                    //Recalcula o preço de custo do produto composto
                    for (int i = 0; i < listViewProdutosDaComposicao.Items.Count; i++)
                    {
                        produtoSimples = (ProdutoSimples)listViewProdutosDaComposicao.Items[i].Tag;
                        decimal valorCusto = produtoSimples.PrecoCusto *
                                             int.Parse(listViewProdutosDaComposicao.Items[i].SubItems[1].Text);
                        totalCusto += valorCusto;
                    }
                    txtCostValue.Text = totalCusto.ToString();
                }
            }
        }
    }
}