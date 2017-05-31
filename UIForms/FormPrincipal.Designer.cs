namespace UIForms
{
    partial class FormPrincipal
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
            this.btnCadastrarProdutosSimples = new System.Windows.Forms.Button();
            this.btnCadastrarProdutoComposto = new System.Windows.Forms.Button();
            this.btnRequisicao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCadastrarProdutosSimples
            // 
            this.btnCadastrarProdutosSimples.Location = new System.Drawing.Point(59, 36);
            this.btnCadastrarProdutosSimples.Name = "btnCadastrarProdutosSimples";
            this.btnCadastrarProdutosSimples.Size = new System.Drawing.Size(166, 23);
            this.btnCadastrarProdutosSimples.TabIndex = 0;
            this.btnCadastrarProdutosSimples.Text = "Produto Simples";
            this.btnCadastrarProdutosSimples.UseVisualStyleBackColor = true;
            this.btnCadastrarProdutosSimples.Click += new System.EventHandler(this.btnCadastrarProdutosSimples_Click);
            // 
            // btnCadastrarProdutoComposto
            // 
            this.btnCadastrarProdutoComposto.Location = new System.Drawing.Point(59, 90);
            this.btnCadastrarProdutoComposto.Name = "btnCadastrarProdutoComposto";
            this.btnCadastrarProdutoComposto.Size = new System.Drawing.Size(166, 23);
            this.btnCadastrarProdutoComposto.TabIndex = 1;
            this.btnCadastrarProdutoComposto.Text = "Produto Composto";
            this.btnCadastrarProdutoComposto.UseVisualStyleBackColor = true;
            this.btnCadastrarProdutoComposto.Click += new System.EventHandler(this.btnCadastrarProdutoComposto_Click);
            // 
            // btnRequisicao
            // 
            this.btnRequisicao.Location = new System.Drawing.Point(59, 146);
            this.btnRequisicao.Name = "btnRequisicao";
            this.btnRequisicao.Size = new System.Drawing.Size(166, 23);
            this.btnRequisicao.TabIndex = 2;
            this.btnRequisicao.Text = "Requisição";
            this.btnRequisicao.UseVisualStyleBackColor = true;
            this.btnRequisicao.Click += new System.EventHandler(this.btnRequisicao_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnRequisicao);
            this.Controls.Add(this.btnCadastrarProdutoComposto);
            this.Controls.Add(this.btnCadastrarProdutosSimples);
            this.Name = "FormPrincipal";
            this.Text = "Menu Inicial";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadastrarProdutosSimples;
        private System.Windows.Forms.Button btnCadastrarProdutoComposto;
        private System.Windows.Forms.Button btnRequisicao;
    }
}