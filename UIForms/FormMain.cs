using iTextSharp;
using Model;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormMain : Form
    {
        //Formulário principal para seleção da função a ser executada
        public FormMain()
        {
            try
            {
                InitializeComponent();
                this.WindowState = FormWindowState.Maximized;
                DBtriade banco = new DBtriade();
                banco.Database.Connection.Open();
                banco.Database.Connection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show(@"Erro ao conectar com o banco. Verifique as configurações e tente novamente.", @"Erro ao salvar",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
        }

        private void ProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProdutos formProdutos = new FormProdutos();
            formProdutos.ShowDialog();
        }

        private void RequisiçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRequestList formRequestList = new FormRequestList();
            formRequestList.ShowDialog();
        }

        private void RequisiçõesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var form = new FormDateInterval())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {

                    SaveFileDialog saveFileDialog = new SaveFileDialog()
                    {
                        Filter = "Arquivo PDF|*.pdf",
                        Title = "Salvar relatório de requisições"
                    };
                    saveFileDialog.ShowDialog();
                    if (saveFileDialog.FileName != "")
                    {
                        ReportGeneratorPDF reportGenerator = new ReportGeneratorPDF(saveFileDialog.FileName, form.StartDate, form.EndDate);
                        try
                        {
                            reportGenerator.RequestReport();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(@"Erro ao salvar relatório", @"Erro ao salvar",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
        }

        private void SaídasDoEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormDateInterval())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {

                    SaveFileDialog saveFileDialog = new SaveFileDialog()
                    {
                        Filter = "Arquivo PDF|*.pdf",
                        Title = "Salvar relatório de requisições"
                    };
                    saveFileDialog.ShowDialog();
                    if (saveFileDialog.FileName != "")
                    {
                        ReportGeneratorPDF reportGenerator = new ReportGeneratorPDF(saveFileDialog.FileName, form.StartDate, form.EndDate);
                        try
                        {
                            reportGenerator.RequestProductsReport();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(@"Erro ao salvar relatório", @"Erro ao salvar",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
        }
    }
}
