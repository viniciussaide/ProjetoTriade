namespace UIForms
{
    partial class FormRequisicao
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
            this.datePickerDataDaRequisicao = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFuncionario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewProdutosNaRequisicao = new System.Windows.Forms.ListView();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCostValue = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // datePickerDataDaRequisicao
            // 
            this.datePickerDataDaRequisicao.Location = new System.Drawing.Point(114, 26);
            this.datePickerDataDaRequisicao.Name = "datePickerDataDaRequisicao";
            this.datePickerDataDaRequisicao.Size = new System.Drawing.Size(113, 20);
            this.datePickerDataDaRequisicao.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data da requisição";
            // 
            // txtFuncionario
            // 
            this.txtFuncionario.Location = new System.Drawing.Point(114, 61);
            this.txtFuncionario.Name = "txtFuncionario";
            this.txtFuncionario.Size = new System.Drawing.Size(312, 20);
            this.txtFuncionario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Funcionário";
            // 
            // listViewProdutosNaRequisicao
            // 
            this.listViewProdutosNaRequisicao.Location = new System.Drawing.Point(15, 96);
            this.listViewProdutosNaRequisicao.Name = "listViewProdutosNaRequisicao";
            this.listViewProdutosNaRequisicao.Size = new System.Drawing.Size(411, 134);
            this.listViewProdutosNaRequisicao.TabIndex = 4;
            this.listViewProdutosNaRequisicao.UseCompatibleStateImageBehavior = false;
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(351, 271);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveProduct.TabIndex = 24;
            this.btnRemoveProduct.Text = "Remover";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(267, 271);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 23;
            this.btnAddProduct.Text = "Adicionar";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 249);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Preço de Custo";
            // 
            // txtCostValue
            // 
            this.txtCostValue.Location = new System.Drawing.Point(312, 246);
            this.txtCostValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtCostValue.Name = "txtCostValue";
            this.txtCostValue.ReadOnly = true;
            this.txtCostValue.Size = new System.Drawing.Size(114, 20);
            this.txtCostValue.TabIndex = 21;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(363, 305);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Excluir";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(279, 305);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormRequisicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 338);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCostValue);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listViewProdutosNaRequisicao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFuncionario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datePickerDataDaRequisicao);
            this.Name = "FormRequisicao";
            this.Text = "Requisição";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePickerDataDaRequisicao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFuncionario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewProdutosNaRequisicao;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCostValue;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
    }
}