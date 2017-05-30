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
            this.listViewProdutosDaComposicao = new System.Windows.Forms.ListView();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxProductName
            // 
            this.comboBoxProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxProductName.FormattingEnabled = true;
            this.comboBoxProductName.Location = new System.Drawing.Point(112, 19);
            this.comboBoxProductName.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxProductName.Name = "comboBoxProductName";
            this.comboBoxProductName.Size = new System.Drawing.Size(264, 21);
            this.comboBoxProductName.TabIndex = 8;
            this.comboBoxProductName.SelectedValueChanged += new System.EventHandler(this.ComboBoxProductName_TextChanged);
            this.comboBoxProductName.TextChanged += new System.EventHandler(this.ComboBoxProductName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Preço de Venda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nome do Produto";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(301, 313);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Excluir";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(217, 313);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtSellValue
            // 
            this.txtSellValue.Location = new System.Drawing.Point(112, 50);
            this.txtSellValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtSellValue.Name = "txtSellValue";
            this.txtSellValue.Size = new System.Drawing.Size(114, 20);
            this.txtSellValue.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 265);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Preço de Custo";
            // 
            // txtCostValue
            // 
            this.txtCostValue.Location = new System.Drawing.Point(98, 262);
            this.txtCostValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtCostValue.Name = "txtCostValue";
            this.txtCostValue.Size = new System.Drawing.Size(114, 20);
            this.txtCostValue.TabIndex = 14;
            // 
            // listViewProdutosDaComposicao
            // 
            this.listViewProdutosDaComposicao.Location = new System.Drawing.Point(21, 85);
            this.listViewProdutosDaComposicao.Name = "listViewProdutosDaComposicao";
            this.listViewProdutosDaComposicao.Size = new System.Drawing.Size(355, 159);
            this.listViewProdutosDaComposicao.TabIndex = 16;
            this.listViewProdutosDaComposicao.UseCompatibleStateImageBehavior = false;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(217, 260);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 17;
            this.btnAddProduct.Text = "Adicionar";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(301, 260);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveProduct.TabIndex = 18;
            this.btnRemoveProduct.Text = "Remover";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            // 
            // FormProdutoComposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.listViewProdutosDaComposicao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCostValue);
            this.Controls.Add(this.comboBoxProductName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSellValue);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.ListView listViewProdutosDaComposicao;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnRemoveProduct;
    }
}