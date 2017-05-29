namespace UIForms
{
    partial class FormProdutoComposto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxProductName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSellValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCostValue = new System.Windows.Forms.TextBox();
            this.listBoxProdutosDaComposicao = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // comboBoxProductName
            // 
            this.comboBoxProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxProductName.FormattingEnabled = true;
            this.comboBoxProductName.Location = new System.Drawing.Point(149, 23);
            this.comboBoxProductName.Name = "comboBoxProductName";
            this.comboBoxProductName.Size = new System.Drawing.Size(351, 24);
            this.comboBoxProductName.TabIndex = 8;
            this.comboBoxProductName.TextChanged += new System.EventHandler(this.ComboBoxProductName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Preço de Venda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nome do Produto";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(425, 386);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Excluir";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(332, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtSellValue
            // 
            this.txtSellValue.Location = new System.Drawing.Point(149, 62);
            this.txtSellValue.Name = "txtSellValue";
            this.txtSellValue.Size = new System.Drawing.Size(151, 22);
            this.txtSellValue.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Preço de Custo";
            // 
            // txtCostValue
            // 
            this.txtCostValue.Location = new System.Drawing.Point(149, 358);
            this.txtCostValue.Name = "txtCostValue";
            this.txtCostValue.Size = new System.Drawing.Size(151, 22);
            this.txtCostValue.TabIndex = 14;
            // 
            // listBoxProdutosDaComposicao
            // 
            this.listBoxProdutosDaComposicao.FormattingEnabled = true;
            this.listBoxProdutosDaComposicao.ItemHeight = 16;
            this.listBoxProdutosDaComposicao.Location = new System.Drawing.Point(27, 110);
            this.listBoxProdutosDaComposicao.Name = "listBoxProdutosDaComposicao";
            this.listBoxProdutosDaComposicao.Size = new System.Drawing.Size(473, 228);
            this.listBoxProdutosDaComposicao.TabIndex = 16;
            // 
            // FormProdutoComposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 445);
            this.Controls.Add(this.listBoxProdutosDaComposicao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCostValue);
            this.Controls.Add(this.comboBoxProductName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSellValue);
            this.Name = "FormProdutoComposto";
            this.Text = "Produto Composto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSellValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCostValue;
        private System.Windows.Forms.ListBox listBoxProdutosDaComposicao;
    }
}