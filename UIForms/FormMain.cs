using iTextSharp;
using System;
using System.Windows.Forms;

namespace UIForms
{
    public partial class FormMain : Form
    {
        //Formulário principal para seleção da função a ser executada
        public FormMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
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
    }
}
